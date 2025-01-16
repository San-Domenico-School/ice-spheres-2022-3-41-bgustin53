using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSphereController : MonoBehaviour
{
    private float startDelay;
    private float reductionEachRepeat;
    private float minimumVolume;

    private Rigidbody iceRB;
    private ParticleSystem iceVFX;
    private float pushForce;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.debugSpawnWaves)
        {
            reductionEachRepeat = .5f;
        }
        else
        {
            reductionEachRepeat = 0.975f;
        }

        startDelay = 3;
        minimumVolume = 0.2f;

        iceRB = GetComponent<Rigidbody>();
        iceVFX = GetComponent<ParticleSystem>();

        RandomizeSizeAndMass();
        InvokeRepeating("Melt", startDelay, 0.4f);
    }

    // Update is called once per frame
    private void RandomizeSizeAndMass()
    {
        float sizeReduction = Random.Range(0.5f, 1.0f);
        transform.localScale *= sizeReduction;
        iceRB.mass *= sizeReduction;
    }

    private void Dissolution()
    {
        float volume = 4 / 3 * Mathf.PI * Mathf.Pow(transform.localScale.x, 2);
        if (volume < minimumVolume)
        {
            iceVFX.Stop();
            Destroy(this.gameObject);
        }
    }

    private void Melt()
    {
        transform.localScale *= reductionEachRepeat;
        iceRB.mass *= reductionEachRepeat;
        Dissolution();
    }
}

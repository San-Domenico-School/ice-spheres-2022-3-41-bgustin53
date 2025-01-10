using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInteracter : MonoBehaviour
{
    [SerializeField] private float pushForce;
    private Rigidbody icsSphereRB;
    private IceSphereController iceSphereController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}

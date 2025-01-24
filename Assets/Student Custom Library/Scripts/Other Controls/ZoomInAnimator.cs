using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInAnimator : MonoBehaviour
{
    private Vector3 desiredScale;
    private Vector3 initialScale = Vector3.one.normalized;
    private float zoomInRate = 1.06f;
    private float zoomInFrequency = 0.03f;

    // Start is called before the first frame update
    void OnEnable()
    {
        desiredScale = transform.localScale;
        transform.localScale = initialScale;
        InvokeRepeating("ZoomIn", 0, zoomInFrequency);
    }

    // Resets original scale and makes sure that the portal reacts to player physics
    private void OnDisable()
    {
        transform.localScale = desiredScale;
        //gameObject.layer = LayerMask.NameToLayer("Player");
    }

    // What gets invoked on enable to zoom in the portal.
    private void ZoomIn()
    {
        if (transform.localScale.magnitude < desiredScale.magnitude)
        {
            transform.localScale *= zoomInRate;
        }
        else
        {
            CancelInvoke();
        }
    }
}

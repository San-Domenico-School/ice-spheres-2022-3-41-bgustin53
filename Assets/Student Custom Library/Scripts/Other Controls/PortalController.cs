using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private string destination;

    public string GetDestination()
    {
        return destination;
    }    
}

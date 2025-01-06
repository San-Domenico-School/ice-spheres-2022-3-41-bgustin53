using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Attach this script to all character models.
*  This script makes sure that when the charter enters the scene, 
*  it is centered inside its container 
*/

public class CharacterCenterer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}

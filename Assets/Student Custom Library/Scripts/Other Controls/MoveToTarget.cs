using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private GameObject target;
    private Rigidbody targetRB;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        targetRB = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        navMeshAgent.SetDestination(targetRB.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetEnemy : MonoBehaviour
{
    public Transform enemyObj;
    protected NavMeshAgent sphereMesh;
    public GameObject sphereSpawn;


    void Start()
    {
        sphereMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        sphereMesh.SetDestination(enemyObj.position);
    }
}

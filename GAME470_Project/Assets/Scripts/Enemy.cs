using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform playerObj;
    protected NavMeshAgent enemyMesh;

    public int enemyHP = 2;

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMesh.SetDestination(playerObj.position);

        if(enemyHP <= 0)
        {
            //have it so enemy gets fucking killed
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Renderer renderer;

    public Transform playerObj;
    public GameObject spawn;
    protected NavMeshAgent enemyMesh;
    PlayTune tune;
    SpawnEnemy spawnScript;

    public float enemyHP = 2.0f;

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        tune = playerObj.gameObject.GetComponent<PlayTune>();
        spawnScript = spawn.gameObject.GetComponent<SpawnEnemy>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMesh.SetDestination(playerObj.position);

        if(enemyHP <= 0.0f)
        {
            //have it so enemy gets fucking killed
            //spawnScript.EnemySpawn();
            //Destroy(gameObject);
            transform.position = spawn.transform.position;
            enemyHP = 2.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Tune")
        {
            PlayTune tune;
            tune = playerObj.gameObject.GetComponent<PlayTune>();
            Debug.Log("Hit");
        }*/
        renderer.material.color = Color.red;
        enemyHP -= tune.baseDamage;
        renderer.material.color = Color.white;
    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

}

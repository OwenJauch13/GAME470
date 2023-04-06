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
    private IEnumerator coroutine;

    public float enemyHP = 2.0f;
    private float baseSpeed = 2.0f;

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        tune = playerObj.gameObject.GetComponent<PlayTune>();
        spawnScript = spawn.gameObject.GetComponent<SpawnEnemy>();
        renderer = GetComponent<Renderer>();

        coroutine = ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyStats();

        if(enemyHP <= 0.0f)
        {
            //have it so enemy gets fucking killed
            //spawnScript.EnemySpawn();
            Destroy(gameObject);
            Destroy(gameObject);
            //transform.position = spawn.transform.position;
            enemyHP = 2.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Tune")
        {
            Debug.Log("Hit");
            PlayTune tune;
            tune = playerObj.gameObject.GetComponent<PlayTune>();
        }*/
        enemyHP -= tune.baseDamage;
        Debug.Log("Hit");
        if (enemyHP > 0)
        {
            StartCoroutine(coroutine);
        }
    }

    private void EnemyMove()
    {
        enemyMesh.speed = baseSpeed;
        enemyMesh.SetDestination(playerObj.position);

        if (enemyMesh.tag == "Scout")
        {
            baseSpeed = 6.0f;
        }
        else if (enemyMesh.tag == "Warrior")
        {
            baseSpeed = 2.0f;
        }
        else if (enemyMesh.tag == "Brute")
        {
            baseSpeed = 4.0f;
        }
        else if (enemyMesh.tag == "Healer")
        {
            baseSpeed = 2.0f;
        }
    }

    private void EnemyStats()
    {
        if (enemyMesh.tag == "Scout")
        {
            enemyHP = 2.0f;
        }
        else if (enemyMesh.tag == "Warrior")
        {
            enemyHP = 6.0f;
        }
        else if (enemyMesh.tag == "Brute")
        {
            enemyHP = 4.0f;
        }
        else if (enemyMesh.tag == "Healer")
        {
            enemyHP = 2.0f;
        }
    }

    private IEnumerator ChangeColor()
    {
        Debug.Log("Change Color");
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        renderer.material.color = Color.white;
    }
}

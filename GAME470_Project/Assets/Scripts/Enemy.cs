using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyInherit
{
    private Renderer renderer;

    public Transform playerObj;
    public GameObject spawn;
    protected NavMeshAgent enemyMesh;
    PlayTune tune;
    SpawnEnemy spawnScript;
    private IEnumerator coroutine;
    public PlayerStats player;

    

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        tune = playerObj.gameObject.GetComponent<PlayTune>();
        spawnScript = spawn.gameObject.GetComponent<SpawnEnemy>();
        renderer = GetComponent<Renderer>();

        player = GameObject.Find("PlayerObject").GetComponent<PlayerStats>();
        coroutine = ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        playerObj = GameObject.Find("Player").GetComponent<Transform>();
        enemyMesh.SetDestination(playerObj.position);

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
        }
        
        if (collision.gameObject.tag == "HitPlayer")
        {
            Debug.Log("Hit the player");
        }
        enemyHP -= tune.baseDamage;
        Debug.Log("Hit");
        if (enemyHP > 0)
        {
            StartCoroutine(coroutine);
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitPlayer")
        {
            
            if (other.GetComponent<PlayerStats>().canBeHit)
            {
                other.GetComponent<PlayerStats>().TakeDamage();
            }
        }

        if (other.tag == "Tune")
        {
            PlayTune tune;
            tune = playerObj.gameObject.GetComponent<PlayTune>();
            enemyHP -= tune.baseDamage;
            if (enemyHP > 0)
            {
                StartCoroutine(coroutine);
            }
        }
    }

    /*private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }*/

    private IEnumerator ChangeColor()
    {
        Debug.Log("Change Color");
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        renderer.material.color = Color.white;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

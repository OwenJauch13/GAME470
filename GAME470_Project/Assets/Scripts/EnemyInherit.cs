using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInherit : MonoBehaviour
{
    public float enemyHP = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyEnemies()
    {
        Debug.Log(109);
        enemyHP = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEvent(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("The enemy is here");
        }
    }
}

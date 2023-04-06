using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialNote : MonoBehaviour
{
    public EnemyInherit enemyScript;
    public PlayerMovement playerSpeed;
    public PlayerStats playerStats;
    public int decision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GotPickedUp()
    {
        if (decision == 2)
        {
            playerStats.StartInvulnChange();
        } else if (decision == 1)
        {
            playerSpeed.StartSpeedChange();
        }
        gameObject.SetActive(false);
    }
}

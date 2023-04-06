using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialNote : MonoBehaviour
{
    public EnemyInherit enemyScript;
    public PlayerMovement playerSpeed;
    public PlayerStats playerStats;
    private int randomNum;
    public int decision;

    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(1, 101);

        if (randomNum > 20)
        {
            decision = 0;
        } else if (randomNum > 10 && randomNum <= 20)
        {
            decision = 1;
        } else
        {
            decision = 2;
        }
        Debug.Log(randomNum);
        Debug.Log(decision);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotPickedUp()
    {
        if (decision == 2)
        {
            //
        } else if (decision == 1)
        {
            playerSpeed.StartSpeedChange();
        }
        gameObject.SetActive(false);
    }
}

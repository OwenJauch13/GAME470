using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Took Damage");
        if (health <= 0)
        {
            Debug.Log("Player Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

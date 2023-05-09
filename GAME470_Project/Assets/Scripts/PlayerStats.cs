using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public bool canBeHit;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        canBeHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void StartInvulnChange()
    {
        StartCoroutine(ChangeInvuln());
    }

    private IEnumerator ChangeInvuln()
    {
        canBeHit = false;
        yield return new WaitForSeconds(5);
        canBeHit = true;
    }
}

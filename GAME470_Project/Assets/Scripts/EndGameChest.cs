using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameChest : MonoBehaviour
{
    private int randomNum;
    public int decision;
    public bool isEndChest;
    public GameObject openChest;
    public GameObject closedChest;
    public GameObject bonePile;

    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(1, 101);

        if (randomNum > 91)
        {
            decision = 0;
        }
        else
        {
            decision = 1;
        }

        GameManager.numOfChests++;
        Debug.Log(GameManager.numOfChests);

        StartCoroutine(SetEndGameChest());
    }

    private IEnumerator SetEndGameChest()
    {
        yield return new WaitForSeconds(1);
        GameManager.numOfChests--;
        Debug.Log(GameManager.numOfChests);
        if (!GameManager.endChestSelected && GameManager.numOfChests == 0)
        {
            isEndChest = true;
            GameManager.endChestSelected = true;
            Debug.Log("This is the end chest");
        }
        else if (decision == 0 && !GameManager.endChestSelected)
        {
            isEndChest = true;
            GameManager.endChestSelected = true;
            Debug.Log("This is the end chest");
        } else if (decision == 1)
        {
            isEndChest = false;
            Debug.Log("This is not the end chest");
        } else if (decision == 0 && GameManager.endChestSelected)
        {
            isEndChest = false;
            Debug.Log("This would have been the end chest");
        }

    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void SetToBones()
    {
        closedChest.SetActive(false);
        bonePile.SetActive(true);
        Debug.Log("BonePile");
    }

    public void SetToOpen()
    {
        closedChest.SetActive(false);
        openChest.SetActive(true);
        StartCoroutine(ReturnToMenu());
        Debug.Log("OpenChest");
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}

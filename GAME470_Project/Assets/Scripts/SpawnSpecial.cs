using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpecial : MonoBehaviour
{
    public GameObject specialNote;
    private int randomNum;
    public int decision;
    private int maxNum = 80;
    private int minNum = 40;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(1, 101);

        if (randomNum > maxNum)
        {
            decision = 0;
        }
        else if (randomNum > minNum && randomNum <= maxNum)
        {
            decision = 1;
        }
        else
        {
            decision = 2;
        }
        StartCoroutine(SpawnSpecialMethod());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnSpecialMethod()
    {
        if (decision == 0)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(5, 7));
            Debug.Log("SpawnedSpecial");
            specialNote.gameObject.SetActive(true);
            specialNote.GetComponent<SpecialNote>().decision = decision;
        }
    }
}

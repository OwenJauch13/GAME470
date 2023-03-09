using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2Effect2 : Notes
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        note2Effect2Time = 2.5f;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeParent()
    {
        transform.SetParent(null);
    }

    public void RunCor()
    {
        StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(note2Effect2Time);
        transform.SetParent(player.transform);
        gameObject.transform.position = player.transform.position;
        gameObject.SetActive(false);
    }
}

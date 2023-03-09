using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2Effect1 : Notes
{
    public GameObject effect4;
    public GameObject effect2;
    public GameObject effect3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunCor()
    {
        effect4.GetComponent<Note2Effect4>().note2Effect4Time = 3.5f;
        effect2.GetComponent<Note2Effect2>().note2Effect2Time = 3.5f;
        effect3.GetComponent<Note2Effect3>().note2Effect3Time = 3.5f;
        StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(1);
        effect4.GetComponent<Note2Effect4>().note2Effect4Time = 2.5f;
        effect2.GetComponent<Note2Effect2>().note2Effect2Time = 2.5f;
        effect3.GetComponent<Note2Effect3>().note2Effect3Time = 2.5f;
    }
}

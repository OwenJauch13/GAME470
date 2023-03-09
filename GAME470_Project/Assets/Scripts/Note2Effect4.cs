using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2Effect4 : Notes
{
    void Start()
    {
        note2Effect4Time = 2.5f;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 125 * Time.deltaTime, 0);
        Debug.Log(note2Effect4Time);
    }

    public void RunCor()
    {
        StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(note2Effect4Time);
        gameObject.SetActive(false);
    }
}

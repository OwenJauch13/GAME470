using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    public GameObject player;
    PlayTune playTune;
    public PlayerStats playerStats;
    public Image qKeyImg;
    public Image eKeyImg;
    public Image rKeyImg;
    public Image fKeyImg;
    public Text qNote;
    public Text eNote;
    public Text rNote;
    public Text fNote;
    public Text health;

    public bool qKeyInUse;
    public bool eKeyInUse;
    public bool rKeyInUse;
    public bool fKeyInUse;

    // Start is called before the first frame update
    void Start()
    {
        playTune = player.GetComponent<PlayTune>();
        qKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        eKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        rKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        fKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        qNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnQKey.ToString();
        eNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnEKey.ToString();
        rNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnRKey.ToString();
        fNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnFKey.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        health.GetComponent<Text>().text = playerStats.health.ToString();
        qKeyInUse = player.GetComponent<PlayTune>().canUseQKey;
        eKeyInUse = player.GetComponent<PlayTune>().canUseEKey;
        rKeyInUse = player.GetComponent<PlayTune>().canUseRKey;
        fKeyInUse = player.GetComponent<PlayTune>().canUseFKey;

        if (qKeyInUse)
            qKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        else
            qKeyImg.GetComponent<Image>().color = new Color32(215, 62, 62, 255);

        if (eKeyInUse)
            eKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        else
            eKeyImg.GetComponent<Image>().color = new Color32(215, 62, 62, 255);

        if (rKeyInUse)
            rKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        else
            rKeyImg.GetComponent<Image>().color = new Color32(215, 62, 62, 255);

        if (fKeyInUse)
            fKeyImg.GetComponent<Image>().color = new Color32(27, 209, 32, 255);
        else
            fKeyImg.GetComponent<Image>().color = new Color32(215, 62, 62, 255);

        qNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnQKey.ToString();
        eNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnEKey.ToString();
        rNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnRKey.ToString();
        fNote.GetComponent<Text>().text = player.GetComponent<PlayTune>().noteOnFKey.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTune : MonoBehaviour
{

    public List<int> notesList;    //Array to hold the notes that will play in the tune
    Dictionary<string, int> notes = new Dictionary<string, int>(); //Dictionary used to distinguish what numbers correspond to what notes, we may not need this though but i wanted to make it

    public bool canPlayTune;
    public float tuneCooldownVar;
    public float tuneLastTime;

    public int noteOnQKey;
    public int noteOnEKey;
    public int noteOnRKey;
    public int noteOnFKey;

    public GameObject tuneRing;

    [Header("Damage And Types")]
    public float baseDamage;
    public bool canDoFireDmg;
    public bool canDoIceDmg;
    public bool canDoPsnDmg;

    [Header("Cooldowns for Key Presses")]
    public float qKeyCooldown;
    public float eKeyCooldown;
    public float rKeyCooldown;
    public float fKeyCooldown;
    public bool canUseQKey;
    public bool canUseEKey;
    public bool canUseRKey;
    public bool canUseFKey;

    [Header("Note 2 Effects")]
    public GameObject Note2Effect4;
    public GameObject Note2Effect2;
    public GameObject Note2Effect3;
    public GameObject Note2Effect1;

    // Start is called before the first frame update
    void Start()
    {
        canPlayTune = true;
        tuneCooldownVar = 3.0f;
        tuneLastTime = 0.35f;

        baseDamage = 1.0f;
        canDoFireDmg = false;
        canDoIceDmg = false;
        canDoPsnDmg = false;

        canUseQKey = true;
        canUseEKey = true;
        canUseRKey = true;
        canUseFKey = true;
        qKeyCooldown = 5.0f;
        eKeyCooldown = 5.0f;
        rKeyCooldown = 5.0f;
        fKeyCooldown = 5.0f;


    notes = new Dictionary<string, int>()
        {
            {"Note1", 1 },
            {"Note2", 2 },
            {"Note3", 3 },
            {"Note4", 4 }
        };

        noteOnQKey = 2;
        noteOnEKey = 1;
        noteOnRKey = 1;
        noteOnFKey = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canPlayTune == true)
        {
            SortNotesFromTune();
            PlayEmptyTune();
            if (!canUseQKey) { StartCoroutine(QKeyCooldown(qKeyCooldown)); }
            if (!canUseEKey) { StartCoroutine(EKeyCooldown(eKeyCooldown)); }
            if (!canUseRKey) { StartCoroutine(RKeyCooldown(rKeyCooldown)); }
            if (!canUseFKey) { StartCoroutine(FKeyCooldown(fKeyCooldown)); }
        }

        if (Input.GetKeyDown("q") && notesList.Count < 4 && canUseQKey)
        {
            notesList.Add(noteOnQKey);
            canUseQKey = false;
        }
        if (Input.GetKeyDown("e") && notesList.Count < 4 && canUseEKey)
        {
            notesList.Add(noteOnEKey);
            canUseEKey = false;
        }
        if (Input.GetKeyDown("r") && notesList.Count < 4 && canUseRKey)
        {
            notesList.Add(noteOnRKey);
            canUseRKey = false;
        }
        if (Input.GetKeyDown("f") && notesList.Count < 4 && canUseFKey)
        {
            notesList.Add(noteOnFKey);
            canUseFKey = false;
        }
    }

    void SortNotesFromTune() //This function will look through the array notesList and pull out the values in them to figure out what notes were played in what order
    {
        for (int i = 0; i < notesList.Count; i++)
        {
            if (notesList[i] == 1)
            {
                NoteOneFunc(i + 1);
            } else if (notesList[i] == 2)
            {
                NoteTwoFunc(i + 1);
            } else if (notesList[i] == 3)
            {
                NoteThreeFunc(i + 1);
            } else
            {
                NoteFourFunc(i + 1);
            }
        }

        if (notesList.Count == 0)
        {
            Debug.Log("Played an empty tune");
        }

        notesList.Clear();
    }

    void NoteOneFunc(int notePlacement) //This function will take the position that note one was in and do something based off of that
    {
        Debug.Log("Note 1 was played at position " + notePlacement);
        if (notePlacement == 1)
        {
            //Do something related to what note 1 owuld do in position 1
            baseDamage *= 2;
        } else if (notePlacement == 2)
        {
            //Do something related to what note 1 owuld do in position 2
            canDoFireDmg = true;
        }
        else if (notePlacement == 3)
        {
            //Do something related to what note 1 owuld do in position 3
            canDoIceDmg = true;
        }
        else
        {
            //Do something related to what note 1 owuld do in position 4
            canDoPsnDmg = true;
        }
    }

    void NoteTwoFunc(int notePlacement) //This function will take the position that note two was in and do something based off of that
    {
        Debug.Log("Note 2 was played at position " + notePlacement);
        if (notePlacement == 1)
        {
            //Do something related to what note 2 owuld do in position 1
            Note2Effect1.GetComponent<Note2Effect1>().RunCor();
        }
        else if (notePlacement == 2)
        {
            //Do something related to what note 2 owuld do in position 2
            Note2Effect2.SetActive(true);
            Note2Effect2.GetComponent<Note2Effect2>().ChangeParent();
            Note2Effect2.GetComponent<Note2Effect2>().RunCor();
        }
        else if (notePlacement == 3)
        {
            //Do something related to what note 2 owuld do in position 3
            Note2Effect3.SetActive(true);
            Note2Effect3.GetComponent<Note2Effect3>().ChangeParent();
            Note2Effect3.GetComponent<Note2Effect3>().RunCor();
        }
        else
        {
            //Do something related to what note 2 owuld do in position 4
            Note2Effect4.SetActive(true);
            Note2Effect4.GetComponent<Note2Effect4>().RunCor();
        }
    }

    void NoteThreeFunc(int notePlacement) //This function will take the position that note three was in and do something based off of that
    {
        Debug.Log("Note 3 was played at position " + notePlacement);
        if (notePlacement == 1)
        {
            //Do something related to what note 3 owuld do in position 1
        }
        else if (notePlacement == 2)
        {
            //Do something related to what note 3 owuld do in position 2
        }
        else if (notePlacement == 3)
        {
            //Do something related to what note 3 owuld do in position 3
        }
        else
        {
            //Do something related to what note 3 owuld do in position 4
        }
    }

    void NoteFourFunc(int notePlacement) //This function will take the position that note four was in and do something based off of that
    {
        Debug.Log("Note 4 was played at position " + notePlacement);
        if (notePlacement == 1)
        {
            //Do something related to what note 4 owuld do in position 1
        }
        else if (notePlacement == 2)
        {
            //Do something related to what note 4 owuld do in position 2
        }
        else if (notePlacement == 3)
        {
            //Do something related to what note 4 owuld do in position 3
        }
        else
        {
            //Do something related to what note 4 owuld do in position 4
        }
    }

    void PutNoteIntoQ(int noteToBePutIn) //function that puts the note into the Q key
    {
        noteOnQKey = noteToBePutIn;
    }

    void PutNoteIntoE(int noteToBePutIn) //function that puts the note into the E key
    {
        noteOnEKey = noteToBePutIn;
    }

    void PutNoteIntoR(int noteToBePutIn) //function that puts the note into the R key
    {
        noteOnRKey = noteToBePutIn;
    }

    void PutNoteIntoF(int noteToBePutIn) //function that puts the note into the F key
    {
        noteOnFKey = noteToBePutIn;
    }

    void PlayEmptyTune() //This function will do the basic attack for playing an empty tune
    {
        Debug.Log(1234);
        tuneRing.SetActive(true);
        canPlayTune = false;
        StartCoroutine(TuneCooldown(tuneCooldownVar, tuneLastTime));
        StartCoroutine(NoteOneReset());
    }

    private IEnumerator TuneCooldown(float waitTime, float lastTime) // this IEnumerator will run the cooldown for the base tune ring that will be played
    {
        yield return new WaitForSeconds(lastTime);
        tuneRing.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        canPlayTune = true;
    }

    private IEnumerator QKeyCooldown(float cooldown) // this IEnumerator will run the cooldown for the Q key cooldown that will be played
    {
        yield return new WaitForSeconds(cooldown);
        canUseQKey = true;
    }

    private IEnumerator EKeyCooldown(float cooldown) // this IEnumerator will run the cooldown for the E key cooldown that will be played
    {
        yield return new WaitForSeconds(cooldown);
        canUseEKey = true;
    }

    private IEnumerator RKeyCooldown(float cooldown) // this IEnumerator will run the cooldown for the R key cooldown that will be played
    {
        yield return new WaitForSeconds(cooldown);
        canUseRKey = true;
    }

    private IEnumerator FKeyCooldown(float cooldown) // this IEnumerator will run the cooldown for the F key cooldown that will be played
    {
        yield return new WaitForSeconds(cooldown);
        canUseFKey = true;
    }

    private IEnumerator NoteOneReset() // This IEmuerator will run the reset for the note 1 stuff
    {
        yield return new WaitForSeconds(1);
        baseDamage = 1;
        canDoFireDmg = false;
        canDoIceDmg = false;
        canDoPsnDmg = false;
    }
}

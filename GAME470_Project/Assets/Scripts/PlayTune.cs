using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTune : MonoBehaviour
{
    public List<int> notesList;    //Array to hold the notes that will play in the tune
    Dictionary<string, int> notes = new Dictionary<string, int>(); //Dictionary used to distinguish what numbers correspond to what notes, we may not need this though but i wanted to make it

    public int noteOnQKey;
    public int noteOnEKey;
    public int noteOnRKey;
    public int noteOnFKey;

    // Start is called before the first frame update
    void Start()
    {
        notes = new Dictionary<string, int>()
        {
            {"Note1", 1 },
            {"Note2", 2 },
            {"Note3", 3 },
            {"Note4", 4 }
        };

        noteOnQKey = 1;
        noteOnEKey = 2;
        noteOnRKey = 3;
        noteOnFKey = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SortNotesFromTune();
        }

        if (Input.GetKeyDown("q") && notesList.Count < 4)
        {
            notesList.Add(noteOnQKey);
        }
        if (Input.GetKeyDown("e") && notesList.Count < 4)
        {
            notesList.Add(noteOnEKey);
        }
        if (Input.GetKeyDown("r") && notesList.Count < 4)
        {
            notesList.Add(noteOnRKey);
        }
        if (Input.GetKeyDown("f") && notesList.Count < 4)
        {
            notesList.Add(noteOnFKey);
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

        notesList.Clear();
    }

    void NoteOneFunc(int notePlacement) //This function will take the position that note one was in and do something based off of that
    {
        Debug.Log("Note 1 was played at position " + notePlacement);
    }

    void NoteTwoFunc(int notePlacement) //This function will take the position that note two was in and do something based off of that
    {
        Debug.Log("Note 2 was played at position " + notePlacement);
    }

    void NoteThreeFunc(int notePlacement) //This function will take the position that note three was in and do something based off of that
    {
        Debug.Log("Note 3 was played at position " + notePlacement);
    }

    void NoteFourFunc(int notePlacement) //This function will take the position that note four was in and do something based off of that
    {
        Debug.Log("Note 4 was played at position " + notePlacement);
    }
}

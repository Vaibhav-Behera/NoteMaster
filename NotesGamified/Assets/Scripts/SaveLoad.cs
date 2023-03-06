using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public string theText;
    public GameObject ourNote;
    public GameObject Placeholder;
    public GameObject Savetext_Anim;
    void Start()
    {
        theText = PlayerPrefs.GetString("NoteContents");
        Placeholder.GetComponent<InputField>().text = theText;
    }

    public void SaveNote()
    {
        theText = ourNote.GetComponent<Text>().text;
        PlayerPrefs.SetString("NoteContents", theText);
        StartCoroutine(SaveTextRoll());
    }

    IEnumerator SaveTextRoll() //Cannot use waitfor seconds in a function that is why we are using a coroutine
    {
        Savetext_Anim.GetComponent<Animator>().Play("SaveText");
        yield return new WaitForSeconds(1);
        Savetext_Anim.GetComponent<Animator>().Play("New State");
    }
}

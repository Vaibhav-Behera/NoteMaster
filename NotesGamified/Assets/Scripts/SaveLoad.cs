using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";
    public string saveString;
    private string[] contents;
    public string theText;
    public string theText2;
    public string theText3;
    public GameObject ourNote;
    public GameObject ourNote2;
    public GameObject ourNote3;
    public GameObject Placeholder;
    public GameObject Placeholder2;
    public GameObject Placeholder3;
    public GameObject Savetext_Anim;
    private int currentNoteIndex = 1;
//     void Start()
//     {
//         // theText = PlayerPrefs.GetString("NoteContents");
//         // Placeholder.GetComponent<InputField>().text = theText;
//         // theText2 = PlayerPrefs.GetString("NoteContents2");
//         // Placeholder2.GetComponent<InputField>().text = theText2;
//         // theText3 = PlayerPrefs.GetString("NoteContents3");
//         // Placeholder3.GetComponent<InputField>().text = theText3;
//         //Trying code monkey code with text
//         //To delete all the contents of a file : 
//         //File.WriteAllText(Application.dataPath + "/save.txt", "");
//         saveString = File.ReadAllText(Application.dataPath + "/save.txt");
//         contents = saveString.Split(new[]{ SAVE_SEPARATOR }, System.StringSplitOptions.None);
//         Placeholder.GetComponent<InputField>().text = contents[1];
//         Placeholder2.GetComponent<InputField>().text = contents[2];
//         Placeholder3.GetComponent<InputField>().text = contents[3];
        
//     }

//     public void SaveNote()
//     {
//         //theText = ourNote.GetComponent<Text>().text;
//         // PlayerPrefs.SetString("NoteContents", theText);
//         // theText2 = ourNote2.GetComponent<Text>().text;
//         // PlayerPrefs.SetString("NoteContents2", theText2);
//         // theText3 = ourNote3.GetComponent<Text>().text;
//         // PlayerPrefs.SetString("NoteContents3", theText3);
//         //Trying code monkey code with text
    
//         theText = ourNote.GetComponent<Text>().text;
//         theText2 = ourNote2.GetComponent<Text>().text;
//         theText3 = ourNote3.GetComponent<Text>().text;
//         contents = new string[] {
//         "",
//         ""+theText,
//         ""+theText2,
//         ""+theText3
//     };
//         saveString = string.Join(SAVE_SEPARATOR, contents);
//         //File.WriteAllText(Application.dataPath + "/save.txt", saveString);
//         if (File.Exists(Application.dataPath + "/save.txt")) {
//     // If the file exists, append the new values to the end of the file
//     using (StreamWriter sw = File.AppendText(Application.dataPath + "/save.txt")) {
//         sw.WriteLine(saveString);
//     }
// } else {
//     // If the file doesn't exist, create a new file and write the new values to it
//     File.WriteAllText(Application.dataPath + "/save.txt", saveString);
// }
//         StartCoroutine(SaveTextRoll());
//     }

//     IEnumerator SaveTextRoll() //Cannot use waitfor seconds in a function that is why we are using a coroutine
//     {
//         Savetext_Anim.GetComponent<Animator>().Play("SaveText");
//         yield return new WaitForSeconds(1);
//         Savetext_Anim.GetComponent<Animator>().Play("New State");
//     }
void Start()
{
    //File.WriteAllText(Application.dataPath + "/save.txt", "");
    LoadData();
}

    public void SaveNote()
    {
        theText = ourNote.GetComponent<Text>().text;
        theText2 = ourNote2.GetComponent<Text>().text;
        theText3 = ourNote3.GetComponent<Text>().text;
        string[] contents = new string[] {
            "",
            ""+theText,
            ""+theText2,
            ""+theText3
        };
        saveString = string.Join(SAVE_SEPARATOR, contents);
                //File.WriteAllText(Application.dataPath + "/save.txt", saveString);
        if (File.Exists(Application.dataPath + "/save.txt")) {
    // If the file exists, append the new values to the end of the file
    using (StreamWriter sw = File.AppendText(Application.dataPath + "/save.txt")) {
        sw.WriteLine(saveString);
    }
} else {
    // If the file doesn't exist, create a new file and write the new values to it
    File.WriteAllText(Application.dataPath + "/save.txt", saveString);
}
    }
public void LoadData()
{
    saveString = File.ReadAllText(Application.dataPath + "/save.txt");
    contents = saveString.Split(new[] {SAVE_SEPARATOR}, System.StringSplitOptions.None);
    DisplayData(1);
}

public void DisplayData(int index)
{
    if (index < contents.Length)
    {
        Placeholder.GetComponent<InputField>().text = contents[index];
        Placeholder2.GetComponent<InputField>().text = contents[index + 1];
        Placeholder3.GetComponent<InputField>().text = contents[index + 2];
    }
}

public void ShowNextNote()
{
    saveString = File.ReadAllText(Application.dataPath + "/save.txt");
    string[] contents = saveString.Split(new[]{ SAVE_SEPARATOR }, System.StringSplitOptions.None);

    currentNoteIndex += 3;

    // Wrap around to beginning of array if end is reached
    if (currentNoteIndex + 2 >= contents.Length) {
        currentNoteIndex = 1;
    }

    Placeholder.GetComponent<InputField>().text = contents[currentNoteIndex];
    Placeholder2.GetComponent<InputField>().text = contents[currentNoteIndex + 1];
    Placeholder3.GetComponent<InputField>().text = contents[currentNoteIndex + 2];
}


    IEnumerator SaveTextRoll() //Cannot use waitfor seconds in a function that is why we are using a coroutine
    {
        Savetext_Anim.GetComponent<Animator>().Play("SaveText");
        yield return new WaitForSeconds(1);
        Savetext_Anim.GetComponent<Animator>().Play("New State");
    }

}
// // I will have to learn how to use files more 
// // so that i can save the topic,question and answer in a file as a single entity
// // than i can retrieve those things from a file 
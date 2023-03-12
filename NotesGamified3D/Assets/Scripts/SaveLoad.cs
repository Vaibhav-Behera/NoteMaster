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
    public GameObject FlashCardPlaceHolder1;
    public GameObject FlashCardPlaceHolder2;
    public GameObject FlashCardPlaceHolder3;

    public GameObject Savetext_Anim;
    private int currentNoteIndex = 1;

    public int notesSeen = 0;
    public Text notesSeenText;
    public int flashnotesSeen = 0;
    public Text Flashnoteseentext;

    public int correctans = 0;
    public Text correctanstext;
    public int wrongans = 0;
    public Text wronganstext;
void Start()
{
    //File.WriteAllText(Application.dataPath + "/save.txt", "");
    LoadData();
}

    public void CorrectAns()
    {
    correctans++;
    correctanstext.text = correctans.ToString();        
    }

    public void WrongAns()
    {
    wrongans++;
    wronganstext.text = wrongans.ToString();
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
        FlashCardPlaceHolder1.GetComponent<InputField>().text = contents[index];
        FlashCardPlaceHolder2.GetComponent<InputField>().text = contents[index + 1];
        FlashCardPlaceHolder3.GetComponent<InputField>().text = contents[index + 2];

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
    
    notesSeen++;
    notesSeenText.text = notesSeen.ToString();
}

public void FlashNextNote()
{
    saveString = File.ReadAllText(Application.dataPath + "/save.txt");
    string[] contents = saveString.Split(new[] { SAVE_SEPARATOR }, System.StringSplitOptions.None);

    // Get a random index that is a multiple of 3 and within the bounds of the array
    int maxIndex = contents.Length - 3;
    int randomIndex = Random.Range(1, maxIndex + 1) / 3 * 3;

    FlashCardPlaceHolder1.GetComponent<InputField>().text = contents[randomIndex + 1];
    FlashCardPlaceHolder2.GetComponent<InputField>().text = contents[randomIndex + 2];
    FlashCardPlaceHolder3.GetComponent<InputField>().text = contents[randomIndex + 3];

    flashnotesSeen++;
    Flashnoteseentext.text = flashnotesSeen.ToString();
}



    IEnumerator SaveTextRoll() //Cannot use waitfor seconds in a function that is why we are using a coroutine
    {
        Savetext_Anim.GetComponent<Animator>().Play("SaveText");
        yield return new WaitForSeconds(1);
        Savetext_Anim.GetComponent<Animator>().Play("New State");
    }
    public void deleteallnotes()
    {
    File.WriteAllText(Application.dataPath + "/save.txt", "");
    }


}



// public void DeleteNoteByIndex(int index)
// {
//     if (index < contents.Length)
//     {
//         // Remove the note from the contents array
//         contents = contents.Where((val, idx) => idx < index || idx > index + 2).ToArray();
//         saveString = string.Join(SAVE_SEPARATOR, contents);
//         File.WriteAllText(Application.dataPath + "/save.txt", saveString); // Update the save file
//         DisplayData(1); // Refresh the display
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public InputField theText;
    public InputField theText2;
    public InputField theText3;
    public AudioSource clearSound;
    public GameObject thePanel; // the panel refers to that panel which appears upon clicking on cross
    public GameObject SaveNotesPanel;
    public GameObject LoadingDeletingNotesPanel;
    public GameObject MenuPanel;

    public void ClearText()
    {
        theText.text = "";
        theText2.text = "";
        theText3.text = "";
        clearSound.Play();
    }

    public void CancelButton()
    {
        thePanel.SetActive(false);
    }

    public void CloseButton()
    {
        thePanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OpenSaveNotesPanel()
    {
        SaveNotesPanel.SetActive(true);
        LoadingDeletingNotesPanel.SetActive(false);
        MenuPanel.SetActive(false);
    }

    public void OpenLoadingDeletingNotesPanel()
    {
        LoadingDeletingNotesPanel.SetActive(true);
        SaveNotesPanel.SetActive(false);
        MenuPanel.SetActive(false);
    }

    public void Play()
    {
        MenuPanel.SetActive(false);
        SaveNotesPanel.SetActive(false);
        LoadingDeletingNotesPanel.SetActive(false);
    }

    public void SaveNotesPanelBack()
    {
        SaveNotesPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void LoadingDeletingNotesPanelBack()
    {
        LoadingDeletingNotesPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}

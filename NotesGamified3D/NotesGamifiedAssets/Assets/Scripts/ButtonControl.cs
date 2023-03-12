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
    public GameObject thePanel;

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
}

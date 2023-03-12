using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public InputField theText;
    public InputField theText2;
    public InputField theText3;
    public GameObject MenuPanel;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPanel.SetActive(!MenuPanel.activeSelf);
        }
    }

    public void ClearText()
    {
        theText.text = "";
        theText2.text = "";
        theText3.text = "";
    }


    public void QuitButton()
    {
        Application.Quit();
    }



    public void Play()
    {
        MenuPanel.SetActive(false);
    }


}

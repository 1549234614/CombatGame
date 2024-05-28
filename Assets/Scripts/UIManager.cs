using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject settingScreen;

    public GameObject matchingScreen;

    public GameObject selectionScreen;


    public void SettingScreenStart()
    {
        settingScreen.SetActive(true);
    }

    public void SettingScreenExit()
    {
        settingScreen.SetActive(false);
    }

    public void MatchingScreenStart()
    {
        matchingScreen.SetActive(true);
    }

    public void MatchingScreenExit()
    {
        matchingScreen.SetActive(false);
    }

    public void SelectionScreenStart()
    {
        selectionScreen.SetActive(true);

    }
    public void SelectionScreenExit()
    {
        selectionScreen.SetActive(false);
    }

}

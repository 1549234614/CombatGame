using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject selectionScreen;

    public void SelectionScreenStart()
    {
        selectionScreen.SetActive(true);
    }
    public void SelectionScreenExit()
    {
        selectionScreen.SetActive(false);
    }
}

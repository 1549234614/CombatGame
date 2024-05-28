using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSwitcher : MonoBehaviour
{

    private int currentCharacter;

    public float countTime = 0f;

    public Text showText;

    private void Update()
    {
        CountTime();
    }

    public void SelectCharacters()
    {
        if(currentCharacter>=1 && currentCharacter<=6)
        {
            PlayerPrefs.SetInt("CurrentCharacter", currentCharacter);
            SceneManager.LoadScene("BattleScene");
        }
    }

    public void Character(int currentIndex)
    {
        currentCharacter = currentIndex;
        SelectCharacters();
    }

    private void CountTime()
    {
        countTime -= Time.deltaTime;
        showText.text = countTime.ToString("f2");
        if (countTime <= 0f)
        {
            SceneManager.LoadScene("BattleScene");
            Character(1);
        }
    }
  
    private void OnDisable()
    {
        countTime = 10f;
    }

}

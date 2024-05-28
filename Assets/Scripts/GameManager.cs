using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Character;

    public GameObject[] Enemy;

    private int currentCharacter;

    public Transform player1Position;

    public Transform EnemyPosition;

    private void Start()
    {
        GetPlayer1();
        GetEnemy();
    }

    private void GetPlayer1()
    {
        /*currentCharacter = 1;//PlayerPrefs.GetInt("CurrentCharacter");
        Instantiate(Character[currentCharacter - 1], player1Position.position, Quaternion.identity);
        PlayerPrefs.DeleteAll();*/
    }

    private void GetEnemy()
    {
        /*Instantiate(Enemy[0], EnemyPosition.position, Quaternion.identity);*/
    }
}

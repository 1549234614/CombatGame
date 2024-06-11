using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage = 10;

    Animator ani;

    Enemy enemy;

    public GameObject BloodPre;

    private void Start()
    {
        ani = GetComponentInParent<Animator>();
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            enemy.isRebound = true;
            ani.SetFloat("speed", -1);
            return;
        }
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.ChangeHealth(damage);

            /*Instantiate(BloodPre, collision.transform.GetChild(0).position, Quaternion.identity);
            Destroy(GameObject.Find("Blood(Clone)"), 0.3f);*/
        }
    }
}

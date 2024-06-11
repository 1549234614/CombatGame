using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("����")]
    public float damage = 10;

    Animator ani;
    Player player;

    [Header("����Ч��")]
    public GameObject BloodPre;

    private void Start()
    {
        ani = GetComponentInParent<Animator>();
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�������ƴ���
        if (collision.tag == "Shield")
        {
            player.isRebound = true;
            ani.SetFloat("speed", -1);
            return;
        }
        //�������˴���
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.ChangeHealth(damage);
            
/*            //��Ч
            Instantiate(BloodPre, collision.transform.GetChild(0).position, Quaternion.identity);
            Destroy(GameObject.Find("Blood(Clone)"), 0.3f);*/
        }
    }
}

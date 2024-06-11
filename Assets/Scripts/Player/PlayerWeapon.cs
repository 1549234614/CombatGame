using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("属性")]
    public float damage = 10;

    Animator ani;
    Player player;

    [Header("受伤效果")]
    public GameObject BloodPre;

    private void Start()
    {
        ani = GetComponentInParent<Animator>();
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //攻击盾牌触发
        if (collision.tag == "Shield")
        {
            player.isRebound = true;
            ani.SetFloat("speed", -1);
            return;
        }
        //攻击敌人触发
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.ChangeHealth(damage);
            
/*            //特效
            Instantiate(BloodPre, collision.transform.GetChild(0).position, Quaternion.identity);
            Destroy(GameObject.Find("Blood(Clone)"), 0.3f);*/
        }
    }
}

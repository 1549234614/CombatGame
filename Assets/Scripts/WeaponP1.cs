using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponP1 : MonoBehaviour
{
    public float damage = 10;

    Animator animator;

    PlayerController1 playerController1;

    public GameObject BloodPre;
   /* private float ffTimer, ffTimerTotal;*/

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        playerController1 = GetComponentInParent<PlayerController1>();
    }

   /* private void FixedUpdate()
    {
        if (ffTimer > 0)
        {
            ffTimer -= Time.deltaTime;
            Time.timeScale = Mathf.Lerp(0.5f, 1f, (1 - (ffTimer / ffTimerTotal)));
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //FrameFrozen(0.5f);
        if (collision.tag == "Shield")
        {
            playerController1.isTanDao = true;
            animator.SetFloat("speed", -1);
            return;
        }
        if (collision.tag == "Player")
        {
            PlayerController2 playerController2 = collision.GetComponent<PlayerController2>();
            playerController2.ChangeHealth(damage);
        }
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.ChangeHealth(damage);
            Instantiate(BloodPre, collision.transform.GetChild(0).position, Quaternion.identity);
            Destroy(GameObject.Find("Blood(Clone)"),0.3f);
        }
    }



 /*   public void EndSpecialEffects()
    {
        Debug.Log(1);
        Destroy(GameObject.Find("Blood(Clone)"));
    }*/


    /*    public void FrameFrozen(float time)
        {
            ffTimer = time;
            ffTimerTotal = time;
        }*/


}

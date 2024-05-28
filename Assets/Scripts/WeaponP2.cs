using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponP2 : MonoBehaviour
{
    public float damage = 10;

    Animator animator;
    PlayerController2 playerController2;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        playerController2 = GetComponentInParent<PlayerController2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Shield")
        {
            playerController2.isTanDao = true;
            animator.SetFloat("speed", -1);
            return;
        }
        if(collision.tag == "Player")
        {
            PlayerController1 playerController1 = collision.GetComponent<PlayerController1>();
            playerController1.ChangeHealth(damage);
        }

    }

 
}

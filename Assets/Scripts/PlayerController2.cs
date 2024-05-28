using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    private Animator animator;

    
    public float speed;

    public float health;
    public float currentHealth;

    private bool isDead;

    public bool isTanDao;
    private void Start()
    {
        health = 100;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
            return;
        Attack();
        Defense();
        Move();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            animator.SetFloat("speed", 1);
            animator.SetBool("isAttack",true);
            
        }
    }

    private void StopAttack()
    {
        animator.SetBool("isAttack", false);
    }
    private void Speed()
    {
        if(isTanDao == true)
        {
            animator.SetBool("isAttack", false);
            isTanDao = false;
        }

    }

    private void Defense()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            animator.SetTrigger("defense");
        }
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(new Vector2(-1, 0)* speed * Time.deltaTime);
        }

    }


    public void ChangeHealth(float num)
    {
        animator.SetTrigger("hurt");
        health -= num;
        currentHealth = health;
        if(currentHealth <= 0)
        {
            isDead = true;
            animator.SetBool("die",true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController1 : MonoBehaviour
{

    private Animator animator;
    
    public float speed;

    public float health;
    
    public float currentHealth;
    
    private bool isDead;

    public bool isTanDao;

    private bool isAttack;
   
    private bool isDefense;

    public bool isWalk;

    private InputControl inputControl;

    public Vector2 inputDirection;

    private void Awake()
    {
        inputControl = new InputControl();
    }

    private void Start()
    {
        health = 100;
        animator = GetComponent<Animator>();
        inputControl.Player.Attack.started += Attack;
        inputControl.Player.Defense.started += Defense;
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        if (isDead)
            return;
        Move();
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        if (isDead)
            return;
        if (isDefense == true)
            return;
        animator.SetFloat("speed", 1);
        animator.SetBool("isAttack", true);
        isAttack = true;
    }

    private void Defense(InputAction.CallbackContext obj)
    {
        if (isAttack == true)
            return;
        animator.SetBool("isDefense", true);
        isDefense = true;
    }

    private void StopAttack()
    {
        animator.SetBool("isAttack", false);
        isAttack = false;
    }
    private void Speed()
    {
        if (isTanDao == true)
        {
            animator.SetBool("isAttack", false);
            isAttack = false;
            isTanDao = false;
        }
    }

    private void StopDefense()
    {
        animator.SetBool("isDefense", false);
        isDefense = false;
    }

    private void Move()
    {
        if (isAttack == true || isDefense == true)
            return;
        inputDirection = inputControl.Player.Move.ReadValue<Vector2>();

        this.transform.Translate(inputDirection * speed * Time.deltaTime);
        if (inputDirection.x == 0)
        {
            animator.SetBool("isWalk", false);
            isWalk = false;
        }
        else
        {
            animator.SetBool("isWalk", true);
            isWalk = true;
        }
    }

    public void ChangeHealth(float num)
    {
        animator.SetTrigger("hurt");
        health -= num;
        currentHealth = health;
        if (currentHealth <= 0)
        {
            isDead = true;
            animator.SetBool("die", true);
        }
    }

    
}

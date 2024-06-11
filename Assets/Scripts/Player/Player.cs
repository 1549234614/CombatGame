using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("属性")]
    public float speed;
    public float health;
    public float currentHealth;

    private bool isDead;

    public bool isRebound;//弹反

    private bool isAttack;

    private bool isDefense;

    public bool isWalk;
    public Vector2 inputDirection;

    //组件
    private Animator ani;
    private InputControl inputControl;
    private CapsuleCollider2D capsuleCollider2D;
    public Slider healthSlider;

    private void Awake()
    {
        inputControl = new InputControl();
    }

    private void Start()
    {
        health = 100;
        ani = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
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
        ani.SetFloat("speed", 1);
        ani.SetBool("isAttack", true);
        isAttack = true;
    }

    private void Defense(InputAction.CallbackContext obj)
    {
        if (isAttack == true)
            return;
        ani.SetBool("isDefense", true);
        isDefense = true;
    }

    private void Move()
    {
        if (isAttack == true || isDefense == true)
            return;
        inputDirection = inputControl.Player.Move.ReadValue<Vector2>();

        this.transform.Translate(inputDirection * speed * Time.deltaTime);
        if (inputDirection.x == 0)
        {
            ani.SetBool("isWalk", false);
            isWalk = false;
        }
        else
        {
            ani.SetBool("isWalk", true);
            isWalk = true;
        }
    }

    public void ChangeHealth(float num)
    {
        ani.SetTrigger("hurt");
        health -= num;
        currentHealth = health;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            isDead = true;
            ani.SetBool("die", true);
            capsuleCollider2D.enabled = false;
        }
    }


    private void StopAttack()
    {
        ani.SetBool("isAttack", false);
        isAttack = false;
    }
    private void Speed()
    {
        if (isRebound == true)
        {
            ani.SetBool("isAttack", false);
            isAttack = false;
            isRebound = false;
        }
    }
    private void StopDefense()
    {
        ani.SetBool("isDefense", false);
        isDefense = false;
    }
}

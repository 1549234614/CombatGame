using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D body;
    private CapsuleCollider2D capsuleCollider2D;

    public float MoveSpeed = 3;

    [Header("µÐÈËÑªÁ¿")]
    public float health;
    public float currentHealth;
    public Slider healthSlider;

    public StateMachine<Enemy> machine;
    public Dictionary<EnemyType, _State<Enemy>> stateDie;

    //private int i=0;
    private void Start()
    {
        initEnemy();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        stateDie = new Dictionary<EnemyType, _State<Enemy>>();
        stateDie.Add(EnemyType.Move, new Enemy_Move());
        stateDie.Add(EnemyType.Idle, new Enemy_Idle());

        machine = new StateMachine<Enemy>(this);

        machine.SetCurrent(stateDie[EnemyType.Idle]);

    }

    public void ChangeState(EnemyType type)
    {
        if (stateDie.ContainsKey(type))
        {
            machine.ChangeState(stateDie[type]);
        }
    }

    void Update()
    {
        machine.OnUpdate();
    }

    public void Move()
    {
        Vector3 movePos = body.position + Vector2.right * Mathf.Sign(transform.localScale.x) * MoveSpeed * Time.deltaTime;
        body.MovePosition(movePos);
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
    }

    private void initEnemy()
    {
        currentHealth = health;
    }

    public void ChangeHealth(float num)
    {
        animator.SetTrigger("hurt");
        currentHealth -= num;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("die");
            capsuleCollider2D.enabled = false;
        }
    }

    public enum EnemyType
    {
        Idle,
        Move,
        Attack,
        Die,
        Hurt
    }
}

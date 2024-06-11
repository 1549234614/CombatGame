using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//״̬ö��,ö�ٱ���������ͬһ�����ռ���ȫ�ַ��ʡ�c#��û����ʾ���������ռ䣬������һ�������ռ��¡�
public enum EnemyType
{
    Idle,
    Move,
    Attack,
    Die,
    Hurt
}

public class Enemy : MonoBehaviour
{
    //���
    public Animator ani;
    public Rigidbody2D body;
    private CapsuleCollider2D capsuleCollider2D;

    [Header("����")]
    public float MoveSpeed = 10;
    public float health;
    public float currentHealth;
    public Slider healthSlider;
    public bool isRebound;//����

    //����
    private int MoveDirection;//�ƶ�����
    public StateMachine<Enemy> machine;//״̬��
    public Dictionary<EnemyType, _State<Enemy>> stateDie;//�洢״̬�ֵ�

    private void Start()
    {
        initEnemy();
        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        //�����ֵ�
        stateDie = new Dictionary<EnemyType, _State<Enemy>>();
        stateDie.Add(EnemyType.Move, new Enemy_Move());
        stateDie.Add(EnemyType.Idle, new Enemy_Idle());
        stateDie.Add(EnemyType.Attack, new Enemy_Attack());
        stateDie.Add(EnemyType.Die, new Enemy_Die());
        stateDie.Add(EnemyType.Hurt, new Enemy_Hurt());

        //����״̬��
        machine = new StateMachine<Enemy>(this);

        //����Ĭ��״̬
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
        machine.OnUpdate();//ʱ�̸���״̬
    }

    public void Move()//�ƶ�
    {
        Vector3 movePos = body.position + Vector2.left* MoveDirection* Mathf.Sign(transform.localScale.x) * MoveSpeed * Time.deltaTime;
        body.MovePosition(movePos);
    }

    /// <summary>
    /// ����ת��
    /// </summary>
    public void Flip()
    {
        MoveDirection *= -1;//�����ƶ�
    }

    private void initEnemy()
    {
        currentHealth = health;
        MoveDirection = -1;//��ʼ����
    }

    public void ChangeHealth(float num)
    {
        ChangeState(EnemyType.Hurt);
        currentHealth -= num;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            ChangeState(EnemyType.Die);
            capsuleCollider2D.enabled = false;//���ӹ��ܣ���������ݸ���
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//状态枚举,枚举变量可以在同一命名空间下全局访问。c#中没有显示定义命名空间，就是在一个命名空间下。
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
    //组件
    public Animator ani;
    public Rigidbody2D body;
    private CapsuleCollider2D capsuleCollider2D;

    [Header("属性")]
    public float MoveSpeed = 10;
    public float health;
    public float currentHealth;
    public Slider healthSlider;
    public bool isRebound;//弹反

    //其他
    private int MoveDirection;//移动方向
    public StateMachine<Enemy> machine;//状态机
    public Dictionary<EnemyType, _State<Enemy>> stateDie;//存储状态字典

    private void Start()
    {
        initEnemy();
        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        //创建字典
        stateDie = new Dictionary<EnemyType, _State<Enemy>>();
        stateDie.Add(EnemyType.Move, new Enemy_Move());
        stateDie.Add(EnemyType.Idle, new Enemy_Idle());
        stateDie.Add(EnemyType.Attack, new Enemy_Attack());
        stateDie.Add(EnemyType.Die, new Enemy_Die());
        stateDie.Add(EnemyType.Hurt, new Enemy_Hurt());

        //创建状态机
        machine = new StateMachine<Enemy>(this);

        //设置默认状态
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
        machine.OnUpdate();//时刻更新状态
    }

    public void Move()//移动
    {
        Vector3 movePos = body.position + Vector2.left* MoveDirection* Mathf.Sign(transform.localScale.x) * MoveSpeed * Time.deltaTime;
        body.MovePosition(movePos);
    }

    /// <summary>
    /// 人物转向
    /// </summary>
    public void Flip()
    {
        MoveDirection *= -1;//向右移动
    }

    private void initEnemy()
    {
        currentHealth = health;
        MoveDirection = -1;//初始方向
    }

    public void ChangeHealth(float num)
    {
        ChangeState(EnemyType.Hurt);
        currentHealth -= num;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            ChangeState(EnemyType.Die);
            capsuleCollider2D.enabled = false;//增加功能，死后的数据更新
        }
    }
}

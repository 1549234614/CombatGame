using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : _State<Enemy>
{
    float moveTime;//移动的时间

    public override void Enter(Enemy target)
    {
        target.ani.Play("walk");
        moveTime = Random.Range(0.5f, 1f);

        if (Random.Range(0, 1) == 0)
        {
            target.Flip();
        }
    }

    public override void Execute(Enemy target)
    {
        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            target.ChangeState(EnemyType.Attack);
        }
        target.Move();
    }

    public override void Exit(Enemy target)
    {
        
    }
}

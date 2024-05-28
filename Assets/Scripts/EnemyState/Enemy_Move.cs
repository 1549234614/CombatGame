using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : _State<Enemy>
{

    float moveTime;

    public override void Enter(Enemy target)
    {
        target.animator.Play("walk");
        moveTime = Random.Range(2.1f, 2.6f);


        if(Random.Range(0,2) == 0)
        {
            target.Flip();
        }
    }

    public override void Execute(Enemy target)
    {
        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            target.ChangeState(Enemy.EnemyType.Idle);
        }

        target.Move();
    }

    public override void Exit(Enemy target)
    {
        
    }
}

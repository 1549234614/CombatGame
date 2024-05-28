using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : _State<Enemy>
{
    float idleTime;

    public override void Enter(Enemy target)
    {
        target.animator.Play("idle");
        idleTime = Random.Range(1.2f, 2.1f);
    }

    public override void Execute(Enemy target)
    {
        idleTime -= Time.deltaTime;
        if(idleTime <= 0)
        {
            target.ChangeState(Enemy.EnemyType.Move);
        }
    }

    public override void Exit(Enemy target)
    {
      
    }
}

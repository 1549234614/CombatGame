using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hurt : _State<Enemy>
{
    float hurtTime;

    public override void Enter(Enemy target)
    {
        target.ani.Play("hurt");
        hurtTime = 0.5f;
    }

    public override void Execute(Enemy target)
    {
        hurtTime -= Time.deltaTime;
        if (hurtTime <= 0)
        {
            target.ChangeState(EnemyType.Idle);
        }
    }

    public override void Exit(Enemy target)
    {
       
    }
}

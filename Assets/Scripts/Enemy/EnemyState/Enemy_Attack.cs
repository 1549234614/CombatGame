using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : _State<Enemy>
{
    float attackTime;//�����¼����

    public override void Enter(Enemy target)
    {
        target.ani.Play("attack");
        attackTime = 0.7f;
    }

    public override void Execute(Enemy target)
    {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0)
        {
            target.ChangeState(EnemyType.Idle);
        }
    }

    public override void Exit(Enemy target)
    {
        
    }
}

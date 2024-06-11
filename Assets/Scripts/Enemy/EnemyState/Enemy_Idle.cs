using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : _State<Enemy>
{
    //待机时间
    float idleTime;

    public override void Enter(Enemy target)
    {
        target.ani.Play("idle");
        idleTime = Random.Range(0.3f, 1f);//待机时长随机
    }

    public override void Execute(Enemy target)
    {
        idleTime -= Time.deltaTime;
        if(idleTime <= 0)
        {
            target.ChangeState(EnemyType.Move);
        }
    }

    public override void Exit(Enemy target)
    {
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Die : _State<Enemy>
{

    public override void Enter(Enemy target)
    {
        target.ani.Play("die");
    }

    public override void Execute(Enemy target)
    {
        
    }

    public override void Exit(Enemy target)
    {
        
    }
}

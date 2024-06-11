using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态机 管理状态
public class StateMachine<T>
{
    private T target;//状态的拥有者
    private _State<T> preState;//上一个状态
    public _State<T> currentState;//当前状态

    public StateMachine(T target)
    {
        this.target = target;
        preState = null;
        currentState = null;
    }

    //设置默认状态
    public void SetCurrent(_State<T> current)
    {
        this.currentState = current;
        //进入状态
        this.currentState.Enter(target);
    }

    //改变状态
    public void ChangeState(_State<T> current)
    {
        //退出当前状态
        this.currentState.Exit(target);
        //将当前状态记录
        this.preState = this.currentState;
        //设置新的状态
        this.currentState = current;
        //进入
        this.currentState.Enter(target);
    }
    
    //更新
    public void OnUpdate()
    {
        if(this.currentState != null)
        {
            this.currentState.Execute(target);
        }
    }
}

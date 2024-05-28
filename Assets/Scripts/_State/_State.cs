using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态基类 不要继承mono
/// </summary>
public abstract class _State<T>
{
    //进入状态
    public abstract void Enter(T target);
    //持续
    public abstract void Execute(T target);
    //离开状态
    public abstract void Exit(T target);

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ״̬���� ��Ҫ�̳�mono
/// </summary>
public abstract class _State<T>
{
    //����״̬
    public abstract void Enter(T target);
    //����
    public abstract void Execute(T target);
    //�뿪״̬
    public abstract void Exit(T target);

}

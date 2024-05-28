using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EventPoint : UnityEvent { }
public class AnimationEvent : MonoBehaviour
{
    Animator anim;
    public AnimatorEventID[] animatorEventIDs;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void AnimationEventIDIndex(int Index)
    {
        animatorEventIDs[Index].countPlay++;
        if (animatorEventIDs[Index].countPlay >= animatorEventIDs[Index].m_CountRun)
            animatorEventIDs[Index].Event?.Invoke();
        //Debug.LogWarning(transform.gameObject.name);
    }


    public void AnimatorSpeed(float speed)
    {
        anim.speed = speed;
    }


}

[System.Serializable]
public struct AnimatorEventID
{
    [Tooltip("�����¼��ӿ�")]
    public EventPoint Event;
    [Tooltip("�������ż���֮��ִ�ж����¼��ӿ��е��¼�")]
    public int m_CountRun;
    [HideInInspector]
    [Tooltip("�����¼�������")]
    public int countPlay;
}
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
    [Tooltip("动画事件接口")]
    public EventPoint Event;
    [Tooltip("动画播放几次之后执行动画事件接口中的事件")]
    public int m_CountRun;
    [HideInInspector]
    [Tooltip("动画事件计数器")]
    public int countPlay;
}
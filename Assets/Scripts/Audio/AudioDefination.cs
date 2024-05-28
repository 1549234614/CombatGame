using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO playerAudioEventSO;

    public AudioClip audioClip;

    public bool playOnEnable;

    private void OnEnable()
    {
        if (playOnEnable)//控制是否物体激活就发出声音，如果在面板勾选playOnEnable就直接调用PlayAudioClip()方法:
        {
            PlayAudioClip();
        }
    }

    public void PlayAudioClip()
    {
        playerAudioEventSO.RaiseEvent(audioClip);
    }
}

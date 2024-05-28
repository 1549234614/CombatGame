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
        if (playOnEnable)//�����Ƿ����弤��ͷ����������������年ѡplayOnEnable��ֱ�ӵ���PlayAudioClip()����:
        {
            PlayAudioClip();
        }
    }

    public void PlayAudioClip()
    {
        playerAudioEventSO.RaiseEvent(audioClip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;

    public static BKMusic Instance => instance;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;

        audioSource = this.GetComponent<AudioSource>();
        // 每次打开游戏并唤醒脚本时，都调用一次方法，来改变已存储的音量数据
        SwitchOpenOrCloseBKMusic(GameDataMgr.Instance.musicData.isOpenMusic);
        ChangeVolume(GameDataMgr.Instance.musicData.musicValue);
    }

    public void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }

    public void SwitchOpenOrCloseBKMusic(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音乐数据类，用于存储音乐设置相关的信息
/// </summary>
public class MusicData
{
    // 背景音乐是否开启
    public bool isOpenMusic;
    // 音效是否开启
    public bool isOpenSound;
    // 背景音乐音量大小
    public float musicValue;
    // 音效音量大小
    public float soundValue;

    // 第一次加载游戏的设置默认值标识
    public bool isNotFirst;
}

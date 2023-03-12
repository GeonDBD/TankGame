using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    public RankList rankData;

    // 初始化
    private GameDataMgr()
    {
        // 音乐数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        // 判断是否是第一次加载游戏，如果是则设置并存储一次默认值
        if (!musicData.isNotFirst)
        {
            musicData.isNotFirst = true;
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }

        // 排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }

    // 提供一些API，用于外部调用数据的存储方法
    // 音乐与音效
    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        // 控制开关
        BKMusic.Instance.SwitchOpenOrCloseBKMusic(isOpen);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        // 改变音量大小
        BKMusic.Instance.ChangeVolume(value);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    // 排行榜
    public void AddRankInfo(string name, int score, float time)
    {
        // 往data添加数据
        rankData.list.Add(new RankInfo(name, score, time));
        // 排序
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        // 移除多余数据
        for (int i = rankData.list.Count - 1; i >= 8; i--)
        {
            rankData.list.RemoveAt(i);
        }
        // 存储数据
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }
}

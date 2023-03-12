using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    public RankList rankData;

    // ��ʼ��
    private GameDataMgr()
    {
        // ��������
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        // �ж��Ƿ��ǵ�һ�μ�����Ϸ������������ò��洢һ��Ĭ��ֵ
        if (!musicData.isNotFirst)
        {
            musicData.isNotFirst = true;
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }

        // ���а�����
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }

    // �ṩһЩAPI�������ⲿ�������ݵĴ洢����
    // ��������Ч
    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        // ���ƿ���
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
        // �ı�������С
        BKMusic.Instance.ChangeVolume(value);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    // ���а�
    public void AddRankInfo(string name, int score, float time)
    {
        // ��data�������
        rankData.list.Add(new RankInfo(name, score, time));
        // ����
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        // �Ƴ���������
        for (int i = rankData.list.Count - 1; i >= 8; i--)
        {
            rankData.list.RemoveAt(i);
        }
        // �洢����
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }
}

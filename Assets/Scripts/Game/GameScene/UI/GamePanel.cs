using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Timeline;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel labScore;
    public CustomGUILabel labTime;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUITexture texHP;

    // 记录当前分数
    [HideInInspector]
    public int nowScore = 0;
    // 记录当前时间
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // 血量
    public float hpw = 300;

    // Start is called before the first frame update
    void Start()
    {
        // 监听面板控件
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            // 改变时间缩放值，时停。但是要记得在隐藏面板是要把timeScale重新设为1
            Time.timeScale = 0;
        };

        btnQuit.clickEvent += () =>
        {
            QuitPanel.Instance.ShowPanel();
            Time.timeScale = 0;
        };
    }

    // Update is called once per frame
    void Update()
    {
        // 用帧间隔时间累加，会比较准确
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";
    }

    public void AddScore(int score)
    {
        nowScore += score;
        labScore.content.text = nowScore.ToString();
    }

    public void UpdateHP(int maxHP, int hp)
    {
        texHP.guiPos.width = (float)hp / maxHP * hpw;
    }
}

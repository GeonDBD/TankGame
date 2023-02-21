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

    // ��¼��ǰ����
    [HideInInspector]
    public int nowScore = 0;
    // ��¼��ǰʱ��
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // Ѫ��
    public float hpw = 300;

    // Start is called before the first frame update
    void Start()
    {
        // �������ؼ�
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            // �ı�ʱ������ֵ��ʱͣ������Ҫ�ǵ������������Ҫ��timeScale������Ϊ1
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
        // ��֡���ʱ���ۼӣ���Ƚ�׼ȷ
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "ʱ";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "��";
        }
        labTime.content.text += time % 60 + "��";
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

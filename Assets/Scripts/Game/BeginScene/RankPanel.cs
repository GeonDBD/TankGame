using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    private List<CustomGUILabel> labRank = new List<CustomGUILabel>();
    private List<CustomGUILabel> labPlayerName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            // ͨ��"������/�Ӷ���"����ȥ�ҵ��Ӷ�����Ӷ���
            labPlayerName.Add(this.transform.Find("PlayerName/labPlayerName" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("Score/labScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("Time/labTime" + i).GetComponent<CustomGUILabel>());
        }

        // �����¼������߼�
        btnClose.clickEvent += () =>
        {
            HidePanel();
            BeginPanel.Instance.ShowPanel();
        };

        HidePanel();
    }

    // ������������߼�
    public void UpdatePanelInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            labPlayerName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();
            int time = (int)list[i].time;
            labTime[i].content.text = ""; // Ҫ���һ�Σ���Ȼ�ַ���Խ��Խ��
            if (time / 3600 > 0)
            {
                labTime[i].content.text += time / 3600 + "h";
            }
            if (time % 3600 / 60 > 0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += time % 3600 / 60 + "m";
            }
            labTime[i].content.text += time % 60 + "s";
        }
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdatePanelInfo();
    }
}

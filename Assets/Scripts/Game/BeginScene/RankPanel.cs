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
            // 通过"父对象/子对象"索引去找到子对象的子对象
            labPlayerName.Add(this.transform.Find("PlayerName/labPlayerName" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("Score/labScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("Time/labTime" + i).GetComponent<CustomGUILabel>());
        }

        // 处理事件监听逻辑
        btnClose.clickEvent += () =>
        {
            HidePanel();
            BeginPanel.Instance.ShowPanel();
        };

        HidePanel();
    }

    // 处理更新数据逻辑
    public void UpdatePanelInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            labPlayerName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();
            int time = (int)list[i].time;
            labTime[i].content.text = ""; // 要清空一次，不然字符串越加越长
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

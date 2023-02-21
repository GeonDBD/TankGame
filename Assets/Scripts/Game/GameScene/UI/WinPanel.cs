using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnConfirm;

    // Start is called before the first frame update
    void Start()
    {
        btnConfirm.clickEvent += () =>
        {
            Time.timeScale = 1;

            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
        };

        HidePanel();
    }
}

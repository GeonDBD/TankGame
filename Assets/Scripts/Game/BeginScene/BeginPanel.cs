using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化鼠标
        Cursor.lockState = CursorLockMode.Confined;

        // 监听按钮，监听一次点击
        btnBegin.clickEvent += () =>
        {
            // 切换场景
            SceneManager.LoadScene("GameScene");
        };

        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            HidePanel();
        };

        btnQuit.clickEvent += () =>
        {
            // 退出游戏
            Application.Quit();
        };

        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowPanel();
            HidePanel();
        };
    }
}

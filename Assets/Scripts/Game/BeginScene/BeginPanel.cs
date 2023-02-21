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
        // ��ʼ�����
        Cursor.lockState = CursorLockMode.Confined;

        // ������ť������һ�ε��
        btnBegin.clickEvent += () =>
        {
            // �л�����
            SceneManager.LoadScene("GameScene");
        };

        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            HidePanel();
        };

        btnQuit.clickEvent += () =>
        {
            // �˳���Ϸ
            Application.Quit();
        };

        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowPanel();
            HidePanel();
        };
    }
}

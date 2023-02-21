using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    // 声明并关联控件
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        // 监听事件
        // 1.改变音乐
        sliderMusic.changeValue += (value) =>
        {
            GameDataMgr.Instance.ChangeMusicValue(value);
        };

        // 2.改变音效
        sliderSound.changeValue += (value) =>
        {
            GameDataMgr.Instance.ChangeSoundValue(value);
        };

        // 3.开关音乐
        togMusic.changeValue += (value) =>
        {
            GameDataMgr.Instance.OpenOrCloseMusic(value);
        };

        // 4.开关音效
        togSound.changeValue += (value) =>
        {
            GameDataMgr.Instance.OpenOrCloseSound(value);
        };

        // 5.关闭面板
        btnClose.clickEvent += () =>
        {
            HidePanel();
            // 通过SceneManager.GetActiveScene().name获取场景名
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowPanel();
            }
        };

        // 游戏开始运行，初始化一次上面事件，就隐藏面板
        HidePanel();
    }

    // 更新面板
    public void UpdatePanelInfo()
    {
        // 获取GameDataMgr的音乐数据并存储
        MusicData data = GameDataMgr.Instance.musicData;

        // 设置面板数据
        sliderMusic.nowValue = data.musicValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenMusic;
        togSound.isSel = data.isOpenSound;
    }

    // 重写显示方法
    public override void ShowPanel()
    {
        base.ShowPanel();
        // 每次显示面板时，都调用一次更新数据
        UpdatePanelInfo();
    }
    public override void HidePanel()
    {
        base.HidePanel();
        Time.timeScale = 1f;
    }
}

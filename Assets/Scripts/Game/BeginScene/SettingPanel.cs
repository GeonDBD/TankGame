using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    // �����������ؼ�
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        // �����¼�
        // 1.�ı�����
        sliderMusic.changeValue += (value) =>
        {
            GameDataMgr.Instance.ChangeMusicValue(value);
        };

        // 2.�ı���Ч
        sliderSound.changeValue += (value) =>
        {
            GameDataMgr.Instance.ChangeSoundValue(value);
        };

        // 3.��������
        togMusic.changeValue += (value) =>
        {
            GameDataMgr.Instance.OpenOrCloseMusic(value);
        };

        // 4.������Ч
        togSound.changeValue += (value) =>
        {
            GameDataMgr.Instance.OpenOrCloseSound(value);
        };

        // 5.�ر����
        btnClose.clickEvent += () =>
        {
            HidePanel();
            // ͨ��SceneManager.GetActiveScene().name��ȡ������
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowPanel();
            }
        };

        // ��Ϸ��ʼ���У���ʼ��һ�������¼������������
        HidePanel();
    }

    // �������
    public void UpdatePanelInfo()
    {
        // ��ȡGameDataMgr���������ݲ��洢
        MusicData data = GameDataMgr.Instance.musicData;

        // �����������
        sliderMusic.nowValue = data.musicValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenMusic;
        togSound.isSel = data.isOpenSound;
    }

    // ��д��ʾ����
    public override void ShowPanel()
    {
        base.ShowPanel();
        // ÿ����ʾ���ʱ��������һ�θ�������
        UpdatePanelInfo();
    }
    public override void HidePanel()
    {
        base.HidePanel();
        Time.timeScale = 1f;
    }
}

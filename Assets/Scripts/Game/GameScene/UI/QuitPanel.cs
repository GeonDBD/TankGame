using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnCloss;
    public CustomGUIButton btnConfirm;
    public CustomGUIButton btnCancel;

    // Start is called before the first frame update
    void Start()
    {
        btnConfirm.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };
        btnCancel.clickEvent += () =>
        {
            HidePanel();
        };
        btnCloss.clickEvent += () =>
        { 
            HidePanel();
        };

        HidePanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        Time.timeScale = 1.0f;
    }
}

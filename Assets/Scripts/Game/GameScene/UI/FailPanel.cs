using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : BasePanel<FailPanel>
{
    public CustomGUIButton btnBack;
    public CustomGUIButton btnGoOn;

    // Start is called before the first frame update
    void Start()
    {
        btnBack.clickEvent += () =>
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("BeginScene");
        };

        btnGoOn.clickEvent += () =>
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("GameScene");
        };
        HidePanel();
    }
}

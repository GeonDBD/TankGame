using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 场景切换
        // 需要把场景加载到场景列表
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Test2");
        }

        // 退出游戏
        // 游戏打包发布后起效
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}

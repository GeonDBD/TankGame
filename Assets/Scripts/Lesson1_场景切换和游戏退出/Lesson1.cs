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
        // �����л�
        // ��Ҫ�ѳ������ص������б�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Test2");
        }

        // �˳���Ϸ
        // ��Ϸ�����������Ч
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}

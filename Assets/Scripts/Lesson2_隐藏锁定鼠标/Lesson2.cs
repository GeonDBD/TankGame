using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    public Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        // 1.�������
        //Cursor.visible = false;

        // 2.�������
        // None ������
        // Locked ��������Ļ���ĵ㣬������
        // Confined ��������Ļ������
        Cursor.lockState = CursorLockMode.Confined;

        // 3.�������ͼƬ
        // Cursor.SetCursor(ͼƬ, ͼƬ���Ͻ�ƫ��λ��, ���ģʽ)
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

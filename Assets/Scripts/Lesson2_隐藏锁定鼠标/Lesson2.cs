using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    public Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        // 1.隐藏鼠标
        //Cursor.visible = false;

        // 2.锁定鼠标
        // None 不锁定
        // Locked 锁定在屏幕中心点，并隐藏
        // Confined 锁定在屏幕窗口内
        Cursor.lockState = CursorLockMode.Confined;

        // 3.设置鼠标图片
        // Cursor.SetCursor(图片, 图片左上角偏移位置, 光标模式)
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

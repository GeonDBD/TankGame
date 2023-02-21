using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板基类
/// </summary>
/// <typeparam name="T">添加约束为class，保证传进来的T是class类，防止单例无法实例化</typeparam>
public class BasePanel<T> : MonoBehaviour where T:class
{
    // 这里不用私有化无参构造，是因为继承了 Mono本来就不允许 new出来
    // 只能通过 AddComponent挂载到 GameObject对象上
    private static T instance;
    
    public static T Instance => instance;

    private void Awake()
    {
        // 在Awake中进行单例实例化
        // 因为面板脚本在场景上，肯定只挂载一次
        instance = this as T;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 写虚函数，方便外部访问和子类重写
    public virtual void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
}

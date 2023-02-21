using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
/// <typeparam name="T">���Լ��Ϊclass����֤��������T��class�࣬��ֹ�����޷�ʵ����</typeparam>
public class BasePanel<T> : MonoBehaviour where T:class
{
    // ���ﲻ��˽�л��޲ι��죬����Ϊ�̳��� Mono�����Ͳ����� new����
    // ֻ��ͨ�� AddComponent���ص� GameObject������
    private static T instance;
    
    public static T Instance => instance;

    private void Awake()
    {
        // ��Awake�н��е���ʵ����
        // ��Ϊ���ű��ڳ����ϣ��϶�ֻ����һ��
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

    // д�麯���������ⲿ���ʺ�������д
    public virtual void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
}

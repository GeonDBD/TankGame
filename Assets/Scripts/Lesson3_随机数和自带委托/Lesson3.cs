using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1.�����
        // Unity�е�
        int randomNum = Random.Range(0, 100); // ��������Ҳ�����
        print(randomNum);
        float randomF = Random.Range(1.0f, 100.0f); // ���Ҷ�����
        print(randomF);
        // C#�е�
        System.Random r = new System.Random();
        r.Next(0, 100);

        // 2.ί��
        // C#�е�
        System.Action ac = () =>
        {
            print("ac");
        };

        System.Action<int> ac2 = (i) =>
        {
            print(i);
        };

        System.Func<int> func1 = () =>
        {
            return 1;
        };

        System.Func<int, string> func2 = (i) =>
        {
            return i.ToString();
        };

        // Unity�Դ�ί��
        UnityAction unityAction1 = () =>
        {

        };

        UnityAction<int> unityAction2 = (i) =>
        {

        };

        UnityAction<int, int> unityAction3 = (i, j) =>
        {
            
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

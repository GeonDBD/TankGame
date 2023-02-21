using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1.随机数
        // Unity中的
        int randomNum = Random.Range(0, 100); // 左包含，右不包含
        print(randomNum);
        float randomF = Random.Range(1.0f, 100.0f); // 左右都包含
        print(randomF);
        // C#中的
        System.Random r = new System.Random();
        r.Next(0, 100);

        // 2.委托
        // C#中的
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

        // Unity自带委托
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

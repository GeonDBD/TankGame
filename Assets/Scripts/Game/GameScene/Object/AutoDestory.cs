using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    public float time = 2;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }
}

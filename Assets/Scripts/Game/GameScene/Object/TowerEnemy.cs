using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : TankBaseObj
{
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    public Transform[] shootPos;
    public GameObject bulletObj;

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime >= fireOffsetTime)
        {
            Fire();
            nowTime = 0;
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            // ����ӵ����
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetTank(this);
        }
    }
    public override void Wound(TankBaseObj other)
    {
        // ����֮ǰ�ķ����壬������̨���������
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    // 子弹对象
    public GameObject bullet;
    // 发射位置
    public Transform[] shootPos;
    // 武器拥有者
    public TankBaseObj tankObj;

    // 设置武器拥有者
    public void SetTank(TankBaseObj obj)
    {
        tankObj = obj;
    }
    // 开火
    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetTank(tankObj);
        }
    }
}

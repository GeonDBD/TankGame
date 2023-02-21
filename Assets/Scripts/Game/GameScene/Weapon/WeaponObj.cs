using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    // �ӵ�����
    public GameObject bullet;
    // ����λ��
    public Transform[] shootPos;
    // ����ӵ����
    public TankBaseObj tankObj;

    // ��������ӵ����
    public void SetTank(TankBaseObj obj)
    {
        tankObj = obj;
    }
    // ����
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

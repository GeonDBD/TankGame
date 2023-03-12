using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    // ��ǰ����
    public WeaponObj nowWeapon;
    // �������ص�
    public Transform weaponPoint;

    void Update()
    {
        // λ�ƿ���
        transform.Translate(Input.GetAxisRaw("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);

        // ��ת����
        transform.Rotate(Input.GetAxisRaw("Horizontal") * Vector3.up * rotateSpeed * Time.deltaTime);

        // ��̨��ת����
        tankHead.transform.Rotate(Input.GetAxisRaw("Mouse X") * Vector3.up * headRotateSpeed * Time.deltaTime);

        // ����
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }

    public override void Dead()
    {
        // ���Ƴ����̹�ˣ���ֹ����������Ƴ�
        // ����������ʧ�����
        FailPanel.Instance.ShowPanel();
        Time.timeScale = 0;
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        // ������Ϸ����ϵ�Ѫ�������ξ������Ѫ���͵�ǰ���˺��Ѫ��ֵ
        GamePanel.Instance.UpdateHP(maxHP, hp);
    }

    // �ı�����
    public void ChangeWeapon(GameObject obj)
    {
        // ����������
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        // �л�����
        GameObject weaponObj = Instantiate(obj, weaponPoint, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();

        // ��������ӵ����
        nowWeapon.SetTank(this);
    }
}

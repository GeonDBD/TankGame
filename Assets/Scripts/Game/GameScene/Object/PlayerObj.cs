using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    // 当前武器
    public WeaponObj nowWeapon;
    // 武器挂载点
    public Transform weaponPoint;

    void Update()
    {
        // 位移控制
        transform.Translate(Input.GetAxisRaw("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);

        // 旋转控制
        transform.Rotate(Input.GetAxisRaw("Horizontal") * Vector3.up * rotateSpeed * Time.deltaTime);

        // 炮台旋转控制
        tankHead.transform.Rotate(Input.GetAxisRaw("Mouse X") * Vector3.up * headRotateSpeed * Time.deltaTime);

        // 开火
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
        // 不移除玩家坦克，防止主摄像机被移除
        // 死亡即弹出失败面板
        FailPanel.Instance.ShowPanel();
        Time.timeScale = 0;
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        // 更新游戏面板上的血条，传参就是最大血量和当前受伤后的血量值
        GamePanel.Instance.UpdateHP(maxHP, hp);
    }

    // 改变武器
    public void ChangeWeapon(GameObject obj)
    {
        // 丢弃旧武器
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        // 切换武器
        GameObject weaponObj = Instantiate(obj, weaponPoint, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();

        // 设置武器拥有者
        nowWeapon.SetTank(this);
    }
}

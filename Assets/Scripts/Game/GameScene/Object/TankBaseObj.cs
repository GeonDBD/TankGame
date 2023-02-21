using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    // 基础属性
    public int atk;
    public int def;
    public int maxHP;
    public int hp;

    // 速度
    public float moveSpeed = 10;
    public float rotateSpeed = 100;
    public float headRotateSpeed = 100;

    // 炮台（坦克顶部）
    public Transform tankHead;

    // 特效
    public GameObject deadEff;

    public abstract void Fire();
    public virtual void Wound(TankBaseObj other)
    {
        int dmg = other.atk - def;
        if (dmg <= 0)
        {
            return;
        }
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }
    public virtual void Dead()
    {
        if (deadEff != null )
        {
            // 实例化创建GameObject
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            // 特效的音效控制
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        }
        Destroy(gameObject);
    }
}

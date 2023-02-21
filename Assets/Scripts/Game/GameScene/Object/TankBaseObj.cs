using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    // ��������
    public int atk;
    public int def;
    public int maxHP;
    public int hp;

    // �ٶ�
    public float moveSpeed = 10;
    public float rotateSpeed = 100;
    public float headRotateSpeed = 100;

    // ��̨��̹�˶�����
    public Transform tankHead;

    // ��Ч
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
            // ʵ��������GameObject
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            // ��Ч����Ч����
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        }
        Destroy(gameObject);
    }
}

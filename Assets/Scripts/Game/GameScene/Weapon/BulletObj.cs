using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed;
    // �ӵ�������
    public TankBaseObj tankObj;
    // �ӵ���ը��Ч
    public GameObject bulletEffObj;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // ��������
    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            return;
        }
        if (other.CompareTag("Cube") ||
            other.CompareTag("Ground") ||
            other.CompareTag("Wall") ||
            tankObj.CompareTag("Player") && other.CompareTag("Enemy") ||
            tankObj.CompareTag("Enemy") && other.CompareTag("Player"))
        {
            // �˺��ж�
            TankBaseObj tank = other.GetComponent<TankBaseObj>();
            if (tank != null)
            {
                tank.Wound(tankObj);
            }

            // ������Ч
            if (bulletEffObj != null)
            {
                GameObject effObj = Instantiate(bulletEffObj, transform.position, transform.rotation);
                // �ı���Ч����Ч
                AudioSource audioSource = effObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }
            Destroy(gameObject);
        }
    }

    // ���÷�����
    public void SetTank(TankBaseObj obj)
    {
        tankObj = obj;
    }
}

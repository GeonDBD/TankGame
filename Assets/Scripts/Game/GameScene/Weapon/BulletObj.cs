using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed;
    // 子弹发射者
    public TankBaseObj tankObj;
    // 子弹爆炸特效
    public GameObject bulletEffObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // 触发处理
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || 
            other.CompareTag("Ground") ||
            other.CompareTag("Wall") || 
            tankObj.CompareTag("Player") && other.CompareTag("Enemy") ||
            tankObj.CompareTag("Enemy") && other.CompareTag("Player"))
        {
            // 伤害判定
            TankBaseObj tank = other.GetComponent<TankBaseObj>();
            if (tank != null)
            {
                tank.Wound(tankObj);
            }

            // 播放特效
            if (bulletEffObj != null)
            {
                GameObject effObj = Instantiate(bulletEffObj, this.transform.position, transform.rotation);
                // 改变特效的音效
                AudioSource audioSource = effObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }
            Destroy(gameObject);
        }
    }

    // 设置发射者
    public void SetTank(TankBaseObj obj)
    {
        tankObj = obj;
    }
}

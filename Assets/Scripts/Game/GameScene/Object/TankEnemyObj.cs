using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyObj : TankBaseObj
{
    // 自动移动相关
    private Transform nowTargetPos;
    public Transform[] randomPos;

    // 攻击目标相关
    public Transform attackTarget;

    // 自动攻击
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    public GameObject bulletObj;
    public Transform[] shootPos;

    // 距离判定
    public float fireDis = 5;

    // 血条
    public Texture maxHpBg;
    public Texture hpBg;
    private Rect maxHpBgRect;
    private Rect hpBgRect;
    // 血条显示时间
    private float showHpTime;

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        // 位移
        transform.LookAt(nowTargetPos);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, nowTargetPos.position) < 0.05f)
        {
            RandomPos();
        }

        // 选择攻击目标
        if (attackTarget != null)
        {
            tankHead.LookAt(attackTarget);
            if (Vector3.Distance(transform.position, attackTarget.position) <= fireDis)
            {
                // 开火
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
    }

    private void RandomPos()
    {
        if (randomPos.Length == 0) return;
        nowTargetPos = randomPos[Random.Range(0, randomPos.Length)];
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            // 设置拥有者
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetTank(this);
        }
    }

    // 重写死亡加分奖励
    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }

    // 血条UI绘制
    private void OnGUI()
    {
        if (showHpTime > 0)
        {
            // 血条显示时间计时
            showHpTime -= Time.deltaTime;

            // 世界坐标转屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            // 屏幕坐标转GUI坐标
            screenPos.y = Screen.height - screenPos.y;

            // 绘制图片
            maxHpBgRect.x = screenPos.x - 50;
            maxHpBgRect.y = screenPos.y - 50;
            maxHpBgRect.width = 100;
            maxHpBgRect.height = 10;
            GUI.DrawTexture(maxHpBgRect, maxHpBg);
            hpBgRect.x = screenPos.x - 50;
            hpBgRect.y = screenPos.y - 50;
            hpBgRect.width = (float)hp / maxHP * 100f;
            hpBgRect.height = 10;
            GUI.DrawTexture(hpBgRect, hpBg);
        }
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showHpTime = 3;
    }
}

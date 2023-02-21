using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyObj : TankBaseObj
{
    // �Զ��ƶ����
    private Transform nowTargetPos;
    public Transform[] randomPos;

    // ����Ŀ�����
    public Transform attackTarget;

    // �Զ�����
    public float fireOffsetTime = 1;
    private float nowTime = 0;
    public GameObject bulletObj;
    public Transform[] shootPos;

    // �����ж�
    public float fireDis = 5;

    // Ѫ��
    public Texture maxHpBg;
    public Texture hpBg;
    private Rect maxHpBgRect;
    private Rect hpBgRect;
    // Ѫ����ʾʱ��
    private float showHpTime;

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        // λ��
        transform.LookAt(nowTargetPos);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, nowTargetPos.position) < 0.05f)
        {
            RandomPos();
        }

        // ѡ�񹥻�Ŀ��
        if (attackTarget != null)
        {
            tankHead.LookAt(attackTarget);
            if (Vector3.Distance(transform.position, attackTarget.position) <= fireDis)
            {
                // ����
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
            // ����ӵ����
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetTank(this);
        }
    }

    // ��д�����ӷֽ���
    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }

    // Ѫ��UI����
    private void OnGUI()
    {
        if (showHpTime > 0)
        {
            // Ѫ����ʾʱ���ʱ
            showHpTime -= Time.deltaTime;

            // ��������ת��Ļ����
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            // ��Ļ����תGUI����
            screenPos.y = Screen.height - screenPos.y;

            // ����ͼƬ
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

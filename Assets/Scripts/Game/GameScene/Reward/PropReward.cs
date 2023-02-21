using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ����ö��
public enum E_PropType
{
    Atk,
    Def,
    Hp,
    MaxHp
}

public class PropReward : MonoBehaviour
{
    public E_PropType type;
    public int changeValue = 2;

    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.Atk:
                    playerObj.atk += changeValue;
                    break;
                case E_PropType.Def:
                    playerObj.def += changeValue;
                    break;
                case E_PropType.Hp:
                    playerObj.hp += changeValue;
                    // ��ֹ����Ѫ����
                    if (playerObj.hp > playerObj.maxHP)
                    {
                        playerObj.hp = playerObj.maxHP;
                    }
                    GamePanel.Instance.UpdateHP(playerObj.maxHP, playerObj.hp);
                    break;
                case E_PropType.MaxHp:
                    playerObj.maxHP += changeValue;
                    GamePanel.Instance.UpdateHP(playerObj.maxHP, playerObj.hp);
                    break;
            }

            // ������Ч
            GameObject eff = Instantiate(effect, transform.position, transform.rotation);
            // �ı���Ч����Ч
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(gameObject);
        }
    }
}

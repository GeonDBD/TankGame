using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;
    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int index = Random.Range(0, weaponObj.Length);
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            playerObj.ChangeWeapon(weaponObj[index]);

            // 获取时播放特效
            GameObject eff = Instantiate(effect, transform.position, transform.rotation);
            // 改变音效
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(gameObject);
        }
    }
}

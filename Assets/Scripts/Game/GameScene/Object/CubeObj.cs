using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjs;
    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        // 破坏后掉落随机奖励
        int randomNum = Random.Range(0, 100);
        if (randomNum < 50)
        {
            randomNum = Random.Range(0, rewardObjs.Length);
            Instantiate(rewardObjs[randomNum], transform.position, transform.rotation);
        }

        // 播放特效
        GameObject effObj = Instantiate(effect, transform.position, transform.rotation);
        AudioSource audioSource = effObj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

        Destroy(gameObject);
    }
}

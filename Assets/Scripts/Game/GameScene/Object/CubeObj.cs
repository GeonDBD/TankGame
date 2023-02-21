using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjs;
    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        // �ƻ�������������
        int randomNum = Random.Range(0, 100);
        if (randomNum < 50)
        {
            randomNum = Random.Range(0, rewardObjs.Length);
            Instantiate(rewardObjs[randomNum], transform.position, transform.rotation);
        }

        // ������Ч
        GameObject effObj = Instantiate(effect, transform.position, transform.rotation);
        AudioSource audioSource = effObj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

        Destroy(gameObject);
    }
}

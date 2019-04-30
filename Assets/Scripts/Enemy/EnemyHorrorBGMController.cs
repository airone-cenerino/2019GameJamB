using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorrorBGMController : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private AudioSource horrorBGMAudioSource;
    [SerializeField] private AudioClip horrorBGM;

    private float horrorSoundStartDistance = 10f;   // 恐怖BGMが流れる距離
    private float horrorSoundMaxVolume = 0.2f;
    private float horrorSoundVolume = 0.2f;
    private bool IsInHorrorSoundArea = false;


    // Start is called before the first frame update
    void Start()
    {
        horrorBGMAudioSource.clip = horrorBGM;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HorrorBGMControl();
    }

    // 恐怖BGMの処理
    private void HorrorBGMControl()
    {
        if ((Vector3.Distance(player.transform.position, transform.position) < horrorSoundStartDistance))
        {
            if (!IsInHorrorSoundArea)   // 今まで外にいて、中に入った時
            {
                horrorSoundVolume = horrorSoundMaxVolume;
                horrorBGMAudioSource.volume = horrorSoundVolume;
                horrorBGMAudioSource.Play();
                IsInHorrorSoundArea = true;
            }
        }
        else
        {   // エリア中にいないとき
            IsInHorrorSoundArea = false;
            horrorSoundVolume -= Time.deltaTime / 2f;
            horrorBGMAudioSource.volume = horrorSoundVolume;
            if (horrorSoundVolume < 0)
            {
                horrorBGMAudioSource.Stop();
            }
        }
    }
}

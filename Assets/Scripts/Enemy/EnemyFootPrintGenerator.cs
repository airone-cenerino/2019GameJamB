using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 足跡, 足音関連

namespace Enemy
{
    public class EnemyFootPrintGenerator : MonoBehaviour
    {
        private AudioSource audioSource;
        private CapsuleCollider capsuleCollider;

        private float walkedDistance = 0.0f;    // 歩いた距離
        private float stepLength = 1f;          // 1歩の長さ
        private Vector3 lastPosition;           // 1フレーム前の場所
        private bool flg = false;               // 右か左かの確認


        [SerializeField] private List<AudioClip> audioClips;    // 足音
        [SerializeField] private GameObject rightFootPrint;
        [SerializeField] private GameObject leftFootPrint;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            lastPosition = transform.position;
        }

        private void Update()
        {
            FootPrintGenerate();
        }

        // 足跡生成の処理
        private void FootPrintGenerate()
        {
            // 動いた距離計算
            walkedDistance += Vector3.Distance(transform.position, lastPosition);

            if (walkedDistance > stepLength)    // 1歩の長さを超えたら
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count())]);   // 足音

                // 足跡の座標
                Vector3 instantiatePosition = new Vector3(transform.position.x, transform.position.y - capsuleCollider.height / 2f - 0.05f, transform.position.z);

                if (flg)
                {
                    GameObject footprint = Instantiate(rightFootPrint, instantiatePosition, transform.rotation);
                    footprint.transform.position += footprint.transform.right * 0.2f;
                    flg = false;
                }
                else
                {
                    GameObject footprint = Instantiate(leftFootPrint, instantiatePosition, transform.rotation);
                    footprint.transform.position += footprint.transform.right * -0.2f;
                    flg = true;
                }

                walkedDistance = 0.0f;  // 歩いた距離初期化
            }

            lastPosition = transform.position;
        }
    }
}
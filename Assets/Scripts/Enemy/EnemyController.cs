using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

// Enemyにアタッチするスクリプト

namespace Enemy
{
    enum EnemyCondition
    {
        Chase, Wait, Stop
    }

    public class EnemyController : MonoBehaviour
    {
        // Enemyにアタッチされているコンポーネント
        private AudioSource audioSource;
        private CapsuleCollider capsuleCollider;
        private GameObject player;
        private NavMeshAgent navMeshAgent;

        [SerializeField] private AudioSource horrorBGMAudioSource;
        [SerializeField] private GameObject rightFootPrint;
        [SerializeField] private GameObject leftFootPrint;
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private AudioClip horrorBGM;


        private float walkedDistance = 0.0f;    // 歩いた距離
        private float stepLength = 1f;          // 1歩の長さ
        private Vector3 lastPosition;           // 1フレーム前の場所
        private bool flg = false;               // 右か左かの確認
        private float horrorSoundStartDistance = 8f;   // 恐怖BGMが流れる距離
        private float horrorSoundMaxVolume = 0.2f;
        private float horrorSoundVolume = 0.2f;
        private bool IsInHorrorSoundArea = false;

        EnemyCondition state;                   // Enemyのステート

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player");

            horrorBGMAudioSource.clip = horrorBGM;
            state = EnemyCondition.Chase;
            lastPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
             // ステート管理
            if(state == EnemyCondition.Chase)
            {
                navMeshAgent.destination = player.transform.position;   // エージェントの目的地をPlayerの現在地に更新
                FootPrintGenerate();    // 足跡の処理
                HorrorBGMControl();     // 恐怖BGMの処理
            }
            else if(state == EnemyCondition.Stop)
            {
                navMeshAgent.destination = transform.position;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        public void EnemyStop()
        {
            state = EnemyCondition.Stop;
        }

        public void EnemyChaseStart()
        {
            state = EnemyCondition.Chase;
        }


        /*
         *以下Private
         */

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
}

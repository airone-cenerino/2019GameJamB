using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Item;

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
        private NavMeshAgent navMeshAgent;
        private GameObject player;

        private GameObject door;  // ぶつかった時に格納する
        private EnemyCondition state;       // Enemyのステート
        private bool IsPause = false;      // Enemyが一時停止中かどうか
        private float pauseRemainingTime = 0.0f;


        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player");
            state = EnemyCondition.Chase;
        }

        // Update is called once per frame
        void Update()
        {
             // ステート管理
            if(state == EnemyCondition.Chase)
            {
                navMeshAgent.destination = player.transform.position;   // エージェントの目的地をPlayerの現在地に更新
            }
            else if(state == EnemyCondition.Stop)
            {
                navMeshAgent.destination = transform.position;
            }

            // 障害物による一時停止中かどうか
            if (IsPause)
            {
                EnemyStop();
                pauseRemainingTime -= Time.deltaTime;

                if (pauseRemainingTime < 0f)
                {
                    
                    door.GetComponent<DoorController>().DoorClose();
                  
                    IsPause = false;
                    EnemyChaseStart();
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Door")
            {
                EnemyPause();   // Enemy一時停止
                door = other.transform.root.gameObject;
            }

            if (other.tag == "Player")
            {
                SceneManager.LoadScene("GameOver");
            }

            if (other.tag == "Books")
            {
                WalkSlowly();   // Enemy一時停止
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if(other.tag == "Books")
            {
                WalkNormally();
            }
        }

        public void EnemyForcedStop()
        {
            IsPause = false;
            EnemyStop();
        }

        public void EnemyForcedChaseStart()
        {
            if(pauseRemainingTime>0)
                IsPause = true;
            EnemyChaseStart();
        }


        /*
        *以下Private関数
        */
        private void EnemyChaseStart()
        {
            state = EnemyCondition.Chase;
        }

        private void EnemyStop()
        {
            state = EnemyCondition.Stop;
        }

        private void EnemyPause()
        {
            IsPause = true;
            pauseRemainingTime = 2.0f;
        }

        private void WalkSlowly()
        {
            navMeshAgent.speed /= 3.0f;
        }

        private void WalkNormally()
        {
            navMeshAgent.speed *= 3.0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
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
        private NavMeshAgent navMeshAgent;
        private GameObject player;

        private EnemyCondition state;       // Enemyのステート
        private bool IsPasuse = false;      // Enemyが一時停止中かどうか
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
            if (IsPasuse)
            {
                EnemyStop();
                pauseRemainingTime -= Time.deltaTime;

                if (pauseRemainingTime < 0f)
                {
                    IsPasuse = false;
                    EnemyChaseStart();
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Door")
            {
                EnemyPause();   // Enemy一時停止
            }

            if (other.tag == "Player")
            {
                SceneManager.LoadScene("GameOver");
            }


        }

        public void EnemyForcedStop()
        {
            IsPasuse = false;
            EnemyStop();
        }

        public void EnemyForcedChaseStart()
        {
            IsPasuse = true;
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
            IsPasuse = true;
            pauseRemainingTime = 2.0f;
        }
    }
}

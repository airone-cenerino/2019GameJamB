using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    enum EnemyCondition
    {
        Chase, Wait
    }

    public class EnemyController : MonoBehaviour
    {
        private GameObject player;
        private CharacterController characterController;
        private NavMeshAgent navMeshAgent;
        [SerializeField] private GameObject rightFootPrint;
        [SerializeField] private GameObject leftFootPrint;


        private double walkedDistance = 0.0f;   // 歩いた距離
        private double stepLength = 1f;
        private Vector3 lastPosition;
        private bool flg = false;

        EnemyCondition state;   // Enemyのステート

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            navMeshAgent = GetComponent<NavMeshAgent>();

            state = EnemyCondition.Chase;
            lastPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            // 動いた距離計算
            walkedDistance += Vector3.Distance(transform.position, lastPosition);
            if (walkedDistance > stepLength)
            {
                if (flg)
                {
                    Instantiate(rightFootPrint, transform.position, transform.rotation);
                    flg = false;
                }
                else
                {
                    Instantiate(leftFootPrint, transform.position, transform.rotation);
                    flg = true;
                }
                walkedDistance = 0.0f;
            }
            
            if(state == EnemyCondition.Chase)
            {
                navMeshAgent.destination = player.transform.position;   // エージェントの目的地をPlayerの現在地に更新
            }

            lastPosition = transform.position;
        }
    }
}

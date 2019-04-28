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
        private NavMeshAgent navMeshAgent;
        private CapsuleCollider capsuleCollider;
        [SerializeField] private GameObject rightFootPrint;
        [SerializeField] private GameObject leftFootPrint;


        private float walkedDistance = 0.0f;   // 歩いた距離
        private float stepLength = 1f;
        private Vector3 lastPosition;
        private bool flg = false;

        EnemyCondition state;   // Enemyのステート

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            navMeshAgent = GetComponent<NavMeshAgent>();
            capsuleCollider = GetComponent<CapsuleCollider>();

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

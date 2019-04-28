using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enemy;

namespace System
{
    public class GameQuitMenu : MonoBehaviour
    {
        private EnemyController enemyController;
        [SerializeField] private GameObject pausePanel;
        
        private void Start()
        {
            enemyController = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                enemyController.EnemyStop();
                pausePanel.SetActive(true);
                //カーソル表示on
            }
        }
    }
}

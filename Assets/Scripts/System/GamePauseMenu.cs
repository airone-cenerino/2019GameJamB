using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enemy;
using UnityEngine.SceneManagement;

namespace System
{
    public class GamePauseMenu : MonoBehaviour
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

        public void Resume()
        {
            enemyController.EnemyChaseStart();
            pausePanel.SetActive(false);
        }

        public void Quit()
        {
            SceneManager.LoadScene("Title");
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enemy;
using UnityEngine.SceneManagement;

using GameSystem;


// ゲーム中のポーズ画面管理

namespace GameSystem
{
    public class GamePauseMenu : MonoBehaviour
    {
        private EnemyController enemyController;
        [SerializeField] private GameObject pausePanel;
        
        private void Start()
        {
            enemyController = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                enemyController.EnemyForcedStop();
                pausePanel.SetActive(true);
                Cursor.visible = true;  //カーソル表示on
            }
        }


        // 以下ボタン用関数
        public void Resume()
        {
            enemyController.EnemyForcedChaseStart();
            pausePanel.SetActive(false);
            Cursor.visible = false;
        }

        public void Quit()
        {
            SceneManager.LoadScene("Title");
        }
    }
}

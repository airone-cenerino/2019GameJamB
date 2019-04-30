using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;

namespace GameSystem
{

    public class TextScroll : MonoBehaviour
    {
        public bool IsReadFinish = false;
        [SerializeField] private PlayerMover player;
        [SerializeField] private GameObject enemy;
        public GameObject text_object = null;
        public int text_number = 0;
        [SerializeField] private GameObject canvas;
        [SerializeField] private float PlayerSpeed = 500f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Text letter = text_object.GetComponent<Text>();

            switch (text_number)
            {
                case 0:
                    letter.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                    letter.text = "「こんばんは…\n" +
                                  "ずっと一人でここにいるのでひましてるんですが、\n" +
                                  "あまりにも血に飢えてしまって…";
                    break;
                case 1:
                    letter.text = "もしよかったら殺されてくれませんか？？\n" +
                                  "顔を見られるのは恥ずかしいので、\n" +
                                  "館内は消灯して…\n";
                    break;
                case 2:
                    letter.text = "もしOKでしたら、音を立てて場所を教えてください…\n" +
                                  "それでおとなしく立っていれば結構です…\n" +
                                  "すぐに楽になりますので…";
                    break;
                case 3:
                    letter.text = "私に貴方の血を、血を、血、血、血・・\n" +
                                  "・・・・・・・・血を：＠。＋＞＋＋＊\n" +
                                  "‘＞：・。；。＠」";
                    break;
                case 4:
                    letter.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                    letter.text = "危険な予感がする…\n" +
                                  "逃げないと";

                    break;
                case 5:
                    IsReadFinish = true;
                    letter.text = "ん？ブレーカーが落ちた?\n" +
                                  "ひとまずスマホのライトをつけよう";
                    break;
                default:
                    letter.text = "XXXXXX";
                    break;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (text_number < 6) text_number++;

                // 読み終わり
                if (text_number == 6)
                {
                    canvas.SetActive(false);
                    PlayerMover.moveSpeed = player.playerMoveSpeed;
                    enemy.SetActive(true);
                }
            }
        }
    }

}

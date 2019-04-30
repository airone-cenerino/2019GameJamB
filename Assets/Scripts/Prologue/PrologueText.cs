using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSystem;


namespace Prologue
{
    public class PrologueText : MonoBehaviour
    {
        public GameObject text_object = null;
        public int text_number = 0;
        public string[] text_line1 = new string[] { "(いつから寝ていたのだろう。",
                                                      "頭が痛い。",
                                                      "時間は・・・？",
                                                      "そろそろ帰らなくては。",
                                                      "・・・・・",
                                                      "・・・あれ？・・・スマホがない。",
                                                      "・・・・・",
                                                      "・・・・・・・あ、",
                                                      "トイレに忘れたんだ。",
                                                      "回収して帰ろう)"};

        public string[] text_line2 = new string[] { "(はっ、、、)",
                                                      "気が付くと元の部屋に戻っていた",
                                                      "(なんだ、夢か。",
                                                      "・・・恐ろしい夢だった。",
                                                      "とにかく帰ろう)",
                                                      "急いで荷物をまとめる。",
                                                      "(・・・・っえ、・・・)",
                                                      "またもやスマホがない。",
                                                      "(まさか、、、)",
                                                      "恐怖に怯えながらも、",
                                                      "再びあのトイレに向かうのであった。"};

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Text letter = text_object.GetComponent<Text>();

            if (LoopManager.loop == 1 && text_number <= 7)
                letter.text = text_line1[text_number] + "\n" + text_line1[text_number + 1] + "\n" + text_line1[text_number + 2];

            if (LoopManager.loop >= 2 && text_number <= 8)
                letter.text = text_line2[text_number] + "\n" + text_line2[text_number + 1] + "\n" + text_line2[text_number + 2];

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 15"))
            {
                if ((LoopManager.loop == 1 && text_number >= 7) || (LoopManager.loop >= 2 && text_number >= 8))
                    SceneManager.LoadScene("GameScene");

                if ((LoopManager.loop == 1 && text_number < 7) || (LoopManager.loop >= 2 && text_number < 8))
                    text_number++;

            }
        }
    }
}

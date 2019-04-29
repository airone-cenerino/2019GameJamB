using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace GameSystem
{

    public class TextScroll : MonoBehaviour
    {
        public GameObject text_object = null;
        public int text_number = 0;

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
                    letter.text = "こんばんは…\n" +
                                  "一人で来ているんですが、\n" +
                                  "少し寂しくなってきてしまって…";
                    break;
                case 1:
                    letter.text = "もしよかったらお会いできませんか？\n" +
                                  "姿を見られるのは恥ずかしいのでこっそり伺います";
                    break;
                case 2:
                    letter.text = "もしOKでしたら入り口近くにあるコピー機のサイドに\n" +
                                  "目隠しになるヘアバンドを置いておきます";
                    break;
                case 3:
                    letter.text = "それで目隠しをして、部屋を暗くして\n" +
                                  "ドアを少し開けて待っていてください";
                    break;
                default:
                    letter.text = "XXXXXX";
                    break;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (text_number <= 3) text_number++;
                //if (text_number == 3) SceenManager.LoadScene("");
            }
        }
    }

}

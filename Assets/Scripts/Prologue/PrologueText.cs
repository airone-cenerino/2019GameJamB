using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using GameSystem;

public class PrologueText : MonoBehaviour
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

        if (LoopManager.loop == 1)
        {
            switch (text_number)
            {
                case 0:
                    letter.text = "\n" +
                                  "";
                    break;
                case 1:
                    letter.text = "\n" +
                                  "";
                    break;
                case 2:
                    letter.text = "\n" +
                                  "";
                    break;
                case 3:
                    letter.text = "\n" +
                                  "";
                    break;
                case 4:
                    letter.text = "\n" +
                                  "";
                    break;
                default:
                    letter.text = "XXXXXX";
                    break;
            }
        }

        if (LoopManager.loop == 2)
        {
            switch (text_number)
            {
                case 0:
                    letter.text = "\n" +
                                  "";
                    break;
                case 1:
                    letter.text = "\n" +
                                  "";
                    break;
                case 2:
                    letter.text = "\n" +
                                  "";
                    break;
                case 3:
                    letter.text = "\n" +
                                  "";
                    break;
                case 4:
                    letter.text = "\n" +
                                  "";
                    break;
                default:
                    letter.text = "XXXXXX";
                    break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (text_number < 4) text_number++;
            //if (text_number == 3) SceenManager.LoadScene("");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Epilogue2 : MonoBehaviour
{
    public GameObject text_object = null;
    public int text_number = 0;
    public string[] text_line = new string[] { "(あれ・・・？)",
                                                      "スマホを持ち上げると、そこには一通の手紙が。",
                                                      "(なんだこれ・・・？)",
                                                      "手紙を開いてみると・・・",
                                                      "",
                                                      "",
                                                      "マ タ ア ソ ビ マ シ ョ"};

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text letter = text_object.GetComponent<Text>();

        letter.text = text_line[text_number] + "\n" + text_line[text_number + 1] + "\n" + text_line[text_number + 2];

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 15"))
        {
            if (text_number >= 4)
                SceneManager.LoadScene("title");

            if (text_number < 4)
                text_number++;

        }
    }
}

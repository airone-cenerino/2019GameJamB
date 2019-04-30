using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Epilogue : MonoBehaviour
{
    public GameObject text_object = null;
    public int text_number = 0;
    public string[] text_line = new string[] { "(はっ、、、)",
                                                      "目覚めるとそこはkskハウスだった。",
                                                      "(スマホは・・・)",
                                                      "確かに枕元にある。",
                                                      "よかった・・・。"};

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
            if (text_number >= 2)
                SceneManager.LoadScene("GameClear");

            if (text_number < 2)
                text_number++;

        }
    }
}

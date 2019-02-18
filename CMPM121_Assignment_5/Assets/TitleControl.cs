using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    public Button start;
    public Text text1;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        text1.enabled = false;
        text2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        start.onClick.AddListener(startScene);
        if (SimpleCharacterControl.youWon)
        {
            text1.enabled = true;
            text2.enabled = true;
        }
    }

    void startScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class updateScore : MonoBehaviour
{
    private TextMeshProUGUI textArea;
    private spawner game;
    // Start is called before the first frame update
    void Start()
    {
        textArea = GetComponent<TextMeshProUGUI>();
        game = GameObject.Find("GameController").GetComponent<spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        textArea.SetText("Score : {0}", game.getScore());
    }
}

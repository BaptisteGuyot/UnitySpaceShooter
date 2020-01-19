using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataContainerScript : MonoBehaviour
{
    public int previousScore;
    public bool won;
    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPreviousScore(int score)
    {
        previousScore = score;
    }
    public int getPreviousScore()
    {
        return previousScore;
    }
    public void setWon(bool isWon)
    {
        won = isWon;
    }
    public bool getWon()
    {
        return won;
    }
}

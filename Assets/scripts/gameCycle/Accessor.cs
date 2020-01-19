using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Accessor 
{
    public static int updateScore(int alter)
    {
        int score =  GameObject.Find("GameController").GetComponent<spawner>().updateScore(alter);
        GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>().SetText("Score : {0}", score);
        return score;
    }
    public static int getScore()
    {
        return GameObject.Find("GameController").GetComponent<spawner>().getScore();
    }
    public static void attackPlayer()
    {
        GameObject.Find("vaisseaujoueur").GetComponent<playerLifeCycle>().inflictDamage();
    }
    public static int getPlayerLife()
    {
        return GameObject.Find("vaisseaujoueur").GetComponent<playerLifeCycle>().getHp();
    }
    public static void updateLifeDisplay()
    {
        GameObject.Find("lifeText").GetComponent<TextMeshProUGUI>().SetText("Vies : {0}", getPlayerLife());
    }
    public static void gameOver(bool win)
    {
        GameObject.Find("dataContainer").GetComponent<dataContainerScript>().setPreviousScore(getScore());
        GameObject.Find("dataContainer").GetComponent<dataContainerScript>().setWon(win);
        SceneManager.LoadScene("MenuPrincipal");
    }
}

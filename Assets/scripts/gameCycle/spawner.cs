using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawner : MonoBehaviour
{

    public GameObject mobNoir;
    public GameObject mobRouge;
    public GameObject boss;
    public GameObject deathstar;

    public GameObject gameAudio;
    public GameObject bossAudio;

    GameObject currentMusic;
    AudioSource currentAudioSource;

    private int score = 0;

    float timer = 0;
    int count = 0;
    int step =0;
    //step correspond à l'avancement du jeu
    // 0 : découverte des mechants noirs et rouges
    // 1 : Assaut des méchants noirs et rouges
    // 2 : Découverte des deathstars
    // 3 : Attente
    // 4 : Assaut rouge+noirs+deathstar
    // 5 : boss



    


    // Start is called before the first frame update
    void Start()
    {
        currentMusic = Instantiate(gameAudio);
        currentAudioSource = currentMusic.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(step == 0 & timer >=3f)
        {
            count++;
            if (count == 1)
            {
                spawnNoir();
            }
            if(count == 2)
            {
                spawnRouge();
            }
            if (count == 3)
            {
                step = 1;
                count = 0;
            }
            timer = 0;
        }
        if (step == 1 & timer >= 0.8)
        {
            count++;
            if (count % 5 == 0)
            {
                spawnRouge();
            }
            else
            {
                spawnNoir();
            }
            if (count >= 50)
            {
                step = 2;
            }
            timer = 0;
        }
        if(step == 2)
        {
            spawnMultipleDeathStars();
            
            step = 3;
            timer = 0;
        }
        if(step == 3 & timer >= 10f)
        {
            step = 4;
            timer = 0;
            count = 0;
        }
        if(step == 4 & timer >=0.8)
        {
            count++;
            if (count % 5 == 0)
            {
                spawnRouge();
            }
            else
            {
                spawnNoir();
            }
            if(count == 20)
            {
                spawnDeathStarRandomPos();
            }
            if (count == 30)
            {
                IEnumerator fadeAudio = AudioFade.FadeOut(currentAudioSource, 5f);
                StartCoroutine(fadeAudio);
            }
            if(count >= 40)
            {
                step = 5;
                count = 0;
            }
            timer = 0;
        }
        if(step == 5)
        {
            if (timer >= 0.5)
            {
                timer = 0;
                if (count == 0)
                {
                    spawnBoss();
                }
                count++;
                if (count % 40 == 0)
                {
                    spawnDeathStarRandomPos();
                }
            }
        }

    }




    void spawnNoir()
    {
        Instantiate(mobNoir, new Vector2(Random.Range(-8.5f,-8f), 0), new Quaternion(0,0,180,0));
    }
    void spawnRouge()
    {
        Instantiate(mobRouge, new Vector2(Random.Range(-8.5f, -8f), 0), new Quaternion(0, 0, 180, 0));
    }
    void spawnMultipleDeathStars()
    {
        Instantiate(deathstar, new Vector2(-4f, 3.75f), new Quaternion());
        Instantiate(deathstar, new Vector2(0f, 3.75f), new Quaternion());
        Instantiate(deathstar, new Vector2(4f, 3.75f), new Quaternion());
    }
    void spawnDeathStarRandomPos()
    {
        Instantiate(deathstar, new Vector2(Random.Range(-6.5f,6.5f), Random.Range(1f,4f)), new Quaternion());
    }
    void spawnBoss()
    {
        Instantiate(boss, new Vector2(6f, 3.5f), new Quaternion());
        Destroy(currentMusic);
        currentMusic = Instantiate(bossAudio);
        currentAudioSource = currentMusic.GetComponent<AudioSource>();
        IEnumerator fadeAudio = AudioFade.FadeIn(currentAudioSource, 2f);
        StartCoroutine(fadeAudio);
    }



    public int updateScore(int increment)
    {
        score += increment;
        return score;
    }
    public int getScore()
    {
        return score;
    }



}

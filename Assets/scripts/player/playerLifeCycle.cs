using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerLifeCycle : MonoBehaviour
{

    public int maxHp;
    private int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void inflictDamage()
    {
        hp--;
        // Todo afficher les coeurs;
        if (hp <= 0)
        {
            Debug.Log("Fin du game)");
            //finDuGame();
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        projectile projo = col.gameObject.GetComponent<projectile>();
        if (projo is projectile)
        {
            if (!projo.isFriendly)
            {
                inflictDamage();
                Destroy(col.gameObject);
            }
        }
    }
}

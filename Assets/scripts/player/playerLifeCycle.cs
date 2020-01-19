using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerLifeCycle : MonoBehaviour
{

    public int maxHp;
    private int hp;
    private bool invincible = false;
    private float timer = 0;
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

        if (invincible)
        {
            timer += Time.deltaTime;
            if (timer >= 0.25)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
                timer = 0;
            }
        }
    }

    public void inflictDamage()
    {
        if (!invincible)
        {
            hp--;
            Accessor.updateLifeDisplay();
            Accessor.updateScore(-250);
            if (hp <= 0)
            {
                Accessor.gameOver(false);
            }
            else
            {
                invincible = true;
                transform.position = new Vector2(0, -4);
                Invoke("resetInvulnerability", 2);
            }
        }
    }
    void resetInvulnerability()
    {
        invincible = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public int getHp()
    {
        return hp;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("projectileTag")){
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
        if (col.gameObject.CompareTag("mechant"))
        {
            Debug.Log("collision avec machant");
            inflictDamage();
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public GameObject tirPrefab;
    public int maxHp;
    private int hp;
    private float timer;
    private float speed = 3f;
    private bool reverse;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement
        float newX = transform.position.x + Time.deltaTime * (reverse ? -speed : speed);
        transform.position = new Vector2(newX, 3.35f);
        if(transform.position.x <= -6.40)
        {
            reverse = false;
        }
        if(transform.position.x >= 6.40)
        {
            reverse = true;
        }

        //Tir
        timer += Time.deltaTime;
        if (timer >= 0.8f)
        {
            shot(transform.position.y - 0.1f);
            shot(transform.position.y - 0.3f);
            shot(transform.position.y - 0.5f);
            shot(transform.position.y - 0.7f);
            shot(transform.position.y - 0.9f);
            shot(transform.position.y - 0.11f);
            shot(transform.position.y - 0.13f);
            timer = 0;
        }

    }
    private void shot(float y)
    {
        GameObject tir = Instantiate(tirPrefab, new Vector2(transform.position.x, y), new Quaternion());
        Physics2D.IgnoreCollision(tir.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        tir = Instantiate(tirPrefab, new Vector2(transform.position.x, y), new Quaternion());
        Physics2D.IgnoreCollision(tir.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        tirSinusoidal tirViolet = tir.GetComponent<tirSinusoidal>();
        tirViolet.setInversed();

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        projectile projo = col.gameObject.GetComponent<projectile>();
        if (projo is projectile & projo.isFriendly)
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
                Accessor.updateScore(1000);
                Accessor.gameOver(true);
            }
        }
    }
}

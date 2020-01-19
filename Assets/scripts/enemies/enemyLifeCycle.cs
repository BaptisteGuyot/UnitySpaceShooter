using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLifeCycle : MonoBehaviour
{


    public GameObject tirPrefab;
    public int maxHp;
    private int hp;

    private float amp;
    private float periode;
    private float hauteur;
    // Start is called before the first frame update
    public void Start()
    {
        hauteur = Random.Range(1f, 3.5f);
        amp = Random.Range(0.2f, 1f);
        periode = Random.Range(1f, 3f);
        hp = maxHp;
    }

    // Update is called once per frame
    public void Update()
    {
        //Déplacement
        float newX = transform.position.x + 3f*Time.deltaTime;
        Vector2 newPos = new Vector2(newX, getY(newX));
        transform.position = newPos;


        // Verif sortie
        if (transform.position.y > 5.02 || transform.position.y < -5.2 || transform.position.x > 8)
        {
            Destroy(gameObject);
        }
    }

    float getY(float x)
    {
        return (amp * Mathf.Sin(x / periode) + hauteur);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("projectileTag")){
            projectile projo = col.gameObject.GetComponent<projectile>();
            if (projo is projectile & projo.isFriendly)
            {
                hp--;
                if (hp <= 0)
                {
                    Destroy(gameObject);
                    Accessor.updateScore(100);
                    //todo instantiate an explosion
                }
            }
        }
        
    }
}

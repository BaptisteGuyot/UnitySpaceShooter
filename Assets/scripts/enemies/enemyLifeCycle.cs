using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLifeCycle : MonoBehaviour
{


    public GameObject tirPrefab;
    public int maxHp;
    private int hp;
    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        //Déplacement
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        projectile projo = col.gameObject.GetComponent<projectile>();
        if (projo is projectile & projo.isFriendly)
        {
            hp--;
            Destroy(col.gameObject);
            if(hp <= 0)
            {
                Destroy(gameObject);
                //todo instantiate an explosion
            }
        }
    }
}

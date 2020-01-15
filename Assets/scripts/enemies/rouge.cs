using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouge : enemyLifeCycle
{
    private GameObject player;


    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.Find("vaisseaujoueur");
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        //rotation spéciale pour le rouge
        transform.up = player.transform.position - transform.position + new Vector3(0, 0, 0);

        //tir du rouge
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            GameObject tir = Instantiate(tirPrefab, new Vector2(transform.up.x, transform.up.y), new Quaternion());
            vaVersJoueur tirRouge = tir.GetComponent<vaVersJoueur>();
            Physics2D.IgnoreCollision(tir.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            tirRouge.transform.position = transform.position;
            timer = 0;
        }
    }
}

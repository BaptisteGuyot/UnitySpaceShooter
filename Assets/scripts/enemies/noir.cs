using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noir : enemyLifeCycle
{

    private float timer;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        // tir du noir
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            GameObject tir1 = Instantiate(tirPrefab, new Vector3(transform.position.x-0.4f, transform.position.y-0.5f), new Quaternion());
            Physics2D.IgnoreCollision(tir1.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            GameObject tir2 = Instantiate(tirPrefab, new Vector3(transform.position.x + 0.4f, transform.position.y - 0.5f), new Quaternion());
            Physics2D.IgnoreCollision(tir2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathStar : enemyLifeCycle
{

    private float timer;
    private int count = 0;
    private int max = 20;
    private float rayon = 0.09f;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.1f && count < max)
        {
            Debug.Log("spawn kiboujpa");
            float x = transform.position.x + (rayon / Mathf.Sin(Mathf.PI / max)) * Mathf.Sin((2 * Mathf.PI * count) / max);
            float y = transform.position.y + (rayon / Mathf.Sin(Mathf.PI / max)) * Mathf.Cos((2 * Mathf.PI * count) / max);
            spawnProjo(x, y);
            count++;
            timer = 0;
        }
        if (timer > 9f)
        {
            count = 0;
        }
    }

    private void spawnProjo(float x, float y)
    {
        GameObject tir = Instantiate(tirPrefab, new Vector2(x, y), new Quaternion());
        vaVersJoueur tirRouge = tir.GetComponent<vaVersJoueur>();
        Physics2D.IgnoreCollision(tir.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

}

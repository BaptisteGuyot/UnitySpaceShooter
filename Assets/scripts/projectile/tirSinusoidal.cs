using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirSinusoidal : projectile
{

    public float speed;
    private bool inversed;
    private float originX;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        originX = transform.position.x;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        float newY = transform.position.y - speed * Time.deltaTime;
        Vector2 newPos = new Vector2(getX(newY), newY);
        transform.position = newPos;
    }
    public void setInversed()
    {
        inversed = true;
    }
    float getX(float y)
    {
        float newX = 0.3f * Mathf.Sin(y / 0.3f);
        return (inversed ? -newX : newX) + originX;
    }
}

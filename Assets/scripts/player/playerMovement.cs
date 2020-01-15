using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float baseSpeed;
    private float minY = (float)-4.40;
    private float maxY = (float)4.45;
    private float minX = (float)-7.22;
    private float maxX = (float)7.22;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, -4);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float speedX = Time.deltaTime * baseSpeed * inputX;
        float inputY = Input.GetAxis("Vertical");
        float speedY = Time.deltaTime * baseSpeed * inputY;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedX /= 2;
            speedY /= 2;
        }

        transform.Translate(new Vector2(speedX, speedY));

        if(transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }

    }
}

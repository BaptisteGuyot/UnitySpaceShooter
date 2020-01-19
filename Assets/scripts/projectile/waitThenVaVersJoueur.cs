using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitThenVaVersJoueur : projectile
{
    private GameObject player;
    public float speed;
    private Vector3 directionOfTravel;
    private float timer;
    private bool isGone = false;

    // Start is called before the first frame update
    new void Start()
    {
        player = GameObject.Find("vaisseaujoueur");
    }
    void defineDirection()
    {
        directionOfTravel = player.transform.position - transform.position;
    }
    // Update is called once per frame
    new void Update()
    {

        if (isGone)
        {
            base.Update();
            avancer();
        }
        else
        {
            if (timer >= 5f)
            {
                isGone = true;
                directionOfTravel = player.transform.position - transform.position;
            }
            timer += Time.deltaTime;
        }
        
    }
    void avancer()
    {
        directionOfTravel.Normalize();
        base.Update();
        transform.Translate(
            (directionOfTravel.x * speed * Time.deltaTime),
            (directionOfTravel.y * speed * Time.deltaTime),
            (directionOfTravel.z * speed * Time.deltaTime));
    }
}

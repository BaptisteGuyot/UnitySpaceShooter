using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaVersJoueur : projectile
{
    private GameObject player;
    public float speed;
    private Vector3 directionOfTravel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("vaisseaujoueur");
        directionOfTravel = player.transform.position - transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        directionOfTravel.Normalize();
        base.Update();
        transform.Translate(
            (directionOfTravel.x * speed * Time.deltaTime),
            (directionOfTravel.y * speed * Time.deltaTime),
            (directionOfTravel.z * speed * Time.deltaTime));
    }
}

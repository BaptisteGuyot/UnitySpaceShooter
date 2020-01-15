using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public bool isFriendly;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(transform.position.y > 5.02 || transform.position.y < -5.2 || transform.position.x > 7.8 || transform.position.x < -7.8)
        {
            Destroy(gameObject);
        }
    }
}

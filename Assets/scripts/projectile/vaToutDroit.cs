using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaToutDroit : projectile
{
    public float translationY;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * translationY);
        base.Update();
    }
}
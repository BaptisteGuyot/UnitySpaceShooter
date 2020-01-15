using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShots : MonoBehaviour
{
    public GameObject tirPrefab;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > 0.1f)
        {
            Instantiate(tirPrefab, new Vector2((float)(transform.position.x-0.07), (float)(transform.position.y+ 0.69)), transform.rotation);
            Instantiate(tirPrefab, new Vector2((float)(transform.position.x + 0.11), (float)(transform.position.y + 0.69)), transform.rotation);
            timer = 0;
        }
    }
}

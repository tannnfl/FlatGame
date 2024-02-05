using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    GameObject carEnd;

    void Start()
    {
        carEnd = GameObject.Find("carEnd");
    }
    void Update()
    {
        //move
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //restart
        if (collision.gameObject == carEnd)
        {
            this.transform.position += new Vector3(0, -180, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    public float speed;

    void Update()
    {
        //move
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        //camera move
        Camera.main.transform.position = this.transform.position + new Vector3(0, 0, -10); 

    }   
}

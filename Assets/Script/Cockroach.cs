using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    float speed;
    public float normalSpeed;
    public float fastSpeed;
    bool isMove = true;
    int VectorX;
    int VectorY;
    float angleDeg;
    float angleRad;

    AudioSource blood;
    AudioSource walk;

    void Start()
    {
        blood = GameObject.Find("sfxBlood").GetComponent<AudioSource>();
        walk = GameObject.Find("sfxFootstep").GetComponent<AudioSource>();
    }

    void Update()
    {
        //Move
        //Initialize
        VectorX = 0;
        VectorY = 0;
        //speed up
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = fastSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        //Get Key
        isMove = false;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            VectorX = 1;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            VectorX = -1;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            VectorY = 1;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            VectorY = -1;
            isMove = true;
        }
        //Player Move
        this.transform.position += new Vector3(VectorX * speed * Time.deltaTime, VectorY * speed * Time.deltaTime, 0); 
        if (isMove)
        {
            //Player Rotation
            angleRad = Mathf.Atan2(VectorY, VectorX);
            angleDeg = angleRad * Mathf.Rad2Deg - 90;
            this.transform.eulerAngles = new Vector3(0, 0, angleDeg);
            //sfx
            if (!walk.isPlaying)
            {
                walk.Play();
            }
        }

        //Camera move
        Camera.main.transform.position = this.transform.position + new Vector3(0, 0, -200);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //car crashed
        if (collision.gameObject.tag == "car")
        {
            if(!blood.isPlaying)
            {
                blood.Play();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //car crashed
        if (collision.gameObject.tag == "car")
        {
            if (blood.isPlaying)
            {
                blood.Stop();
            }
        }
    }
}

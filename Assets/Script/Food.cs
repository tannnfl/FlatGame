using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float fadeSpeed;
    bool isCollide;
    GameObject cockroach;
    SpriteRenderer spriteRenderer;
    AudioSource sfx;

    void Start()
    {
        isCollide = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        cockroach = GameObject.Find("cockroach");
        sfx = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isCollide && spriteRenderer.color.a > 0)
        {
            float newAlpha = spriteRenderer.color.a - (fadeSpeed * Time.deltaTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            //play sound
            if (!sfx.isPlaying)
            {
                sfx.Play();
            }
        }
        else if (isCollide && spriteRenderer.color.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == cockroach)
        {
            isCollide = true;
        }
    }
}

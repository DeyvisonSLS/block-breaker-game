using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float hitLife = 3.0f;
    [SerializeField]
    private float number;
    int value = 4;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        wasHit();
    }
    private void wasHit()
    {
        hitLife--;
        
        if(hitLife <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            float newAlpha = hitLife / 4;
            number = newAlpha;
            // float test = Random.Range(0.0f, 1.0f);

            _sprite.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        }
    }
}

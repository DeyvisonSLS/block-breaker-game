using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float _hitLife = 3.0f;
    [SerializeField]
    private float _number;
    private int _value = 4;
    private SpriteRenderer _sprite;
    [SerializeField]
    private AudioClip _breakSound;

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
        _hitLife--;
        
        if(_hitLife <= 0)
        {
            AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
        else
        {
            float newAlpha = _hitLife / 4;
            _number = newAlpha;
            // float test = Random.Range(0.0f, 1.0f);

            _sprite.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        }
    }
}

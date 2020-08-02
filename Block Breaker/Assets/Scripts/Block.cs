using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int _hitLife = 3;
    [SerializeField]
    private float _number;
    private int _value = 4;
    private SpriteRenderer _sprite;
    [SerializeField]
    private AudioClip _breakSound;
    private GameManager _gameManager;
    void Awake()
    {
        // _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _sprite = GetComponent<SpriteRenderer>();
        _gameManager.IncreaseBlockCount();
    }
    void Start()
    {
        ChangeColor();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock(collision);
    }
    private void DestroyBlock(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.transform.tag == "Ball")
        {
            wasHit();
        }
    }
    private void wasHit()
    {
        _hitLife--;
        
        if(_hitLife <= 0)
        {
            AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
            _gameManager.DecreaseBlockCount();
            Destroy(this.gameObject);
        }
        else
        {
            ChangeColor();
        }
    }
    private void ChangeColor()
    {
        Color32 newColor;
        float newAlpha = _hitLife / 4;
        _number = newAlpha;
        

        switch(_hitLife)
        {
            case 3:
            newColor = new Color32(255, 255, 0, 255);
            break;

            case 2:
            newColor = new Color32(255, 137, 0, 255);
            break;

            case 1:
            newColor = new Color32(255, 0, 0, 255);
            break;

            default:
            newColor = new Color32(255, 255, 0, 255);
            break;
        }

        _sprite.color = (Color) newColor;
    }
}

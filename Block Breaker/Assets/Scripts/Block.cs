﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region FIELDS
    //  The Sprite component in the gameobject.
    private SpriteRenderer _sprite;
    //  The AudioClip played [PlayClipAtPoint] when the block is destroyed .
    [SerializeField]
    private AudioClip _breakSound;
    //  GameManager in the scene.
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _sparklePrefab;
    public enum BlockTypes {None, BlockType01, BlockTypes02};
    #endregion

    #region PROPERTIES
    [SerializeField]
    public BlockTypes BlockType = BlockTypes.None;
    //  How much points it gives when it's destroyed
    [SerializeField]
    public int Points
    { 
        get
        {
            int points;

            switch(BlockType)
            {
                case BlockTypes.BlockType01:
                points = 10;
                break;

                case BlockTypes.BlockTypes02:
                points = 20;
                break;

                default:
                points = 5;
                break;
            }

            return points;
        }
        private set{} 
    }
    //  The values that represents the times the block can be hitted before break
    [SerializeField]
    public int HitLife {get; private set;}  = 3;
    #endregion

    #region MONOBEHAVIOUR
    private void Awake()
    {
        // _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        ChangeColor();
        _gameManager.IncreaseBlockCount();
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
            WasHit();
        }
    }
    #endregion

    #region PUBLIC METHODS
    #endregion

    #region PRIVATE METHODS
    private void WasHit()
    {
        HitLife--;
        
        if(HitLife <= 0)
        {
            AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
            _gameManager.DecreaseBlockCount();
            IncreaseScore();
            PlaySparkle();
            Destroy(this.gameObject);
        }
        else
        {
            ChangeColor();
        }
    }
    private void IncreaseScore()
    {
        _gameManager.AddPointsToScore(Points);
    }
    private void ChangeColor()
    {
        Color32 newColor;
        
        switch(HitLife)
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
    private void PlaySparkle()
    {
        GameObject sparkle = Instantiate(_sparklePrefab, transform.position, transform.rotation);
        Destroy(sparkle, 1.0f);
    }
    #endregion
}

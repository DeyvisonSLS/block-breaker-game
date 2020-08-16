using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Block : MonoBehaviour
{
    #region FIELDS
    //  The Sprite component in the gameobject.
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite[] _blockSprites;
    //  The AudioClip played [PlayClipAtPoint] when the block is destroyed .
    [SerializeField]
    private AudioClip _breakSound = null;
    //  GameManager in the scene.
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _sparklePrefab = null;
    public enum BlockTypes {Sensible, Normal, Unbreakable};
    #endregion

    #region PROPERTIES
    [SerializeField]
    public BlockTypes BlockType;
    //  How much points it gives when it's destroyed
    [SerializeField]
    public int Points
    { 
        get
        {
            int points = 0;

            switch(BlockType)
            {
                case BlockTypes.Sensible:
                points = 10;
                break;

                case BlockTypes.Normal:
                points = 20;
                break;
            }

            return points;
        }
        private set{} 
    }
    //  The values that represents the times the block can be hitted before break

    [SerializeField]
    private int _hitLife = 0;
    public int HitLife
    {
        get
        {
            return _hitLife;
        } 
        private set
        {
            _hitLife = value;
        }
    }
    #endregion

    #region MONOBEHAVIOUR
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if(BlockType != BlockTypes.Unbreakable)
        {
            _gameManager.IncreaseBlockCount();
        }

        SetLife();
    }
    private void OnValidate()
    {
        SetLife();
        ChangeBlockState();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockCollision(collision);
    }
    private void BlockCollision(Collision2D collision)
    {
        Debug.Log("Hit");
        if(collision.transform.tag == "Ball")
        {
            WasHit();
        }
    }
    #endregion

    #region PUBLIC METHODS
    #endregion

    #region PRIVATE METHODS
    private void SetLife()
    {
        switch(BlockType)
        {
            case BlockTypes.Sensible:
            _hitLife = 1;
            break;

            case BlockTypes.Normal:
            _hitLife = 3;
            break;
        }
    }
    private void WasHit()
    {
        if(BlockType != BlockTypes.Unbreakable)
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
                ChangeBlockState();
            }
        }
        else
        {
            ChangeBlockState();
        }
    }
    private void IncreaseScore()
    {
        _gameManager.AddPointsToScore(Points);
    }
    private void ChangeBlockState()
    {
        Color32 newColor;
        
        if(BlockType != BlockTypes.Unbreakable)
        {
            switch(HitLife)
            {
                case 3:
                newColor = new Color32(255, 255, 0, 255);
                break;

                case 2:
                newColor = new Color32(255, 137, 0, 255);
                if(_spriteRenderer != null)
                _spriteRenderer.sprite = _blockSprites[1];
                break;

                case 1:
                newColor = new Color32(255, 0, 0, 255);
                if(_spriteRenderer != null)
                _spriteRenderer.sprite = _blockSprites[2];
                break;

                default:
                newColor = new Color32(255, 255, 0, 255);
                break;
            }
        }
        else
        {
            newColor = Color.grey;
        }

        if(_spriteRenderer != null)
        _spriteRenderer.color = (Color) newColor;
    }
    private void PlaySparkle()
    {
        GameObject sparkle = Instantiate(_sparklePrefab, transform.position, transform.rotation);
        Destroy(sparkle, 1.0f);
    }
    #endregion
}

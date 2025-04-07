using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] Sprite[] _possibleSprites;

    SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        //_sprite.flipX = Random.Range(0, 1);
        //_sprite.flipY = Random.Range(0, 1);
        int randomSprite = Random.Range(0, _possibleSprites.Length - 1);
        _sprite.sprite = _possibleSprites[randomSprite];
    }
}

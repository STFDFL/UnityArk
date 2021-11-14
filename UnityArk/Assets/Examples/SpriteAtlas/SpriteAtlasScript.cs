using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteAtlasScript : MonoBehaviour
{

    [SerializeField] private SpriteAtlas atlas;
    [SerializeField] private string sprite_name;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = atlas.GetSprite(sprite_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

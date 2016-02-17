using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour
{
    public static ColorDefs.DefiniteColor playerColor;
    SpriteRenderer mySprite;
    // Use this for initialization
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        
        playerColor = ColorDefs.DefiniteColor.CO_RED;
        mySprite.color = Color.red;

    }

    void ChangeColor()
    {
        switch (playerColor)
        {
            case ColorDefs.DefiniteColor.CO_RED:
                mySprite.color = Color.blue;
                playerColor = ColorDefs.DefiniteColor.CO_BLUE;
                break;
            case ColorDefs.DefiniteColor.CO_BLUE:
                mySprite.color = Color.yellow;
                playerColor = ColorDefs.DefiniteColor.CO_YELLOW;
                break;
            case ColorDefs.DefiniteColor.CO_YELLOW:
                mySprite.color = Color.red;
                playerColor = ColorDefs.DefiniteColor.CO_RED;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if the enum is red, change it to green
        if(Input.GetMouseButtonDown(1))
        {
                ChangeColor();
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorNode
{
    ColorDefs.DefiniteColor selectedColor;
    public ColorNode(ColorDefs.DefiniteColor _selectedColor)
    {
        selectedColor = _selectedColor;
    }
}

public class PlayerColor : MonoBehaviour
{
    public static ColorDefs.DefiniteColor playerColor;
    SpriteRenderer mySprite;
    ColorNode[,] colorMap = new ColorNode[2,3];
    

    // Use this for initialization
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        
        playerColor = ColorDefs.DefiniteColor.CO_RED;
        mySprite.color = Color.red;
        //setting up array to select your gun color
        colorMap[0, 0] = new ColorNode(ColorDefs.DefiniteColor.CO_BLUE);
        colorMap[0, 1] = new ColorNode(ColorDefs.DefiniteColor.CO_YELLOW);
        colorMap[0, 2] = new ColorNode(ColorDefs.DefiniteColor.CO_RED);
        colorMap[1, 0] = new ColorNode(ColorDefs.DefiniteColor.CO_ORANGE);
        colorMap[1, 1] = new ColorNode(ColorDefs.DefiniteColor.CO_PURPLE);
        colorMap[1, 2] = new ColorNode(ColorDefs.DefiniteColor.CO_GREEN);

    }

    void ChangeColor()
    { 

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

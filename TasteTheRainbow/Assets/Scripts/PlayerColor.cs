﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorNode
{
    public ColorDefs.DefiniteColor selectedColor;
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
    Vector2 mapLocation = new Vector2(0,0);

    public static int maxColorVal = 100;
    public static int minColorThreshhold = 40;
    public static int redVal;
    public static int blueVal;
    public static int yellowVal;

    public static int bulletCost = 2;

    // Use this for initialization
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        
        //setting up array to select your gun color
        colorMap[0, 0] = new ColorNode(ColorDefs.DefiniteColor.CO_BLUE);
        colorMap[0, 1] = new ColorNode(ColorDefs.DefiniteColor.CO_YELLOW);
        colorMap[0, 2] = new ColorNode(ColorDefs.DefiniteColor.CO_RED);
        colorMap[1, 0] = new ColorNode(ColorDefs.DefiniteColor.CO_ORANGE);
        colorMap[1, 1] = new ColorNode(ColorDefs.DefiniteColor.CO_PURPLE);
        colorMap[1, 2] = new ColorNode(ColorDefs.DefiniteColor.CO_GREEN);

        playerColor = colorMap[(int)mapLocation.x, (int)mapLocation.y].selectedColor;
        mySprite.color = Color.blue;

        redVal = maxColorVal;
        blueVal = maxColorVal;
        yellowVal = maxColorVal;
    }

    void ChangeColor()
    {
        if (Input.GetKeyDown("d"))
        {
            if (mapLocation.y > 1)
                mapLocation.y = 0;
            else
                mapLocation.y++;
        }

        else if (Input.GetKeyDown("a"))
        {
            if (mapLocation.y < 1)
                mapLocation.y = 2;
            else
                mapLocation.y--;
        }

        else if (Input.GetKeyDown("w"))
        {
            if (mapLocation.x >= 1)
                mapLocation.x = 0;
            else
                mapLocation.x++;
        }

        else if (Input.GetKeyDown("s"))
        {
            if (mapLocation.x < 1)
                mapLocation.x = 1;
            else
                mapLocation.x--;
        }
        playerColor = colorMap[(int)mapLocation.x, (int)mapLocation.y].selectedColor;

        switch (playerColor)
        {
            case ColorDefs.DefiniteColor.CO_RED:
                mySprite.color = Color.red;
                break;
            case ColorDefs.DefiniteColor.CO_BLUE:
                mySprite.color = Color.blue;
                break;
            case ColorDefs.DefiniteColor.CO_YELLOW:
                mySprite.color = Color.yellow;
                break;
            case ColorDefs.DefiniteColor.CO_PURPLE:
                mySprite.color = new Color(0.5f, 0.0f, 0.5f, 1.0f);
                break;
            case ColorDefs.DefiniteColor.CO_GREEN:
                mySprite.color = Color.green;
                break;
            case ColorDefs.DefiniteColor.CO_ORANGE:
                mySprite.color = Color.red + (Color.green * 0.5f);
                break;
            case ColorDefs.DefiniteColor.CO_WHITE:
                mySprite.color = Color.white;
                break;
            case ColorDefs.DefiniteColor.CO_BLACK:
                mySprite.color = Color.black;
                break;
            case ColorDefs.DefiniteColor.CO_GREY:
                mySprite.color = Color.gray;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeColor();
        blueVal = Mathf.Clamp(blueVal,0, maxColorVal);
        yellowVal = Mathf.Clamp(yellowVal, 0, maxColorVal);
        redVal = Mathf.Clamp(redVal, 0, maxColorVal);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletProjection otherBullet = other.GetComponent<BulletProjection>();
        if (otherBullet != null)
        {
            redVal -= 10;
            blueVal -= 10;
            yellowVal -= 10;

            Destroy(other.gameObject);
        }
        else
        {
            Enemy otherEnemy = other.GetComponent<Enemy>();
            if (otherEnemy != null)
            {
                redVal -= 10;
                blueVal -= 10;
                yellowVal -= 10;

                otherEnemy.currentHealth -= otherEnemy.critDamage;

                if (otherEnemy.currentHealth <= 0)
                {
                    Destroy(other.gameObject);
                }

            }
        }

        blueVal = Mathf.Clamp(blueVal, 0, maxColorVal);
        yellowVal = Mathf.Clamp(yellowVal, 0, maxColorVal);
        redVal = Mathf.Clamp(redVal, 0, maxColorVal);

        if (redVal + blueVal + yellowVal < minColorThreshhold)
        {
            Destroy(gameObject);
        }
    }

    public void FiredBullet()
    {
        switch (playerColor)
        {
            case ColorDefs.DefiniteColor.CO_RED:
                redVal -= bulletCost;
                break;
            case ColorDefs.DefiniteColor.CO_BLUE:
                blueVal -= bulletCost;
                break;
            case ColorDefs.DefiniteColor.CO_YELLOW:
                yellowVal -= bulletCost;
                break;
            case ColorDefs.DefiniteColor.CO_PURPLE:
                redVal -= bulletCost / 2;
                blueVal -= bulletCost / 2;
                break;
            case ColorDefs.DefiniteColor.CO_GREEN:
                blueVal -= bulletCost / 2;
                yellowVal -= bulletCost / 2;
                break;
            case ColorDefs.DefiniteColor.CO_ORANGE:
                redVal -= bulletCost / 2;
                yellowVal -= bulletCost / 2;
                break;
            default:
                break;
        }

        if (redVal + blueVal + yellowVal < minColorThreshhold)
        {
            Destroy(gameObject);
        }
    }

    public static void EnemyKilled(ColorDefs.DefiniteColor killedColor)
    {
        switch (killedColor)
        {
            case ColorDefs.DefiniteColor.CO_RED:
                redVal += bulletCost * 5;
                break;
            case ColorDefs.DefiniteColor.CO_BLUE:
                blueVal += bulletCost * 5;
                break;
            case ColorDefs.DefiniteColor.CO_YELLOW:
                yellowVal += bulletCost * 5;
                break;
            case ColorDefs.DefiniteColor.CO_PURPLE:
                redVal += bulletCost * 3;
                blueVal += bulletCost * 3;
                break;
            case ColorDefs.DefiniteColor.CO_GREEN:
                blueVal += bulletCost * 3;
                yellowVal += bulletCost * 3;
                break;
            case ColorDefs.DefiniteColor.CO_ORANGE:
                redVal += bulletCost * 3;
                yellowVal += bulletCost * 3;
                break;
            default:
                redVal += bulletCost * 2;
                blueVal += bulletCost * 2;
                yellowVal += bulletCost * 2;
                break;
        }

        redVal = Mathf.Min(redVal, maxColorVal);
        blueVal = Mathf.Min(blueVal, maxColorVal);
        yellowVal = Mathf.Min(yellowVal, maxColorVal);
    }
}

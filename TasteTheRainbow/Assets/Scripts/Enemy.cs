using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField]
    ColorDefs.DefiniteColor absColor = ColorDefs.DefiniteColor.CO_WHITE;
    [SerializeField]
    protected float mySpeed = -1.0f;

    public float lowestY;

    SpriteRenderer mySprite = null;

    // Use this for initialization
    protected virtual void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        ChangeColor(absColor);
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        transform.Translate(0, mySpeed * Time.deltaTime, 0);
        if (transform.position.y < lowestY)
        {
            Destroy(gameObject);
        }
	}

    public void ChangeColor(ColorDefs.DefiniteColor newColor)
    {
        absColor = newColor;
        if (mySprite != null)
        {
            switch (newColor)
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
    }
}

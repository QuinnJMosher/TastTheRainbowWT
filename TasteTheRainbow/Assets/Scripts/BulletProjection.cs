using UnityEngine;
using System.Collections;

public class BulletProjection : MonoBehaviour
{
    public Rigidbody2D rbody;
    public int bulletSpeed;
    SpriteRenderer mySprite;
    public ColorDefs.DefiniteColor AbsColor = ColorDefs.DefiniteColor.CO_WHITE;
    // Use this for initialization
    void Start ()
    {
        mySprite = GetComponent<SpriteRenderer>();
        Vector3 force = new Vector3(0,bulletSpeed,0);
        rbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void ChangeColor(ColorDefs.DefiniteColor parentColor)
    {
        if (mySprite == null)
        {
            Start();
        }
        AbsColor = parentColor;
        switch(parentColor)
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
	void Update ()
    {
        //set 60 to screen height, may need to 
        //get camera to find world view
        if (transform.position.y > 6 || transform.position.y < -6)
            Destroy(gameObject);
            
	}
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public ColorDefs.DefiniteColor absColor = ColorDefs.DefiniteColor.CO_WHITE;
    [SerializeField]
    protected float mySpeed = -1.0f;
    [SerializeField]
    int maxHealth = 9;
    public int currentHealth;
    public int normalDamage = 1;
    public int critDamage = 3;

    public float lowestY;

    SpriteRenderer mySprite = null;

    // Use this for initialization
    protected virtual void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        ChangeColor(absColor);
        currentHealth = maxHealth;
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

    bool IsWeakTo(ColorDefs.DefiniteColor incomingType)
    {
        switch (absColor)
        {
            case ColorDefs.DefiniteColor.CO_RED:
                return (incomingType == ColorDefs.DefiniteColor.CO_GREEN);
            case ColorDefs.DefiniteColor.CO_BLUE:
                return (incomingType == ColorDefs.DefiniteColor.CO_ORANGE);
            case ColorDefs.DefiniteColor.CO_YELLOW:
                return (incomingType == ColorDefs.DefiniteColor.CO_PURPLE);
            case ColorDefs.DefiniteColor.CO_PURPLE:
                return (incomingType == ColorDefs.DefiniteColor.CO_YELLOW);
            case ColorDefs.DefiniteColor.CO_GREEN:
                return (incomingType == ColorDefs.DefiniteColor.CO_RED);
            case ColorDefs.DefiniteColor.CO_ORANGE:
                return (incomingType == ColorDefs.DefiniteColor.CO_BLUE);
            default:
                return false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletProjection collidedBullet = other.gameObject.GetComponent<BulletProjection>();
        if (collidedBullet != null)
        {
            if (IsWeakTo(collidedBullet.AbsColor))
            {
                currentHealth -= critDamage;
            }
            else
            {
                currentHealth -= normalDamage;
            }
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);//die
            }
        }
    }
}

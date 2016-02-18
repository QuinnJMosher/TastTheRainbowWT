using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWeaponSprite : MonoBehaviour
{
    public Image blueWeapon;
    public Image yellowWeapon;
    public Image redWeapon;
    public Image orangeWeapon;
    public Image purpleWeapon;
    public Image greenWeapon;
    public Text blue;
    public Text yellow;
    public Text red;
    public Text health;
    private int currentHealth;
    private Image selectedWeapon;

    // Use this for initialization
    void Start()
    {
        selectedWeapon = blueWeapon;
    }

    void UpdateHealth()
    {
        blue.text = PlayerColor.blueVal.ToString();
        yellow.text = PlayerColor.yellowVal.ToString();
        red.text = PlayerColor.redVal.ToString();
        currentHealth = PlayerColor.blueVal + PlayerColor.yellowVal + PlayerColor.redVal;
        health.text = "= \n" + currentHealth + "\n Keep this above 40!";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();

        selectedWeapon.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 27);
        selectedWeapon.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 35);
        switch (PlayerColor.playerColor)
        {
            case ColorDefs.DefiniteColor.CO_BLUE:
                selectedWeapon = blueWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_YELLOW:
                selectedWeapon = yellowWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_RED:
                selectedWeapon = redWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_ORANGE:
                selectedWeapon = orangeWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_PURPLE:
                selectedWeapon = purpleWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_GREEN:
                selectedWeapon = greenWeapon;
                break;
        }
        selectedWeapon.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 35.0f);
        selectedWeapon.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 44.0f);
    }
}

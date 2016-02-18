using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWeaponSprite : MonoBehaviour
{
    public Sprite blueWeapon;
    public Sprite yellowWeapon;
    public Sprite redWeapon;
    public Sprite orangeWeapon;
    public Sprite purpleWeapon;
    public Sprite greenWeapon;
    public Image weaponUI;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerColor.playerColor)
        {
            case ColorDefs.DefiniteColor.CO_BLUE:
                weaponUI.sprite = blueWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_YELLOW:
                weaponUI.sprite = yellowWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_RED:
                weaponUI.sprite = redWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_ORANGE:
                weaponUI.sprite = orangeWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_PURPLE:
                weaponUI.sprite = purpleWeapon;
                break;
            case ColorDefs.DefiniteColor.CO_GREEN:
                weaponUI.sprite = greenWeapon;
                break;
        }
    }
}

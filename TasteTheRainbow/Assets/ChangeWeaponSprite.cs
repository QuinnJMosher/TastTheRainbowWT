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
    private Image selectedWeapon;

    // Use this for initialization
    void Start()
    {
        selectedWeapon = blueWeapon;
    }

    // Update is called once per frame
    void Update()
    {
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

using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour
{
    public Material mat;
    public static ColorDefs.DefiniteColor playerColor;
    // Use this for initialization
    void Start ()
    {
        mat.color = new Color(1, 0, 0, 1);
        playerColor = ColorDefs.DefiniteColor.CO_RED;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if the enum is red, change it to green
        if(Input.GetMouseButtonDown(1) &&
            playerColor == ColorDefs.DefiniteColor.CO_RED)
        {

            mat.color = new Color(0, 1, 0, 1);
            playerColor = ColorDefs.DefiniteColor.CO_GREEN;
        }
        //if the enum is green change it to blue
        else if(Input.GetMouseButtonDown(1) &&
            playerColor == ColorDefs.DefiniteColor.CO_GREEN)
        {
            mat.color = new Color(0, 0, 1, 1);
            playerColor = ColorDefs.DefiniteColor.CO_BLUE;
        }
        //if the enum is blue change it to red
        else if (Input.GetMouseButtonDown(1) &&
            playerColor == ColorDefs.DefiniteColor.CO_BLUE)
        {
            mat.color = new Color(1, 0, 0, 1);
            playerColor = ColorDefs.DefiniteColor.CO_RED;
        }
    }
}

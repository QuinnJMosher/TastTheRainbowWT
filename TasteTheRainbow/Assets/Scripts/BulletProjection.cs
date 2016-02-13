using UnityEngine;
using System.Collections;

public class BulletProjection : MonoBehaviour
{
    public ColorDefs.DefiniteColor bulletColor;
    public Material mat;
    public Rigidbody rbody;
    public int bulletSpeed; 
    // Use this for initialization
    void Start ()
    {
        bulletColor = PlayerColor.playerColor;

        if (bulletColor == ColorDefs.DefiniteColor.CO_RED)
            mat.color = new Color(1, 0, 0, 1); // this line will change based on asset from artist
        else if (bulletColor == ColorDefs.DefiniteColor.CO_GREEN)
            mat.color = new Color(0,1,0,1);
        else if (bulletColor == ColorDefs.DefiniteColor.CO_BLUE)
            mat.color = new Color(0, 0, 1, 1);

        Vector3 force = new Vector3(0,bulletSpeed,0);
        rbody.AddForce(force, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //set 60 to screen height, may need to 
        //get camera to find world view
        if (transform.position.y > 60)
            Destroy(gameObject);
	}
}

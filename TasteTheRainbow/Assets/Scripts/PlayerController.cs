using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    private Shoot shoot;
    public Camera cam;
    private Vector3 target;
	// Use this for initialization
	void Start ()
    {
        shoot = GetComponent<Shoot>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        target = Input.mousePosition;
        target = cam.ScreenToWorldPoint(target);
        target.z = 0;

        transform.position = Vector3.Lerp(transform.position, target, playerSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
            shoot.OnShoot();
    }
}

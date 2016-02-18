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

    public void Move()
    {
       
        target = Input.mousePosition;
        target = cam.ScreenToWorldPoint(target);
        target.z = 0;
        target.x = Mathf.Clamp(target.x, -2.6f, 2.6f);
        target.y = Mathf.Clamp(target.y, -4.7f, 4.7f);
        transform.position = Vector3.Lerp(transform.position, target, playerSpeed * Time.deltaTime);
    }


    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            shoot.OnShoot();
    }

    void FixedUpdate()
    {
        Move();
    }
}

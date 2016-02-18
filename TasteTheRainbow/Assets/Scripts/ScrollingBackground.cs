using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

    public GameObject background0;
    public GameObject background1;
    public GameObject startPoint;
    public GameObject endPoint;

    public float scrollSpeed = -1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        background0.transform.Translate(0, scrollSpeed * Time.deltaTime, 0);
        if (background0.transform.position.y <= endPoint.transform.position.y)
        {
            background0.transform.position = new Vector3(0, startPoint.transform.position.y, 1);
        }

        background1.transform.Translate(0, scrollSpeed * Time.deltaTime, 0);
        if (background1.transform.position.y <= endPoint.transform.position.y)
        {
            background1.transform.position = new Vector3(0, startPoint.transform.position.y, 1);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OnShoot()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}

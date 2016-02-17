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

    public GameObject OnShoot()
    {
        return Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
    }
}

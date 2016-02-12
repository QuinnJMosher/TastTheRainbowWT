using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

    public float StartingFrequencey = 0.5f;
    public float FrequenceyGrowth = 0.01f;
    float currentFrequencey;
    float maximumFrequencey = 10.0f;
    public float placementBuffer = .01f;

    public Transform minPosition;
    public Transform maxPosition;

    public GameObject lightEnemy;//enemy class?
    //public GameObject heavyEnemy;

	// Use this for initialization
	void Start () {
        //Random.seed = 123456789;
        currentFrequencey = StartingFrequencey;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.P)) //force enemy spawn
        {
            Generate();
        }
	}

    void FixedUpdate()
    {
        if (Random.Range(0.0f, maximumFrequencey) < currentFrequencey)
        {
            Generate();
            currentFrequencey += FrequenceyGrowth;
        }
    }

    void Generate()
    {
        ColorDefs.DefiniteColor spawnedColor = (ColorDefs.DefiniteColor)Random.Range(0, (int)ColorDefs.DefiniteColor.CO_COUNT);
        Vector3 spawnedPosition = new Vector3(Random.Range(minPosition.position.x, maxPosition.position.x), Random.Range(minPosition.position.y, maxPosition.position.y), 0);
        GameObject newEnemy = null;

        /*if (Random.Range(0, 2) == 0) //determine Type
        {
            //small enemy
            newEnemy = Instantiate(lightEnemy, spawnedPosition, Quaternion.Euler(Vector3.forward)) as GameObject;
        }
        else {
            //big enemy
        }*/

        newEnemy = Instantiate(lightEnemy, spawnedPosition, Quaternion.Euler(Vector3.forward)) as GameObject;
        //get enemy's script
        //giv ememy its color

    }
}

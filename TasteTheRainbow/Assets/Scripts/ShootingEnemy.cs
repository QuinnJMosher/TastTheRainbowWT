using UnityEngine;
using System.Collections;

public class ShootingEnemy : Enemy {

    public float shootInterval = 1.0f;
    float remaningInterval;
    Shoot myShootScript;

    // Use this for initialization
    protected override void Start () {
        remaningInterval = shootInterval;
        myShootScript = GetComponent<Shoot>();

        base.Start();
	}

    // Update is called once per frame
    protected override void Update () {

        remaningInterval -= Time.deltaTime;
        if (remaningInterval < 0.0f)
        {
            GameObject newBullet = myShootScript.OnShoot();
            newBullet.GetComponent<BulletProjection>().ChangeColor(base.absColor);
            remaningInterval = shootInterval + remaningInterval;
        }

        base.Update();

	}
}

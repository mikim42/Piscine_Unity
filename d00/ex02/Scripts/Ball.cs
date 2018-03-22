using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Club club;
    float power;
    int direction;

	// Use this for initialization
	void Start () {
        direction = 1;
        power = 0;
	}

    //bot -3.50 top 5.50

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 3.75f && transform.position.y <= 4.15f &&
           power < 1)
        {
            GameObject.Destroy(this);
            GameObject.Destroy(club);
        }
        if (power > 0)
        {
            if (power > 0)
            {
                moveBall(0.5f * power);
                power -= 0.15f;
            }
            if (power < 0)
                club.moveClub();
        }
    }

    public void setPower(int force)
    {
        power = Mathf.Clamp((float)force, 0.0f, 7.0f);
        direction = 1;
    }

    void moveBall(float velocity)
    {
        float dist = velocity * direction * 0.33f;

        if (transform.position.y + dist > 5.40f)
        {
            transform.Translate(0, 5.40f - transform.position.y, 0);
            direction = -1;
            power += 0.075f;
        }
        else if (transform.position.y + dist < -3.40f)
        {
            transform.Translate(0, -3.40f - transform.position.y, 0);
            direction = 1;
            power += 0.075f;
        }
        else
        {
            transform.Translate(0, dist, 0);
        }
    }
}

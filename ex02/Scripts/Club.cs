using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {
    public Ball ball;

    private int score;
    private int force;

	// Use this for initialization
    void Start () {
        force = 0;
        score = -15;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && force < 10)
        {
            force++;
            transform.Translate(0, -0.1f, 0);
        }
        else if (!Input.GetKey(KeyCode.Space) && force > 0)
        {
            transform.Translate(0, (0.1f * force) + 0.1f, 0);
            ball.setPower(force);
            force = 0;
            score += 5;
            Debug.Log("Score: " + score);
        }
	}

    public void moveClub()
    {
        float movement = ball.transform.position.y - transform.position.y + 0.25f;

        transform.Translate(0, movement, 0);
    }
}

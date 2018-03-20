using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float velocity;

    // Use this for initialization
    void Start()
    {
        velocity = Random.Range(0.1f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector3(0, -velocity, 0));
    }
}
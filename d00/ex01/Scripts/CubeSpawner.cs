using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabS;
    public GameObject prefabD;

    private GameObject squareA;
    private GameObject squareS;
    private GameObject squareD;

    public Transform targetA;
    public Transform targetS;
    public Transform targetD;

    private float runtime = 1;

    private float hitBox = -2.6f;
    private float endBox = -3.8f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (squareA && squareA.transform.position.y <= endBox)
            destroySquare(squareA);
        if (squareS && squareS.transform.position.y <= endBox)
            destroySquare(squareS);
        if (squareD && squareD.transform.position.y <= endBox)
            destroySquare(squareD);
        if (Time.realtimeSinceStartup > runtime)
        {
            int r = Random.Range(0, 3);
            if (r == 0 && !squareA)
            {
                squareA = GameObject.Instantiate(prefabA, targetA.transform.position, targetA.transform.rotation);
            }
            else if (r == 1 && !squareS)
            {
                squareS = GameObject.Instantiate(prefabS, targetS.transform.position, targetS.transform.rotation);
            }
            else if (r == 2 && !squareD)
            {
                squareD = GameObject.Instantiate(prefabD, targetD.transform.position, targetD.transform.rotation);
            }
            runtime++;
        }
        if (squareA && Input.GetKeyDown(KeyCode.A))
            destroySquare(squareA);
        if (squareS && Input.GetKeyDown(KeyCode.S))
            destroySquare(squareS);
        if (squareD && Input.GetKeyDown(KeyCode.D))
            destroySquare(squareD);
    }

    void destroySquare(GameObject target)
    {
        float   dist = target.transform.position.y - hitBox;
        int pct = 100 - (int)(dist < 0 ? -dist * 100 : dist * 100);

        Debug.Log(dist);
        if (dist < 0)
            dist = -dist;
        if (pct < 0)
            pct = 0;
        Debug.Log("Precision: " + dist + " | " + pct + "%");
        GameObject.Destroy(target);
    }
}

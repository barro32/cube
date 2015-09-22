using UnityEngine;
using System.Collections;

public class scriptCube : MonoBehaviour
{

    public int cubeGroupX;
    public int cubeGroupY;
    public int cubeGroupZ;

    // Use this for initialization
    void Start()
    {
        getCubeGroups();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getCubeGroups()
    {
        if (transform.position.x < 0)
        {
            cubeGroupX = 1;
            gameObject.transform.Find("tagX").tag = "x1";
        }
        else if (transform.TransformPoint(transform.position).x == 0)
        {
            cubeGroupX = 2;
            gameObject.transform.Find("tagX").tag = "x2";
        }
        else if (transform.position.x > 0)
        {
            cubeGroupX = 3;
            gameObject.transform.Find("tagX").tag = "x3";
        }
        if (transform.position.y < 0)
        {
            cubeGroupY = 1;
            gameObject.transform.Find("tagY").tag = "y1";
        }
        else if (transform.position.y == 0)
        {
            cubeGroupY = 2;
            gameObject.transform.Find("tagY").tag = "y2";
        }
        else if (transform.position.y > 0)
        {
            cubeGroupY = 3;
            gameObject.transform.Find("tagY").tag = "y3";
        }
        if (transform.position.z < 0)
        {
            cubeGroupZ = 1;
            gameObject.transform.Find("tagZ").tag = "z1";
        }
        else if (transform.position.z == 0)
        {
            cubeGroupZ = 2;
            gameObject.transform.Find("tagZ").tag = "z2";
        }
        else if (transform.position.z > 0)
        {
            cubeGroupZ = 3;
            gameObject.transform.Find("tagZ").tag = "z3";
        }
    }


}

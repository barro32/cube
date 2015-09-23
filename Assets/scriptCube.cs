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
        updateCube();
    }

    // Update is called once per frame
    void Update()
    {
        updateCube();
    }

    public void updateCube() {
        getCubeGroups();
        getFaceNormals();
    }

    void getCubeGroups() {
        if (transform.position.x < 0) {
            cubeGroupX = 1;
            gameObject.transform.Find("tagX").tag = "x1";
        } else if (transform.TransformPoint(transform.position).x == 0) {
            cubeGroupX = 2;
            gameObject.transform.Find("tagX").tag = "x2";
        } else if (transform.position.x > 0) {
            cubeGroupX = 3;
            gameObject.transform.Find("tagX").tag = "x3";
        }
        if (transform.position.y < 0) {
            cubeGroupY = 1;
            gameObject.transform.Find("tagY").tag = "y1";
        } else if (transform.position.y == 0) {
            cubeGroupY = 2;
            gameObject.transform.Find("tagY").tag = "y2";
        } else if (transform.position.y > 0) {
            cubeGroupY = 3;
            gameObject.transform.Find("tagY").tag = "y3";
        }
        if (transform.position.z < 0) {
            cubeGroupZ = 1;
            gameObject.transform.Find("tagZ").tag = "z1";
        } else if (transform.position.z == 0) {
            cubeGroupZ = 2;
            gameObject.transform.Find("tagZ").tag = "z2";
        } else if (transform.position.z > 0) {
            cubeGroupZ = 3;
            gameObject.transform.Find("tagZ").tag = "z3";
        }
    }

    void getFaceNormals() {
        // cycle through the cubes faces and update their tags with their normals
        for (int i = 0; i < 6; i++) {
            Vector3 normal = gameObject.transform.GetChild(i).transform.forward;
            if (normal.x != 0) {
                gameObject.transform.GetChild(i).tag = "x";
            } else if (normal.y != 0) {
                gameObject.transform.GetChild(i).tag = "y";
            } else if (normal.z != 0) {
                gameObject.transform.GetChild(i).tag = "z";
            }
        }
    }
}

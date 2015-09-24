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
        //highlightCubeFace();
    }

    public void updateCube() {
        getCubeGroups();
        getFaceNormals();
    }

    void getCubeGroups() {
        if (transform.position.x < -0.5) {
            transform.position = new Vector3(-1, transform.position.y, transform.position.z);

            cubeGroupX = 1;
            transform.Find("tagX").tag = "x1";
        } else if (-0.5 < transform.position.x && transform.position.x < 0.5) {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);

            cubeGroupX = 2;
            transform.Find("tagX").tag = "x2";
        } else if (transform.position.x > 0.5) {
            transform.position = new Vector3(1, transform.position.y, transform.position.z);

            cubeGroupX = 3;
            transform.Find("tagX").tag = "x3";
        }

        if (transform.position.y < -0.5) {
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);

            cubeGroupY = 1;
            transform.Find("tagY").tag = "y1";
        } else if (-0.5 < transform.position.y && transform.position.y < 0.5) {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

            cubeGroupY = 2;
            transform.Find("tagY").tag = "y2";
        } else if (transform.position.y > 0.5) {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);

            cubeGroupY = 3;
            transform.Find("tagY").tag = "y3";
        }

        if (transform.position.z < -0.5) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);

            cubeGroupZ = 1;
            transform.Find("tagZ").tag = "z1";
        } else if (-0.5 < transform.position.z && transform.position.z < 0.5) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            cubeGroupZ = 2;
            transform.Find("tagZ").tag = "z2";
        } else if (transform.position.z > 0.5) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);

            cubeGroupZ = 3;
            transform.Find("tagZ").tag = "z3";
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

    //void highlightCubeFace() {
    //    for (int i = 0; i < 6; i++) {
    //        transform.GetChild(i)
    //        Texture colour = transform.GetChild(i).GetComponent<Renderer>().material.mainTexture;
    //        Debug.Log(colour);
    //    }
    //}
}

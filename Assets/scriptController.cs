﻿using UnityEngine;
using System.Collections;

public class scriptController : MonoBehaviour
{

    //public GameObject[] groupXTags;
    //public GameObject[] groupYTags;
    //public GameObject[] groupZTags;

    GameObject[] cubesHor;
    GameObject[] cubesVer;

    Vector3[] rotationAxes = new Vector3[2];

    Vector2 clickStart;
    Vector2 clickEnd;
    Vector2 swipe;
    string swipeDirection;

    public scriptCube cubeScript;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        handleClick();
    }

    void handleClick() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) { // find which face of a cube has been selected, the group it belongs to and the direction the rotate

                // highlight hit face
                //Material colour = hitInfo.transform.GetComponent<Renderer>().material;
                //string name  = colour.name+"Highlight";
                //colour = new Material.

                // get the groups of the selected cube face
                string faceTag = hitInfo.transform.gameObject.transform.tag;
                string[] groupTags = new string[2];
                if (faceTag == "x") {
                    groupTags[0] = "Y";
                    groupTags[1] = "Z";
                    rotationAxes[0] = Vector3.forward;
                    rotationAxes[1] = Vector3.down;
                }
                if (faceTag == "y") {
                    groupTags[0] = "Y";
                    groupTags[1] = "X";
                    rotationAxes[0] = Vector3.right;
                    rotationAxes[1] = Vector3.down;
                }
                if (faceTag == "z") {
                    groupTags[0] = "Y";
                    groupTags[1] = "X";
                    rotationAxes[0] = Vector3.right;
                    rotationAxes[1] = Vector3.down;
                }

                string hor = hitInfo.transform.parent.gameObject.transform.FindChild("tag" + groupTags[0]).tag;
                string ver = hitInfo.transform.parent.gameObject.transform.FindChild("tag" + groupTags[1]).tag;

                cubesHor = GameObject.FindGameObjectsWithTag(hor);
                cubesVer = GameObject.FindGameObjectsWithTag(ver);

                // get initial click position for direction of rotation
                clickStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            }
        }
        if (Input.GetMouseButtonUp(0)) {
            // get the end of the click position
            clickEnd = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // creat a vector between the click start and end and normalize
            swipe = new Vector2(clickEnd.x - clickStart.x, clickEnd.y - clickStart.y);
            swipe.Normalize();

            // find direction of swipe and rotate cubes
            if (swipe.y > 0 && swipe.x > -0.5f && swipe.x < 0.5f) {
                swipeDirection = "up";
                rotateGroup(cubesVer, rotationAxes[0], true);
            }
            if (swipe.y < 0 && swipe.x > -0.5f && swipe.x < 0.5f) {
                swipeDirection = "down";
                rotateGroup(cubesVer, rotationAxes[0], false);
            }
            if (swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f) {
                swipeDirection = "right";
                rotateGroup(cubesHor, rotationAxes[1], true);
            }
            if (swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f) {
                swipeDirection = "left";
                rotateGroup(cubesHor, rotationAxes[1], false);
            }
        }
    }

    void rotateGroup(GameObject[] tags, Vector3 axis, bool clockwise) {
        int direction;
        if (clockwise) {
            direction = 90;
        } else {
            direction = -90;
        }
        foreach (GameObject tag in tags) {
            tag.transform.parent.gameObject.transform.RotateAround(Vector3.zero, axis, direction);
            // update the cubes with their new positions and add them to their new groups
            cubeScript = tag.transform.parent.gameObject.GetComponent<scriptCube>();
            cubeScript.updateCube();
        }
    }
}

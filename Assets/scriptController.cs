using UnityEngine;
using System.Collections;

public class scriptController : MonoBehaviour {

    public GameObject[] groupXTags;
    public GameObject[] groupYTags;
    public GameObject[] groupZTags;

    Vector2 clickStart;
    Vector2 clickEnd;
    Vector2 swipe;
    string swipeDirection;

    public scriptCube cubeScript;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        click();
	}

    void click() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) { // find which face of a cube has been selected, the group it belongs to and the direction the rotate

                // get initial click position for direction of rotation
                clickStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                // get the groups of the selected cube
                string x = hitInfo.transform.parent.gameObject.transform.FindChild("tagX").tag;
                string y = hitInfo.transform.parent.gameObject.transform.FindChild("tagY").tag;
                string z = hitInfo.transform.parent.gameObject.transform.FindChild("tagZ").tag;

                groupXTags = GameObject.FindGameObjectsWithTag(x);
                groupYTags = GameObject.FindGameObjectsWithTag(y);
                groupZTags = GameObject.FindGameObjectsWithTag(z);
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
                rotateGroup(groupXTags, Vector3.right, true);
            }
            if (swipe.y < 0 && swipe.x > -0.5f && swipe.x < 0.5f) {
                swipeDirection = "down";
                rotateGroup(groupXTags, Vector3.right, false);
            }
            if (swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f) {
                Debug.Log("right");
                swipeDirection = "right";
                rotateGroup(groupYTags, Vector3.down, true);
            }
            if (swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f) {
                Debug.Log("Left");
                swipeDirection = "left";
                rotateGroup(groupYTags, Vector3.down, false);
            }

            // update cube groups
            //cubeScript.getCubeGroups();
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
        }
    }

    void updateGroup() {
        // rotating around an axis doesn't effect that value, so you can treat it as a 2D rotation, ie. +90 = transpose and reverse rows, -90 transpose and reverse columns
    }
}

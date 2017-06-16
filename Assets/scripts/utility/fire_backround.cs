using UnityEngine;
using System.Collections;

public class fire_backround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        Debug.logger.Log("info", "pressed");
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        g.GetComponent<player_movment>().shoot();
    }
}

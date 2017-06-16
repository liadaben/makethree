using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class jar_system : MonoBehaviour {
    public int MAX_NUM_OF_BALLS = 6;
    public List<jar> m_jars;
    private positions m_position;
	// Use this for initialization
	void Start () {
        m_jars = new List<jar>();
        m_position = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<positions>();
        foreach(float pos in m_position.position_values) {
            m_jars.Add(new jar(MAX_NUM_OF_BALLS));
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void add_ball(Ball b, int pos) {
        //Debug.logger.Log("info", "adding ball to " + pos.ToString());

        if (m_jars[pos].add_ball(b)) {
            SceneManager.LoadScene("mainmenu");
        }
    }
}

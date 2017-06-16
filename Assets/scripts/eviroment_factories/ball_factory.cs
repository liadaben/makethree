using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ball_factory : MonoBehaviour {
    public float y_to_drop = 5.0f;
    public List<int> balls_prob;
    public List<Ball> balls;
    public List<KeyValuePair<int, Ball>> myList;

    public float time_between_balls = 1.0f;
    private timer m_wait_for_next_ball;
    // Use this for initialization
    void Start () {
        m_wait_for_next_ball = new timer(time_between_balls);
    }
	
	// Update is called once per frame
	void Update () {
        if (!m_wait_for_next_ball.did_time_passed()) {
            return;
        }
        GetComponent<victory>().update_for_win_next_ball();

        positions p = GetComponent<positions>();

        int type_ball = (int)Random.Range(0, balls.Count);
        int place_index = (int)Random.Range(0, p.position_values.Count);

        Ball ball_to_create = balls[type_ball];
       
        float position_x = p.position_values[place_index];
        Vector3 fin_pos = new Vector3(position_x, y_to_drop);
        GameObject g = (GameObject)Instantiate(ball_to_create.gameObject, fin_pos, Quaternion.identity);
        g.GetComponent<Ball>().pos_index = place_index;
        g.GetComponent<Ball>().ball_index = type_ball;
    }
}

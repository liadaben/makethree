using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ball : MonoBehaviour {

    public int pos_index;
    public int ball_index;
    private positions position;
    public bool collied;
    // Use this for initialization
    void Start() {
        collied = false;
        position = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<positions>();
    }

    // Update is called once per frame
    void Update() {

    }

    public abstract List<bool> check_for_destroy(List<Ball> balls, int my_pos);

    public abstract Player get_player_from_ball();

    public Ball get_ball_clone() {
        ball_factory j = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ball_factory>();
        return j.balls[ball_index];
    }

    protected List<bool> get_false_list(List<Ball> balls) {
        List<bool> res = new List<bool>();
        for (int i = 0; i < balls.Count; i++) {
            res.Add(false);
        }
        return res;
    }

    void pass_ball(float y) {
        collied = true;
        Vector3 ball_pos = transform.position;
        ball_pos.y -= y;
        transform.position = ball_pos;
        jar_system j = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<jar_system>();
        j.add_ball(this, pos_index);
    }

    void OnCollisionEnter(Collision col) {
        if(collied) {
            return;
        }
        if (col.transform.tag == "ball") {
            if (col.transform.position.y <= transform.position.y) {
                Destroy(gameObject);
            }
        }
        if (col.transform.tag == "Player") {
            player_movment p = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movment>();
            if (p.is_avliable()) {
                p.set_player(this.get_player_from_ball());
                Destroy(gameObject);
            }
            else {
                pass_ball(2.2f);
                return;
            }
        }
        if (col.transform.tag == "floor") {
            //Debug.logger.Log("info", "adding ball place" + this.pos_index.ToString());
            //Debug.logger.Log("info", "adding ball color" + (this as ColoredBall).ball_color.ToString());
            pass_ball(1.2f);
        }
    }
}

using UnityEngine;
using System.Collections;
using System;

public class ColoredPlayer : Player {

    public ColoredBall.BallColors m_color;
    private Ball m_ball;

    public ColoredPlayer(ColoredBall.BallColors color, Ball b) {
        m_ball = b;
        m_color = color;
    }

    public override void update_player() {
        m_player.GetComponent<Renderer>().material.color = ColoredBall.get_color(m_color);
    }

    public override void shoot() {
        player_movment player_mov = m_player.GetComponent<player_movment>();



        float position_x = player_mov.position.position_values[player_mov.get_player_index()];
        Vector3 fin_pos = new Vector3(position_x, m_player.transform.position.y - 2f);
        GameObject g = (GameObject)GameObject.Instantiate(m_ball.gameObject, fin_pos, Quaternion.identity);
        g.GetComponent<Ball>().pos_index = player_mov.get_player_index();
        g.GetComponent<Ball>().ball_index = m_ball.ball_index;
        g.GetComponent<Ball>().collied = true;
        jar_system j = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<jar_system>();
        j.add_ball(g.GetComponent<Ball>(), player_mov.get_player_index());

    }

    public override bool is_avliable() {
        return false;
    }
}

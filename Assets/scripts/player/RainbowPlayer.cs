using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RainbowPlayer : Player {

    private Ball m_ball;

    private int color_index;
    private timer m_wait_for_next_move;
    List<ColoredBall.BallColors> m_inner_colors;

    public RainbowPlayer(float time_to_wait, Ball b, List<ColoredBall.BallColors> inner_colors) {
        m_wait_for_next_move = new timer(time_to_wait);
        m_ball = b;
        m_inner_colors = inner_colors;
    }

    public override void update_player() {
        if (!m_wait_for_next_move.did_time_passed()) {
            return;
        }
        var values = System.Enum.GetValues(typeof(ColoredBall.BallColors));
        m_player.GetComponent<Renderer>().material.color = ColoredBall.get_color(m_inner_colors[color_index]);
        color_index++;
        color_index %= m_inner_colors.Count;
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

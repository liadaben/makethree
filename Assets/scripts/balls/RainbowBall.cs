using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainbowBall : Ball {

    public float time_to_wait = 0.2f;
    public List<ColoredBall.BallColors> inner_colors;

    private int color_index;
    private timer m_wait_for_next_move;

    public override Player get_player_from_ball() {
        return new RainbowPlayer(time_to_wait, get_ball_clone(), inner_colors);
    }

    // Use this for initialization
    void Start() {
        m_wait_for_next_move = new timer(time_to_wait);
        color_index = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!m_wait_for_next_move.did_time_passed()) {
            return;
        }
        var values = System.Enum.GetValues(typeof(ColoredBall.BallColors));
        GetComponent<Renderer>().material.color = ColoredBall.get_color(inner_colors[color_index]);
        color_index++;
        color_index %= inner_colors.Count;
    }

    public override List<bool> check_for_destroy(List<Ball> balls, int my_pos) {
        List<bool> res = get_false_list(balls);
        //Debug.logger.Log("info", "adding ball my_pos " + my_pos.ToString());
        //Debug.logger.Log("info", "balls.Count is " + balls.Count.ToString());
        if (my_pos == 0 || my_pos == balls.Count - 1) {
            return res;
        }

        bool ok = false;

        RainbowBall rainbow_ball_down = balls[my_pos - 1] as RainbowBall;
        RainbowBall rainbow_ball_up = balls[my_pos + 1] as RainbowBall;

        ok |= rainbow_ball_down != null || rainbow_ball_up != null;

        ColoredBall colored_ball_down = balls[my_pos - 1] as ColoredBall;
        ColoredBall colored_ball_up = balls[my_pos + 1] as ColoredBall;
        if(colored_ball_down != null && colored_ball_up != null) {
            ok |= colored_ball_up.ball_color == colored_ball_down.ball_color;
        }

        if (ok) {
            res[my_pos - 1] = true;
            res[my_pos] = true;
            res[my_pos + 1] = true;
        }
        return res;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColoredBall : Ball {

    public enum BallColors { RED, GREEN, BLUE, YELLOW };

    public BallColors ball_color;

    public static Color get_color(BallColors color) {
        switch (color) {
            case BallColors.RED: {
                    return Color.red;
                }
            case BallColors.GREEN: {
                    return Color.green;
                }
            case BallColors.BLUE: {
                    return Color.blue;
                }
            case BallColors.YELLOW: {
                    return Color.yellow;
                }

        }
        return Color.black;
    }

    public override Player get_player_from_ball() {
        return new ColoredPlayer(ball_color, get_ball_clone());
    }

    // Use this for initialization
    void Start() {
        GetComponent<Renderer>().material.color = get_color(ball_color);
    }

    // Update is called once per frame
    void Update() {

    }

    public override List<bool> check_for_destroy(List<Ball> balls, int my_pos) {
        List<bool> res = get_false_list(balls);
        //Debug.logger.Log("info", "adding ball my_pos " + my_pos.ToString());
        //Debug.logger.Log("info", "balls.Count is " + balls.Count.ToString());
        if (my_pos == 0 || my_pos == balls.Count - 1) {
            return res;
        }

        bool down_ok = false;
        bool up_ok = false;

        ColoredBall colored_ball_down = balls[my_pos - 1] as ColoredBall;
        down_ok |= colored_ball_down != null && ball_color == colored_ball_down.ball_color;
        ColoredBall colored_ball_up = balls[my_pos + 1] as ColoredBall;
        up_ok |= colored_ball_up != null && ball_color == colored_ball_up.ball_color;

        RainbowBall rainbow_ball_down = balls[my_pos - 1] as RainbowBall;
        down_ok |= rainbow_ball_down != null;
        RainbowBall rainbow_ball_up = balls[my_pos + 1] as RainbowBall;
        up_ok |= rainbow_ball_up != null;


        if (down_ok && up_ok) {
            res[my_pos - 1] = true;
            res[my_pos] = true;
            res[my_pos + 1] = true;
        }

        return res;
    }
}

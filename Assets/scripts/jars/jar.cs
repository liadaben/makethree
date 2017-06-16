using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class jar {
    public List<Ball> balls;
    private int m_max_ball;
    public jar(int max_num_of_balls) {
        balls = new List<Ball>();
        m_max_ball = max_num_of_balls;
    }

    public bool add_ball(Ball b) {
        
        
        balls.Add(b);

        List<bool> ball_max = new List<bool>();
        int max_balls_destroyed = 0;
        for(int i = 0;i < balls.Count;i++) {
            List<bool> ball_destroyed = balls[i].check_for_destroy(balls, i);
            if(get_num_of_balls_destroyed(ball_destroyed) > max_balls_destroyed) {
                max_balls_destroyed = get_num_of_balls_destroyed(ball_destroyed);
                ball_max = ball_destroyed;
            }
        }
        if (max_balls_destroyed != 0) {
            for (int i = balls.Count - 1; i >= 0; i--) {
                if(ball_max[i]) {
                    UnityEngine.Object.Destroy(balls[i].gameObject);
                    balls.RemoveAt(i);
                }
            }

        }

        if (balls.Count >= m_max_ball) {
            return true;
        }

        return false;
    }

    private int get_num_of_balls_destroyed(List<bool> ball_destroyed) {
        int c = 0;
        foreach (bool b in ball_destroyed) {
            if(b) {
                c++;
            }
        }
        return c;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class BallVictory : victory {

    public int num_of_balls = 50;
    private float ball_so_far;

    public float text_width;
    public float text_height;

    void start() {
        ball_so_far = 0;
    }

    public override bool checkwin() {
        ball_so_far++;
        if (ball_so_far >= num_of_balls) {
            return true;
        }
        return false;
    }

    void OnGUI() {

        float button_width_abs = Screen.width / this.text_width;
        float button_height_abs = Screen.height / this.text_height;

        Rect text_rect = new Rect(Screen.width / 2.0f,
                                         0,
                                         button_width_abs,
                                         button_height_abs);

        GUI.Button(text_rect, "Ball left: " + max(0,(num_of_balls - ball_so_far)).ToString());
    }

    private object max(int v1, float v2) {
        if( v1 > v2) {
            return v1;
        }
        return v2;
    }
}

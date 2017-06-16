using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeVictory : victory {

    public float play_time = 1.0f;
    private float time_so_far;

    public float text_width;
    public float text_height;

    void start() {
        time_so_far = 0;
    }

    public override bool checkwin() {
        time_so_far += Time.deltaTime;
        if (time_so_far > play_time) {
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

        GUI.Button(text_rect, "Time left: " + ((int)((play_time - time_so_far) * 100)).ToString());
    }
}

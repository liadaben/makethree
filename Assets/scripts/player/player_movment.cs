using UnityEngine;
using System.Collections;

public class player_movment : MonoBehaviour {
    public const float PUSH_SENSETIVITY = 0.3f;
    public float DIST_PER_PUSH = 0.2f;
    public float SPEED = 0.1f;

    public float MAX_RANGE = 6.0f;

    public float button_width = 2.0f;
    public float button_highet = 2.0f;

    private timer m_wait_for_next_move;
    private int m_button_pressed;

    private int position_index;
    public positions position;

    private Player player;
    // Use this for initialization
    void Start() {
        player = new DefultPlayer();

        m_wait_for_next_move = new timer(SPEED);
        position = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<positions>();
        position_index = 0;
        Vector3 player_pos = transform.position;
        player_pos.x = position.position_values[position_index];
        transform.position = player_pos;
    }

    public void set_player(Player p) {
        player = p;
    }

    public int get_player_index() {
        return position_index;
    }

    public bool is_avliable() {
        return player.is_avliable();
    }

    public void shoot() {
        player.shoot();
        player = new DefultPlayer();
        return;
    }
    // Update is called once per frame
    void Update() {
        player.update_player();

        float in_shoot = Input.GetAxis("Fire");
        if (in_shoot > PUSH_SENSETIVITY) {
            player.shoot();
            player = new DefultPlayer();
            return;
        }
        if (!m_wait_for_next_move.did_time_passed()) {
            return;
        }
        float in_dir = Input.GetAxis("Horizontal");
        Vector3 player_pos = transform.position;
        //Debug.logger.Log("info", in_dir.ToString());
        if (in_dir > PUSH_SENSETIVITY || m_button_pressed == 1) {
            
            if (position_index < position.position_values.Count - 1) {
                position_index++;
                player_pos.x = position.position_values[position_index];
                transform.position = player_pos;
            }
        } else if (in_dir < -1 * PUSH_SENSETIVITY || m_button_pressed == -1) {
            if (position_index > 0) {
                position_index--;
                player_pos.x = position.position_values[position_index];
                transform.position = player_pos;
            }

        }
        m_button_pressed = 0;
    }

    void OnGUI() {
        GUIStyle custom_button = new GUIStyle("button");
        custom_button.fontSize = Screen.width / 20;

        float button_width_abs = Screen.width / this.button_width;
        float button_height_abs = Screen.height / this.button_highet;

        Rect left_button_rect = new Rect(Screen.width - button_width_abs,
                                         Screen.height - button_height_abs + 20,
                                         button_width_abs,
                                         button_height_abs);
        Rect right_button_rect = new Rect(0, Screen.height - button_height_abs + 20, button_width_abs, button_height_abs);
        if (GUI.RepeatButton(left_button_rect, "left", custom_button)) {
            m_button_pressed = 1;
        }
        if (GUI.RepeatButton(right_button_rect, "right", custom_button)) {
            m_button_pressed = -1;
        }

    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class victory : MonoBehaviour {

    public int next_level_num;

    public void update_for_win_next_ball() {
        if(checkwin()) {
            PlayerPrefs.SetInt("level", next_level_num);
            SceneManager.LoadScene("level" + next_level_num.ToString());
        }
    }

    public abstract bool checkwin();
}

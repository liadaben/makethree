using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_level : MonoBehaviour {

    public int max_level = 1;
    private int level_selected;
	// Use this for initialization
	void Start () {
        level_selected = 1;
        
        max_level = PlayerPrefs.GetInt("level");
        if(max_level == 0) {
            PlayerPrefs.SetInt("level", 1);
            max_level = 1;
        }
        GameObject g = GameObject.FindGameObjectWithTag("scroll");
        if (max_level == 1) {
            Destroy(g);
            Destroy(GameObject.FindGameObjectWithTag("loader"));
        } else {
            g.GetComponent<Scrollbar>().size = 1.0f / (float)max_level;
            g.GetComponent<Scrollbar>().numberOfSteps = max_level;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void load_new_level() {
        SceneManager.LoadScene("level1");
    }

    public void continue_level() {
        SceneManager.LoadScene("level" + level_selected.ToString());
    }

    public void set_level_to_load(float level) {
        Debug.logger.Log("info", "levl info" + level.ToString());
        level_selected = (int)((level * (max_level - 1)) + 1);
        GameObject g = GameObject.FindGameObjectWithTag("loader");
        g.GetComponentsInChildren<Text>()[0].text = "Load level: " + level_selected.ToString();
    }
}

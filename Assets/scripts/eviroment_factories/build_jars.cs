using UnityEngine;
using System.Collections;

public class build_jars : MonoBehaviour {

    public GameObject jar_prefab;
    public float y_index = 0.0f;
	// Use this for initialization
	void Start () {
        positions position = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<positions>();
        
        foreach (float pos in position.position_values) {
            Vector3 pos_vec = new Vector3(pos, y_index, 0.0f);
            Instantiate(jar_prefab, pos_vec, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

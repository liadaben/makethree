using UnityEngine;
using System.Collections;
using System;

public class DefultPlayer : Player {

    public override void update_player() {
        m_player.GetComponent<Renderer>().material.color = Color.cyan;
    }

    public override void shoot() { }

    public override bool is_avliable() {
        return true;
    }
}

using UnityEngine;
using System.Collections;

public abstract class Player {

    protected GameObject m_player;
    public Player() {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    public abstract void update_player();

    public abstract void shoot();

    public abstract bool is_avliable();


}

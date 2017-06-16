using UnityEngine;
using System.Collections;

public class timer {

    private float m_inner_time;
    private float m_time_to_wait;

    public timer(float time_to_wait) {
        m_inner_time = 0;
        m_time_to_wait = time_to_wait;
    }

    public bool did_time_passed() {
        m_inner_time += Time.deltaTime;
        if(m_time_to_wait < m_inner_time) {
            m_inner_time = 0;
            return true;
        }
        return false;
    }
}

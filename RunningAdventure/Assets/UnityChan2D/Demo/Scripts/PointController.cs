using System;
using UnityEngine;

public class PointController : MonoBehaviour
{

    public GUIText higthscore;
    public GUIText score;

    private static PointController m_instance;

    public static PointController instance
    {
        get
        {
            if (m_instance == false)
            {
                m_instance = FindObjectOfType<PointController>();
            }
            return m_instance;
        }
    }

    public void AddCoin()
    {
        score.text = (Convert.ToInt32(score.text) + 1).ToString();
        higthscore.text = (Convert.ToInt32(higthscore.text) + 100).ToString("0000000");
    }
}

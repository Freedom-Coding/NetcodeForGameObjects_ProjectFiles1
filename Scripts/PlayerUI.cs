using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] Player player;

    private void Update()
    {
        if (player != null)
        {
            scoreText.text = "Score: " + player.playerScore;
        }
    }
}

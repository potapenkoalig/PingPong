using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCtrl : MonoBehaviour
{
    [SerializeField] Text best_score;

    Text text;

    int top_player_score, down_player_score;

    void UpdateBestScoreText()
    {
        best_score.text = "Best score - " + FileSaveLoad.bestScoreDown + ":" + FileSaveLoad.bestScoreTop;
    }

    void UpdateText()
    {
        text.text = top_player_score + "\n" + down_player_score;
    }

    public void ResetScore()
    {
        top_player_score  = 0;
        down_player_score = 0;
        UpdateText();
    }

    public void ScoreTopPlayer()
    {
        top_player_score++;
        UpdateText();
    }

    public void ScoreDownPlayer()
    {
        down_player_score++;
        /* Best score for down player - max difference between his score and opponent score */
        if (down_player_score - top_player_score > FileSaveLoad.bestScoreDown - FileSaveLoad.bestScoreTop)
        {
            FileSaveLoad.bestScoreTop = top_player_score;
            FileSaveLoad.bestScoreDown = down_player_score;
            UpdateBestScoreText();
            FileSaveLoad.SaveFile();
        }
        UpdateText();
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        UpdateBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

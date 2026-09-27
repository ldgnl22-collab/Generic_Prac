using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBinder : MonoBehaviour
{
    private void Start()
    {
        BindScoreEvent();
    }

    private void OnDisable()
    {
        UnBindScoreEvent();
    }

    private void OnScoreChanged(int score)
    {
        Debug.Log($"ScoreBinder: {score}");
    }

    private void BindScoreEvent()
    {
        ScoreManager.Instance.OnChangedScore.AddListener(OnScoreChanged);
    }
    
    private void UnBindScoreEvent()
    {
        ScoreManager.Instance.OnChangedScore.RemoveListener(OnScoreChanged);
    }
}

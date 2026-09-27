using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    
    public static ScoreManager Instance
    {
        get;
        private set;
    }

    [SerializeField] private UnityEvent<int> _onChangedScore;

    public UnityEvent<int> OnChangedScore => _onChangedScore;
    
    private void Awake() => SetSingleton();

    public void AddScore(int score)
    {
        _score += score;
        
        OnChangedScore.Invoke(_score);
    }
    
    private void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}

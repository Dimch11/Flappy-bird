using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator
{
    private Settings _settings;
    private Obstacle.Factory _obstacleFactory;
    private AsyncProcessor _asyncProcessor;
    private InputPanel _inputPanel;

    private bool _isGenerating = false;

    private Obstacle _curObstacle;
    private float _curDistanceBetweenObstacles;
    private float _curSpaceBetweenObstacleParts;

    public ObstacleGenerator(Obstacle.Factory obstacleFactory, Settings settings, 
        AsyncProcessor asyncProcessor, InputPanel inputPanel)
    {
        _settings = settings;
        _obstacleFactory = obstacleFactory;
        _asyncProcessor = asyncProcessor;
        _inputPanel = inputPanel;

        _inputPanel.Clicked += StartGeneratingObstacles;

        _curDistanceBetweenObstacles = _settings.startDistanceBetweenObstacles;
        _curSpaceBetweenObstacleParts = _settings.startSpaceBetweenObstacleParts;
    }

    public void StartGeneratingObstacles()
    {
        _isGenerating = true;
        _asyncProcessor.StartCoroutine(GenerateObstaclesEveryTime());
        _inputPanel.Clicked -= StartGeneratingObstacles;
    }
    public void StopGeneratingObstacles()
    {
        _isGenerating = false;
    }

    private IEnumerator GenerateObstaclesEveryTime()
    {
        while (_isGenerating)
        {
            GenerateObstacle();
            UpdateDifficulty();
            yield return new WaitForSeconds(GetTimeToNextObstacleGeneration());
        }
    }
    private void GenerateObstacle()
    {
        _curObstacle = _obstacleFactory.Create();
        _curObstacle.SetPosition(_settings.generationPoint);
        SetObstaclePartPositions();
        LaunchObstacle();
    }
    private void SetObstaclePartPositions()
    {
        var spacePosFromBottom = CalcSpaceHeightPos();

        _curObstacle.SetPartHeights(spacePosFromBottom, spacePosFromBottom + _curSpaceBetweenObstacleParts);
    }
    private float CalcSpaceHeightPos()
    {
        return UnityEngine.Random.Range(0, _settings.screenHeightInUnits - _curSpaceBetweenObstacleParts);
    }
    private void LaunchObstacle()
    {
        _curObstacle.Launch(_settings.obstacleSpeed);
    }

    private void UpdateDifficulty()
    {
        UpdateDistanceBetweenObstacles();
        UpdateSpaceBetweenObstacleParts();
    }
    private void UpdateDistanceBetweenObstacles()
    {
        _curDistanceBetweenObstacles -= _settings.stepToDecreaseDistanceBetweenObstacles;
        if (_curDistanceBetweenObstacles < _settings.minDistanceBetweenObstacles)
        {
            _curDistanceBetweenObstacles = _settings.minDistanceBetweenObstacles;
        }
    }
    private void UpdateSpaceBetweenObstacleParts()
    {
        _curSpaceBetweenObstacleParts -= _settings.stepToDecreaseSpaceBetweenObstacleParts;
        if (_curSpaceBetweenObstacleParts < _settings.minSpaceBetweenObstacleParts)
        {
            _curSpaceBetweenObstacleParts = _settings.minSpaceBetweenObstacleParts;
        }
    }

    private float GetTimeToNextObstacleGeneration()
    {
        return _curDistanceBetweenObstacles / _settings.obstacleSpeed;
    }

    [Serializable]
    public class Settings
    {
        public float obstacleSpeed;
        public float screenHeightInUnits;
        public Vector2 generationPoint;

        [Header("Distance between obstacles")]
        public float startDistanceBetweenObstacles;
        public float minDistanceBetweenObstacles;
        public float stepToDecreaseDistanceBetweenObstacles;

        [Header("Space between obstacle parts")]
        public float startSpaceBetweenObstacleParts;
        public float minSpaceBetweenObstacleParts;
        public float stepToDecreaseSpaceBetweenObstacleParts;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator
{
    private Settings _settings;
    private ObstacleGeneratorBehaviour _obstacleGeneratorBeh;
    private AsyncProcessor _asyncProcessor;
    private InputPanel _inputPanel;

    private bool _isGenerating = false;

    private ObstacleBehaviour _curObstacle;
    private float _curDistanceBetweenObstacles;
    private float _curSpaceBetweenObstacleParts;

    public ObstacleGenerator(ObstacleGeneratorBehaviour obstacleGeneratorBeh, Settings settings, 
        AsyncProcessor asyncProcessor, InputPanel inputPanel)
    {
        _settings = settings;
        _obstacleGeneratorBeh = obstacleGeneratorBeh;
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
        _curObstacle = _obstacleGeneratorBeh.InstantiateObstacle();
        SetObstaclePartPositions();
        LaunchObstacle();
    }
    private void SetObstaclePartPositions()
    {
        var spaceHeightPos = CalcSpaceHeightPos();

        _curObstacle.SetDownPartHeight(spaceHeightPos);
        _curObstacle.SetUpPartHeight(spaceHeightPos + _curSpaceBetweenObstacleParts);
    }
    private float CalcSpaceHeightPos()
    {
        return UnityEngine.Random.Range(0, _settings.screenHeightInUnits - _curSpaceBetweenObstacleParts);
    }
    private void LaunchObstacle()
    {
        _obstacleGeneratorBeh.SetObstacleSpeed(_curObstacle, _settings.obstacleSpeed);
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

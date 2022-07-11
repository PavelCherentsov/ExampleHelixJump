using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private float _additinalScale;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private float _startAndFinishAdditinalScale = 0.5f;
    private SceneLoader _sceneLoader;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditinalScale + _additinalScale/2;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
        _levelCount = _sceneLoader.CurrentLevel;
        Build();
    }

    private void Build()
    {
        var beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        var spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y  - _additinalScale;

        SpawnPlatform(_startPlatform, ref spawnPosition, transform);

        for (var i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition,transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, 
                    spawnPosition, 
                    Quaternion.Euler(0,Random.Range(0,360),0), 
                    parent);
        spawnPosition.y -= 1;
    }
}

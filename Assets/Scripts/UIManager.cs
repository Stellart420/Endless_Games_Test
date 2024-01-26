using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_InputField speedInput;
    public TMP_InputField distancecInput;
    public TMP_InputField spawnIntervalInput;

    public delegate void SpeedlChanged(float newSpeed);
    public static event SpeedlChanged OnSpeedChanged;
    public delegate void DistanceChanged(float newwDistance);
    public static event DistanceChanged OnDistanceChanged;
    public delegate void SpawnIntervalChanged(float newInterval);
    public static event SpawnIntervalChanged OnSpawnIntervalChanged;

    private void Awake()
    {
        Instance = this;
        speedInput.onValueChanged.AddListener(UpdateSpeed);
        distancecInput.onValueChanged.AddListener(UpdateDistance);
        spawnIntervalInput.onValueChanged.AddListener(UpdateSpawnInterval);
    }

    private void OnDestroy()
    {
        Instance = null;
        speedInput.onValueChanged.RemoveListener(UpdateSpeed);
        distancecInput.onValueChanged.RemoveListener(UpdateDistance);
        spawnIntervalInput.onValueChanged.RemoveListener(UpdateSpawnInterval);
    }

    public void UpdateSpeed(string tex)
    {
        if (float.TryParse(speedInput.text, out float newSpeed))
        {
            newSpeed = Mathf.Max(newSpeed, 0.1f);
            OnSpeedChanged?.Invoke(newSpeed);
        }
    }

    public void UpdateDistance(string tex)
    {
        if (float.TryParse(distancecInput.text, out float newDistance))
        {
            newDistance = Mathf.Max(newDistance, 0.1f);
            OnDistanceChanged?.Invoke(newDistance);
        }
    }

    public void UpdateSpawnInterval(string tex)
    {
        if (float.TryParse(spawnIntervalInput.text, out float newInterval))
        {
            newInterval = Mathf.Max(newInterval, 0.1f);
            OnSpawnIntervalChanged?.Invoke(newInterval);
        }
    }
}


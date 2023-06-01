using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text timer;
    private float elapsedTime;
    private bool isRunning;

    private void Start()
    {
        timer = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            timer.text = $"Time: {elapsedTime.ToString("00")}";
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
    }

    public string GetElapsedTime()
    {
        return $"Time: {elapsedTime.ToString("00")}";
    }
}
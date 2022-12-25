using UnityEngine;

public class Timer 
{
    private float _time;

    public Timer(float timeParam = 0)
    {
        this._time = timeParam;
    }

    public void ResetTimer()
    {
        _time = 0f;
    }

    public void Tick()
    {
        _time += Time.deltaTime;
    }

    public float GetTime()
    {
        return _time;
    }
}

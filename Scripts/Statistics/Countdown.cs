using UnityEngine;

public class Countdown 
{
  public float _time;
  public float _originalTime;

  public Countdown(float timeParam = 0.0f)
  {
    this._time = 0.0f;
    this._originalTime = timeParam;
  }

  public void Tick()
  {
    _time -= Time.deltaTime;
  }

  public void Reset()
  {
    _time = _originalTime;
  }

  public void Reset(float newTime)
  {
    _time = newTime;
  }


  public float TimeLeft()
  {
      if (_time > 0.0f) {
        return _time;
      } else {
        return 0.0f;
      }
  }

  public bool TimeEnded()
  {
      if (_time > 0.0f) {
        return false;
      } else {
        return true;
      }
  }

}

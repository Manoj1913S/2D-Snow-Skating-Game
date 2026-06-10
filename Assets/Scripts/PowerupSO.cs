using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float ValueChange;
    [SerializeField] float time;

    public string GetPowerupType()
    {
        return powerupType;
    }

    public float GetValueChange()
    {
        return ValueChange;
    }
    public float GetTime()
    {
      return time;   
    }
}

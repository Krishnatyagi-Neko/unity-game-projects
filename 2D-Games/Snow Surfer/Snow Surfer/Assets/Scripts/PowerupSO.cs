using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] string powerupTypes;
    [SerializeField] float valueChange;
    [SerializeField] float time ;


    public string GetPowerType()
    {
        return powerupTypes;
    }

    public float GetValueChange()
    {
        return valueChange;
    }

    public float GetTime()
    {
        return time;
    }






}

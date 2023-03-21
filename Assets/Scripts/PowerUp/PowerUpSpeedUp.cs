using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up SpeedUp")]
    public float amountToSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Speed Up");
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeed);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.ResetSpeed();
    }
}

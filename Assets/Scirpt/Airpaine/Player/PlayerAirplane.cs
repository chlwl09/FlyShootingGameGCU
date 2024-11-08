using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirplane : AireplaneBase
{
    protected override void OnDeath()
    {
        Debug.Log("게임 종료");
        // 게임이 종료되는 UI가 생성되게 구현
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirplane : AireplaneBase
{
    protected override void OnDeath()
    {
        Debug.Log("���� ����");
        // ������ ����Ǵ� UI�� �����ǰ� ����
    }
}

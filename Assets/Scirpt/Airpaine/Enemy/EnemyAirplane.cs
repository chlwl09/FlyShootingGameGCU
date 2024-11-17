using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirplane : AirplaneBase
{
    protected override void OnDeath()
    {
        Debug.Log("적 처지");
        ScoreUp();
        Destroy(gameObject);
    }

    /// <summary>
    /// 처치시 점수가 추가됨
    /// </summary>
    public void ScoreUp()
    {
        //점수 관련 로직
    }
}

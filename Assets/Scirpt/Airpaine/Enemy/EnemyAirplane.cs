using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirplane : AireplaneBase
{
    protected override void OnDeath()
    {
        Debug.Log("�� ó��");
        ScoreUp();
        Destroy(gameObject);
    }

    /// <summary>
    /// óġ�� ������ �߰���
    /// </summary>
    public void ScoreUp()
    {
        //���� ���� ����
    }
}
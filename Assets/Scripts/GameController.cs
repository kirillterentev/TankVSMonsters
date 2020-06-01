using System.Collections;
using System.Collections.Generic;
using BattleVehicle;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private TankController player;
	[SerializeField]
	private MonsterController monster;

    void Start()
    {
        monster.SetTarget(player);
    }
}

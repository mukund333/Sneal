﻿using SnealUltra.Assets._Project.Scripts.Player;
using SnealUltra.Assets._Project.Scripts.Weapon;

using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace SnealUltra.Assets._Project.Scripts.Pickup
{
	[RequireComponent(typeof(Collider2D))]
	public class PickupController : MonoBehaviour
	{

		//
		public string powerUpName;
		public int poolId;
		public PickupData thisPickup;

		private PickupBoost pickupBoost;
		private delegate void PickupBoost();

		public bool WeaponBool = false;
		// SpriteRenderer wepSpriteRend;

		public PlayerStats playerStats;
		public CurrentPlayerComponentData player;

		private void Awake()
		{		
			playerStats = FindObjectOfType<PlayerStats>();
			player = playerStats.GetComponent<CurrentPlayerComponentData>();
		}


		private void OnEnable()
		{
			InitPickup();
		}


		private void InitPickup()
		{
			thisPickup = PickupDatabase.instance.GetPickupRandom();

			switch (thisPickup.pickupType)
			{
				case PickupData.PickupType.Repair:
					pickupBoost = new PickupBoost(Repair);
					break;

				case PickupData.PickupType.Invincibility:
					pickupBoost = new PickupBoost(Invincibility);
					break;

				case PickupData.PickupType.Speed:
					pickupBoost = new PickupBoost(Speed);
					break;

				case PickupData.PickupType.Weapon:
					pickupBoost = new PickupBoost(WeaponPick);
					WeaponBool = true;
					break;

			}
		}


		private void OnTriggerEnter2D(Collider2D col)
		{
			
			if (col.CompareTag("Player"))
			{
				pickupBoost();
			
				if (WeaponBool == true)
				{
					player.isEquipDirect = true;
				}
				gameObject.SetActive(false);
			}
		}


		private void Repair()
		{
			playerStats.Repair();
		}

		private void Invincibility()
		{
			playerStats.Invincibility();
		}

		private void Speed()
		{
			playerStats.Speed();
		}

		private void WeaponPick()
		{

			
		}

		public string GetPowerUpName()
		{
			 powerUpName = thisPickup.Name;
			return powerUpName;
		}
		public void SetPowerUpPoolId(int poolid)
		{
			this.poolId = poolid;
			thisPickup.poolId = poolid;
		}

		public Vector2 GetSpawnFreqRange()
		{
			return thisPickup.spawnFreqRange;
		}

		public int GetSpawnStartTime()
		{
			return thisPickup.spawnStartTime;
		}

		public AnimationCurve GetCurve()
		{
			return thisPickup.curve;
		}

		public int GetMaxFreq()
		{
			return thisPickup.timeToMaxSpawnFreq;
	}

	}
}
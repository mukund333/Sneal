﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Player
{
	public class PlayerDatabase : MonoBehaviour
	{
		//public PlayerStruct[] players;

		public PlayerData_SO[] players;

		//private static PlayerDatabase _instance;

		//public static PlayerDatabase instance
		//{
		//	get
		//	{
		//		if (_instance == null)
		//		{
		//			_instance = FindObjectOfType<PlayerDatabase>();
		//		}
		//		return _instance;
		//	}
		//}

		private void Start()
		{
			//for (int i = 0; i < players.Length; i++)
			//{
			//	players[i].index = i;
			//}

			for (int i = 0; i < players.Length; i++)
			{
				players[i].index = i;
			}
		}


		//public PlayerStruct GetPlayer(int index)
		//{
		//	for (int i = 0; i < players.Length; i++)
		//	{
		//		if (i == index)
		//		{
		//			return players[i];
		//		}
		//	}
		//	return players[0];
		//}

		public PlayerData_SO GetPlayer(int index)
		{
			for (int i = 0; i < players.Length; i++)
			{
				if (i == index)
				{
					return players[i];
				}
			}
			return players[0];
		}




	}
}
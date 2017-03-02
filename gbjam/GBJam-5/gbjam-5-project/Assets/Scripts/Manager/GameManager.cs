using UnityEngine;
using System.Collections;

public static class GameManager  {

	public static Dungeon Dungeon {get; private set;}

	public static void SetupDungeon(Dungeon dungeon){
		Dungeon = dungeon;
	}
}

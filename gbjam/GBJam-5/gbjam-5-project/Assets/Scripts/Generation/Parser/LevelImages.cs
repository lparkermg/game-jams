using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelImages : MonoBehaviour {

	public List<Texture2D> LevelMaps;
	public List<Texture2D> ItemMaps;

	public LevelRenderer LevelRend;

	// Use this for initialization
	void Start () {
		GameManager.SetupDungeon(MakeLevel (12345));
		StartCoroutine (LevelRend.RenderLevel (GameManager.Dungeon.Sections [0]));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Dungeon MakeLevel(int seed){
		Random.seed = seed;
		ImageToParser.Initilise (20, 18);//(y,x)
		var dungeonSize = Random.Range (3, 10);
		var spawnNumber = Random.Range (1, dungeonSize * dungeonSize);
		var dungeonSections = new List<DungeonSection> ();
		var count = 0;
		Debug.Log ("Dungeon Size: " + dungeonSize);
		for(var x = 0; x< dungeonSize;x++){
			for(var y = 0; y < dungeonSize;y++){
				var section = Random.Range (0,LevelMaps.Count);
				var spawn = false;
				if (spawnNumber == count)
					spawn = true;
				dungeonSections.Add (ImageToParser.ToDungeon (LevelMaps [section], ItemMaps [section], spawn, x, y,GetEdgeType(x,y,dungeonSize)));
			}
		}
		Debug.Log ("Section Count: " + dungeonSections.Count);
		return new Dungeon (seed, dungeonSections);
	}

	private string GetEdgeType(int x, int y,int maxSize){
		var edges = "";
		if(x == 0)
			edges += "south ";

		if(y == 0)
			edges += "west ";

		if(x == maxSize - 1)
			edges += "north ";

		if(y == maxSize - 1)
			edges += "east ";

		return edges;
			
	}
}

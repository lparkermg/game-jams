using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelImages : MonoBehaviour {

	public List<Texture2D> LevelMaps;
	public List<Texture2D> ItemMaps;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Dungeon MakeLevel(int seed){
		//TODO: Maybe change to fill the entire dungeon and shrink dungeon size to something like 5 by 5 and only remove the exits on edges.
		Random.seed = seed;
		ImageToParser.Initilise (20, 18);
		var sectionCount = 10;
		var dungeonSections = new List<DungeonSection> ();
		for(var i = 0; i< sectionCount;i++){
			var section = Random.Range (LevelMaps.Count);
			var spawn = false;
			if (i == 0)
				spawn = true;
			dungeonSections.Add(ImageToParser.ToDungeon(LevelMaps[section],ItemMaps[section],spawn,))
		}
	}
}

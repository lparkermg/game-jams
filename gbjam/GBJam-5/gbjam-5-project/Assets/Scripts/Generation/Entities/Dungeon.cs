using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dungeon{

	public int Seed;
	public List<DungeonSection> Sections;

	public Dungeon(int seed, List<DungeonSection> sections){
		Seed = seed;
		Sections = sections;
	}
}

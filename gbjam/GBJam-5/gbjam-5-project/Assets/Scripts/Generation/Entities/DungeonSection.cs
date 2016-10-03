using UnityEngine;
using System.Collections;

public class DungeonSection {

	public int[,] ItemLocations { get; private set;}
	public int[,] TileLocations { get; private set;}
	public SectionDoors Doors { get; private set;}
	public SectionCoord Position { get; private set;}
	public bool SpawnSection { get; private set;}

	public DungeonSection(int[,] items, int[,] tiles, SectionDoors doors, SectionCoord position,bool spawn){
		ItemLocations = items;
		TileLocations = tiles;
		Doors = doors;
		Position = position;
		SpawnSection = spawn;
	}

	public int RemoveItemAt(int x, int y){
		if (ItemLocations [x, y] == 1) {
			return 1;
		} else if (ItemLocations [x, y] == 2) {
			return 5;
		} else {
			return 0;
		}
	}
}

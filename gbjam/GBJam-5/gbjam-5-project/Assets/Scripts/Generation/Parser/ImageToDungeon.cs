using UnityEngine;
using System.Collections;

public static class ImageToParser{

	//Info

	//TileMap
	/*
	* Black = Walls(1),
	* White = floors (0),
	* Red = Traps(2),
	* Blue = floor (To Next Area)(3)
	*/

	//ItemMap
	/*
	* White = No item (0),
	* Black = Coin (1),
	* Red = Gem (2)
	*/

	private static bool _initialized = false;
	public static int Width { get; private set;}
	public static int Height { get; private set;}

	public static void Initilise(int height,int width){
		Height = height;
		Width = width;
		_initialized = true;
	}

	public static DungeonSection ToDungeon(Texture2D tileMap, Texture2D itemMap, bool spawn, int x, int y, string edge){
		var tiles = ParseTileMap (tileMap);
		var items = ParseItemMap (itemMap);
		var doors = CheckDoors (tiles,edge);
		return new DungeonSection (items, tiles, doors, new SectionCoord (x, y), spawn);
	}

	private static SectionDoors CheckDoors(int[,] tileMap, string edge){
		var doors = new SectionDoors(false,false,false,false);

		for(var x = 0; x < Width;x++){
			if(tileMap[x,Height - 1] == 3 && edge.Contains("north")){
				doors.NorthExit = true;
			}
		}

		for(var y = 0; y < Height; y++){
			if(tileMap[Width - 1,y] == 3 && edge.Contains("east")){
				doors.EastExit = true;
			}
		}

		for(var y = 0; y < Height; y++){
			if(tileMap[0,y] == 3 && edge.Contains("south")){
				doors.SouthExit = true;
			}
		}
			
		for(var x = 0; x < Width; x++){
			if(tileMap[x,0] == 3 && edge.Contains("west")){
				doors.WestExit = true;
			}
		}

		return doors;
	}

	private static int[,] ParseItemMap(Texture2D itemMap){
		var items = new int[Width,Height];

		for(var x = 0; x < itemMap.width;x++){
			for(var y = 0; y < itemMap.height;y++){
				items [x, y] = ColourToNumber (itemMap.GetPixel (x, y),true);
			}
		}

		return items;
	}

	private static int[,] ParseTileMap(Texture2D tileMap){
		var tiles = new int[Width, Height];
		
		for(var x = 0; x < tileMap.width;x++){
			for(var y = 0; y < tileMap.height;y++){
				tiles [x, y] = ColourToNumber (tileMap.GetPixel (x, y), false);
			}
		}

		return tiles;
	}

	private static int ColourToNumber(Color pixelColour, bool isItem){
		if(!isItem){
			if (pixelColour == Color.white) {
				return 0;
			} else if (pixelColour == Color.black) {
				return 1;
			} else if (pixelColour == Color.red) {
				return 2;
			} else if (pixelColour == Color.blue) {
				return 3;
			}else {
				return 0;
			}
		}
		else{
			if (pixelColour == Color.white) {
				return 0;
			} else if (pixelColour == Color.black) {
				return 1;
			} else if (pixelColour == Color.red) {
				return 2;
			} else {
				return 0;
			}
		}
	}
}

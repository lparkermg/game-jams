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

	public static DungeonSection ToDungeon(Texture2D tileMap, Texture2D itemMap, bool spawn, int x, int y){
		var tiles = ParseTileMap (tileMap);
		var items = ParseItemMap (itemMap);
		var doors = CheckDoors (tiles);
		return new DungeonSection (itemMap, tileMap, doors, new SectionCoord (x, y), spawn);
	}

	private static SectionDoors CheckDoors(int[,] tileMap){
		var doors = new SectionDoors(false,false,false,false);

		for(var x = 0; x < Width;x++){
			if(tileMap[x,Height - 1] == 3){
				doors.NorthExit = true;
			}
		}

		for(var y = 0; y < Height; y++){
			if(tileMap[Width - 1,y] == 3){
				doors.EastExit = true;
			}
		}

		for(var y = 0; y < Height; y++){
			if(tileMap[0,y] == 3){
				doors.SouthExit = true;
			}
		}
			
		for(var x = 0; x < Width; x++){
			if(tileMap[x,0] == 3){
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
			switch(pixelColour){
			case(Color.white):
				return 0;
			case(Color.black):
				return 1;
			case(Color.red):
				return 2;
			case(Color.blue):
				return 3;
			default:
				return 0;
			}
		}
		else{
			switch(pixelColour){
			case(Color.white):
				return 0;
			case(Color.black):
				return 1;
			case(Color.red):
				return 2;
			default:
				return 0;
			}
		}
	}
}

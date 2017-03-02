using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelRenderer : MonoBehaviour {

	public GameObject WallTile;
	public GameObject FloorTile;

	public GameObject DoorOpenTile;
	public GameObject DoorClosedTile;

	public GameObject TrapTile;

	public GameObject CoinObject;
	public GameObject GemObject;

	public List<GameObject> RenderedObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator RenderLevel(DungeonSection sectionToRender){
		var height = 20;
		var width = 18;

		for(var x = 0; x < width;x++){
			for(var y = 0; y < height; y++){
				var tileCode = sectionToRender.TileLocations [x, y];
				var itemCode = sectionToRender.ItemLocations [x, y];
				var doors = DoorCheck (sectionToRender.Doors,x,y);
				var tileGo = CodeToGameObject (tileCode,doors,false);
				var itemGo = CodeToGameObject (itemCode, doors, true);
				var pos = new Vector3 ((x * 0.5f),(y * 0.5f),0.0f);
				var itemPos = new Vector3 ((x * 0.5f), (y * 0.5f), -1.0f);
				if (itemGo != null) {
					GameObject itm = GameObject.Instantiate (itemGo, itemPos, transform.rotation) as GameObject;
					RenderedObjects.Add (itm);
				}
				GameObject go = GameObject.Instantiate (tileGo, pos, tileGo.transform.rotation) as GameObject;
				RenderedObjects.Add (go);
			}
		}
		yield return null;
	}

	private bool DoorCheck(SectionDoors doors,int x, int y){
		return false;
	}

	private GameObject CodeToGameObject(int code,bool doorOpen, bool isItem){
		if(!isItem){
			switch(code){
			case(0):
				return FloorTile;
			case(1):
				return WallTile;
			case(2):
				return TrapTile;
			case(3):
				if(doorOpen){
					return DoorOpenTile;
				}
				else{
					return DoorClosedTile;
				}
			default:
				return FloorTile;
			}
		}
		else{
			switch(code){
			case(0):
				return null;
			case(1):
				return CoinObject;
			case(2):
				return  GemObject;
			default:
				return null;
			}
		}
	}
}

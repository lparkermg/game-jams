using UnityEngine;
using System.Collections;

public class SectionDoors{
	public bool NorthExit;
	public bool EastExit;
	public bool SouthExit;
	public bool WestExit;

	public SectionDoors(bool north, bool east, bool south, bool west){
		NorthExit = north;
		EastExit = east;
		SouthExit = south;
		WestExit = west;
	}
}
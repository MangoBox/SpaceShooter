using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ShipData", menuName = "ShipData", order = 1)]
public class ShipData : ScriptableObject {

	[Header("Ship Information")]
	public string displayName;
	public ShipType shipType;
	public ShipRarity shipRarity;
	public GameObject shipPrefab;

	[Header("Ship Physics")]
	public float accelerationMultiplier = 1f;
	public float speedMultipler = 1f;



	public ShipController createShipController() {
		ShipController sc = new ShipController ();
		applyData (sc);
		return sc;
	}


	//Return type not strictly nessceary due to a reference type, however we are using it for other overloads.
	public ShipController applyData(ShipController sc) {
		sc.accelerationMultipler = accelerationMultiplier;
		sc.speedMultipler = speedMultipler;
		return sc;
	}
}

public enum ShipType {
	Cruiser,
	Racer
}

public enum ShipRarity {
	Common,
	Rare,
	Supership,
	Hypership
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrolWeapon : MonoBehaviour {
	public GameObject Weapon1;
	public GameObject Weapon2;
	public GameObject Weapon3;
	public int MaxWeapon = 3;

    
    private int ScrolInt;
	
	void Start () {
		
	}
	
	
	void Update () {
		if (ScrolInt == 0) {
			Weapon1.SetActive (true);
			Weapon2.SetActive (false);
			Weapon3.SetActive (false);

        }
		if (ScrolInt == 1) {
			Weapon1.SetActive (false);
			Weapon2.SetActive (true);
			Weapon3.SetActive (false);

        }
		if (ScrolInt == 2) {
			Weapon1.SetActive (false);
			Weapon2.SetActive (false);
			Weapon3.SetActive (true);


        }
		if (ScrolInt < 0) {
			ScrolInt = 3;
		}
		if (ScrolInt >= 4) {
			ScrolInt = 0;
		}
		if (Input.GetKeyDown(KeyCode.E)) { 
			ScrolInt += 1;
		}if (Input.GetKeyDown(KeyCode.Q)) { 
			ScrolInt -= 1;
		}
	}
}
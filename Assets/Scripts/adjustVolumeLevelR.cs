using UnityEngine;
using System.Collections;

public class adjustVolumeLevelR : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void changeVolumeR(float volumeLevel){
		GetComponent<AudioSource> ().volume = volumeLevel;
	}

}

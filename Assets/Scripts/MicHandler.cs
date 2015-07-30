using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MicHandler : MonoBehaviour {

	public AudioSource audioSauce;
	public AudioSource audioSauceR;
	public AudioSource audioMaster;
	public string CurrentAudioInput = "none";
	public Text textObject;
	private AudioClip masterClip;

	int deviceNum = 0;
	
	void Start()
	{
		
		string[] inputDevices = new string[Microphone.devices.Length];
		deviceNum = 0;
		
		for (int i = 0; i < Microphone.devices.Length; i++) {
			inputDevices [i] = Microphone.devices [i].ToString ();
			Debug.Log("Device: " + inputDevices [i]);
		}
		CurrentAudioInput = Microphone.devices[deviceNum].ToString();
		StartMic ();
	}
	
	public const float freq = 24000f;
	
	public void StartMic(){
		audioMaster.clip = Microphone.Start(CurrentAudioInput, true, 5, (int) freq); 
		masterClip = audioMaster.clip;
	}

	void Update() {
		audioSauce.clip = masterClip;
		audioSauceR.clip = masterClip;
		if (textObject.text.Equals("Turn Off Hearing Aid")) {
				
			if (Input.GetKeyDown(KeyCode.Equals))
			{
				Microphone.End (CurrentAudioInput);
				deviceNum+= 1;
				if (deviceNum > Microphone.devices.Length - 1)
					deviceNum = 0;
				CurrentAudioInput = Microphone.devices[deviceNum].ToString();
				
				StartMic ();
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				audioSauce.Play ();
				audioSauceR.Play ();
			}

			float delay = 0.030f;
			int microphoneSamples = Microphone.GetPosition (CurrentAudioInput);
			//		Debug.Log ("Current samples: " + microphoneSamples);
			if (microphoneSamples / freq > delay) {
				if (!audioSauce.isPlaying) {
					audioSauce.timeSamples = (int) (microphoneSamples - (delay * freq));
					audioSauce.Play ();
				}
				if (!audioSauceR.isPlaying) {
					audioSauceR.timeSamples = (int) (microphoneSamples - (delay * freq));
					audioSauceR.Play ();
				}
			}
		}
	}
}

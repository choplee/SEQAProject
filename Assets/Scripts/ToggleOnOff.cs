using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleOnOff : MonoBehaviour {

	public Text textObject;
	public Button button1;
	Color colorGreen = new Color(192, 223, 217);
	Color colorRed = new Color(230, 39, 57);
	ColorBlock buttonColors;

	public void onClick(){
		if (textObject.text.Equals( "Turn On Hearing Aid")) {
			textObject.text = "Turn Off Hearing Aid";
			buttonColors = button1.colors;
			buttonColors.normalColor = colorRed;
			button1.colors = buttonColors;
		}
		else{
			textObject.text = "Turn On Hearing Aid";
			buttonColors = button1.colors;
			buttonColors.normalColor = colorGreen;
			button1.colors = buttonColors;
		}
	}
}

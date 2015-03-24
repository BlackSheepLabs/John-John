using UnityEngine;
using System.Collections;

public class PracticeRGBSlider : MonoBehaviour {

	public Color newColor;
	public Material objMat;

	void OnGUI () {
		newColor = RGBSlider(new Rect (350,425,100,20),newColor);
	}

	Color RGBSlider (Rect screenRect, Color rgb) {
		rgb.r = PracticeCompoundControls.LabelSlider(screenRect,rgb.r,1.0f,"Red");

		screenRect.y+=20;
		rgb.g = PracticeCompoundControls.LabelSlider(screenRect,rgb.g,1.0f,"Green");

		screenRect.y+=20;
		rgb.b = PracticeCompoundControls.LabelSlider(screenRect,rgb.b,1.0f,"Blue");

		return rgb;
	}

	void Update(){
		objMat.color = newColor;
	}
}

using UnityEngine;
using System.Collections;

public class PracticeCompoundControls : MonoBehaviour {

	public static float LabelSlider (Rect screenRect, float sliderValue, float sliderMaxValue, string labelText){
		GUI.Label(screenRect,labelText);

		screenRect.x+=screenRect.width;
		sliderValue = GUI.HorizontalSlider(screenRect,sliderValue,0.0f,sliderMaxValue);
		return sliderValue;
	}
}

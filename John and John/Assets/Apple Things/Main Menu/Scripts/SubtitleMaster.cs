using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

//http://forum.unity3d.com/threads/17753-What-s-the-least-boring-way-to-do-subtitles
public class SubtitleMaster : MonoBehaviour {
	//Holds functions for the game to display subtitles

	//filename - The name of the file in string format
	//totalLines - The total number of lines in the file
	//To be used in the start of each scene
	public static bool loadText(string filename,int totalLines,string[] dialogue){
		StreamReader reader = new StreamReader(filename,Encoding.Default);
		string curLine;
		int i = 0;

		try{
			using (reader){
				curLine = reader.ReadLine();		//Reads current line up until a '\n'
				
				while (curLine != null && i < totalLines){
					dialogue[i] = curLine;
					curLine = reader.ReadLine();
				}
				
				reader.Close();
				return true;
			}
		}
		catch (IOException e){
			Debug.LogError(e.Message);
			return false;
		}
	}

	//time - The length of the audio clip
	//display - while this is true, the subtitle will be displayed
	public static IEnumerator displaySubtitle(float time,bool display){
		display = true;
		yield return new WaitForSeconds(time);
		display = false;
	}

}

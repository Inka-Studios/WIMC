using UnityEngine;
using System.Collections;

public class GetScores : MonoBehaviour
{
	
		// Public variables
		public UILabel myScore;
		public UILabel myRank;
		public UILabel myName;
		public UILabel Scores;
		public string GetHighscoreUrl = "inkastudios.com/ScriptsPHPparaManejodeBD/WhereisMyCebiche/getHighscore.php";
		private string name = "Name";
		private string score = "Score";
		private string WindowTitel = "";
		private string Score = "";

		public int maxNameLength = 10;
		public int getLimitScore = 15;

		void Start ()
		{
				StartCoroutine ("GetScore");	
		}
	
		void Update ()
		{

		}

		IEnumerator GetScore ()
		{
				Score = "";
		
				WindowTitel = "Loading";
		
				WWWForm form = new WWWForm ();
				form.AddField ("limit", getLimitScore);
		
				WWW www = new WWW (GetHighscoreUrl, form);
				yield return www;
		
				if (www.text == "") {
						print ("There was an error getting the high score: " + www.error);
						WindowTitel = "There was an error getting the high score";
				} else {
						WindowTitel = "Done";
						Scores.text = www.text;
				}
				Debug.Log ("Entro coroutine GetScore");
				Scores.fontSize = 20;
		}
}

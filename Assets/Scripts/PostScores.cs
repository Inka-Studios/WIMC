﻿using UnityEngine;
using System.Collections;
using System.Text;
using System.Security;

public class PostScores : MonoBehaviour
{
		public string secretKey = "12345";
		public string PostScoreUrl = "inkastudios.com/ScriptsPHPparaManejodeBD/WhereisMyCebiche/postScore.php";
		private string name = "Name";
		private string score = "Score";
		private string WindowTitel = "";
		private string Score = "";

		void Start ()
		{

		}

		void Update ()
		{

		}

		public IEnumerator PostScore (string name, int score)
		{
				string _name = name;
				int _score = score;

				string hash = Md5Sum (_name + _score + secretKey).ToLower ();

				WWWForm form = new WWWForm ();
				form.AddField ("name", _name);
				form.AddField ("score", _score);
				form.AddField ("hash", hash);

				WWW www = new WWW (PostScoreUrl, form);
				WindowTitel = "Wait";
				yield return www;

				if (www.text != "done") {
						Debug.Log ("There was an error posting the high score: " + www.error);
				} else
						Debug.Log ("Se posteo name: " + name + " score: " + score);
		}

		public string Md5Sum (string input)
		{
				System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create ();
				byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes (input);
				byte[] hash = md5.ComputeHash (inputBytes);

				StringBuilder sb = new StringBuilder ();
				for (int i = 0; i < hash.Length; i++) {
						sb.Append (hash [i].ToString ("X2"));
				}
				return sb.ToString ();
		}
}

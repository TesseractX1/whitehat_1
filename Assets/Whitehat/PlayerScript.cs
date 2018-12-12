namespace Whitehat.Player{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class PlayerScript : MonoBehaviour {
		public Text cpuNum;
		public Text ramNum;
		public int cpu = 0;
		public int ram = 0;
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			cpuNum.text = ""+cpu;
			ramNum.text = ""+ram;
		}
	}
}

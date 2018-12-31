using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	//public int cpuNum;
	//public GameObject ramNum;
	public Text cpucounter;
	public Text ramcounter;
	public int cpu = 0;
	public int ram = 0;
	// Update is called once per frame
	void Update () {
		cpucounter.text = cpu.ToString();
		ramcounter.text = ram.ToString();
	}
}

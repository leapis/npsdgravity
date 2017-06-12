using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class newplanet : MonoBehaviour {

	GameObject newp;
	public GameObject planet;
	public InputField InputFieldMass, InputFieldxPos, InputFieldyPos, InputFieldxVel, InputFieldyVel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void doNow(){

		newp = Instantiate (planet, new Vector3 (float.Parse(InputFieldxPos.text), float.Parse(InputFieldyPos.text), 0), Quaternion.Euler (0, 0, 0));
		newp.GetComponent<gravity> ().Mass = float.Parse (InputFieldMass.text);
		newp.GetComponent<gravity> ().xVel = float.Parse (InputFieldxVel.text);
		newp.GetComponent<gravity> ().yVel = float.Parse (InputFieldyVel.text);
		
	}
}

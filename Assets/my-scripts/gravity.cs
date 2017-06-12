using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {

	float grav_const = 0;
	float xPos,xAcc,yPos,yAcc,zPos,zVel,zAcc,distance,fG;
	public float Mass = 1;
	public GameObject[] planets;
	public float xVel = 0;
	public float yVel = 16/2;

	// Use this for initialization
	void Start () {
		zVel = 0;
		grav_const = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		xPos = transform.position.x;
		yPos = transform.position.y;
		zPos = transform.position.z;

		planets = GameObject.FindGameObjectsWithTag ("planet");
		foreach (GameObject planet in planets) {

			float pXPos, pYPos, pZPos, pMass;
			pMass = planet.GetComponent<gravity>().Mass;
			pXPos = planet.transform.position.x;
			pYPos = planet.transform.position.y;
			pZPos = planet.transform.position.z;

			distance = Mathf.Sqrt (Mathf.Pow (xPos - pXPos, 2) + Mathf.Pow (yPos - pYPos, 2) + Mathf.Pow (zPos - pZPos, 2));

			fG = grav_const * pMass / Mathf.Pow (distance, 2);

			zAcc = 0;

			xAcc = ((xPos - pXPos) / distance) * fG;
			yAcc = ((yPos - pYPos)/ distance) * fG;

			zVel = zVel + zAcc;
			if (xPos - pXPos > 1/10) {

				xVel = xVel - xAcc;
			} else if (xPos - pXPos < - 1/10){
				xVel = xVel - xAcc;
			}
			if (yPos - pYPos > 1/10) {

				yVel = yVel - yAcc;
			} else if (yPos - pYPos < - 1/10){
				yVel = yVel - yAcc;
			}
			
		}
			


		//Debug.Log ("xpos: " + xPos + "; ypos: " + yPos);
		transform.position = new Vector3 (xPos + xVel * Time.deltaTime, yPos + yVel * Time.deltaTime, zPos + zVel * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;

namespace UrbanAirshipTutorial
{
	public class UrbanAirshipTutorial : MonoBehaviour {

		// Use this for initialization
		void Start () {

			// Enter additional configuration here
			DDNA.Instance.ClientVersion = "v1.0.0";
			DDNA.Instance.SetLoggingLevel(DeltaDNA.Logger.Level.DEBUG);

			// Launch the SDK
			DDNA.Instance.StartSDK(
				"79390137655202368653993446815131",
				"https://collect12606ttrlr.deltadna.net/collect/api",
				"https://engage12606ttrlr.deltadna.net"
			);

		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
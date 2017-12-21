using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;
using UrbanAirship ; 

namespace UrbanAirshipTutorial
{
	public class UrbanAirshipTutorial : MonoBehaviour {

		public string addTagOnStart ;

		void Awake() {

			UAirship.Shared.UserNotificationsEnabled = true; 
			
		}

		// Use this for initialization
		void Start ()
		{
			if (!string.IsNullOrEmpty (addTagOnStart)) {
				UAirship.Shared.AddTag (addTagOnStart);
			}

			UAirship.Shared.OnPushReceived += OnPushReceived;
			UAirship.Shared.OnChannelUpdated += OnChannelUpdated;
			UAirship.Shared.OnDeepLinkReceived += OnDeepLinkReceived;



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

		void OnDestroy ()
		{
			UAirship.Shared.OnPushReceived -= OnPushReceived;
			UAirship.Shared.OnChannelUpdated -= OnChannelUpdated;
			UAirship.Shared.OnDeepLinkReceived -= OnDeepLinkReceived;
		}

		void OnPushReceived(PushMessage message) {
			Debug.Log ("Received push! " + message.Alert);

			if (message.Extras != null) {
				foreach (KeyValuePair<string, string> kvp in message.Extras) {
					Debug.Log (string.Format ("Extras Key = {0}, Value = {1}", kvp.Key, kvp.Value));
				}
			}
		}

		void OnChannelUpdated(string channelId) {
			Debug.Log ("Channel updated: " + channelId);
		}

		void OnDeepLinkReceived(string deeplink) {
			Debug.Log ("Received deep link: " + deeplink);
		}
	}
}
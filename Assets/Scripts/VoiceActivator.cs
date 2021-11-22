using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Oculus.Voice
{
    public class VoiceActivator : MonoBehaviour
    {
        [SerializeField] private AppVoiceExperience voiceController;
        public UnityEvent onButton, onTrigger;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) onTrigger.Invoke();
            // if (OVRInput.GetDown(OVRInput.Button.One)) onButton.Invoke();


            if (OVRInput.GetDown(OVRInput.Button.One)) 
            {
                voiceController.Activate();
                onButton.Invoke();
            }
            // if (Input.GetKeyDown(KeyCode.W)) voiceController.Activate();
        }




    }
}
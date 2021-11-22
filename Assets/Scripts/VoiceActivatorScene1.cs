using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Oculus.Voice
{
    public class VoiceActivatorScene1 : MonoBehaviour
    {
        [SerializeField] private AppVoiceExperience voiceController;
        [SerializeField] private CTABuilder CTABuilder;
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
                if(!CTABuilder.inMenu)
                {
                    voiceController.Activate();
                }
            }
            // if (Input.GetKeyDown(KeyCode.W)) voiceController.Activate();
        }




    }
}
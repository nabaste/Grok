using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Show off all the Debug UI components.
public class DisclaimerBuilder : MonoBehaviour
{
    bool inMenu;
    private Text sliderText;
    public GameObject ConfirmAudioSource, DenyAudioSource, VoiceOverAudioSource, BKGAudioSource;
    void Start()
    {
        DebugUIBuilder.instance.AddLabel("The following experience is a fictional representation of the scenes associated with real life events experienced by some people with the mental condition. The experience is in no way intended to represent what it is like having the mental condition in the physical world or a means to find a solution to the problem of symptoms of the mental condition. It is simply a way to understand parts of the symptoms experienced during the mental condition better and to generate awareness and empathy in regards to those who have the mental condition. You have the option to end this experience anytime at your will by exiting the application or simply saying Unspace *app name*, to return to home.", 2);
        DebugUIBuilder.instance.AddDivider(0);
        DebugUIBuilder.instance.AddButton("Continue", ContinueButtonPressed);
        DebugUIBuilder.instance.AddButton("Go Back", BackButtonPressed);

        // DebugUIBuilder.instance.AddLabel("Label");
        // var sliderPrefab = DebugUIBuilder.instance.AddSlider("Slider", 1.0f, 10.0f, SliderPressed, true);
        // var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        // Assert.AreEqual(textElementsInSlider.Length, 2, "Slider prefab format requires 2 text components (label + value)");
        // sliderText = textElementsInSlider[1];
        // Assert.IsNotNull(sliderText, "No text component on slider prefab");
        // sliderText.text = sliderPrefab.GetComponentInChildren<Slider>().value.ToString();
        // DebugUIBuilder.instance.AddDivider();
        // DebugUIBuilder.instance.AddToggle("Toggle", TogglePressed);
        // DebugUIBuilder.instance.AddRadio("Radio1", "group", delegate(Toggle t) { RadioPressed("Radio1", "group", t); }) ;
        // DebugUIBuilder.instance.AddRadio("Radio2", "group", delegate(Toggle t) { RadioPressed("Radio2", "group", t); }) ;
        // DebugUIBuilder.instance.AddLabel("Secondary Tab", 1);
        // DebugUIBuilder.instance.AddDivider(1);
        // DebugUIBuilder.instance.AddRadio("Side Radio 1", "group2", delegate(Toggle t) { RadioPressed("Side Radio 1", "group2", t); }, DebugUIBuilder.DEBUG_PANE_RIGHT);
        // DebugUIBuilder.instance.AddRadio("Side Radio 2", "group2", delegate(Toggle t) { RadioPressed("Side Radio 2", "group2", t); }, DebugUIBuilder.DEBUG_PANE_RIGHT);
    }

    public void TogglePressed(Toggle t)
    {
        Debug.Log("Toggle pressed. Is on? " + t.isOn);
    }
    public void RadioPressed(string radioLabel, string group, Toggle t)
    {
        Debug.Log("Radio value changed: " + radioLabel + ", from group " + group + ". New value: " + t.isOn);
    }

    public void SliderPressed(float f)
    {
        Debug.Log("Slider: " + f);
        sliderText.text = f.ToString();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }
    public void ShowMenu()
    {
        DebugUIBuilder.instance.Show();
        VoiceOverAudioSource.GetComponent<AudioSource>().Play();
        BKGAudioSource.GetComponent<AudioSource>().volume = 0.3f;
        inMenu = true;

    }

    void ContinueButtonPressed()
    {
        SceneManager.LoadScene(1);
        ConfirmAudioSource.GetComponent<AudioSource>().Play();
        Debug.Log("Button pressed");
    }

    void BackButtonPressed()
    {
        DenyAudioSource.GetComponent<AudioSource>().Play();
        VoiceOverAudioSource.GetComponent<AudioSource>().Stop();
        BKGAudioSource.GetComponent<AudioSource>().volume = 1f;
        inMenu = false;
        DebugUIBuilder.instance.Hide();
        Debug.Log("back");
    }

    public void PlayVoiceOver()
    {
        VoiceOverAudioSource.GetComponent<AudioSource>().Play();
        BKGAudioSource.GetComponent<AudioSource>().volume = 0.3f;
    }
}

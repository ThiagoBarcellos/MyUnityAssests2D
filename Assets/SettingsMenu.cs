using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audiomixer;

	public Dropdown resolutionDropDown;

	Resolution[] resolutions;

	void Start(){
		resolutions = Screen.resolutions;

		resolutionDropDown.ClearOptions ();

		List<string> options = new List<string> ();

		int CurrResolutionIndex = 0;

		for(int i = 0; i < resolutions.Length; i++){
			string option = resolutions [i].width + " X " + resolutions[i].height;
			options.Add (option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
				CurrResolutionIndex = i;
			}
		}

		resolutionDropDown.AddOptions (options);
		resolutionDropDown.value = CurrResolutionIndex;
		resolutionDropDown.RefreshShownValue ();
	}

	public void setResolution(int resolutionIndex){
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetVolume(float volume){
		audiomixer.SetFloat ("Volume", volume);
	}

	public void SetQuality(int QualityIndex){
		QualitySettings.SetQualityLevel (QualityIndex);
	}

	public void SetFullScreen(bool IsFullScreen){
		Screen.fullScreen = IsFullScreen;
	}
}

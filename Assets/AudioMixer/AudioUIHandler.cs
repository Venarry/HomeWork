using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioMixerHomework
{
    public class AudioUIHandler : MonoBehaviour
    {
        private const string VolumeMaster = "Master";
        private const string VolumeButtons = "Buttons";
        private const string VolumeBackground = "Background";

        [SerializeField] private Button _masterVolumeSwitcher;
        [SerializeField] private Slider _buttonsVolume;
        [SerializeField] private Slider _backgroundVolume;
        [SerializeField] private AudioMixer _audioMixer;

        private void OnEnable()
        {
            _masterVolumeSwitcher.onClick.AddListener(OnMasterVolumeSwitcherClick);
        }

        private void OnMasterVolumeSwitcherClick()
        {
            _audioMixer.SetFloat(VolumeMaster, Mathf.Log10(0) * 20);
        }
    }
}

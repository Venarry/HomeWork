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
        [SerializeField] private Slider _generalVolume;
        [SerializeField] private Slider _buttonsVolume;
        [SerializeField] private Slider _backgroundVolume;
        [SerializeField] private AudioMixer _audioMixer;

        private bool _masterVolumeEnabled = true;

        private void OnEnable()
        {
            _masterVolumeSwitcher.onClick.AddListener(OnMasterVolumeSwitcherClick);
            _generalVolume.onValueChanged.AddListener(OnGeneralVolumeSliderValueChange);
            _buttonsVolume.onValueChanged.AddListener(OnButtonsVolumeSliderValueChange);
            _backgroundVolume.onValueChanged.AddListener(OnBackgroundVolumeSliderValueChange);
        }

        private void OnDisable()
        {
            _masterVolumeSwitcher.onClick.RemoveListener(OnMasterVolumeSwitcherClick);
            _generalVolume.onValueChanged.RemoveListener(OnGeneralVolumeSliderValueChange);
            _buttonsVolume.onValueChanged.RemoveListener(OnButtonsVolumeSliderValueChange);
            _backgroundVolume.onValueChanged.RemoveListener(OnBackgroundVolumeSliderValueChange);
        }

        private void OnGeneralVolumeSliderValueChange(float value)
        {
            SetVolume(VolumeMaster, value);
        }

        private void OnBackgroundVolumeSliderValueChange(float value)
        {
            SetVolume(VolumeBackground, value);
        }

        private void OnButtonsVolumeSliderValueChange(float value)
        {
            SetVolume(VolumeButtons, value);
        }

        private void OnMasterVolumeSwitcherClick()
        {
            _masterVolumeEnabled = !_masterVolumeEnabled;
            float targetVolume = _masterVolumeEnabled ? 1f : 0.0001f;

            SetVolume(VolumeMaster, targetVolume);
        }

        private void SetVolume(string volumeName, float value)
        {
            float minValue = 0.0001f;
            float maxValue = 1f;
            value = Mathf.Clamp(value, minValue, maxValue);

            _audioMixer.SetFloat(volumeName, Mathf.Log10(value) * 20);
        }
    }
}

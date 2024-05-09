using UnityEngine;
using UnityEngine.UI;

namespace AudioMixerHomework
{
    [RequireComponent(typeof(Button))]
    public class ButtonSoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}

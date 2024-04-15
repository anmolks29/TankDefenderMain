using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider bgAudioSlider;
    [SerializeField] private Slider sfxAudioSlider;



    public void SetBgVolume()
    {
        float bgVolume = bgAudioSlider.value;
        audioMixer.SetFloat("BgMusic", Mathf.Log10(bgVolume)*20);
    }

    public void SetSfxVolume()
    {
        float sfxVolume = sfxAudioSlider.value;
        audioMixer.SetFloat("Sfx", Mathf.Log10(sfxVolume)*20);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider bgmVolumeSlider; // Slider untuk mengatur volume BGM
    public Dropdown controlDropdown; // Dropdown untuk memilih kontrol
    private float bgmVolume = 1.0f; // Default volume BGM
    private string controlScheme = "Default"; // Default kontrol

    private void Start()
    {
        // Inisialisasi slider dan dropdown dengan nilai yang disimpan
        bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        controlScheme = PlayerPrefs.GetString("ControlScheme", "Default");

        if (bgmVolumeSlider != null)
        {
            bgmVolumeSlider.value = bgmVolume;
            bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        }

        if (controlDropdown != null)
        {
            controlDropdown.value = controlDropdown.options.FindIndex(option => option.text == controlScheme);
            controlDropdown.onValueChanged.AddListener(SetControlScheme);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume);
        // Atur volume audio source BGM di sini
        AudioListener.volume = bgmVolume;
    }

    public void SetControlScheme(int index)
    {
        controlScheme = controlDropdown.options[index].text;
        PlayerPrefs.SetString("ControlScheme", controlScheme);
        // Implementasikan logika untuk mengubah kontrol berdasarkan controlScheme
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
        Debug.Log("Settings saved.");
    }
} 
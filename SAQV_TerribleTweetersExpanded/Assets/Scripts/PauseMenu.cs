using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] string _musicVolume = "MusicVolume";
    [SerializeField] string _sfxVolume = "SFXVolume";
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _sfxSlider;
    [SerializeField] float _multiplier = 30f;
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        _musicSlider.onValueChanged.AddListener(HandleMusicValueChanged);
        _sfxSlider.onValueChanged.AddListener(HandleSFXValueChanged);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_musicVolume, _musicSlider.value);
        PlayerPrefs.SetFloat(_sfxVolume, _sfxSlider.value);
    }

    private void HandleMusicValueChanged(float arg0)
    {
        _mixer.SetFloat(_musicVolume, Mathf.Log10(arg0)* _multiplier);
    }

    private void HandleSFXValueChanged(float arg0)
    {
        _mixer.SetFloat(_sfxVolume, Mathf.Log10(arg0) * _multiplier);
    }

    void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(_musicVolume, _musicSlider.value);
        _sfxSlider.value = PlayerPrefs.GetFloat(_sfxVolume, _sfxSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused) 
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

//    public 
}

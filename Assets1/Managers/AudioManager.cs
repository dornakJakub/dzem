using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Singleton instance for global access
    public static AudioManager Instance { get; private set; }

    [Header("Main Theme")]
    

    [Header("Main Theme")]
    [SerializeField] private AudioClip mainTheme;
    [SerializeField] [Range(0f, 1f)] private float mainThemeVolume = 0.5f;
    
    [Header("Sound Effects")]
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip achievementSound;
    [SerializeField] private AudioClip errorSound;
    [SerializeField] private AudioClip enddaySound;
    [SerializeField] private AudioClip itemBoughtSound;
    [SerializeField] private AudioClip itemServedSound;
    [SerializeField] private AudioClip dragSound;
    
    [Header("Sound Effects animals")]
    [SerializeField] private AudioClip snakeSound;
    [SerializeField] private AudioClip elephantSound;
    [SerializeField] private AudioClip cibetSound;
    [SerializeField] private AudioClip penguinSound;
    [SerializeField] private AudioClip spiderSound;
    [SerializeField] private AudioClip porcupineSound;
    
    [SerializeField] [Range(0f, 1f)] private float sfxVolume = 1.0f;

    private AudioSource musicSource;
    private AudioSource sfxSource;
    private List<AudioSource> loopingSounds = new List<AudioSource>();

    // Public properties to access current volumes
    public float MainThemeVolume { get; private set; }
    public float SFXVolume { get; private set; }
    public float MasterVolume { get; private set; } = 1f;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetupAudioSources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetupAudioSources()
    {
        // Create music source for main theme
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = mainThemeVolume * MasterVolume;

        // Create SFX source for one-shot sounds
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        
        // Initialize volume properties
        MainThemeVolume = mainThemeVolume;
        SFXVolume = sfxVolume;
    }

    // ==================== VOLUME CONTROL FUNCTIONS ====================

    // Change MAIN THEME volume only
    public void SetMainThemeVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        MainThemeVolume = volume;
        
        if (musicSource != null)
        {
            musicSource.volume = MainThemeVolume * MasterVolume;
        }
    }

    // Change SFX volume only
    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        SFXVolume = volume;
        
        // Update all looping sounds with new volume
        foreach (AudioSource loopingSource in loopingSounds)
        {
            if (loopingSource != null)
            {
                loopingSource.volume = SFXVolume * MasterVolume;
            }
        }
    }

    // Change MASTER volume (affects both music and SFX)
    public void SetMasterVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        MasterVolume = volume;
        
        // Update music volume with new master volume
        if (musicSource != null)
        {
            musicSource.volume = MainThemeVolume * MasterVolume;
        }
        
        // Update all looping sounds with new master volume
        foreach (AudioSource loopingSource in loopingSounds)
        {
            if (loopingSource != null)
            {
                loopingSource.volume = SFXVolume * MasterVolume;
            }
        }
    }

    // Change ALL volumes at once
    public void SetAllVolumes(float masterVolume, float musicVolume, float sfxVolume)
    {
        SetMasterVolume(masterVolume);
        SetMainThemeVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    // Reset all volumes to default (what's set in Inspector)
    public void ResetVolumesToDefault()
    {
        MasterVolume = 1f;
        MainThemeVolume = mainThemeVolume;
        SFXVolume = sfxVolume;
        
        if (musicSource != null)
        {
            musicSource.volume = MainThemeVolume * MasterVolume;
        }
        
        // Update looping sounds
        foreach (AudioSource loopingSource in loopingSounds)
        {
            if (loopingSource != null)
            {
                loopingSource.volume = SFXVolume * MasterVolume;
            }
        }
    }

    public float GetEffectiveMusicVolume()
    {
        return MainThemeVolume * MasterVolume;
    }

    public float GetEffectiveSFXVolume()
    {
        return SFXVolume * MasterVolume;
    }

    // ==================== MAIN THEME FUNCTIONS ====================

    public void PlayMainTheme()
    {
        if (mainTheme != null && musicSource != null)
        {
            musicSource.clip = mainTheme;
            musicSource.Play();
        }
    }

    public void StopMainTheme()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    public void PauseMainTheme()
    {
        if (musicSource != null)
        {
            musicSource.Pause();
        }
    }

    public void ResumeMainTheme()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public bool IsMainThemePaused()
    {
        if (musicSource == null || musicSource.clip == null)
            return false;
        
        // Paused if: has a clip, is not playing, but has playback position (time > 0)
        return !musicSource.isPlaying && musicSource.time > 0f;
    }
    // ==================== SOUND EFFECT FUNCTIONS ====================

    public void PlayButtonClick()
    {
        PlaySFX(buttonClickSound);
    }

    public void PlayAchievementSound()
    {
        PlaySFX(achievementSound);
    }

    public void PlayBuySound()
    {
        PlaySFX(itemBoughtSound);
    }
    public void PlayServeSound()
    {
        PlaySFX(itemServedSound);
    }
    public void PlayEndDaySound()
    {
        PlaySFX(enddaySound);
    }
    public void PlayDragSound()
    {
        PlaySFX(dragSound);
    }
    public void PlayporcupineSound()
    {
        PlaySFX(porcupineSound);
    }
    public void PlaySpiderSound()
    {
        PlaySFX(spiderSound);
    }
    public void PlayPenguinSound()
    {
        PlaySFX(penguinSound);
    }
    public void PlayElephantSound()
    {
        PlaySFX(elephantSound);
    }
    public void PlayCibetSound()
    {
        PlaySFX(cibetSound);
    }
    public void PlaySnakeSound()
    {
        PlaySFX(snakeSound);
    }

    // Generic SFX function for custom sounds
    public void PlaySFX(AudioClip clip, float volumeMultiplier = 1.0f)
    {
        if (clip != null && sfxSource != null)
        {
            float effectiveVolume = SFXVolume * MasterVolume * volumeMultiplier;
            sfxSource.PlayOneShot(clip, effectiveVolume);
        }
    }

    // Stop all sound effects
    public void StopAllSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
        }
    }

    // ==================== LOOPING SOUND FUNCTIONS ====================

    // Play any sound as a loop (returns ID to control it later)
    public int PlayLoopingSound(AudioClip clip, float volumeMultiplier = 1.0f)
    {
        if (clip == null) return -1;

        // Create new AudioSource for this looping sound
        AudioSource loopingSource = gameObject.AddComponent<AudioSource>();
        loopingSource.clip = clip;
        loopingSource.loop = true;
        loopingSource.volume = SFXVolume * MasterVolume * volumeMultiplier;
        loopingSource.Play();

        // Add to our list and return its index as ID
        loopingSounds.Add(loopingSource);
        return loopingSounds.Count - 1;
    }

    // Stop a specific looping sound by ID
    public void StopLoopingSound(int soundID)
    {
        if (soundID >= 0 && soundID < loopingSounds.Count && loopingSounds[soundID] != null)
        {
            loopingSounds[soundID].Stop();
            Destroy(loopingSounds[soundID]);
            loopingSounds[soundID] = null;
        }
    }

    // Stop all looping sounds
    public void StopAllLoopingSounds()
    {
        for (int i = 0; i < loopingSounds.Count; i++)
        {
            if (loopingSounds[i] != null)
            {
                loopingSounds[i].Stop();
                Destroy(loopingSounds[i]);
            }
        }
        loopingSounds.Clear();
    }

    // Pause a specific looping sound
    public void PauseLoopingSound(int soundID)
    {
        if (soundID >= 0 && soundID < loopingSounds.Count && loopingSounds[soundID] != null)
        {
            loopingSounds[soundID].Pause();
        }
    }

    // Resume a specific looping sound
    public void ResumeLoopingSound(int soundID)
    {
        if (soundID >= 0 && soundID < loopingSounds.Count && loopingSounds[soundID] != null)
        {
            loopingSounds[soundID].Play();
        }
    }

    // Change volume of a specific looping sound
    public void SetLoopingSoundVolume(int soundID, float volumeMultiplier)
    {
        if (soundID >= 0 && soundID < loopingSounds.Count && loopingSounds[soundID] != null)
        {
            loopingSounds[soundID].volume = SFXVolume * MasterVolume * volumeMultiplier;
        }
    }

    // Check if a specific looping sound is playing
    public bool IsLoopingSoundPlaying(int soundID)
    {
        if (soundID >= 0 && soundID < loopingSounds.Count && loopingSounds[soundID] != null)
        {
            return loopingSounds[soundID].isPlaying;
        }
        return false;
    }

    // Clean up null references (call this occasionally if you stop many sounds)
    public void CleanUpLoopingSounds()
    {
        loopingSounds.RemoveAll(source => source == null);
    }
}
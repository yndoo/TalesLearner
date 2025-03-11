using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load("SoundManager")).GetComponent<SoundManager>();
            }
            return _instance;
        }
    }

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public List<AudioClip> BGMList;
    public List<AudioClip> SFXList;
    public List<AudioClip> Footsteps;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        sfxSource.volume = 0.6f;
        PlayBGM(EBGMType.Normal);
    }

    #region BGM
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip) return;
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }
    public void PlayBGM(int bgm)
    {
        if (bgmSource.clip == BGMList[bgm]) return;
        bgmSource.clip = BGMList[bgm];
        bgmSource.loop = true;
        bgmSource.Play();
    }
    public void PlayBGM(EBGMType bgm)
    {
        PlayBGM((int)bgm);
    }
    #endregion

    #region SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlaySFX(int sfx)
    {
        sfxSource.PlayOneShot(SFXList[sfx]);
    }
    public void PlaySFX(ESFXType sfx)
    {
        PlaySFX((int)sfx);
    }
    public void PlayFootStep()
    {
        sfxSource.PlayOneShot(Footsteps[Random.Range(0, Footsteps.Count)]);
    }
    #endregion
}

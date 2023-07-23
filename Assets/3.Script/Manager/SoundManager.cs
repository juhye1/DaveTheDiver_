using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBGM
{
    Lobby
}
public enum ESE
{

}
public class SoundManager : DontDestroySingleton<SoundManager>
{
    private Dictionary<EBGM, AudioClip> _bgmDic;
    private Dictionary<ESE, AudioClip> _seDic;

    private AudioSource _bgmAudio = null;
    private AudioSource _seAudio = null;

    public float bgmVolume = 0.5f;
    public float seVolume = 0.5f;

    public void Awake()
    {
        if (_bgmAudio == null)
        {
            GameObject go = new GameObject(typeof(SoundManager).Name);
            go.transform.parent = transform;
            _bgmAudio = go.AddComponent<AudioSource>();
            _bgmAudio.loop = true;
            GameObject go1 = new GameObject("EffectSound");
            go1.transform.parent = transform;
            _seAudio = go1.AddComponent<AudioSource>();
            _seAudio.loop = false;
        }

        _bgmAudio.volume = bgmVolume;
        _seAudio.volume = seVolume;

        _bgmDic = new Dictionary<EBGM, AudioClip>();

        _bgmDic[EBGM.Lobby] = Resources.Load<AudioClip>("BGM/BGM_Lobby");



        _seDic = new Dictionary<ESE, AudioClip>();


    }

    // 효과음 재생
    public void PlaySE(ESE se)
    {
        _seAudio.PlayOneShot(_seDic[se]);
    }

    // 배경음 재생
    public void PlayBGM(EBGM bgm)
    {
        if (!_bgmDic.ContainsKey(bgm))
        {
            Debug.Log("없는 bgm 입니다.");
            return;
        }

        if (_bgmAudio.clip == _bgmDic.ContainsKey(bgm))
        {
            Debug.Log("동일한 clip입니다.");
            return;
        }

        _bgmAudio.Stop();
        _bgmAudio.clip = _bgmDic[bgm];
        _bgmAudio.Play();
    }

    // 배경음 중단
    public void StopBgm()
    {
        _bgmAudio.Stop();
    }

    public void ChangeBGMVolume(float value)
    {
        _bgmAudio.volume = value;
    }

    public void ChangeSEVolume(float value)
    {
        _seAudio.volume = value;
    }

    // 배경음 fade in, out 재생
    public IEnumerator FadeInOutAudioSource(EBGM bgm, float duration = 1.5f)
    {
        if (!_bgmDic.ContainsKey(bgm))
        {
            Debug.Log("없는 bgm 입니다.");
            yield break;
        }

        if (_bgmAudio.clip == null)
        {
            Debug.Log("현재 clip이 없습니다.");
            PlayBGM(bgm);
            yield break;
        }

        if (_bgmAudio.clip == _bgmDic[bgm])
        {
            Debug.Log("동일한 clip입니다.");
            yield break;
        }

        float currentTime = 0;
        AudioClip clip = _bgmDic[bgm];

        // FadeOut
        while (currentTime < duration / 2)
        {
            currentTime += Time.deltaTime;
            _bgmAudio.volume = Mathf.Lerp(bgmVolume, 0, currentTime / (duration / 2));
            yield return null;
        }

        _bgmAudio.Stop();
        _bgmAudio.clip = clip;
        _bgmAudio.Play();

        // FadeIn
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            _bgmAudio.volume = Mathf.Lerp(0, bgmVolume, currentTime / duration);
            yield return null;
        }
    }
}

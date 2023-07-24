using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBGM
{
    Lobby, Sushi, UnderWater, Loading, Title
}
public enum ESE
{
    Dave_Swim, Dave_Dash, Dave_Foot_Lobby, Dave_Foot_Sushi, Dave_Dive,Dave_Breath,
    Dave_Dagger,Dave_Harpoon_Shot, Dave_Harpoon_Aim, Dave_Harpoon_Pull_Loop,
    Dave_Harpoon_Hit,Dave_Harpoon_Catch_Success,
    Dave_Harpoon_Fail,Dave_Harpoon_Return,

    UI_SushibarOpen, UI_SushibarClose, UI_button_click, UI_Lobby_Dive, UI_Ingame_GoUp,
    UI_Mission, UI_Lobby_Reward, UI_Lobby_SushiOpen, 

    Lobby_Boat_Move, Lobby_Night,
    Sushi_Tea_Pouring, Sushi_Tea_Perfect, Sushi_Tea_Good, Sushi_Tea_Bad, Sushi_Dump, Sushi_Bancho_FoodReady,
    Sushi_Customer_Eat,
    Sushi_Customer_Served, Sushi_Customer_Pay, Sushi_Customer_ReadMenu,


    AMB_Birds, VO_Cobra_Nice, VO_Cobra_Normal, VO_Dave_Normal, VO_Dave_Thinking
}
public class SoundManager : DontDestroySingleton<SoundManager>
{
    private Dictionary<EBGM, AudioClip> _bgmDic;
    private Dictionary<ESE, AudioClip> _seDic;

    private AudioSource _bgmAudio = null;
    private AudioSource _seAudio = null;

    public float bgmVolume = 0.5f;
    public float seVolume = 0.7f;

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
        _bgmDic[EBGM.Title] = Resources.Load<AudioClip>("BGM/BGM_Title");
        _bgmDic[EBGM.UnderWater] = Resources.Load<AudioClip>("BGM/BGM_InGame");
        _bgmDic[EBGM.Sushi] = Resources.Load<AudioClip>("BGM/BGM_SushiBar_Night");



        _seDic = new Dictionary<ESE, AudioClip>();

        //UI
        _seDic[ESE.UI_button_click] = Resources.Load<AudioClip>("SFX/ui_button_click");
        _seDic[ESE.UI_SushibarClose] = Resources.Load<AudioClip>("SFX/ui_sushibar_close");
        _seDic[ESE.UI_SushibarOpen] = Resources.Load<AudioClip>("SFX/ui_sushibar_open");
        _seDic[ESE.UI_Lobby_Dive] = Resources.Load<AudioClip>("SFX/ui_lobby_dive_01");
        _seDic[ESE.UI_Ingame_GoUp] = Resources.Load<AudioClip>("SFX/ui_ingame_goup");
        _seDic[ESE.UI_Mission] = Resources.Load<AudioClip>("SFX/ui_mission_update");
        _seDic[ESE.UI_Lobby_Reward] = Resources.Load<AudioClip>("SFX/ui_lobby_reward");
        _seDic[ESE.UI_Lobby_SushiOpen] = Resources.Load<AudioClip>("SFX/ui_lobby_sushi_openpopup");

        //Lobby
        _seDic[ESE.AMB_Birds] = Resources.Load<AudioClip>("SFX/amb_lobby_far_bird");
        _seDic[ESE.Lobby_Boat_Move] = Resources.Load<AudioClip>("SFX/lobby_boat_move");
        _seDic[ESE.Lobby_Night] = Resources.Load<AudioClip>("SFX/amb_lobby_Night");


        //Sushi
        _seDic[ESE.Sushi_Tea_Pouring] = Resources.Load<AudioClip>("SFX/sushi_tea_pouring_02");
        _seDic[ESE.Sushi_Tea_Perfect] = Resources.Load<AudioClip>("SFX/sushi_drink_perfect_04");
        _seDic[ESE.Sushi_Tea_Good] = Resources.Load<AudioClip>("SFX/sushi_drink_good_05");
        _seDic[ESE.Sushi_Tea_Bad] = Resources.Load<AudioClip>("SFX/sushi_drink_bad_02");
        _seDic[ESE.Sushi_Dump] = Resources.Load<AudioClip>("SFX/sushi_dump_02");
        _seDic[ESE.Sushi_Customer_Served] = Resources.Load<AudioClip>("SFX/sushi_customer_served");
        _seDic[ESE.Sushi_Customer_Pay] = Resources.Load<AudioClip>("SFX/sound_sushibar_pay_02");
        _seDic[ESE.Sushi_Customer_Eat] = Resources.Load<AudioClip>("SFX/sushi_customer_eat_04");
        _seDic[ESE.Sushi_Customer_ReadMenu] = Resources.Load<AudioClip>("SFX/sushi_customer_read_menu_03");
        _seDic[ESE.Sushi_Bancho_FoodReady] = Resources.Load<AudioClip>("SFX/sushi_bancho_foodready_02");

        //Dave
        _seDic[ESE.Dave_Foot_Lobby] = Resources.Load<AudioClip>("SFX/lobby_dave_foot_01");
        _seDic[ESE.Dave_Foot_Sushi] = Resources.Load<AudioClip>("SFX/sound_dave_foot_01");
        _seDic[ESE.Dave_Dash] = Resources.Load<AudioClip>("SFX/sound_dave_dash_02");
        _seDic[ESE.Dave_Swim] = Resources.Load<AudioClip>("SFX/sound_Dave_Swim_01");
        _seDic[ESE.Dave_Dive] = Resources.Load<AudioClip>("SFX/dave_diving");
        _seDic[ESE.Dave_Breath] = Resources.Load<AudioClip>("SFX/dave_breathe");
        _seDic[ESE.Dave_Harpoon_Shot] = Resources.Load<AudioClip>("SFX/harpoon_shot");
        _seDic[ESE.Dave_Harpoon_Aim] = Resources.Load<AudioClip>("SFX/harpoon_aim");
        _seDic[ESE.Dave_Dagger] = Resources.Load<AudioClip>("SFX/sound_weapon_shortsword");
        _seDic[ESE.Dave_Harpoon_Pull_Loop] = Resources.Load<AudioClip>("SFX/harpoon_line_pull_loop");
        _seDic[ESE.Dave_Harpoon_Hit] = Resources.Load<AudioClip>("SFX/harpoon_hit");
        _seDic[ESE.Dave_Harpoon_Return] = Resources.Load<AudioClip>("SFX/harpoon_return");
        _seDic[ESE.Dave_Harpoon_Fail] = Resources.Load<AudioClip>("SFX/sound_harpoon_QTE_Fail_02");
        _seDic[ESE.Dave_Harpoon_Catch_Success] = Resources.Load<AudioClip>("SFX/harpoon_catch_success");


        _seDic[ESE.Dave_Harpoon_Catch_Success] = Resources.Load<AudioClip>("SFX/harpoon_catch_success");

        //VO
        _seDic[ESE.VO_Cobra_Normal] = Resources.Load<AudioClip>("VO/VO_Cobra_Normal_01");
        _seDic[ESE.VO_Cobra_Nice] = Resources.Load<AudioClip>("VO/VO_Cobra_Nice_01");
        _seDic[ESE.VO_Dave_Normal] = Resources.Load<AudioClip>("VO/VO_Dave_Normal_01");
        _seDic[ESE.VO_Dave_Thinking] = Resources.Load<AudioClip>("VO/VO_Dave_Thinking_02");


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

        if (_bgmAudio.clip == _bgmDic[bgm])
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

    public void StopESE()
    {
        _seAudio.Stop();
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

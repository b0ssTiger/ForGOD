using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public AudioSource bgSound;
    public BgmType[] bgList;
    public Slider volumebar;

    public bool MusicOnOff = true;
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LateUpdate()
    {
        if (bgSound != null)
        {
            bgSound.volume = volumebar.value;
            volumebar.value = bgSound.volume;
        }
    }


    public void PlayBGM(string bgmname)
    {
        for(int i = 1; i < bgList.Length; i++)
        {
            if(bgmname == bgList[i].name)
            {
                bgSound.clip = bgList[i].bgm;
                BgSoundPlay(bgSound.clip);
            }
        }
    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }

    [System.Serializable]
    public class BgmType
    {
        public string name;
        public AudioClip bgm;
    }

    public void MusicButtonClick()
    {
        if(MusicOnOff == true)
        {
            MusicOnOff = false;
            bgSound.Stop();
        }
        else if(MusicOnOff == false)
        {
            MusicOnOff = true;
            bgSound.Play();
        }
    }


}



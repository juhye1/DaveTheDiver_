using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public class CharacterAnimator
    {
        public int m_FileID { get; set; }
        public object m_PathID { get; set; }
    }

    public class DialogueTalkerDict
    {
        public List<int> keyData { get; set; }
        public List<ValueDatum> valueData { get; set; }
    }

    public class EmotionVFX
    {
        public int m_FileID { get; set; }
        public object m_PathID { get; set; }
    }

    public class EmotionVoice
    {
        public int m_FileID { get; set; }
        public object m_PathID { get; set; }
    }

    public class MGameObject
    {
        public int m_FileID { get; set; }
        public int m_PathID { get; set; }
    }

    public class MScript
    {
        public int m_FileID { get; set; }
        public long m_PathID { get; set; }
    }

    public class Root
    {
        public MGameObject m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public MScript m_Script { get; set; }
        public string m_Name { get; set; }
        public DialogueTalkerDict dialogueTalkerDict { get; set; }
    }

    public class Sprite
    {
        public int m_FileID { get; set; }
        public object m_PathID { get; set; }
    }

    public class TalkerInfoArray
    {
        public int emotion { get; set; }
        public Sprite sprite { get; set; }
        public EmotionVFX emotionVFX { get; set; }
        public List<EmotionVoice> emotionVoices { get; set; }
    }

    public class ValueDatum
    {
        public string characterNameID { get; set; }
        public CharacterAnimator characterAnimator { get; set; }
        public List<TalkerInfoArray> talkerInfoArray { get; set; }
    }
}

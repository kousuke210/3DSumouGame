using UnityEngine;

public class SEManager : MonoBehaviour 
{
    public static SEManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource seSource; //スピーカー

    [Header("SE File")]
    [SerializeField] private AudioClip strike; //打撃音
    [SerializeField] private AudioClip tackle; //体当たり
    [SerializeField] private AudioClip down; //倒れた

    void Awake()
    {
        if (instance == null) instance = this;
    }

    //打撃音鳴らす
    public void PlayStrike()
    {
        seSource.PlayOneShot(strike);
    }

    //体当たり音鳴らす
    public void PlayTackle()
    {
        seSource.PlayOneShot(tackle);
    }

    //倒れた音鳴らす
    public void PlayDown()
    {
        seSource.PlayOneShot(down);
    }
}

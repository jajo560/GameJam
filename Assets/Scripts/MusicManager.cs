using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;
    [SerializeField]
    private AudioSource audioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance.audioSource.clip != audioSource.clip)
            {
                Instance.audioSource.clip = audioSource.clip;
                Instance.audioSource.Play();
            }
            Destroy(gameObject);
        }
    }
}

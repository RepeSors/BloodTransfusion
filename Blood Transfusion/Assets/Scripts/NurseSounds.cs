using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSounds : MonoBehaviour
{
    [SerializeField] private AudioSource nurse;
    [SerializeField] private AudioClip tutorial, recovery, recovery2, medicine;
    private bool medicinePlayed, recovery2Played;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.TutorialRoom)
        {
            StartCoroutine(WaitForSeconds());
        }

        if (state == GameManager.GameState.GameStart)
        {
            nurse.Stop();
            nurse.PlayOneShot(recovery);
        }

        if (state == GameManager.GameState.MonitorPatient)
        {
            nurse.PlayOneShot(recovery2);
        }

        if (state == GameManager.GameState.Disinfect && !medicinePlayed)
        {
            medicinePlayed = true;
            nurse.PlayOneShot(medicine);
        }


    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        nurse.PlayOneShot(tutorial);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

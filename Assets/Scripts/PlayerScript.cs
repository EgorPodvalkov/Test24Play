using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public float _speed;
    public GameObject _failMenu;
    public GameObject[] _tracks;
    public GameObject _warp;

    public int CubeCount = 1;
    public GameObject MainCube;
    public bool moved = false;


    private int TrackNumber=0;
    private int TrackSpawnDistance = 30;

    

    void Start()
    {
        MainCube = transform.Find("CubeHolder").gameObject;
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        StartCoroutine(EnableParticalsCoroutine());
        SpawnTrack();
        SpawnTrack();
        SpawnTrack();
    }

    private void Update()
    {
        if (TrackSpawnDistance <= transform.position.z)
        {
            TrackSpawnDistance += 30;
            SpawnTrack();
            Instantiate(_warp, new Vector3(0, 0, 30 * TrackNumber), transform.rotation);
            if (transform.childCount != 1)
            {
                MainCube=transform.GetChild(transform.childCount - 1).gameObject;
            }
            else
            {
                moved = false;
                _failMenu.SetActive(true);
                Handheld.Vibrate();
            }
        }
    }

    public void FixedUpdate()
    {
        if (moved)
        {
            transform.Translate(0, 0, _speed);
        }
    }

    private void SpawnTrack()
    {
        Instantiate(_tracks[Random.Range(0, _tracks.Length)], new Vector3(0, 0, 30 * TrackNumber), transform.rotation);
        TrackNumber++;
    }
    public void StartGame()
    {
        moved = true;
        Instantiate(_warp, new Vector3(0, 0, 30), transform.rotation);
        Instantiate(_warp, new Vector3(0, 0, 60), transform.rotation);
        Instantiate(_warp, new Vector3(0, 0, 90), transform.rotation);
    }
    IEnumerator EnableParticalsCoroutine()
    {
        yield return null;
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
    }

}

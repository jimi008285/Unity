using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float _speed = 0f;
    float _minSpeed;
    float _maxSpeed;

    AudioSource _audioSource;
    [SerializeField]
    AudioClip[] _clip;

    // Start is called before the first frame update
    void Start()
    {
        _minSpeed = Random.Range(0.001f, 0.005f);
        _maxSpeed = Random.Range(15f, 20f);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rolling();
    }

    private void Rolling()
    {
        // 클릭시 회전 속도 오름
        if (Input.GetMouseButton(0))
        {
            _speed = _maxSpeed;
        }
        // 속도 랜덤 감소
        this._speed *= Random.Range(0.995f, 0.999f);
        if (_speed < _minSpeed)
        {
            _speed = 0f;
            StartCoroutine(SoundOn(1));
        }
        else
        {
            StartCoroutine(SoundOn(0));
        }
        // 룰렛 회전
        transform.Rotate(0, 0, this._speed);
    }

    IEnumerator SoundOn(int num)
    {
        yield return null;

        _audioSource.clip = _clip[num];
    }
}

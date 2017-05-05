using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour
{
    Camera _MainCamera;
    RectTransform _Transform;
    [SerializeField]
    public float _MoveSpeed = 0.0f;

    void Start()
    {
        _MainCamera = Camera.main;
        _Transform = GetComponent<RectTransform>();
    }

    void Update()
    {
        _Transform.position += new Vector3(_MoveSpeed * Time.deltaTime, 0, 0);
        if(_Transform.position.x + _Transform.rect.size.x / 2 < _MainCamera.transform.position.x - 640)
        {
            _Transform.position = new Vector3(_MainCamera.transform.position.x - 640, _Transform.position.y, _Transform.position.z);
        }
    }
}

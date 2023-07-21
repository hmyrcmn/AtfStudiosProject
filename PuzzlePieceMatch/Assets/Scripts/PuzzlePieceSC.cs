using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceSC : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging;
    private Vector3 _offset;
    private Vector3 _originalPosition;

    void Awake()
    {
        _originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
        print("hata4");
    }

    void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
        _offset = GetMousePos() - (Vector3)transform.position;
        print("hata3");
    }

    void OnMouseDrag()
    {
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
        print("hata1");
    }

    void OnMouseUp()
    {
        transform.position = _originalPosition;
        _dragging = false;
        _source.PlayOneShot(_dropClip);
        print("hata2");
    }

    Vector3 GetMousePos()
    {
        print(Input.mousePosition);
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

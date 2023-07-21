using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempsc : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging;
    private Vector3 _offset;
    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (_dragging)
        {
            MovePieceWithMouse();
        }
    }

    private void OnMouseDown()
    {
        StartDragging();
    }

    private void OnMouseUp()
    {
        StopDragging();
    }

    private void StartDragging()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
        _offset = GetMousePos() - transform.position;
    }

    private void StopDragging()
    {
        _dragging = false;
        _source.PlayOneShot(_dropClip);
        transform.localPosition = _originalPosition;
    }

    private void MovePieceWithMouse()
    {
        Vector3 mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

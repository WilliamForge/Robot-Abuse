using UnityEngine;
using TMPro;

public class Dragable : MonoBehaviour
{
    [SerializeField] bool attached = true;
    [SerializeField] float _attachDistance = .5f;
    private Vector3 _offset = Vector3.zero;

    private Vector3 _localStartPos = Vector3.zero;
    private float zCoord = 0.0f;
    private TMP_Text _textField;

    private void Start()
    {
        _localStartPos = transform.localPosition;
        _textField = GameObject.FindGameObjectWithTag("HudText").GetComponent<TMP_Text>();

        if (_textField == null)
        {
            Debug.LogWarning("Text Field not found");
        }
    }

    private Vector3 MouseToWorldPoint()
    {
        Vector3 mouseCoord = Input.mousePosition;
        mouseCoord.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mouseCoord);
    }

    private void SetTextValue()
    {
        if (attached == true)
        {
            _textField.text = "Attached";
        }
        else
        {
            _textField.text = "Detached";
        }
    }

    private void OnMouseOver()
    {
        SetTextValue();
    }

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        _offset = transform.position - MouseToWorldPoint();
    }

    private void OnMouseDrag()
    {
        transform.position = MouseToWorldPoint() + _offset;

        if (Vector3.Distance(transform.localPosition, _localStartPos) <= _attachDistance)
        {
            attached = true;
        }
        else
        {
            attached = false;
        }

        SetTextValue();
    }

    private void OnMouseUp()
    {
        if (attached)
        {
            transform.localPosition = _localStartPos;
        }
    }

    private void OnMouseExit()
    {
        _textField.text = "";
    }
}

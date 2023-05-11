using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BDCanvasDropDown : MonoBehaviour
{
    TMP_Dropdown _dropdown;
    [SerializeField] BDInfoToInsert _infoToInsert;
    [SerializeField] List<BDInfoToInsert> _infoToInsertList;
    private void Start()
    {
        _dropdown= GetComponent<TMP_Dropdown>();
        OnValueChange(_dropdown.value);
    }

    public void OnValueChange(int value)
    {
        Debug.Log("Player selected ---> " + _dropdown.value);
        _infoToInsert.nick = _infoToInsertList[_dropdown.value].nick;
        _infoToInsert.score = _infoToInsertList[_dropdown.value].score;
        _infoToInsert.email = _infoToInsertList[_dropdown.value].email;
    }
}

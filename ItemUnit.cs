using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUnitInfo
{
    private int _id;
    private string _name;
    private TMP_Text _text;
    
    public ItemUnitInfo(int id, string name)
    {
        this._id = id;  // 아이템 아이디 
        this._name = name; // 아이템 이름 
    }
}

public class ItemUnit : MonoBehaviour
{
    [SerializeField] private Inventory _inven; 
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _itemPrefab; // 아이템 
    
    [Header("ObjList")] 
    private List<ItemUnitInfo> _itemList = new List<ItemUnitInfo>();
    
    void Start()
    {
        _itemList.Add(new ItemUnitInfo(1, "피노키오의 팔"));
        _itemList.Add(new ItemUnitInfo(2, "피노키오의 다리"));
        _itemList.Add(new ItemUnitInfo(3, "피노키오의 코"));

        foreach (var unit in _itemList)
        {
            GameObject itemUnit = (GameObject)Instantiate(_itemPrefab, transform);
            ItemUnitInfo item = itemUnit.GetComponent<ItemUnitInfo>();
            _itemList.Add(item); 
        }
    }
    public void SetInit(ItemUnitInfo itemUnitinfo)
    {
        _text.text = _inven.name; 
    }
}

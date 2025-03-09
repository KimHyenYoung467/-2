using System.Collections.Generic;
using System.Numerics;
using Sprite.UGUI.UIscript.Manager;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Animation = Sprite.UGUI.UIscript.Animation;
using Vector3 = UnityEngine.Vector3;


//Todo SelectBar 를 받아와서, SelectBar 의 현재 위치에서 마우스 포인터의 위치로 이동하여,

// Todo 클릭 시에 ImgBG 및 ItemStatus 에 설명창 띄우기 

// Todo Item의 Text 오브젝트 내의 내용을 아이템 아이디에 맞춰서 변경하고, 이미지 또한 변경이 필요하다.

//Todo Item => 아이템 고유 ID,  아이템 고유 이름 Name 이 필요. -> public class 선언 필요.



public class Inventory : MonoBehaviour
{
    [Header("Script")] 
    private InventoryManager inventoryManager;
    private Animation _animation;

    [Header("Object")] private RectTransform _rect;
    [SerializeField] RectTransform _selectBar; // SelectBar 오브젝트 
    private GameObject _itemTable; // 아이템 테이블 오브젝트 
    private TMP_Text _iStatusText; // Text_MeshPro 텍스트 상자 내용
    private TMP_Text _iStatusTextChild; // Text_MeshPro 텍스트 상자 자식 
  
    
   

    void Start() // 초기화
    {
        _rect = _rect.gameObject.GetComponent<RectTransform>();
        _selectBar = _selectBar.gameObject.GetComponent<RectTransform>(); 
        _iStatusText = _iStatusText.GetComponent<TMP_Text>();
        _iStatusTextChild = _iStatusTextChild.GetComponentInChildren<TMP_Text>();

      
    }

    void SetInit()
    {
        

    }

    //Todo 클릭 위치에 따라서 인벤토리 테이블을 선택하는 SelectBar 이동 
    private void MoveSelectBar()
    {
        // 현재 선택바 가 어디에 위치해 있는 지 확인.
        // 클릭 시 선택바의 위치를 클릭한 위치로 이동. 
        // 필요 변수 : 선택바의 현재 위치를 담을 변수, 클릭한 위치를 담을 변수.

        //_selectBar.transform.SetParent(_itemTable.transform);

        var _selPos = _selectBar.transform.position; // 선택바의 현재 위치 저장 
        _selPos.z = 0f;
        
        if (Input.GetMouseButtonDown(0) && _itemTable.GetComponentInChildren<GameObject>())
        {
            _selectBar.transform.position = Input.mousePosition; // 선태바의 위치를 마우스 포인터로 선택한 아이템 테이블 위치로 이동. 
            _selPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selPos.z);
            return;
        }

        if (_selectBar.transform.position != Input.mousePosition) return;
        
        //선택바와 마우스 포인터로 클릭한 위치가 같을 때, 선택시 선택바의 크기 줄였다가 크게 하는 선택 표현 하기 
        _selectBar.localScale -= Vector3.one; 
        _selectBar.localScale += Vector3.one;
        return;
    }
} 



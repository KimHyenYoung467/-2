using System.Collections.Generic;
using Sprite.UGUI.UIscript.Manager;
using UnityEngine;

namespace Sprite.UGUI.UIscript
{ 
   public abstract class InvenSetInit
   {
       [SerializeField] private Animation _animation; 
       [SerializeField] private InventoryManager _inventoryManager; 
       
        private Inventory _inven; 
        private RectTransform _rect; // 인벤토리 BG 상자 끌어오기 
        private List<GameObject> _objList;

        public void Start()
        {
            _objList = new List<GameObject>(); 
        }
        
        public RectTransform GetObjectInit(RectTransform rect) // rect 정보 가져오고, 반환 하기 
        {
            rect = this._rect;
            return rect; 
        }
        
        public void SetObjectInit() // 오브젝트 생성  
        {
            // rect 를 리스트 안에 넣기 
            if (_rect != null)
            {
                Debug.Log(_rect.gameObject.name); 
                // 오브젝트가 비어 있지 않다면, 현재 어떤 오브젝트를 저장하고 있는 지 출력 
                return; 
            }

            if (!_rect.gameObject.CompareTag("Inventory")) return;
            
            if (!_rect.gameObject.CompareTag("Quest") || !_rect.gameObject.CompareTag("Config"))
                return;
            
            // 리스트에 추가 
            Debug.Log(_rect.gameObject.name);
            _objList.Add(_rect.gameObject);
        }
        
        public Vector2 Scale(float width, float height) // 인벤토리 BG 상자 
        {
            if (_rect == null) 
            {
                Debug.LogWarning("오브젝트가 비어 있습니다.");
                return _rect.sizeDelta;
            }

            // 리스트에 추가 (필요한 경우)
            if (!_objList.Contains(_rect.gameObject)) // T 가 있는지 판별 
            {
                _objList.Add(_rect.gameObject);
            }

            // 크기 변경
            _rect.sizeDelta = new Vector2(width, height);
            return _rect.sizeDelta; 
        }

       
    }


}

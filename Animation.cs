using System.Linq;
using UnityEngine;

//Todo 애니메이션 완성
//Todo 어떤 오브젝트인지 확인할 수 있는 메서드 작성

//Todo 클릭 횟수에 따라서 어떤 애니메이션을 동작 시킬 것인가. 
//Todo 클릭 횟수가 몇번인지 계산하는 메서드 작성 

//Todo 어떤 오브젝트 태그를 가지고 있는 지 검사 하고, 애니메이션 Play 메서드 작성 

namespace Sprite.UGUI.UIscript
{
    public class Animation
    {
        private ClickInputHandle _inputHandle;
        
        private GameObject _rect; 
        
        [Header("Animation")]
        private static Animator _animator; // 애니메이터
        private bool _isClick;
        private bool _isDclick;
        private bool _isFinished;
        private int _countIdx; // 몇번 클릭 했나. 

        public void SetAnIinit(int countIdx)
        {
            _isClick = false; 
            _rect = _rect.GetComponent<GameObject>(); 
            _animator = _rect.gameObject.GetComponent<Animator>();  // 애니메이터 속성을 찾는다.  
            
        }
        
        public int CountClickIndex(GameObject recttarget)
        {
            // 몇번 클릭 했는 지 검사. 
            // 오브젝트를 클릭할 시 1 증가, 만약에 클릭이 두번째에 도달 할 시 Dclick true, 첫번째 일 시 isClick true

            if (recttarget == null) return 0;

            for (_countIdx = 0; _countIdx < Input.touches.Count(); _countIdx++)
            {
                if (Input.touches[_countIdx].phase != TouchPhase.Began) continue;
                _isClick = true; 
                    Debug.Log("터치 상호작용 회수 : ${_countIdx}");
            }
            SetAnIinit(_countIdx);
            return _countIdx;
        }

        private void SetBooltrigger(int count)
        {
            switch (count)
            {
                case 0 :
                    Input.GetMouseButtonDown(0);
                    _isClick = false;
                    break; 
                case 1 :
                    _isClick = true;
                    _isDclick = false;
                    break; 
                case 2 :
                    _isDclick = true;
                    _isClick = false; 
                    break; 
                default :
                    _isFinished = true;
                    break;
            }
        }
        
        // 애니메이터의 속성을 가져와서 리엑트 오브젝트에 필요 애니메이션 적용 
        private void PlayAnim(GameObject rectObj)
        {
            if (rectObj == null || !Input.GetMouseButtonUp(0)) return;

            switch (_countIdx)
            {
                // isClick 이 트루이거나, false 일 때, 트리거 bool의 스위치 전환과 애니메이션 실행 
                // 클릭되었을 때 
                // 어떤 오브젝트냐? 가 필요.
                case 1 when Input.GetMouseButtonDown(0):
                    _isClick = true;
                    _animator.Play("BtnClicked");
                    _animator.Play("BtnClicked 0");
                    
                    break;
                case 2 when Input.GetMouseButtonDown(0):
                    _isDclick = true;
                    _animator.Play("BtnClicked");
                    _animator.Play("BtnClicked 0");
                    break;
            }
            
            _isClick = false; 
            _isDclick = false; 
        }

        // 삭제 에정 
       private void SideBarInput() // PushBtn 의 isClick이 true 일 때 Input . false 일 때 냅두기 
        {
            if (_rect.gameObject == null) return;

            if (_isClick && _rect.CompareTag("Inventory")) // true 이고, 인벤토리일 떄 
            {
                _animator.Play("SideBarInput"); 
            }
            else  
                _isClick = false;

            if (_isClick && _rect.CompareTag("Quest"))
            {
                _animator.Play("Input_Animation");
                
            }
        }
        
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystems
{
	public class ValkyrieListItem : MonoBehaviour
	{
		// [변수] 필요한 UI 요소들
		[SerializeField] private Image portrait; // 초상화 이미지
		[SerializeField] private Button button; // 버튼; 클릭 이벤트
	
		// [함수] 필요한 정보를 초기화합니다.
		public void Init(Sprite sprite)
		{
			portrait.sprite = sprite; // 초상화를 초기화합니다.
		}
		
		// TODO: 버튼 이벤트를 정의해야 한다.
		public void OnClick()
		{
			Debug.Log("아이템이 클릭되었습니다.");
		}
	}
}

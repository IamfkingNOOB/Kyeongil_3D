using DataSystems;
using UnityEngine;

namespace InventorySystems
{
	public class TitleValkyrieSelector : MonoBehaviour
	{
		private int _selectedID;

		// [함수] 선택된 발키리의 정보를 저장합니다. (UnityEvent에 등록)
		public void OnValkyrieSelected(ValkyrieData valkyrie)
		{
			_selectedID = valkyrie.ID;
		}
		
		// [함수] PlayerPrefs에 타이틀 발키리의 값을 저장합니다. (버튼의 클릭 이벤트에 등록)
		public void OnClick()
		{
			PlayerPrefs.SetInt("Title Valkyrie ID", _selectedID); // PlayerPrefs로 타이틀 발키리의 값을 설정합니다.
			Debug.Log($"_selectedValkyrieID = {_selectedID}");
		}
	}
}

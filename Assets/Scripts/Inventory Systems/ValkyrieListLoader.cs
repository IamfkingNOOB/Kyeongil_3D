using System.Collections.Generic;
using DataSystems;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystems
{
	/// <summary>
	/// [클래스] 발키리의 목록을 불러옵니다.
	/// </summary>
	public class ValkyrieListLoader : MonoBehaviour
	{
		// [변수] 스크롤 뷰와 그 아이템 프리팹
		[SerializeField] private ScrollRect scrollRect;
		[SerializeField] private ValkyrieListItem listItem;
		
		// [변수] 아이템의 클릭 이벤트에 응답하는 관리자
		[SerializeField] private ValkyrieSelectionManager selectionManager;
		
		// [함수] Start()
		private void Start()
		{
			InstantiateListItems(); // 첫 시작 시, 발키리 목록에 따른 아이템을 생성합니다.
		}
		
		// [함수] 발키리 목록을 불러와, 그에 해당하는 아이템을 생성합니다.
		private void InstantiateListItems()
		{
			Dictionary<int, ValkyrieData> valkyrieDictionary = DataManager.Instance.ValkyrieDictionary; // 발키리의 사전을 참조합니다.
			
			foreach (ValkyrieData valkyrie in valkyrieDictionary.Values) // 사전을 순회하면서,
			{
				Instantiate(listItem, scrollRect.content).Init(valkyrie, selectionManager); // 스크롤 뷰에 아이템을 생성하고, 초기화에 필요한 정보를 넘겨 줍니다.
			}
		}
	}
}

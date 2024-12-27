using System.Collections.Generic;
using DataSystems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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
				// 각 발키리에 해당하는 에셋을 불러옵니다.
				string portraitData = $"Avatars/{valkyrie.ResourceName}/Portrait"; // Addressable Name: "Avatars/리소스_이름/Portrait.png"
				AssetReferenceSprite portraitAsset = new AssetReferenceSprite(portraitData); // Addressable로 해당 에셋을 불러옵니다.
				
				// 불러온 에셋을 토대로 아이템을 생성합니다.
				portraitAsset.LoadAssetAsync().Completed += handle =>
				{
					switch (handle.Status)
					{
						case AsyncOperationStatus.Succeeded: // 성공했을 경우,
							Instantiate(listItem, scrollRect.content).Init(handle.Result); // 스크롤 뷰 위치에 아이템을 생성하고, 불러온 초상화 에셋으로 초기화합니다.
							Debug.Log("초상화를 성공적으로 불러왔습니다.");
							break;
						case AsyncOperationStatus.Failed:
							Debug.LogError("초상화를 불러오는 데 실패했습니다.");
							break;
					}
				};
			}
		}
	}
}

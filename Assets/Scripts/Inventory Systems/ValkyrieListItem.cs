using DataSystems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace InventorySystems
{
	/// <summary>
	/// [클래스] 발키리의 목록을 나타내는 스크롤 뷰의 아이템을 정의합니다.
	/// </summary>
	public class ValkyrieListItem : MonoBehaviour
	{
		// [변수] 필요한 UI 요소들
		[SerializeField] private Image portrait; // 초상화 이미지
		[SerializeField] private Button button; // 버튼; 클릭 이벤트

		// [변수] 각 아이템이 가지는 정보들
		private ValkyrieSelectionManager _manager; // 클릭 이벤트에 응답하는 관리자
		private ValkyrieData _data; // 전달할 발키리의 정보
	
		// [함수] 필요한 정보를 초기화합니다.
		public void Init(ValkyrieData data, ValkyrieSelectionManager manager)
		{
			// 참조를 저장합니다.
			_data = data;
			_manager = manager;
			
			// 각 발키리에 해당하는 에셋을 불러옵니다.
			string portraitData = $"Avatars/{data.ResourceName}/Portrait"; // Addressable Name: "Avatars/리소스_이름/Portrait.png"
			AssetReferenceSprite portraitAsset = new AssetReferenceSprite(portraitData); // Addressable로 해당 에셋을 불러옵니다.
			
			// 불러온 에셋을 토대로 초기화를 수행합니다.
			portraitAsset.LoadAssetAsync().Completed += handle =>
			{
				switch (handle.Status)
				{
					case AsyncOperationStatus.Succeeded: // 성공했을 경우,
						portrait.sprite = handle.Result; // 초상화 이미지를 불러온 에셋으로 초기화합니다.
						Debug.Log("초상화를 성공적으로 불러왔습니다.");
						break;
					case AsyncOperationStatus.Failed:
						Debug.LogError("초상화를 불러오는 데 실패했습니다.");
						break;
				}
			};
		}
		
		// TODO: 버튼 이벤트를 정의해야 한다.
		public void OnClick()
		{
			_manager.UpdateUI(_data); // 관리자에게 정보의 갱신을 요청합니다.
			Debug.Log("아이템이 클릭되었습니다.");
		}
	}
}

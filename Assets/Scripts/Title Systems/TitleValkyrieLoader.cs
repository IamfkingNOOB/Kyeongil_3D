using System.Collections.Generic;
using System.Linq;
using DataSystems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;

namespace TitleSystems
{
	/// <summary>
	/// [클래스] 타이틀 화면에 등장할 발키리를 관리합니다.
	/// </summary>
	public class TitleValkyrieLoader : MonoBehaviour
	{
		// [변수] 생성된 타이틀 발키리의 아바타
		private AssetReference _avatarAsset;
		private GameObject _avatarObject;
		
		// [함수] OnEnable()
		private void OnEnable()
		{
			InstantiateAvatar(); // 활성화할 때, 타이틀 발키리의 아바타를 불러와 생성합니다.
		}

		// [함수] OnDisable()
		private void OnDisable()
		{
			DestroyAvatar(); // 비활성화할 때, 타이틀 발키리의 아바타를 파괴합니다.
		}
		
		// [함수] 타이틀 발키리의 아바타를 생성합니다.
		private void InstantiateAvatar()
		{
			DestroyAvatar(); // 우선, 이미 불러온 아바타가 있다면, 그것을 해제합니다.
			
			// 타이틀로 지정한 발키리의 아바타 정보를 불러옵니다.
			string avatarData = $"Avatars/{GetAvatar()}/Model"; // Addressable Name: "Avatars/프리팹_이름/Model.prefab"
			_avatarAsset = new AssetReference(avatarData); // Addressable로 해당 에셋을 불러옵니다.
			
			// 불러온 에셋을 생성합니다.
			_avatarAsset.InstantiateAsync().Completed += handle =>
			{
				switch (handle.Status)
				{
					case AsyncOperationStatus.Succeeded:
						_avatarObject = handle.Result; // 생성한 아바타 오브젝트를 변수에 저장합니다.
						Debug.Log("아바타를 성공적으로 생성했습니다.");
						break;
					case AsyncOperationStatus.Failed:
						Debug.LogError("아바타를 생성하는 데 실패했습니다.");
						break;
				}
			};
		}
		
		// [함수] 이미 생성된 아바타를 파괴합니다.
		private void DestroyAvatar()
		{
			if (_avatarObject)
			{
				_avatarAsset.ReleaseInstance(_avatarObject); // Addressable로 해당 아바타를 해제합니다.
			}
		}
		
		// [함수] 타이틀 발키리의 정보를 불러옵니다.
		private string GetAvatar()
		{
			// TODO: PlayerPrefs를 적용하는 부분이 필요하다.
			int id = PlayerPrefs.GetInt("Title Valkyrie ID"); // PlayerPrefs에서 타이틀 발키리의 값을 찾습니다.
			Dictionary<int, ValkyrieData> valkyrieDictionary = DataManager.Instance.ValkyrieDictionary; // 발키리의 사전을 참조합니다.
			
			if (!valkyrieDictionary.TryGetValue(id, out ValkyrieData valkyrieData)) // 값이 있다면 그것의 데이터를 불러오고,
			{
				valkyrieData = GetRandomAvatar(valkyrieDictionary); // 없다면 무작위로 고릅니다.
			}
			
			return valkyrieData.ResourceName; // 리소스(아바타)의 이름을 반환합니다.
		}
		
		// [함수] 발키리를 무작위로 고릅니다.
		private ValkyrieData GetRandomAvatar(Dictionary<int, ValkyrieData> valkyrieDictionary)
		{
			// 발키리의 사전을 참조하여, 무작위로 하나를 고릅니다.
			ValkyrieData randomAvatar = valkyrieDictionary.ElementAt(Random.Range(0, valkyrieDictionary.Count)).Value;
			return randomAvatar; // 그것을 반환합니다.
		}
	}
}

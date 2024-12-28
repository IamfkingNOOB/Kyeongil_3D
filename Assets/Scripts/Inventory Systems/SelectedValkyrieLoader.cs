using System.Collections.Generic;
using DataSystems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace InventorySystems
{
	public class SelectedValkyrieLoader : MonoBehaviour
	{
		// [변수] 생성된 타이틀 발키리의 아바타
		private AssetReference _avatarAsset;
		private GameObject _avatarObject;

		// [함수] OnDisable()
		private void OnDisable()
		{
			DestroyAvatar(); // 비활성화할 때, 아바타를 파괴합니다.
		}
		
		// [함수] 타이틀 발키리의 아바타를 생성합니다.
		public void InstantiateAvatar(string resourceName)
		{
			DestroyAvatar(); // 우선, 이미 불러온 아바타가 있다면, 그것을 해제합니다.
			
			// 타이틀로 지정한 발키리의 아바타 정보를 불러옵니다.
			string avatarData = $"Avatars/{resourceName}/Model"; // Addressable Name: "Avatars/프리팹_이름/Model.prefab"
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
	}
}

using System.Collections.Generic;
using DataSystems;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	// 한국어 주석
	private void Start()
	{
		Debug.Log("TestScript Start()");

		// DataManager 테스트
		DataManager.Instance.ValkyrieDictionary.GetValueOrDefault(410);
	}
}

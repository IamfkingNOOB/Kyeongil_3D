using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace DataSystems
{
	/// <summary>
	/// [클래스] XML 형식으로 정리된 데이터베이스들을 읽어들입니다.
	/// </summary>
	public class DatabaseReader
	{
		// [변수] 데이터베이스 파일들이 있는 경로 (Application.dataPath = /Assets)
		private readonly string _rootPath = Path.Combine(Application.dataPath, "Databases");
		
		// [함수] 발키리 데이터베이스를 읽어들입니다.
		public Dictionary<int, ValkyrieData> ReadValkyrieData()
		{
			var valkyrieDictionary = new Dictionary<int, ValkyrieData>(); // 반환할 사전을 생성합니다.

			XDocument xDocument = XDocument.Load($"{_rootPath}/Valkyries.xml"); // XML 파일을 불러와서,
			IEnumerable<XElement> xElements = xDocument.Descendants("data"); // 'data' 태그 요소만을 고릅니다.

			var tempData = new ValkyrieData();
			
			foreach (XElement xElement in xElements) // 요소를 순회하면서,
			{
				// 발키리의 정보를 읽어들입니다.
				bool b = int.TryParse(xElement.Attribute(nameof(tempData.ID))?.Value, out int id);
				string characterName = xElement.Attribute(nameof(tempData.CharacterName))?.Value;
				string suitName = xElement.Attribute(nameof(tempData.SuitName))?.Value;
				string type = xElement.Attribute(nameof(tempData.Type))?.Value;
				b = int.TryParse(xElement.Attribute(nameof(tempData.HP))?.Value, out int hp) && b;
				b = int.TryParse(xElement.Attribute(nameof(tempData.SP))?.Value, out int sp) && b;
				b = int.TryParse(xElement.Attribute(nameof(tempData.ATK))?.Value, out int atk) && b;
				b = int.TryParse(xElement.Attribute(nameof(tempData.DEF))?.Value, out int def) && b;
				b = int.TryParse(xElement.Attribute(nameof(tempData.CRT))?.Value, out int crt) && b;
				string resourceName = xElement.Attribute(nameof(tempData.ResourceName))?.Value;

				if (b) // 정상적으로 읽어들였다면,
				{
					ValkyrieData valkyrieData = new() // 그 정보를 토대로 인스턴스를 생성합니다.
					{
						ID = id,
						CharacterName = characterName,
						SuitName = suitName,
						Type = type,
						HP = hp,
						SP = sp,
						ATK = atk,
						DEF = def,
						CRT = crt,
						ResourceName = resourceName
					};
					
					Debug.Log($"ID: {valkyrieData.ID}, CharacterName: {valkyrieData.CharacterName}");
				
					valkyrieDictionary.Add(valkyrieData.ID, valkyrieData); // 생성한 인스턴스를 사전에 추가합니다.
				}
			}
			
			return valkyrieDictionary; // 작업이 완료된 사전을 반환합니다.
		}
	}
}

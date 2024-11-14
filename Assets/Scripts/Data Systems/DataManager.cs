using System.Collections.Generic;
using Frameworks.Singletons;

namespace DataSystems
{
	/// <summary>
	/// [클래스] 게임에 필요한 데이터들을 관리합니다.
	/// </summary>
	public class DataManager : Singleton<DataManager>
	{
		// [변수] 데이터베이스를 읽어들이는 클래스
		private readonly DatabaseReader _databaseReader = new();

		// [변수] 발키리의 정보를 저장하는 사전
		private Dictionary<int, ValkyrieData> _valkyrieDictionary;
		public Dictionary<int, ValkyrieData> ValkyrieDictionary
		{
			get
			{
				if (_valkyrieDictionary == null)
				{
					_valkyrieDictionary = _databaseReader.ReadValkyrieData();
				}
				
				return _valkyrieDictionary;
			}
		}
	}
}

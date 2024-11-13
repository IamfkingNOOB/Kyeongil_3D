namespace DataSystems
{
	/// <summary>
	/// [클래스] 발키리의 기본적인 데이터들을 정의합니다.
	/// </summary>
	public class ValkyrieData
	{
		public int ID { get; init; } // 식별자
		
		public string CharacterName { get; init; } // 캐릭터 이름
		public string SuitName { get; init; } // 슈트 이름

		public string Type { get; init; } // 속성

		public int HP { get; init; } // 체력
		public int SP { get; init; } // 기력
		public int ATK { get; init; } // 공격력
		public int DEF { get; init; } // 방어력
		public int CRT { get; init; } // 회심
		
		public string ResourceName { get; init; } // 리소스 이름
	}
}

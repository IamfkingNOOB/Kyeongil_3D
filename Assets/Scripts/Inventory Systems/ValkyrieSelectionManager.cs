using DataSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystems
{
	/// <summary>
	/// [클래스] 발키리의 목록 중에서 하나가 선택될 때의 처리를 관리합니다.
	/// </summary>
	public class ValkyrieSelectionManager : MonoBehaviour
	{
		// [변수] 발키리의 정보를 나타내는 UI들
		[SerializeField] private TextMeshProUGUI characterName; // 캐릭터의 이름
		[SerializeField] private Image typeImage; // 속성의 이미지
		[SerializeField] private TextMeshProUGUI typeText; // 속성의 이름
		[SerializeField] private TextMeshProUGUI suitName; // 슈트의 이름
		[SerializeField] private TextMeshProUGUI hpText; // 체력(HP)
		[SerializeField] private TextMeshProUGUI spText; // 기력(SP)
		[SerializeField] private TextMeshProUGUI atkText; // 공격력(ATK)
		[SerializeField] private TextMeshProUGUI defText; // 방어력(DEF)
		[SerializeField] private TextMeshProUGUI crtText; // 회심(CRT)
		
		// [변수] 타입의 이미지 목록
		[SerializeField] private Sprite[] typeSprites; // 등록 순서는 EntityType의 순서에 따릅니다.
		
		// [함수] 발키리 목록의 아이템 중 하나가 클릭되었을 때, UI를 업데이트합니다.
		public void UpdateUI(ValkyrieData selectedData)
		{
			characterName.SetText(selectedData.CharacterName);
			typeImage.sprite = typeSprites[(int)selectedData.TypeEnum];
			typeText.SetText(selectedData.Type);
			suitName.SetText(selectedData.SuitName);
			hpText.SetText($"{selectedData.HP}");
			spText.SetText($"{selectedData.SP}");
			atkText.SetText($"{selectedData.ATK}");
			defText.SetText($"{selectedData.DEF}");
			crtText.SetText($"{selectedData.CRT}");
		}
	}
}

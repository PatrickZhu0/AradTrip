using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000ECB RID: 3787
public class ComDungeonComboUnit : MonoBehaviour
{
	// Token: 0x060094F5 RID: 38133 RVA: 0x001BF910 File Offset: 0x001BDD10
	public void SetSkill(int id)
	{
		SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(id, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ETCImageLoader.LoadSprite(ref this.mFg, tableItem.Icon, true);
		}
	}

	// Token: 0x060094F6 RID: 38134 RVA: 0x001BF94C File Offset: 0x001BDD4C
	public void PlayState(bool isRight)
	{
		if (isRight)
		{
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("Effects/Scene_effects/EffectUI/EffUI_xinshou_lianji", enResourceType.UIPrefab, 0U);
			Utility.AttachTo(gameObject, base.gameObject, false);
			this.mFg.color = Color.green;
		}
		else
		{
			this.mFg.color = Color.red;
		}
	}

	// Token: 0x060094F7 RID: 38135 RVA: 0x001BF9A3 File Offset: 0x001BDDA3
	public void Reset()
	{
		this.mFg.color = Color.white;
	}

	// Token: 0x04004BAF RID: 19375
	public Image mFg;
}

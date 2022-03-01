using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001027 RID: 4135
	public class NewbieGuideUseSkillFrame : ClientFrame
	{
		// Token: 0x06009C91 RID: 40081 RVA: 0x001E96CF File Offset: 0x001E7ACF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/NewbieGuideUseSkill";
		}

		// Token: 0x06009C92 RID: 40082 RVA: 0x001E96D8 File Offset: 0x001E7AD8
		protected override void _OnCloseFrame()
		{
			if (this.mBind != null)
			{
				Button com = this.mBind.GetCom<Button>("button");
				com.onClick.RemoveAllListeners();
			}
			base._OnCloseFrame();
		}

		// Token: 0x06009C93 RID: 40083 RVA: 0x001E9718 File Offset: 0x001E7B18
		public void SetSkill(int skillID, Vector3 pos, Vector2 sizeDelta)
		{
			if (this.mBind != null)
			{
				RectTransform com = this.mBind.GetCom<RectTransform>("skillroot");
				Button com2 = this.mBind.GetCom<Button>("button");
				Image com3 = this.mBind.GetCom<Image>("image");
				SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref com3, tableItem.Icon, true);
				}
				com.sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y);
				com.transform.position = pos;
				com2.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideUseSkillFrame>(this, false);
				});
			}
		}
	}
}

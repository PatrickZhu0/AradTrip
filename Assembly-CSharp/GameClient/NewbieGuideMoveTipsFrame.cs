using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001028 RID: 4136
	public class NewbieGuideMoveTipsFrame : ClientFrame
	{
		// Token: 0x06009C96 RID: 40086 RVA: 0x001E97E6 File Offset: 0x001E7BE6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/NewbieGuideMoveTips";
		}

		// Token: 0x06009C97 RID: 40087 RVA: 0x001E97ED File Offset: 0x001E7BED
		public void SetShow(bool bShowJoyStick, bool bShowSkillButton)
		{
			this.joystick.CustomActive(bShowJoyStick);
			this.attackButton.CustomActive(bShowSkillButton);
		}

		// Token: 0x06009C98 RID: 40088 RVA: 0x001E9808 File Offset: 0x001E7C08
		protected override void _OnOpenFrame()
		{
			ActorOccupation jobTableID = (ActorOccupation)DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._setSkill(tableItem.NormalAttackID);
			}
		}

		// Token: 0x06009C99 RID: 40089 RVA: 0x001E9854 File Offset: 0x001E7C54
		private void _setSkill(int skill)
		{
			if (null != this.mBind)
			{
				SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skill, string.Empty, string.Empty);
				if (tableItem != null)
				{
					Image com = this.mBind.GetCom<Image>("image");
					ETCImageLoader.LoadSprite(ref com, tableItem.Icon, true);
				}
			}
		}

		// Token: 0x040055F3 RID: 22003
		[UIObject("bg/ETCJoystick")]
		private GameObject joystick;

		// Token: 0x040055F4 RID: 22004
		[UIObject("bg/Btn_Attack")]
		private GameObject attackButton;
	}
}

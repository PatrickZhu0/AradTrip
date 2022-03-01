using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001622 RID: 5666
	internal class GuildGuardStatueTalkFrame : ClientFrame
	{
		// Token: 0x0600DE6C RID: 56940 RVA: 0x00388A91 File Offset: 0x00386E91
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/TownStatueTalkFrame";
		}

		// Token: 0x0600DE6D RID: 56941 RVA: 0x00388A98 File Offset: 0x00386E98
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.StatueType = (byte)this.userData;
			}
			List<FigureStatueInfo> guildGuardStatueInfo = DataManager<GuildDataManager>.GetInstance().GetGuildGuardStatueInfo();
			bool flag = false;
			for (int i = 0; i < guildGuardStatueInfo.Count; i++)
			{
				FigureStatueInfo figureStatueInfo = guildGuardStatueInfo[i];
				if (figureStatueInfo.statueType == this.StatueType)
				{
					if (figureStatueInfo.statueType <= 0)
					{
						this.mTalkContent.text = TR.Value("Guild_Guard_Statue_No_Talk");
						this.mNpcName.text = string.Empty;
					}
					else
					{
						JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)figureStatueInfo.occu, string.Empty, string.Empty);
						if (tableItem != null && !string.IsNullOrEmpty(tableItem.JobHalfBody) && tableItem.JobHalfBody != "-")
						{
							ETCImageLoader.LoadSprite(ref this.mNpcIcon, tableItem.JobHalfBody, true);
						}
						this.mNpcIcon.gameObject.CustomActive(true);
						this.mTalkContent.text = TR.Value("Guild_Guard_Statue_Talk");
						this.mNpcName.text = figureStatueInfo.name;
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.mTalkContent.text = TR.Value("Guild_Guard_Statue_No_Talk");
				this.mNpcName.text = string.Empty;
			}
		}

		// Token: 0x0600DE6E RID: 56942 RVA: 0x00388C00 File Offset: 0x00387000
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600DE6F RID: 56943 RVA: 0x00388C08 File Offset: 0x00387008
		private void ClearData()
		{
			this.StatueType = 0;
		}

		// Token: 0x0600DE70 RID: 56944 RVA: 0x00388C14 File Offset: 0x00387014
		protected override void _bindExUI()
		{
			this.mBtOk = this.mBind.GetCom<Button>("BtOk");
			this.mBtOk.onClick.AddListener(new UnityAction(this._onBtOkButtonClick));
			this.mTalkContent = this.mBind.GetCom<Text>("TalkContent");
			this.mNpcName = this.mBind.GetCom<Text>("NpcName");
			this.mNpcIcon = this.mBind.GetCom<Image>("NpcIcon");
		}

		// Token: 0x0600DE71 RID: 56945 RVA: 0x00388C95 File Offset: 0x00387095
		protected override void _unbindExUI()
		{
			this.mBtOk.onClick.RemoveListener(new UnityAction(this._onBtOkButtonClick));
			this.mBtOk = null;
			this.mTalkContent = null;
			this.mNpcName = null;
			this.mNpcIcon = null;
		}

		// Token: 0x0600DE72 RID: 56946 RVA: 0x00388CCF File Offset: 0x003870CF
		private void _onBtOkButtonClick()
		{
			this.frameMgr.CloseFrame<GuildGuardStatueTalkFrame>(this, false);
		}

		// Token: 0x040083CE RID: 33742
		private byte StatueType;

		// Token: 0x040083CF RID: 33743
		private Button mBtOk;

		// Token: 0x040083D0 RID: 33744
		private Text mTalkContent;

		// Token: 0x040083D1 RID: 33745
		private Text mNpcName;

		// Token: 0x040083D2 RID: 33746
		private Image mNpcIcon;
	}
}

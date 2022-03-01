using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001767 RID: 5991
	internal class TownStatueTalkFrame : ClientFrame
	{
		// Token: 0x0600EC92 RID: 60562 RVA: 0x003F21D5 File Offset: 0x003F05D5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/TownStatueTalkFrame";
		}

		// Token: 0x0600EC93 RID: 60563 RVA: 0x003F21DC File Offset: 0x003F05DC
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.StatueType = (byte)this.userData;
			}
			List<FigureStatueInfo> townStatueInfo = DataManager<GuildDataManager>.GetInstance().GetTownStatueInfo();
			bool flag = false;
			for (int i = 0; i < townStatueInfo.Count; i++)
			{
				FigureStatueInfo figureStatueInfo = townStatueInfo[i];
				if (figureStatueInfo.statueType == this.StatueType)
				{
					if (figureStatueInfo.statueType <= 0)
					{
						this.mTalkContent.text = TR.Value("Town_Statue_No_Talk");
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
						this.mTalkContent.text = TR.Value("Town_Statue_Talk", figureStatueInfo.guildName, figureStatueInfo.name);
						this.mNpcName.text = figureStatueInfo.name;
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.mTalkContent.text = TR.Value("Town_Statue_No_Talk");
				this.mNpcName.text = string.Empty;
			}
		}

		// Token: 0x0600EC94 RID: 60564 RVA: 0x003F2350 File Offset: 0x003F0750
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600EC95 RID: 60565 RVA: 0x003F2358 File Offset: 0x003F0758
		private void ClearData()
		{
			this.StatueType = 0;
		}

		// Token: 0x0600EC96 RID: 60566 RVA: 0x003F2364 File Offset: 0x003F0764
		protected override void _bindExUI()
		{
			this.mBtOk = this.mBind.GetCom<Button>("BtOk");
			this.mBtOk.onClick.AddListener(new UnityAction(this._onBtOkButtonClick));
			this.mTalkContent = this.mBind.GetCom<Text>("TalkContent");
			this.mNpcName = this.mBind.GetCom<Text>("NpcName");
			this.mNpcIcon = this.mBind.GetCom<Image>("NpcIcon");
		}

		// Token: 0x0600EC97 RID: 60567 RVA: 0x003F23E5 File Offset: 0x003F07E5
		protected override void _unbindExUI()
		{
			this.mBtOk.onClick.RemoveListener(new UnityAction(this._onBtOkButtonClick));
			this.mBtOk = null;
			this.mTalkContent = null;
			this.mNpcName = null;
			this.mNpcIcon = null;
		}

		// Token: 0x0600EC98 RID: 60568 RVA: 0x003F241F File Offset: 0x003F081F
		private void _onBtOkButtonClick()
		{
			this.frameMgr.CloseFrame<TownStatueTalkFrame>(this, false);
		}

		// Token: 0x04008FD0 RID: 36816
		private byte StatueType;

		// Token: 0x04008FD1 RID: 36817
		private Button mBtOk;

		// Token: 0x04008FD2 RID: 36818
		private Text mTalkContent;

		// Token: 0x04008FD3 RID: 36819
		private Text mNpcName;

		// Token: 0x04008FD4 RID: 36820
		private Image mNpcIcon;
	}
}

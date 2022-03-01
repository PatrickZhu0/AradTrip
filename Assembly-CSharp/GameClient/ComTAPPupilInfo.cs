using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE4 RID: 7140
	internal class ComTAPPupilInfo : MonoBehaviour
	{
		// Token: 0x0601180F RID: 71695 RVA: 0x005176BC File Offset: 0x00515ABC
		public void SetValue(RelationData data)
		{
			this.data = data;
			if (data == null)
			{
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)data.occu, string.Empty, string.Empty);
			if (null != this.jobIcon)
			{
				string path = string.Empty;
				if (tableItem != null)
				{
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						path = tableItem2.IconPath;
					}
				}
				ETCImageLoader.LoadSprite(ref this.jobIcon, path, true);
			}
			if (null != this.roleName)
			{
				this.roleName.text = data.name;
			}
			if (tableItem != null && null != this.roleLvAndJob)
			{
				this.roleLvAndJob.text = string.Format("Lv.{0} {1}", data.level, tableItem.Name);
			}
			if (null != this.vipLv)
			{
				this.vipLv.Value = (int)data.vipLv;
			}
			if (null != this.imgFightIcon)
			{
				ETCImageLoader.LoadSprite(ref this.imgFightIcon, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon((int)data.seasonLv), true);
			}
			if (null != this.imgFightLv)
			{
				ETCImageLoader.LoadSprite(ref this.imgFightLv, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon((int)data.seasonLv), true);
				this.imgFightLv.SetNativeSize();
			}
			if (null != this.fightLv)
			{
				this.fightLv.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)data.seasonLv, true);
			}
			this.goBusy.CustomActive(data.status == 1);
			this.goFree.CustomActive(data.status == 0);
			this.goOffLine.CustomActive(data.status == 2);
		}

		// Token: 0x06011810 RID: 71696 RVA: 0x00517898 File Offset: 0x00515C98
		public void OnPopupMenu()
		{
			if (this.data != null)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.data;
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_PUPIL_REAL;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowPupilRealMenu, relationMenuData, null, null, null);
			}
		}

		// Token: 0x06011811 RID: 71697 RVA: 0x005178DD File Offset: 0x00515CDD
		public void OnDonate()
		{
			if (this.data != null)
			{
				TAPDonateFrame.Open(this.data);
			}
		}

		// Token: 0x06011812 RID: 71698 RVA: 0x005178F8 File Offset: 0x00515CF8
		public void OnChat()
		{
			if (this.data != null)
			{
				DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(this.data, false);
				DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(this.data);
				UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(this.data, false));
			}
		}

		// Token: 0x0400B60A RID: 46602
		public Image jobIcon;

		// Token: 0x0400B60B RID: 46603
		public Text roleName;

		// Token: 0x0400B60C RID: 46604
		public Text roleLvAndJob;

		// Token: 0x0400B60D RID: 46605
		public UINumber vipLv;

		// Token: 0x0400B60E RID: 46606
		public Image imgFightIcon;

		// Token: 0x0400B60F RID: 46607
		public Image imgFightLv;

		// Token: 0x0400B610 RID: 46608
		public Text fightLv;

		// Token: 0x0400B611 RID: 46609
		public GameObject goBusy;

		// Token: 0x0400B612 RID: 46610
		public GameObject goFree;

		// Token: 0x0400B613 RID: 46611
		public GameObject goOffLine;

		// Token: 0x0400B614 RID: 46612
		private RelationData data;
	}
}

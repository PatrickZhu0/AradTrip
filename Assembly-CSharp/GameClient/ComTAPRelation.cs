using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE6 RID: 7142
	internal class ComTAPRelation : MonoBehaviour
	{
		// Token: 0x0601181A RID: 71706 RVA: 0x005179FC File Offset: 0x00515DFC
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

		// Token: 0x0601181B RID: 71707 RVA: 0x00517BD8 File Offset: 0x00515FD8
		public void OnPopupMenu()
		{
			if (this.data != null)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.data;
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_TEACHER_REAL;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowTeacherRealMenu, relationMenuData, null, null, null);
			}
		}

		// Token: 0x0601181C RID: 71708 RVA: 0x00517C20 File Offset: 0x00516020
		public void OnChat()
		{
			if (this.data != null)
			{
				DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(this.data, false);
				DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(this.data);
				UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(this.data, false));
			}
		}

		// Token: 0x0400B617 RID: 46615
		public Image jobIcon;

		// Token: 0x0400B618 RID: 46616
		public Text roleName;

		// Token: 0x0400B619 RID: 46617
		public Text roleLvAndJob;

		// Token: 0x0400B61A RID: 46618
		public UINumber vipLv;

		// Token: 0x0400B61B RID: 46619
		public Image imgFightIcon;

		// Token: 0x0400B61C RID: 46620
		public Image imgFightLv;

		// Token: 0x0400B61D RID: 46621
		public Text fightLv;

		// Token: 0x0400B61E RID: 46622
		public GameObject goBusy;

		// Token: 0x0400B61F RID: 46623
		public GameObject goFree;

		// Token: 0x0400B620 RID: 46624
		public GameObject goOffLine;

		// Token: 0x0400B621 RID: 46625
		private RelationData data;
	}
}

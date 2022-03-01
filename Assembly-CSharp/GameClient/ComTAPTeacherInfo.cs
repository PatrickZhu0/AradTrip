using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE8 RID: 7144
	internal class ComTAPTeacherInfo : MonoBehaviour
	{
		// Token: 0x06011825 RID: 71717 RVA: 0x00517F3C File Offset: 0x0051633C
		public void OnItemVisible(object value)
		{
			this.data = (value as RelationData);
			if (this.data != null)
			{
				if (null != this.Name)
				{
					this.Name.text = this.data.name;
				}
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)this.data.occu, string.Empty, string.Empty);
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
				if (null != this.announcement)
				{
					if (!string.IsNullOrEmpty(this.data.announcement))
					{
						this.announcement.text = this.data.announcement;
					}
					else
					{
						this.announcement.text = TR.Value("tap_default_announcement");
					}
				}
				this._UpdateQueryStatus();
				if (null != this.Level)
				{
					this.Level.text = this.data.level.ToString();
				}
			}
		}

		// Token: 0x06011826 RID: 71718 RVA: 0x00518088 File Offset: 0x00516488
		private void _UpdateQueryStatus()
		{
			bool flag = DataManager<TAPDataManager>.GetInstance().CanQuery(this.data.uid);
			this.grayAskTeacher.enabled = !flag;
			this.btnAskTeacher.enabled = flag;
			this.goAllocated.CustomActive(!flag);
			this.btnAskTeacher.CustomActive(flag);
		}

		// Token: 0x06011827 RID: 71719 RVA: 0x005180E4 File Offset: 0x005164E4
		public void SendAskForTeacher()
		{
			if (this.data != null && this.btnAskTeacher.enabled)
			{
				DataManager<TAPDataManager>.GetInstance().SendApplyTeacher(this.data.uid);
				DataManager<TAPDataManager>.GetInstance().AddQueryInfo(this.data.uid);
				this._UpdateQueryStatus();
			}
		}

		// Token: 0x06011828 RID: 71720 RVA: 0x0051813C File Offset: 0x0051653C
		public void OnPopupMenu()
		{
			if (this.data != null)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.data;
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_TEACHER;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowAskTeacherMenu, relationMenuData, null, null, null);
			}
		}

		// Token: 0x06011829 RID: 71721 RVA: 0x00518181 File Offset: 0x00516581
		private void Start()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAskTeacherMsgSended, new ClientEventSystem.UIEventHandler(this._OnAskTeacherMsgSended));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAskTeacherMsgSended, new ClientEventSystem.UIEventHandler(this._OnAskTeacherMsgSended));
		}

		// Token: 0x0601182A RID: 71722 RVA: 0x005181B9 File Offset: 0x005165B9
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAskTeacherMsgSended, new ClientEventSystem.UIEventHandler(this._OnAskTeacherMsgSended));
		}

		// Token: 0x0601182B RID: 71723 RVA: 0x005181D8 File Offset: 0x005165D8
		private void _OnAskTeacherMsgSended(UIEvent uiEvent)
		{
			if (this.data != null && (ulong)uiEvent.Param1 == this.data.uid && this.data != null && this.btnAskTeacher.enabled)
			{
				this.grayAskTeacher.enabled = true;
				this.btnAskTeacher.enabled = false;
				this.btnAskTeacher.CustomActive(false);
				this.goAllocated.CustomActive(true);
			}
		}

		// Token: 0x0400B627 RID: 46631
		private RelationData data;

		// Token: 0x0400B628 RID: 46632
		public Text Name;

		// Token: 0x0400B629 RID: 46633
		public Image jobIcon;

		// Token: 0x0400B62A RID: 46634
		public Text announcement;

		// Token: 0x0400B62B RID: 46635
		public Button btnAskTeacher;

		// Token: 0x0400B62C RID: 46636
		public UIGray grayAskTeacher;

		// Token: 0x0400B62D RID: 46637
		public Text Level;

		// Token: 0x0400B62E RID: 46638
		public GameObject goAllocated;
	}
}

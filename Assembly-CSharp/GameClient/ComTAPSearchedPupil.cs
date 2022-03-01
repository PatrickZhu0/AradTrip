using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE7 RID: 7143
	internal class ComTAPSearchedPupil : MonoBehaviour
	{
		// Token: 0x0601181E RID: 71710 RVA: 0x00517C78 File Offset: 0x00516078
		public void AskForPupil()
		{
			if (this.data != null && DataManager<TAPDataManager>.GetInstance().CheckApplyPupil(true))
			{
				DataManager<TAPDataManager>.GetInstance().SendApplyPupil(this.data.uid);
				DataManager<TAPDataManager>.GetInstance().AddApplyedPupil(this.data.uid);
				this._UpdateStatus();
			}
		}

		// Token: 0x0601181F RID: 71711 RVA: 0x00517CD0 File Offset: 0x005160D0
		private void _UpdateStatus()
		{
			if (null != this.comState)
			{
				if (DataManager<TAPDataManager>.GetInstance().HasPupil(this.data.uid))
				{
					this.comState.Key = "hasBeenTap";
				}
				else if (!DataManager<TAPDataManager>.GetInstance().CanApplyedPupil(this.data.uid))
				{
					if (DataManager<RelationDataManager>.GetInstance().ApplyPupils.Find((RelationData x) => x.uid == this.data.uid) == null)
					{
						this.comState.Key = "applyed";
					}
					else
					{
						this.comState.Key = "applyed_allocated";
					}
				}
				else
				{
					RelationData relationData = DataManager<RelationDataManager>.GetInstance().ApplyPupils.Find((RelationData x) => x.uid == this.data.uid);
					if (relationData != null)
					{
						this.comState.Key = "allocated";
					}
					else
					{
						this.comState.Key = "normal";
					}
				}
			}
		}

		// Token: 0x06011820 RID: 71712 RVA: 0x00517DCC File Offset: 0x005161CC
		public void OnPopupMenu()
		{
			if (this.data != null)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.data;
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_PUPIL_APPLY;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowPupilApplyMenu, relationMenuData, null, null, null);
			}
		}

		// Token: 0x06011821 RID: 71713 RVA: 0x00517E14 File Offset: 0x00516214
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
				if (null != this.Level)
				{
					this.Level.text = this.data.level.ToString();
				}
				this._UpdateStatus();
			}
		}

		// Token: 0x0400B622 RID: 46626
		public Text Name;

		// Token: 0x0400B623 RID: 46627
		public Image jobIcon;

		// Token: 0x0400B624 RID: 46628
		public Text Level;

		// Token: 0x0400B625 RID: 46629
		public StateController comState;

		// Token: 0x0400B626 RID: 46630
		private RelationData data;
	}
}

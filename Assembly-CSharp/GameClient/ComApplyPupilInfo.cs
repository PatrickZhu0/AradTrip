using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE2 RID: 7138
	internal class ComApplyPupilInfo : MonoBehaviour
	{
		// Token: 0x060117FF RID: 71679 RVA: 0x005171F1 File Offset: 0x005155F1
		private void _OnRefusePupilApply(UIEvent uiEvent)
		{
			if (this.data != null && this.data.uid == (ulong)uiEvent.Param1)
			{
				this.OnClickRefuse();
			}
		}

		// Token: 0x06011800 RID: 71680 RVA: 0x0051721F File Offset: 0x0051561F
		public void OnClickRefuse()
		{
			if (this.data != null)
			{
				DataManager<RelationDataManager>.GetInstance().RefuseApplyPupils(new ulong[]
				{
					this.data.uid
				});
				DataManager<RelationDataManager>.GetInstance().RemoveApplyPupil(this.data.uid);
			}
		}

		// Token: 0x06011801 RID: 71681 RVA: 0x00517260 File Offset: 0x00515660
		public void OnClickAccept()
		{
			if (this.data != null)
			{
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
				{
					DataManager<RelationDataManager>.GetInstance().AcceptApplyPupils(this.data.uid);
					DataManager<RelationDataManager>.GetInstance().RemoveApplyPupil(this.data.uid);
				}
				else
				{
					DataManager<RelationDataManager>.GetInstance()._AcceptApplyTeachers(this.data.uid);
					DataManager<RelationDataManager>.GetInstance().RemoveApplyTeacher(this.data.uid);
				}
			}
		}

		// Token: 0x06011802 RID: 71682 RVA: 0x005172E4 File Offset: 0x005156E4
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
						if (null != this.jobText)
						{
							this.jobText.text = tableItem.Name;
						}
					}
					ETCImageLoader.LoadSprite(ref this.jobIcon, path, true);
				}
				if (null != this.Level)
				{
					this.Level.text = this.data.level.ToString();
				}
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
				{
					this.information.text = string.Format("宣言:{0}", TR.Value("tap_teacher_region"));
				}
				else
				{
					this.information.text = string.Format("宣言:{0}", TR.Value("tap_pupil_region"));
				}
				if (null != this.region)
				{
					AreaProvinceTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<AreaProvinceTable>((int)this.data.regionId, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						this.region.text = tableItem3.Name;
					}
				}
				if (null != this.information && this.data.declaration != null && this.data.declaration != string.Empty)
				{
					this.information.text = string.Format("宣言:{0}", this.data.declaration);
				}
			}
		}

		// Token: 0x06011803 RID: 71683 RVA: 0x005174EC File Offset: 0x005158EC
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

		// Token: 0x0400B5FD RID: 46589
		public Text Name;

		// Token: 0x0400B5FE RID: 46590
		public Image jobIcon;

		// Token: 0x0400B5FF RID: 46591
		public Button btnRefuse;

		// Token: 0x0400B600 RID: 46592
		public UIGray grayRefuse;

		// Token: 0x0400B601 RID: 46593
		public Button btnAccept;

		// Token: 0x0400B602 RID: 46594
		public UIGray grayAccept;

		// Token: 0x0400B603 RID: 46595
		public Text Level;

		// Token: 0x0400B604 RID: 46596
		public Text jobText;

		// Token: 0x0400B605 RID: 46597
		public Text region;

		// Token: 0x0400B606 RID: 46598
		public Text information;

		// Token: 0x0400B607 RID: 46599
		private RelationData data;
	}
}

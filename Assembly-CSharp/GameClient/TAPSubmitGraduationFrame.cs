using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BDF RID: 7135
	public class TAPSubmitGraduationFrame : ClientFrame
	{
		// Token: 0x060117CE RID: 71630 RVA: 0x00515A28 File Offset: 0x00513E28
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPSubmitGraduationFrame";
		}

		// Token: 0x060117CF RID: 71631 RVA: 0x00515A2F File Offset: 0x00513E2F
		protected sealed override void _OnOpenFrame()
		{
			this._InitData();
			this._UpdateUI();
			if (this.relationDataToggleList.Count != 0)
			{
				this.relationDataToggleList[0].isOn = true;
			}
		}

		// Token: 0x060117D0 RID: 71632 RVA: 0x00515A5F File Offset: 0x00513E5F
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
		}

		// Token: 0x060117D1 RID: 71633 RVA: 0x00515A67 File Offset: 0x00513E67
		private void _InitData()
		{
			this.relationDataToggleList.Clear();
			this.graduationList.Clear();
			this._InitGraduationList();
			this._InitComUIList();
		}

		// Token: 0x060117D2 RID: 71634 RVA: 0x00515A8C File Offset: 0x00513E8C
		private void _InitGraduationList()
		{
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
			for (int i = 0; i < relation.Count; i++)
			{
				if (i <= 0)
				{
					relation[i].tapType = TAPType.Teacher;
					this.graduationList.Add(relation[i]);
				}
			}
			List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			for (int j = 0; j < relation2.Count; j++)
			{
				relation2[j].tapType = TAPType.Pupil;
				this.graduationList.Add(relation2[j]);
			}
		}

		// Token: 0x060117D3 RID: 71635 RVA: 0x00515B2C File Offset: 0x00513F2C
		private void _InitComUIList()
		{
			this.mTAPItemComUIList.Initialize();
			this.mTAPItemComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateRewardBind(item);
				}
			};
			this.mTAPItemComUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
			this.mTAPItemComUIList.SetElementAmount(this.graduationList.Count);
		}

		// Token: 0x060117D4 RID: 71636 RVA: 0x00515B9C File Offset: 0x00513F9C
		private void _UpdateRewardBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			if (this.graduationList.Count <= 0)
			{
				return;
			}
			RelationData tempRelationData = this.graduationList[item.m_index];
			if (tempRelationData == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("Name");
			Image com2 = component.GetCom<Image>("Icon");
			Toggle com3 = component.GetCom<Toggle>("PupilToggle");
			GameObject mSelect = component.GetGameObject("Select");
			Text com4 = component.GetCom<Text>("Level");
			GameObject gameObject = component.GetGameObject("TeacherImage");
			GameObject gameObject2 = component.GetGameObject("PupilImage");
			com.text = tempRelationData.name;
			com4.text = tempRelationData.level.ToString();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)tempRelationData.occu, string.Empty, string.Empty);
			if (null != com2)
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
				ETCImageLoader.LoadSprite(ref com2, path, true);
			}
			com3.onValueChanged.RemoveAllListeners();
			com3.onValueChanged.AddListener(delegate(bool flag)
			{
				mSelect.CustomActive(flag);
				if (flag)
				{
					this.relationData = tempRelationData;
					this._UpdateUI();
				}
			});
			this.relationDataToggleList.Add(com3);
			if (tempRelationData.tapType == TAPType.Teacher)
			{
				gameObject.CustomActive(true);
				gameObject2.CustomActive(false);
			}
			else if (tempRelationData.tapType == TAPType.Pupil)
			{
				gameObject.CustomActive(false);
				gameObject2.CustomActive(true);
			}
			else
			{
				gameObject.CustomActive(false);
				gameObject2.CustomActive(false);
			}
		}

		// Token: 0x060117D5 RID: 71637 RVA: 0x00515D98 File Offset: 0x00514198
		private void _UpdateUI()
		{
			this.mTips1.CustomActive(false);
			this.mTips2.CustomActive(false);
			this.mTips3.CustomActive(false);
			if (this.relationData == null)
			{
				return;
			}
			if (this.relationData.tapType == TAPType.Pupil)
			{
				if (this.relationData.isOnline == 0)
				{
					this.tapGraduationType = TAPGraduationType.TeacherGraduationLate;
					this.mTips2.CustomActive(true);
				}
				else
				{
					this.tapGraduationType = TAPGraduationType.TeacherGraduation;
					this.mTips1.CustomActive(true);
				}
			}
			else
			{
				this.tapGraduationType = TAPGraduationType.PupilGraduationLate;
				this.mTips3.CustomActive(true);
			}
		}

		// Token: 0x060117D6 RID: 71638 RVA: 0x00515E39 File Offset: 0x00514239
		private void _ClearData()
		{
			this.relationDataToggleList.Clear();
			this.graduationList.Clear();
			this.tapGraduationType = TAPGraduationType.None;
		}

		// Token: 0x060117D7 RID: 71639 RVA: 0x00515E58 File Offset: 0x00514258
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mTips1 = this.mBind.GetGameObject("tips1");
			this.mTips2 = this.mBind.GetGameObject("tips2");
			this.mTips3 = this.mBind.GetGameObject("tips3");
			this.mTAPItemComUIList = this.mBind.GetCom<ComUIListScript>("TAPItemComUIList");
			this.mSubmit = this.mBind.GetCom<Button>("Submit");
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.AddListener(new UnityAction(this._onSubmitButtonClick));
			}
		}

		// Token: 0x060117D8 RID: 71640 RVA: 0x00515F44 File Offset: 0x00514344
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mTips1 = null;
			this.mTips2 = null;
			this.mTips3 = null;
			this.mTAPItemComUIList = null;
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.RemoveListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mSubmit = null;
		}

		// Token: 0x060117D9 RID: 71641 RVA: 0x00515FD5 File Offset: 0x005143D5
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TAPSubmitGraduationFrame>(this, false);
		}

		// Token: 0x060117DA RID: 71642 RVA: 0x00515FE4 File Offset: 0x005143E4
		private void _onSubmitButtonClick()
		{
			TAPGraduationType tapgraduationType = this.tapGraduationType;
			if (tapgraduationType != TAPGraduationType.TeacherGraduation)
			{
				if (tapgraduationType != TAPGraduationType.TeacherGraduationLate)
				{
					if (tapgraduationType == TAPGraduationType.PupilGraduationLate)
					{
						DataManager<TAPNewDataManager>.GetInstance().SendGraduationLate(this.relationData.uid);
					}
				}
				else
				{
					DataManager<TAPNewDataManager>.GetInstance().SendGraduationLate(this.relationData.uid);
				}
			}
			else
			{
				DataManager<TAPNewDataManager>.GetInstance().SendGraduation(this.relationData.uid);
			}
			this.frameMgr.CloseFrame<TAPSubmitGraduationFrame>(this, false);
		}

		// Token: 0x0400B5D7 RID: 46551
		private RelationData relationData;

		// Token: 0x0400B5D8 RID: 46552
		private TAPGraduationType tapGraduationType;

		// Token: 0x0400B5D9 RID: 46553
		private List<RelationData> graduationList = new List<RelationData>();

		// Token: 0x0400B5DA RID: 46554
		private List<Toggle> relationDataToggleList = new List<Toggle>();

		// Token: 0x0400B5DB RID: 46555
		private Button mClose;

		// Token: 0x0400B5DC RID: 46556
		private GameObject mTips1;

		// Token: 0x0400B5DD RID: 46557
		private GameObject mTips2;

		// Token: 0x0400B5DE RID: 46558
		private GameObject mTips3;

		// Token: 0x0400B5DF RID: 46559
		private ComUIListScript mTAPItemComUIList;

		// Token: 0x0400B5E0 RID: 46560
		private Button mSubmit;
	}
}

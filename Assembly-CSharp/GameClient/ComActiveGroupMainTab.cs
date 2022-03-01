using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013DA RID: 5082
	public class ComActiveGroupMainTab : MonoBehaviour
	{
		// Token: 0x0600C50A RID: 50442 RVA: 0x002F689A File Offset: 0x002F4C9A
		public void SetBinderID(int mainId, int subId)
		{
			if (null != this.redBinder)
			{
				this.redBinder.SetId(mainId, subId);
			}
		}

		// Token: 0x0600C50B RID: 50443 RVA: 0x002F68BC File Offset: 0x002F4CBC
		public void OnValueChanged(bool bOn)
		{
			if (null != this.toggle)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnValueChanged));
				this.toggle.isOn = bOn;
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnValueChanged));
			}
			bool flag = false;
			if (bOn)
			{
				if (!this.mSelected)
				{
					this._OnSelected();
					this.mSelected = true;
				}
				else
				{
					flag = true;
					this._OnRepeatSelected();
					this.mSelected = false;
				}
			}
			else
			{
				this.mSelected = false;
			}
			if (null != this.comState)
			{
				if (this.mainItem != null && this.mainItem.ChildTabs.Count == 1)
				{
					this.comState.Key = ((!bOn) ? "t_disable" : "t_enable");
				}
				else if (!flag)
				{
					this.comState.Key = ((!bOn) ? "s_disable" : "s_enable_open");
				}
				else
				{
					this.comState.Key = ((!bOn) ? "s_disable" : "s_enable");
				}
			}
		}

		// Token: 0x0600C50C RID: 50444 RVA: 0x002F6A00 File Offset: 0x002F4E00
		private void _OnSelected()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementGroupSubTabChanged, this.mainItem, this.expandParent, null, null);
		}

		// Token: 0x0600C50D RID: 50445 RVA: 0x002F6A1F File Offset: 0x002F4E1F
		private void _OnRepeatSelected()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementGroupSubTabChangedRepeated, this.mainItem, this.expandParent, null, null);
		}

		// Token: 0x0600C50E RID: 50446 RVA: 0x002F6A40 File Offset: 0x002F4E40
		public void UpdateItemValue()
		{
			int subItemsAValue = DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsAValue(this.mainItem, null, true);
			int subItemsAValue2 = DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsAValue(this.mainItem, null, false);
			float value = 0f;
			if (subItemsAValue2 > 0)
			{
				value = Mathf.Clamp01(1f * (float)subItemsAValue / (float)subItemsAValue2);
			}
			if (null != this.mSlider)
			{
				this.mSlider.value = value;
			}
			string text = string.Empty;
			if (this.mainItem != null && !string.IsNullOrEmpty(this.mainItem.Name))
			{
				text = string.Format(this.mainItem.Name, subItemsAValue, subItemsAValue2);
			}
			for (int i = 0; i < this.mLabels.Length; i++)
			{
				if (null != this.mLabels[i])
				{
					this.mLabels[i].text = text;
				}
			}
		}

		// Token: 0x0600C50F RID: 50447 RVA: 0x002F6B34 File Offset: 0x002F4F34
		private void Awake()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this._OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this._OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this._OnDeleteMission));
		}

		// Token: 0x0600C510 RID: 50448 RVA: 0x002F6BB3 File Offset: 0x002F4FB3
		private void _OnAddNewMission(uint taskID)
		{
			this.UpdateItemValue();
		}

		// Token: 0x0600C511 RID: 50449 RVA: 0x002F6BBB File Offset: 0x002F4FBB
		private void _OnUpdateMission(uint taskID)
		{
			this.UpdateItemValue();
		}

		// Token: 0x0600C512 RID: 50450 RVA: 0x002F6BC3 File Offset: 0x002F4FC3
		private void _OnDeleteMission(uint taskID)
		{
			this.UpdateItemValue();
		}

		// Token: 0x0600C513 RID: 50451 RVA: 0x002F6BCC File Offset: 0x002F4FCC
		private void OnDestroy()
		{
			if (null != this.toggle)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnValueChanged));
				this.toggle = null;
			}
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this._OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this._OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this._OnDeleteMission));
		}

		// Token: 0x0400705D RID: 28765
		private const string mKeyTEnable = "t_enable";

		// Token: 0x0400705E RID: 28766
		private const string mKeyTDisable = "t_disable";

		// Token: 0x0400705F RID: 28767
		private const string mKeySEnable = "s_enable";

		// Token: 0x04007060 RID: 28768
		private const string mKeySDisable = "s_disable";

		// Token: 0x04007061 RID: 28769
		private const string mKeyTEnableOpen = "t_enable_open";

		// Token: 0x04007062 RID: 28770
		private const string mKeyTDisableOpen = "t_disable_open";

		// Token: 0x04007063 RID: 28771
		private const string mKeySEnableOpen = "s_enable_open";

		// Token: 0x04007064 RID: 28772
		private const string mKeySDisableOpen = "s_disable_open";

		// Token: 0x04007065 RID: 28773
		public StateController comState;

		// Token: 0x04007066 RID: 28774
		public Text[] mLabels = new Text[0];

		// Token: 0x04007067 RID: 28775
		public Slider mSlider;

		// Token: 0x04007068 RID: 28776
		public Toggle toggle;

		// Token: 0x04007069 RID: 28777
		public ComAchievementTabReadPointBinder redBinder;

		// Token: 0x0400706A RID: 28778
		private bool mSelected;

		// Token: 0x0400706B RID: 28779
		[HideInInspector]
		public AchievementGroupMainItemTable mainItem;

		// Token: 0x0400706C RID: 28780
		[HideInInspector]
		public GameObject expandParent;
	}
}

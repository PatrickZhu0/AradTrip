using System;
using ProtoTable;
using Scripts.UI;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AA8 RID: 6824
	public class PassiveSkillFrame : ClientFrame
	{
		// Token: 0x06010BD6 RID: 68566 RVA: 0x004BF53F File Offset: 0x004BD93F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/JobPassiveSkillTree";
		}

		// Token: 0x06010BD7 RID: 68567 RVA: 0x004BF546 File Offset: 0x004BD946
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
		}

		// Token: 0x06010BD8 RID: 68568 RVA: 0x004BF54E File Offset: 0x004BD94E
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x06010BD9 RID: 68569 RVA: 0x004BF556 File Offset: 0x004BD956
		private void ClearData()
		{
			this.iCurIndex = 0;
		}

		// Token: 0x06010BDA RID: 68570 RVA: 0x004BF560 File Offset: 0x004BD960
		private void OnChooseSkill(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			if (iIndex >= DataManager<SkillDataManager>.GetInstance().PassiveButtonBindSkill.Count)
			{
				return;
			}
			this.iCurIndex = iIndex;
			int skillid = DataManager<SkillDataManager>.GetInstance().PassiveButtonBindSkill[iIndex].skillid;
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			SkillDescriptionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillid, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.mSelIcon, tableItem.Icon, true);
			ETCImageLoader.LoadSprite(ref this.mSmallIcon, tableItem.SmallIcon, true);
			this.mSelIconGray.SetEnable((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit);
			this.mName.text = tableItem.Name;
			this.mLock.text = string.Empty;
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit)
			{
				this.mLock.text = string.Format("({0}级解锁)", tableItem.LevelLimit);
			}
			this.mDes.text = tableItem2.Description;
			this.mProp.text = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(skillid, 1, 1, FightTypeLabel.PVE);
		}

		// Token: 0x06010BDB RID: 68571 RVA: 0x004BF6AE File Offset: 0x004BDAAE
		public void InitInterface()
		{
			this.InitSkillListScrollBind();
			this.RefreshSkillListCount();
		}

		// Token: 0x06010BDC RID: 68572 RVA: 0x004BF6BC File Offset: 0x004BDABC
		private void InitSkillListScrollBind()
		{
			this.mSkillListScript.Initialize();
			this.mSkillListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdateSkillListScrollBind(item);
				}
			};
			this.mSkillListScript.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Toggle com = component.GetCom<Toggle>("tgSelect");
				com.onValueChanged.RemoveAllListeners();
			};
		}

		// Token: 0x06010BDD RID: 68573 RVA: 0x004BF714 File Offset: 0x004BDB14
		private void UpdateSkillListScrollBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= DataManager<SkillDataManager>.GetInstance().PassiveButtonBindSkill.Count)
			{
				return;
			}
			PassiveSkillData passiveSkillData = DataManager<SkillDataManager>.GetInstance().PassiveButtonBindSkill[item.m_index];
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(passiveSkillData.skillid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("Name");
			Text com2 = component.GetCom<Text>("Level");
			Image com3 = component.GetCom<Image>("Icon");
			Image com4 = component.GetCom<Image>("Lock");
			Image com5 = component.GetCom<Image>("SmallIcon");
			UIGray com6 = component.GetCom<UIGray>("IconRangeGray");
			Toggle com7 = component.GetCom<Toggle>("tgSelect");
			com.text = tableItem.Name;
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit)
			{
				com2.text = string.Format("<color=#ff0000ff>Lv.{0}</color>", tableItem.LevelLimit);
				com2.gameObject.CustomActive(true);
			}
			else
			{
				com2.gameObject.CustomActive(false);
			}
			ETCImageLoader.LoadSprite(ref com3, tableItem.Icon, true);
			ETCImageLoader.LoadSprite(ref com5, tableItem.SmallIcon, true);
			com4.gameObject.CustomActive((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit);
			com6.SetEnable((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit);
			com7.onValueChanged.RemoveAllListeners();
			int iIdex = item.m_index;
			com7.onValueChanged.AddListener(delegate(bool value)
			{
				this.OnChooseSkill(iIdex, value);
			});
			com7.group = this.mTgGroup;
			if (item.m_index == this.iCurIndex)
			{
				com7.isOn = true;
			}
		}

		// Token: 0x06010BDE RID: 68574 RVA: 0x004BF905 File Offset: 0x004BDD05
		private void RefreshSkillListCount()
		{
			this.mSkillListScript.SetElementAmount(DataManager<SkillDataManager>.GetInstance().PassiveButtonBindSkill.Count);
		}

		// Token: 0x06010BDF RID: 68575 RVA: 0x004BF924 File Offset: 0x004BDD24
		protected override void _bindExUI()
		{
			this.mSkillListScript = this.mBind.GetCom<ComUIListScript>("SkillListScript");
			this.mTgGroup = this.mBind.GetCom<ToggleGroup>("tgGroup");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mLock = this.mBind.GetCom<Text>("Lock");
			this.mDes = this.mBind.GetCom<Text>("Des");
			this.mProp = this.mBind.GetCom<Text>("Prop");
			this.mSelIcon = this.mBind.GetCom<Image>("SelIcon");
			this.mSelIconGray = this.mBind.GetCom<UIGray>("SelIconGray");
			this.mSmallIcon = this.mBind.GetCom<Image>("SmallIcon");
		}

		// Token: 0x06010BE0 RID: 68576 RVA: 0x004BF9F8 File Offset: 0x004BDDF8
		protected override void _unbindExUI()
		{
			this.mSkillListScript = null;
			this.mTgGroup = null;
			this.mName = null;
			this.mLock = null;
			this.mDes = null;
			this.mProp = null;
			this.mSelIcon = null;
			this.mSelIconGray = null;
			this.mSmallIcon = null;
		}

		// Token: 0x0400AB41 RID: 43841
		private int iCurIndex;

		// Token: 0x0400AB42 RID: 43842
		private ComUIListScript mSkillListScript;

		// Token: 0x0400AB43 RID: 43843
		private ToggleGroup mTgGroup;

		// Token: 0x0400AB44 RID: 43844
		private Text mName;

		// Token: 0x0400AB45 RID: 43845
		private Text mLock;

		// Token: 0x0400AB46 RID: 43846
		private Text mDes;

		// Token: 0x0400AB47 RID: 43847
		private Text mProp;

		// Token: 0x0400AB48 RID: 43848
		private Image mSelIcon;

		// Token: 0x0400AB49 RID: 43849
		private UIGray mSelIconGray;

		// Token: 0x0400AB4A RID: 43850
		private Image mSmallIcon;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001761 RID: 5985
	internal class LevelUpNotify : ClientFrame
	{
		// Token: 0x0600EC2A RID: 60458 RVA: 0x003EFCC0 File Offset: 0x003EE0C0
		protected override void _OnOpenFrame()
		{
			this.currentLevel = DataManager<PlayerBaseData>.GetInstance().Level;
			this.InitPanel();
			DestroyDelay component = this.frame.GetComponent<DestroyDelay>();
			base.StartCoroutine(this.closeDelay(component.Delay));
			component.enabled = false;
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Count > 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPlayerFunctionUnlockAnimation, null, null, null, null);
			}
		}

		// Token: 0x0600EC2B RID: 60459 RVA: 0x003EFD34 File Offset: 0x003EE134
		private IEnumerator closeDelay(float time)
		{
			yield return new WaitForSeconds(time);
			base.Close(false);
			yield break;
		}

		// Token: 0x0600EC2C RID: 60460 RVA: 0x003EFD56 File Offset: 0x003EE156
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UplevelFrameClose, null, null, null, null);
			if (DataManager<PlayerBaseData>.GetInstance().bNeedShowAwakeFrame)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AwakeFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600EC2D RID: 60461 RVA: 0x003EFD92 File Offset: 0x003EE192
		private void ClearData()
		{
			this.currentLevel = 0;
			this.NewSkillList.Clear();
			this.CanUpLvSkillList.Clear();
		}

		// Token: 0x0600EC2E RID: 60462 RVA: 0x003EFDB1 File Offset: 0x003EE1B1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/UpLevelNotifyNew";
		}

		// Token: 0x0600EC2F RID: 60463 RVA: 0x003EFDB8 File Offset: 0x003EE1B8
		private void InitPanel()
		{
			this.InitLearnSkill();
			this.InitFuncUnLock();
			if (this.currentLevel < 10)
			{
				ETCImageLoader.LoadSprite(ref this.mOddnum, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Vip_Jinse_0{0}", this.currentLevel), true);
				this.mOddnum.gameObject.SetActive(true);
			}
			else
			{
				Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Vip_Jinse_0{0}", (int)(this.currentLevel / 10)), typeof(Sprite), true, 0U).obj as Sprite;
				if (sprite != null)
				{
					ETCImageLoader.LoadSprite(ref this.mEvennumone, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Vip_Jinse_0{0}", (int)(this.currentLevel / 10)), true);
					this.mEvennumone.gameObject.SetActive(true);
				}
				Sprite sprite2 = Singleton<AssetLoader>.instance.LoadRes(string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Vip_Jinse_0{0}", (int)(this.currentLevel % 10)), typeof(Sprite), true, 0U).obj as Sprite;
				if (sprite2 != null)
				{
					ETCImageLoader.LoadSprite(ref this.mEvennumtwo, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Vip_Jinse_0{0}", (int)(this.currentLevel % 10)), true);
					this.mEvennumtwo.gameObject.SetActive(true);
				}
			}
		}

		// Token: 0x0600EC30 RID: 60464 RVA: 0x003EFF0C File Offset: 0x003EE30C
		private void InitAttr()
		{
		}

		// Token: 0x0600EC31 RID: 60465 RVA: 0x003EFF0E File Offset: 0x003EE30E
		private void InitSkillPoint()
		{
		}

		// Token: 0x0600EC32 RID: 60466 RVA: 0x003EFF10 File Offset: 0x003EE310
		private void InitLearnSkill()
		{
			Dictionary<int, int>.Enumerator enumerator = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill.GetEnumerator();
			bool flag = false;
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				SkillTable tableItem = instance.GetTableItem<SkillTable>(keyValuePair.Value, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.LevelLimit == (int)this.currentLevel)
					{
						JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							if (this.currentLevel <= 10 || tableItem2.JobType != 0)
							{
								UpLevelSkillData item = default(UpLevelSkillData);
								item.name = tableItem.Name;
								item.iconpath = tableItem.Icon;
								this.NewSkillList.Add(item);
							}
						}
					}
					else if (tableItem.LevelLimit < (int)this.currentLevel && !flag && this.CanUpLvSkillList.Count < 5 && DataManager<SkillDataManager>.GetInstance().CheckSkillLvUp(tableItem.ID))
					{
						UpLevelSkillData item2 = default(UpLevelSkillData);
						item2.name = tableItem.Name;
						item2.iconpath = tableItem.Icon;
						this.CanUpLvSkillList.Add(item2);
					}
				}
			}
			if (this.NewSkillList.Count <= 0 && this.CanUpLvSkillList.Count <= 0)
			{
				this.mSkillTitle.gameObject.SetActive(false);
				this.mSkillTitleBack.gameObject.SetActive(false);
			}
			int num = 0;
			while (num < this.NewSkillList.Count && num < 5)
			{
				this.AddLearnSkill(this.NewSkillList[num].name, this.NewSkillList[num].iconpath, num);
				this.lvupImg[num].gameObject.SetActive(false);
				num++;
			}
			int count = this.NewSkillList.Count;
			if (this.NewSkillList.Count <= 0)
			{
				this.mSkillTitle.text = "可升级技能";
				int num2 = 0;
				while (num2 < this.CanUpLvSkillList.Count && num2 < 5)
				{
					this.AddLearnSkill(this.CanUpLvSkillList[num2].name, this.CanUpLvSkillList[num2].iconpath, num2);
					this.lvupImg[num2].gameObject.SetActive(true);
					num2++;
				}
				count = this.CanUpLvSkillList.Count;
			}
			else if (this.currentLevel == 45)
			{
				this.mSkillTitle.text = "开启觉醒任务";
			}
			for (int i = count; i < 5; i++)
			{
				this.NewSkillRoot[i].gameObject.SetActive(false);
			}
		}

		// Token: 0x0600EC33 RID: 60467 RVA: 0x003F0211 File Offset: 0x003EE611
		private void AddLearnSkill(string name, string iconpath, int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.NewSkillImg.Length)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.NewSkillImg[iIndex], iconpath, true);
			this.NewSkillText[iIndex].text = name;
		}

		// Token: 0x0600EC34 RID: 60468 RVA: 0x003F024C File Offset: 0x003EE64C
		private void InitFuncUnLock()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FunctionUnLock>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				FunctionUnLock functionUnLock = keyValuePair.Value as FunctionUnLock;
				if (functionUnLock != null && functionUnLock.ShowFunctionOpen == 1 && functionUnLock.FinishLevel == (int)this.currentLevel)
				{
					if (functionUnLock.FuncType != FunctionUnLock.eFuncType.AdventureTeam || functionUnLock.BindType != FunctionUnLock.eBindType.BT_AccBind || DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains(functionUnLock.ID))
					{
						if (functionUnLock.FuncType != FunctionUnLock.eFuncType.AdventurePassSeason || functionUnLock.BindType != FunctionUnLock.eBindType.BT_AccBind || DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains(functionUnLock.ID))
						{
							this.AddUnLockFunction(functionUnLock.Name, functionUnLock.IconPath, num);
							num++;
						}
					}
				}
			}
			if (num == 0)
			{
				this.mFuncTitle.gameObject.SetActive(false);
				this.mFuncTitleBack.gameObject.SetActive(false);
			}
			for (int i = num; i < 4; i++)
			{
				this.NewFuncRoot[i].gameObject.SetActive(false);
			}
		}

		// Token: 0x0600EC35 RID: 60469 RVA: 0x003F0390 File Offset: 0x003EE790
		private void AddUnLockFunction(string name, string iconpath, int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.NewFunctionImg.Length)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.NewFunctionImg[iIndex], iconpath, true);
			this.NewFunctionText[iIndex].text = name;
		}

		// Token: 0x0600EC36 RID: 60470 RVA: 0x003F03CC File Offset: 0x003EE7CC
		private bool CheckIsSevenAwardClose(FunctionUnLock curItem)
		{
			if (curItem == null)
			{
				return false;
			}
			int num = 32;
			return curItem.ID == num && Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SEVEN_AWARDS);
		}

		// Token: 0x0600EC37 RID: 60471 RVA: 0x003F0404 File Offset: 0x003EE804
		protected override void _bindExUI()
		{
			this.mSkillTitle = this.mBind.GetCom<Text>("SkillTitle");
			this.mFuncTitle = this.mBind.GetCom<Text>("FuncTitle");
			this.mSkillTitleBack = this.mBind.GetCom<Image>("SkillTitleBack");
			this.mFuncTitleBack = this.mBind.GetCom<Image>("FuncTitleBack");
			this.mOddnum = this.mBind.GetCom<Image>("oddnum");
			this.mEvennumone = this.mBind.GetCom<Image>("evennumone");
			this.mEvennumtwo = this.mBind.GetCom<Image>("evennumtwo");
		}

		// Token: 0x0600EC38 RID: 60472 RVA: 0x003F04AB File Offset: 0x003EE8AB
		protected override void _unbindExUI()
		{
			this.mSkillTitle = null;
			this.mFuncTitle = null;
			this.mSkillTitleBack = null;
			this.mFuncTitleBack = null;
			this.mOddnum = null;
			this.mEvennumone = null;
			this.mEvennumtwo = null;
		}

		// Token: 0x04008F7E RID: 36734
		private const int iShowSkillNum = 5;

		// Token: 0x04008F7F RID: 36735
		private const int iNewFuncNum = 4;

		// Token: 0x04008F80 RID: 36736
		private ushort currentLevel;

		// Token: 0x04008F81 RID: 36737
		private List<UpLevelSkillData> NewSkillList = new List<UpLevelSkillData>();

		// Token: 0x04008F82 RID: 36738
		private List<UpLevelSkillData> CanUpLvSkillList = new List<UpLevelSkillData>();

		// Token: 0x04008F83 RID: 36739
		[UIControl("Back/NewSkill/Panel/Image{0}", typeof(RectTransform), 1)]
		private RectTransform[] NewSkillRoot = new RectTransform[5];

		// Token: 0x04008F84 RID: 36740
		[UIControl("Back/FunctionUnlock/Panel/Image{0}", typeof(RectTransform), 1)]
		private RectTransform[] NewFuncRoot = new RectTransform[4];

		// Token: 0x04008F85 RID: 36741
		[UIControl("Back/NewSkill/Panel/Image{0}/Image", typeof(Image), 1)]
		private Image[] NewSkillImg = new Image[5];

		// Token: 0x04008F86 RID: 36742
		[UIControl("Back/NewSkill/Panel/Image{0}/Text", typeof(Text), 1)]
		private Text[] NewSkillText = new Text[5];

		// Token: 0x04008F87 RID: 36743
		[UIControl("Back/FunctionUnlock/Panel/Image{0}/Icon", typeof(Image), 1)]
		private Image[] NewFunctionImg = new Image[4];

		// Token: 0x04008F88 RID: 36744
		[UIControl("Back/FunctionUnlock/Panel/Image{0}/Text", typeof(Text), 1)]
		private Text[] NewFunctionText = new Text[4];

		// Token: 0x04008F89 RID: 36745
		[UIControl("Back/NewSkill/Panel/Image{0}/lvup", typeof(Image), 1)]
		private Image[] lvupImg = new Image[5];

		// Token: 0x04008F8A RID: 36746
		private Text mSkillTitle;

		// Token: 0x04008F8B RID: 36747
		private Text mFuncTitle;

		// Token: 0x04008F8C RID: 36748
		private Image mSkillTitleBack;

		// Token: 0x04008F8D RID: 36749
		private Image mFuncTitleBack;

		// Token: 0x04008F8E RID: 36750
		private Image mOddnum;

		// Token: 0x04008F8F RID: 36751
		private Image mEvennumone;

		// Token: 0x04008F90 RID: 36752
		private Image mEvennumtwo;
	}
}

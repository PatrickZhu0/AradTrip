using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200197D RID: 6525
	internal class PetItemTipsFrame : ClientFrame
	{
		// Token: 0x0600FDA8 RID: 64936 RVA: 0x00460120 File Offset: 0x0045E520
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pet/PetItemTips";
		}

		// Token: 0x0600FDA9 RID: 64937 RVA: 0x00460127 File Offset: 0x0045E527
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			this.PetTipsData = (this.userData as PetItemTipsData);
			this.InitInterface();
		}

		// Token: 0x0600FDAA RID: 64938 RVA: 0x0046014C File Offset: 0x0045E54C
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600FDAB RID: 64939 RVA: 0x00460154 File Offset: 0x0045E554
		private void ClearData()
		{
			this.PetTipsData.ClearData();
		}

		// Token: 0x0600FDAC RID: 64940 RVA: 0x00460164 File Offset: 0x0045E564
		private void InitInterface()
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.PetTipsData.petinfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.goFunc.CustomActive(this.PetTipsData.bFunc);
			if (this.PetTipsData.bFunc)
			{
				if (this.PetTipsData.petTipsType == PetTipsType.PetItemTip)
				{
					this.mBtWear.gameObject.CustomActive(true);
					if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle)
					{
						this.mBtUpLevel.gameObject.CustomActive(false);
					}
					else
					{
						this.mBtUpLevel.gameObject.CustomActive(true);
					}
				}
				else if (this.PetTipsData.petTipsType == PetTipsType.OnUsePetTip)
				{
					this.mSpecialText.text = "卸下";
					this.mBtWear.gameObject.CustomActive(true);
					if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle)
					{
						this.mBtUpLevel.gameObject.CustomActive(false);
					}
					else
					{
						this.mBtUpLevel.gameObject.CustomActive(true);
					}
				}
			}
			bool bActive = null != DataManager<PetDataManager>.GetInstance().GetOnUsePetList().Find((PetInfo x) => x.id == this.PetTipsData.petinfo.id);
			this.goTake.CustomActive(bActive);
			this.mName.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, tableItem.Quality);
			this.mSatiety.text = this.PetTipsData.petinfo.hunger.ToString();
			this.mLevel.text = this.PetTipsData.petinfo.level.ToString();
			this.mQuality.text = DataManager<PetDataManager>.GetInstance().GetQualityDesc(tableItem.Quality);
			this.mPetType.text = DataManager<PetDataManager>.GetInstance().GetPetTypeDesc(tableItem.PetType);
			this.mScore.text = this.PetTipsData.petinfo.petScore.ToString();
			if (!string.IsNullOrEmpty(tableItem.IconPath) && tableItem.IconPath != "-")
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.IconPath, true);
			}
			string qualityTipTitleBackGround = DataManager<PetDataManager>.GetInstance().GetQualityTipTitleBackGround(tableItem.Quality);
			if (!string.IsNullOrEmpty(qualityTipTitleBackGround) && qualityTipTitleBackGround != "-")
			{
				ETCImageLoader.LoadSprite(ref this.mTitleBg, qualityTipTitleBackGround, true);
			}
			string qualityIconBack = DataManager<PetDataManager>.GetInstance().GetQualityIconBack(tableItem.Quality);
			if (!string.IsNullOrEmpty(qualityIconBack) && qualityIconBack != "-")
			{
				ETCImageLoader.LoadSprite(ref this.mIconBack, qualityIconBack, true);
			}
			if (this.PetTipsData.petTipsType != PetTipsType.None)
			{
				if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle)
				{
					this.mBtProperty.gameObject.CustomActive(false);
				}
				else
				{
					this.mBtProperty.gameObject.CustomActive(true);
				}
			}
			int num = DataManager<PetDataManager>.GetInstance().ShowPetHalfStarNum((int)this.PetTipsData.petinfo.level);
			for (int i = 0; i < this.stars.Length; i++)
			{
				if (i < num)
				{
					this.stars[i].gameObject.CustomActive(true);
				}
				else
				{
					this.stars[i].gameObject.CustomActive(false);
				}
			}
			if ((int)this.PetTipsData.petinfo.skillIndex <= tableItem.Skills.Count)
			{
				this.mProperty.text = DataManager<PetDataManager>.GetInstance().GetPetPropertyTips(tableItem, (int)this.PetTipsData.petinfo.level);
				this.mCurSkill.text = DataManager<PetDataManager>.GetInstance().GetPetCurSkillTips(tableItem, this.PetTipsData.PlayerJobID, (int)this.PetTipsData.petinfo.skillIndex, (int)this.PetTipsData.petinfo.level, true);
				this.mSelSkill.text = DataManager<PetDataManager>.GetInstance().GetCanSelectSkillTips(tableItem, this.PetTipsData.PlayerJobID, (int)this.PetTipsData.petinfo.skillIndex, (int)this.PetTipsData.petinfo.level);
			}
		}

		// Token: 0x0600FDAD RID: 64941 RVA: 0x004605B8 File Offset: 0x0045E9B8
		private void ClickSellOK()
		{
			this.SendSellPetReq();
			this.frameMgr.CloseFrame<PetItemTipsFrame>(this, false);
		}

		// Token: 0x0600FDAE RID: 64942 RVA: 0x004605D0 File Offset: 0x0045E9D0
		private void SendWearPetReq()
		{
			if (this.PetTipsData.petinfo.id <= 0UL)
			{
				return;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.PetTipsData.petinfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			SceneSetPetSoltReq sceneSetPetSoltReq = new SceneSetPetSoltReq();
			sceneSetPetSoltReq.petType = (byte)tableItem.PetType;
			if (this.PetTipsData.petTipsType == PetTipsType.OnUsePetTip)
			{
				sceneSetPetSoltReq.petId = 0UL;
			}
			else
			{
				sceneSetPetSoltReq.petId = this.PetTipsData.petinfo.id;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneSetPetSoltReq>(ServerType.GATE_SERVER, sceneSetPetSoltReq);
		}

		// Token: 0x0600FDAF RID: 64943 RVA: 0x00460678 File Offset: 0x0045EA78
		private void SendSellPetReq()
		{
			if (this.PetTipsData.petinfo.id <= 0UL)
			{
				return;
			}
			SceneSellPetReq sceneSellPetReq = new SceneSellPetReq();
			sceneSellPetReq.id = this.PetTipsData.petinfo.id;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneSellPetReq>(ServerType.GATE_SERVER, sceneSellPetReq);
		}

		// Token: 0x0600FDB0 RID: 64944 RVA: 0x004606C8 File Offset: 0x0045EAC8
		protected override void _bindExUI()
		{
			this.mBtWear = this.mBind.GetCom<Button>("btWear");
			this.mBtWear.onClick.AddListener(new UnityAction(this._onBtWearButtonClick));
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mIcon = this.mBind.GetCom<Image>("Icon");
			this.mBtUpLevel = this.mBind.GetCom<Button>("btUpLevel");
			this.mBtUpLevel.onClick.AddListener(new UnityAction(this._onBtUpLevelButtonClick));
			this.mBtProperty = this.mBind.GetCom<Button>("btProperty");
			this.mBtProperty.onClick.AddListener(new UnityAction(this._onBtPropertyButtonClick));
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mQuality = this.mBind.GetCom<Text>("Quality");
			this.mPetType = this.mBind.GetCom<Text>("PetType");
			this.mIconBack = this.mBind.GetCom<Image>("IconBack");
			this.mTitleBack = this.mBind.GetCom<Image>("TitleBack");
			this.mProperty = this.mBind.GetCom<Text>("Property");
			this.mSatiety = this.mBind.GetCom<Text>("Satiety");
			this.mSpecialText = this.mBind.GetCom<Text>("SpecialText");
			this.mCurSkill = this.mBind.GetCom<Text>("CurSkill");
			this.mTitleBg = this.mBind.GetCom<Image>("TitleBg");
			this.mSelSkill = this.mBind.GetCom<Text>("SelSkill");
			this.mScore = this.mBind.GetCom<Text>("Score");
		}

		// Token: 0x0600FDB1 RID: 64945 RVA: 0x004608A0 File Offset: 0x0045ECA0
		protected override void _unbindExUI()
		{
			this.mBtWear.onClick.RemoveListener(new UnityAction(this._onBtWearButtonClick));
			this.mBtWear = null;
			this.mName = null;
			this.mIcon = null;
			this.mBtUpLevel.onClick.RemoveListener(new UnityAction(this._onBtUpLevelButtonClick));
			this.mBtUpLevel = null;
			this.mBtProperty.onClick.RemoveListener(new UnityAction(this._onBtPropertyButtonClick));
			this.mBtProperty = null;
			this.mLevel = null;
			this.mQuality = null;
			this.mPetType = null;
			this.mIconBack = null;
			this.mTitleBack = null;
			this.mProperty = null;
			this.mSatiety = null;
			this.mSpecialText = null;
			this.mCurSkill = null;
			this.mTitleBg = null;
			this.mSelSkill = null;
			this.mScore = null;
		}

		// Token: 0x0600FDB2 RID: 64946 RVA: 0x00460978 File Offset: 0x0045ED78
		private void _onBtWearButtonClick()
		{
			this.SendWearPetReq();
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600FDB3 RID: 64947 RVA: 0x0046098A File Offset: 0x0045ED8A
		private void _onBtUpLevelButtonClick()
		{
			DataManager<PetDataManager>.GetInstance().OpenPetInfoFrame(PetInfoTabType.Pet_UpLevel, this.PetTipsData.petinfo);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600FDB4 RID: 64948 RVA: 0x004609AC File Offset: 0x0045EDAC
		private void _onBtPropertyButtonClick()
		{
			DataManager<PetDataManager>.GetInstance().OpenPetInfoFrame(PetInfoTabType.Pet_Property, this.PetTipsData.petinfo);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x04009FA4 RID: 40868
		private const int MaxStarNum = 5;

		// Token: 0x04009FA5 RID: 40869
		private PetItemTipsData PetTipsData = new PetItemTipsData();

		// Token: 0x04009FA6 RID: 40870
		[UIObject("Func")]
		private GameObject goFunc;

		// Token: 0x04009FA7 RID: 40871
		[UIObject("mark")]
		private GameObject goTake;

		// Token: 0x04009FA8 RID: 40872
		[UIControl("BG/InfoView/ViewPort/Content/IconRoot/stars/star{0}", typeof(Image), 1)]
		private Image[] stars = new Image[10];

		// Token: 0x04009FA9 RID: 40873
		private Button mBtWear;

		// Token: 0x04009FAA RID: 40874
		private Text mName;

		// Token: 0x04009FAB RID: 40875
		private Image mIcon;

		// Token: 0x04009FAC RID: 40876
		private Button mBtUpLevel;

		// Token: 0x04009FAD RID: 40877
		private Button mBtProperty;

		// Token: 0x04009FAE RID: 40878
		private Text mLevel;

		// Token: 0x04009FAF RID: 40879
		private Text mQuality;

		// Token: 0x04009FB0 RID: 40880
		private Text mPetType;

		// Token: 0x04009FB1 RID: 40881
		private Image mIconBack;

		// Token: 0x04009FB2 RID: 40882
		private Image mTitleBack;

		// Token: 0x04009FB3 RID: 40883
		private Text mProperty;

		// Token: 0x04009FB4 RID: 40884
		private Text mSatiety;

		// Token: 0x04009FB5 RID: 40885
		private Text mSpecialText;

		// Token: 0x04009FB6 RID: 40886
		private Text mCurSkill;

		// Token: 0x04009FB7 RID: 40887
		private Image mTitleBg;

		// Token: 0x04009FB8 RID: 40888
		private Text mSelSkill;

		// Token: 0x04009FB9 RID: 40889
		private Text mScore;
	}
}

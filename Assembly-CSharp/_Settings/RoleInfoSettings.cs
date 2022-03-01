using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A26 RID: 6694
	public class RoleInfoSettings : SettingsBindUI
	{
		// Token: 0x060106DF RID: 67295 RVA: 0x0049F1E3 File Offset: 0x0049D5E3
		public RoleInfoSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x060106E0 RID: 67296 RVA: 0x0049F1ED File Offset: 0x0049D5ED
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/roleInfo";
		}

		// Token: 0x060106E1 RID: 67297 RVA: 0x0049F1F4 File Offset: 0x0049D5F4
		protected override void InitBind()
		{
			this.headImg = this.mBind.GetCom<Image>("headImg");
			this.imgNum = this.mBind.GetCom<UINumber>("ImgNum");
			this.nameText = this.mBind.GetCom<Text>("Name");
			this.serverFieldText = this.mBind.GetCom<Text>("ServerField");
			this.mVersion = this.mBind.GetCom<Text>("Version");
			this.changeNameBtn = this.mBind.GetCom<Button>("ChangeNameBtn");
			if (this.changeNameBtn)
			{
				this.changeNameBtn.onClick.RemoveListener(new UnityAction(this.OnChangeNameBtnClick));
				this.changeNameBtn.onClick.AddListener(new UnityAction(this.OnChangeNameBtnClick));
			}
			this.levelText = this.mBind.GetCom<Text>("Level");
			this.expNumText = this.mBind.GetCom<Text>("ExpNums");
			this.expNumSlider = this.mBind.GetCom<Slider>("ExpSlider");
			this.jobText = this.mBind.GetCom<Text>("Job");
			this.winRateText = this.mBind.GetCom<Text>("WinRate");
			this.pkNumText = this.mBind.GetCom<Text>("PkNum");
			this.pkLevelTotalImg = this.mBind.GetCom<Image>("PkLevelTotal");
			this.pkLevelDetailGo = this.mBind.GetGameObject("PkLevelDetail");
			this.pkRankDescText = this.mBind.GetCom<Text>("PkRankDesc");
			this.jobTitleText = this.mBind.GetCom<Text>("JobTitle");
			this.addNameTitle = this.mBind.GetCom<Button>("AddNameTitleBtn");
			if (this.addNameTitle)
			{
				this.addNameTitle.onClick.RemoveListener(new UnityAction(this.OnAddNameTitleBtnClick));
				this.addNameTitle.onClick.AddListener(new UnityAction(this.OnAddNameTitleBtnClick));
			}
			this.nameTitleText = this.mBind.GetCom<Text>("NameTitle");
			this.mTitleImg = this.mBind.GetCom<Image>("Tittle_Img");
			this.aniRenderer = this.mBind.GetCom<SpriteAniRenderChenghao>("AniRenderer");
			this.aniImg = this.mBind.GetCom<Image>("AniImg");
			this.equipRankText = this.mBind.GetCom<Text>("EquipRank");
			if (this.equipRankText)
			{
				this.equipRankText.transform.parent.gameObject.CustomActive(false);
				this.equipRankText.gameObject.CustomActive(false);
			}
			this.btnVipLevel = this.mBind.GetCom<Button>("btnVipLevel");
			if (this.btnVipLevel != null)
			{
				this.btnVipLevel.onClick.RemoveAllListeners();
				this.btnVipLevel.onClick.AddListener(new UnityAction(this._onVipLevelButtonClick));
			}
			this.mReplaceHeadPortraitFrame = this.mBind.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
			this.mMoreBtn = this.mBind.GetCom<Button>("More");
			if (this.mMoreBtn != null)
			{
				this.mMoreBtn.onClick.RemoveAllListeners();
				this.mMoreBtn.onClick.AddListener(new UnityAction(this._onMoreButtonClick));
			}
			this.mTitleName = this.mBind.GetCom<Text>("TitleName");
			this.mTitleButton = this.mBind.GetCom<Button>("TitleButton");
			if (this.mTitleButton != null)
			{
				this.mTitleButton.onClick.RemoveListener(new UnityAction(this.OnTitleButtonBtnClick));
				this.mTitleButton.onClick.AddListener(new UnityAction(this.OnTitleButtonBtnClick));
			}
			this.mHonorImg = this.mBind.GetCom<Image>("jobTitleHonor");
			this.mComPKRank = this.mBind.GetCom<ComPKRank>("PKRank");
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UseHeadPortraitFrameSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateHeadPortraitFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HeadPortraitFrameChange, new ClientEventSystem.UIEventHandler(this._OnHeadPortraitFrameChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TitleNameUpdate, new ClientEventSystem.UIEventHandler(this._OnTitleNameUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TitleBookCloseFrame, new ClientEventSystem.UIEventHandler(this._OnTitleBookClose));
		}

		// Token: 0x060106E2 RID: 67298 RVA: 0x0049F67A File Offset: 0x0049DA7A
		private void _onVipLevelButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VipFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<VipFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("VIPLevel");
		}

		// Token: 0x060106E3 RID: 67299 RVA: 0x0049F6BC File Offset: 0x0049DABC
		protected override void UnInitBind()
		{
			this.headImg = null;
			this.imgNum = null;
			this.nameText = null;
			this.serverFieldText = null;
			this.mVersion = null;
			if (this.changeNameBtn)
			{
				this.changeNameBtn.onClick.RemoveListener(new UnityAction(this.OnChangeNameBtnClick));
			}
			this.changeNameBtn = null;
			this.levelText = null;
			this.expNumText = null;
			this.expNumSlider = null;
			this.jobText = null;
			this.winRateText = null;
			this.pkNumText = null;
			this.pkLevelTotalImg = null;
			this.pkLevelDetailGo = null;
			this.pkRankDescText = null;
			this.jobTitleText = null;
			if (this.addNameTitle)
			{
				this.addNameTitle.onClick.RemoveListener(new UnityAction(this.OnAddNameTitleBtnClick));
			}
			this.addNameTitle = null;
			this.nameTitleText = null;
			this.aniRenderer = null;
			this.aniImg = null;
			this.equipRankText = null;
			this.btnVipLevel = null;
			this.mReplaceHeadPortraitFrame = null;
			if (this.mMoreBtn != null)
			{
				this.mMoreBtn.onClick.RemoveListener(new UnityAction(this._onMoreButtonClick));
			}
			this.mMoreBtn = null;
			this.mTitleName = null;
			this.mTitleImg = null;
			if (this.mTitleButton != null)
			{
				this.mTitleButton.onClick.RemoveAllListeners();
			}
			this.mTitleButton = null;
			this.mComPKRank = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UseHeadPortraitFrameSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateHeadPortraitFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HeadPortraitFrameChange, new ClientEventSystem.UIEventHandler(this._OnHeadPortraitFrameChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TitleNameUpdate, new ClientEventSystem.UIEventHandler(this._OnTitleNameUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TitleBookCloseFrame, new ClientEventSystem.UIEventHandler(this._OnTitleBookClose));
		}

		// Token: 0x060106E4 RID: 67300 RVA: 0x0049F89F File Offset: 0x0049DC9F
		private void _OnUpdateHeadPortraitFrame(UIEvent uiEvent)
		{
			this.UpdateHeadPortraitFrame();
		}

		// Token: 0x060106E5 RID: 67301 RVA: 0x0049F8A7 File Offset: 0x0049DCA7
		private void _OnHeadPortraitFrameChanged(UIEvent uiEvent)
		{
			this.UpdateHeadPortraitFrame();
		}

		// Token: 0x060106E6 RID: 67302 RVA: 0x0049F8AF File Offset: 0x0049DCAF
		private void _OnTitleNameUpdate(UIEvent uiEvent)
		{
			this.UpdateTitleInformation();
		}

		// Token: 0x060106E7 RID: 67303 RVA: 0x0049F8B7 File Offset: 0x0049DCB7
		private void _OnTitleBookClose(UIEvent uiEvent)
		{
			this.SetNameTitleImg();
		}

		// Token: 0x060106E8 RID: 67304 RVA: 0x0049F8BF File Offset: 0x0049DCBF
		protected override void OnShowOut()
		{
			this.SetAllViewContent();
			TittleBookManager instance = DataManager<TittleBookManager>.GetInstance();
			instance.onAddTittle = (TittleBookManager.OnAddTittle)Delegate.Combine(instance.onAddTittle, new TittleBookManager.OnAddTittle(this.OnAddNameTitleSucc));
		}

		// Token: 0x060106E9 RID: 67305 RVA: 0x0049F8ED File Offset: 0x0049DCED
		protected override void OnHideIn()
		{
			TittleBookManager instance = DataManager<TittleBookManager>.GetInstance();
			instance.onAddTittle = (TittleBookManager.OnAddTittle)Delegate.Remove(instance.onAddTittle, new TittleBookManager.OnAddTittle(this.OnAddNameTitleSucc));
		}

		// Token: 0x060106EA RID: 67306 RVA: 0x0049F915 File Offset: 0x0049DD15
		private void OnChangeNameBtnClick()
		{
			SystemNotifyManager.SysNotifyTextAnimation("改名功能暂未开放", CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x060106EB RID: 67307 RVA: 0x0049F922 File Offset: 0x0049DD22
		private void OnAddNameTitleBtnClick()
		{
			if (DataManager<PlayerBaseData>.GetInstance().Level >= 7)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TitleBookFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation("称号簿开启等级不足", CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x060106EC RID: 67308 RVA: 0x0049F956 File Offset: 0x0049DD56
		private void _onMoreButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PersonalSettingFrame>(FrameLayer.Middle, 1, string.Empty);
		}

		// Token: 0x060106ED RID: 67309 RVA: 0x0049F96F File Offset: 0x0049DD6F
		private void OnAddNameTitleSucc(ulong uid)
		{
			this.SetNameTitleImg();
		}

		// Token: 0x060106EE RID: 67310 RVA: 0x0049F977 File Offset: 0x0049DD77
		private void OnTitleButtonBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PersonalSettingFrame>(FrameLayer.Middle, 0, string.Empty);
		}

		// Token: 0x060106EF RID: 67311 RVA: 0x0049F990 File Offset: 0x0049DD90
		private void SetAllViewContent()
		{
			this.SetPlayerIcon();
			this.SetPlayerName();
			this.SetVipLevel();
			this.SetServerName();
			this.SetVersion();
			this.SetRoleLevel();
			this.SetRoleExp();
			this.SetJobName();
			this.SetWinRate();
			this.SetTotalPkCount();
			this.SetPkLevelImgShow();
			this.SetGuildJob();
			this.SetNameTitleImg();
			this.SetEquipGrade();
			this.UpdateHeadPortraitFrame();
			this.UpdateTitleInformation();
		}

		// Token: 0x060106F0 RID: 67312 RVA: 0x0049FA00 File Offset: 0x0049DE00
		private void UpdateHeadPortraitFrame()
		{
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (HeadPortraitFrameDataManager.WearHeadPortraitFrameID != 0)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.WearHeadPortraitFrameID);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x060106F1 RID: 67313 RVA: 0x0049FA50 File Offset: 0x0049DE50
		private void UpdateTitleInformation()
		{
			if (!DataManager<TitleDataManager>.GetInstance().IsHaveTitle())
			{
				this.mTitleName.SafeSetText(string.Empty);
				this.mTitleImg.CustomActive(false);
				this.mHonorImg.CustomActive(false);
				return;
			}
			PlayerWearedTitleInfo wearedTitleInfo = DataManager<PlayerBaseData>.GetInstance().WearedTitleInfo;
			if (wearedTitleInfo != null)
			{
				if (wearedTitleInfo.style == 1)
				{
					this.mTitleName.CustomActive(true);
					this.mTitleImg.CustomActive(false);
					this.mHonorImg.CustomActive(false);
					this.mTitleName.SafeSetText(wearedTitleInfo.name);
				}
				else if (wearedTitleInfo.style == 2)
				{
					this.mHonorImg.CustomActive(false);
					this.mTitleName.CustomActive(false);
					this.mTitleImg.CustomActive(true);
					NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)wearedTitleInfo.titleId, string.Empty, string.Empty);
					if (tableItem != null && this.mTitleImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mTitleImg, tableItem.path, true);
						this.mTitleImg.SetNativeSize();
					}
				}
				else if (wearedTitleInfo.style == 3)
				{
					this.mHonorImg.CustomActive(true);
					this.mTitleName.CustomActive(true);
					this.mTitleImg.CustomActive(false);
					this.mTitleName.SafeSetText(wearedTitleInfo.name);
					NewTitleTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)wearedTitleInfo.titleId, string.Empty, string.Empty);
					if (tableItem2 != null && this.mHonorImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mHonorImg, tableItem2.path, true);
						this.mHonorImg.SetNativeSize();
					}
				}
			}
		}

		// Token: 0x060106F2 RID: 67314 RVA: 0x0049FC04 File Offset: 0x0049E004
		private void SetPlayerIcon()
		{
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			if (this.headImg != null)
			{
				ETCImageLoader.LoadSprite(ref this.headImg, path, true);
			}
		}

		// Token: 0x060106F3 RID: 67315 RVA: 0x0049FC83 File Offset: 0x0049E083
		private void SetPlayerName()
		{
			if (this.nameText)
			{
				this.nameText.text = DataManager<PlayerBaseData>.GetInstance().Name;
			}
		}

		// Token: 0x060106F4 RID: 67316 RVA: 0x0049FCAA File Offset: 0x0049E0AA
		private void SetVipLevel()
		{
			if (this.imgNum)
			{
				this.imgNum.Value = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			}
		}

		// Token: 0x060106F5 RID: 67317 RVA: 0x0049FCD1 File Offset: 0x0049E0D1
		private void SetServerName()
		{
			if (this.serverFieldText)
			{
				this.serverFieldText.text = ClientApplication.adminServer.name;
			}
		}

		// Token: 0x060106F6 RID: 67318 RVA: 0x0049FCF8 File Offset: 0x0049E0F8
		private void SetVersion()
		{
			if (this.mVersion)
			{
				string format = TR.Value("system_version_desc");
				this.mVersion.text = string.Format(format, Singleton<VersionManager>.GetInstance().Version());
			}
		}

		// Token: 0x060106F7 RID: 67319 RVA: 0x0049FD3B File Offset: 0x0049E13B
		private void SetRoleLevel()
		{
			if (this.levelText)
			{
				this.levelText.text = "等级：" + DataManager<PlayerBaseData>.GetInstance().Level;
			}
		}

		// Token: 0x060106F8 RID: 67320 RVA: 0x0049FD74 File Offset: 0x0049E174
		private void SetRoleExp()
		{
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			ulong num = Singleton<TableManager>.GetInstance().GetExpByLevel((int)level);
			if (this.expNumText)
			{
				this.expNumText.text = string.Format("{0}/{1}", DataManager<PlayerBaseData>.GetInstance().CurExp, num);
			}
			if (this.expNumSlider)
			{
				this.expNumSlider.maxValue = num;
				this.expNumSlider.value = DataManager<PlayerBaseData>.GetInstance().CurExp;
			}
			int playerMaxLv = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			if ((int)level == playerMaxLv)
			{
				num = DataManager<PlayerBaseData>.GetInstance().CurExp;
				if (this.expNumText)
				{
					this.expNumText.text = string.Format("{0}/{1}", num, num);
				}
				if (this.expNumSlider)
				{
					this.expNumSlider.maxValue = num;
					this.expNumSlider.value = num;
				}
			}
		}

		// Token: 0x060106F9 RID: 67321 RVA: 0x0049FE84 File Offset: 0x0049E284
		private void SetJobName()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null && this.jobText)
			{
				this.jobText.text = tableItem.Name;
			}
		}

		// Token: 0x060106FA RID: 67322 RVA: 0x0049FED8 File Offset: 0x0049E2D8
		private void SetWinRate()
		{
			if (this.winRateText)
			{
				PkStatistic pkStatisticDataByPkType = DataManager<PlayerBaseData>.GetInstance().GetPkStatisticDataByPkType(PkType.Pk_Season_1v1);
				if (pkStatisticDataByPkType != null)
				{
					if (pkStatisticDataByPkType.totalNum > 0U)
					{
						this.winRateText.text = string.Format("{0:P1}", pkStatisticDataByPkType.totalWinNum / pkStatisticDataByPkType.totalNum);
					}
					else
					{
						this.winRateText.text = "0%";
					}
				}
				else
				{
					this.winRateText.text = "0%";
				}
			}
		}

		// Token: 0x060106FB RID: 67323 RVA: 0x0049FF68 File Offset: 0x0049E368
		private void SetTotalPkCount()
		{
			if (this.pkNumText)
			{
				PkStatistic pkStatisticDataByPkType = DataManager<PlayerBaseData>.GetInstance().GetPkStatisticDataByPkType(PkType.Pk_Season_1v1);
				if (pkStatisticDataByPkType != null)
				{
					this.pkNumText.text = pkStatisticDataByPkType.totalNum.ToString();
				}
				else
				{
					this.pkNumText.text = "0";
				}
			}
		}

		// Token: 0x060106FC RID: 67324 RVA: 0x0049FFC8 File Offset: 0x0049E3C8
		private void SetPkLevelImgShow()
		{
			if (this.mComPKRank != null)
			{
				this.mComPKRank.Initialize(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonExp);
			}
		}

		// Token: 0x060106FD RID: 67325 RVA: 0x0049FFFC File Offset: 0x0049E3FC
		private void SetGuildJob()
		{
			string text = string.Empty;
			text = SysNotifyMsgText.GuildJobNames[(int)DataManager<PlayerBaseData>.GetInstance().eGuildDuty];
			if (this.jobTitleText)
			{
				this.jobTitleText.text = text;
			}
		}

		// Token: 0x060106FE RID: 67326 RVA: 0x004A003C File Offset: 0x0049E43C
		private void SetNameTitleImg()
		{
			if (this.addNameTitle)
			{
				List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.WearEquip, ItemTable.eSubType.TITLE);
				if (itemsByPackageSubType != null)
				{
					if (itemsByPackageSubType.Count > 0)
					{
						this.addNameTitle.gameObject.CustomActive(false);
						for (int i = 0; i < itemsByPackageSubType.Count; i++)
						{
							ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[i]);
							if (item != null)
							{
								ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
								if (tableItem != null && tableItem.Path2.Count == 4 && this.aniRenderer)
								{
									this.aniRenderer.gameObject.CustomActive(true);
									this.aniRenderer.Reset(tableItem.Path2[0], tableItem.Path2[1], int.Parse(tableItem.Path2[2]), float.Parse(tableItem.Path2[3]), tableItem.ModelPath);
									if (this.aniImg)
									{
										this.aniImg.enabled = true;
									}
								}
							}
						}
					}
					else
					{
						if (this.aniRenderer)
						{
							this.aniRenderer.gameObject.CustomActive(false);
						}
						if (this.aniImg)
						{
							this.aniImg.enabled = false;
						}
						this.addNameTitle.gameObject.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x060106FF RID: 67327 RVA: 0x004A01C6 File Offset: 0x0049E5C6
		private void SetEquipGrade()
		{
			this.equipRankText.text = string.Empty;
		}

		// Token: 0x0400A701 RID: 42753
		private Image headImg;

		// Token: 0x0400A702 RID: 42754
		private UINumber imgNum;

		// Token: 0x0400A703 RID: 42755
		private Text nameText;

		// Token: 0x0400A704 RID: 42756
		private Text serverFieldText;

		// Token: 0x0400A705 RID: 42757
		private Text mVersion;

		// Token: 0x0400A706 RID: 42758
		private Button changeNameBtn;

		// Token: 0x0400A707 RID: 42759
		private Text levelText;

		// Token: 0x0400A708 RID: 42760
		private Text expNumText;

		// Token: 0x0400A709 RID: 42761
		private Slider expNumSlider;

		// Token: 0x0400A70A RID: 42762
		private Text jobText;

		// Token: 0x0400A70B RID: 42763
		private Text winRateText;

		// Token: 0x0400A70C RID: 42764
		private Text pkNumText;

		// Token: 0x0400A70D RID: 42765
		private Image pkLevelTotalImg;

		// Token: 0x0400A70E RID: 42766
		private GameObject pkLevelDetailGo;

		// Token: 0x0400A70F RID: 42767
		private Text pkRankDescText;

		// Token: 0x0400A710 RID: 42768
		private Button btnVipLevel;

		// Token: 0x0400A711 RID: 42769
		private Text jobTitleText;

		// Token: 0x0400A712 RID: 42770
		private Button addNameTitle;

		// Token: 0x0400A713 RID: 42771
		private Text nameTitleText;

		// Token: 0x0400A714 RID: 42772
		private SpriteAniRenderChenghao aniRenderer;

		// Token: 0x0400A715 RID: 42773
		private Image aniImg;

		// Token: 0x0400A716 RID: 42774
		private Text equipRankText;

		// Token: 0x0400A717 RID: 42775
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x0400A718 RID: 42776
		private Button mMoreBtn;

		// Token: 0x0400A719 RID: 42777
		private Text mTitleName;

		// Token: 0x0400A71A RID: 42778
		private Image mTitleImg;

		// Token: 0x0400A71B RID: 42779
		private Button mTitleButton;

		// Token: 0x0400A71C RID: 42780
		private Image mHonorImg;

		// Token: 0x0400A71D RID: 42781
		private ComPKRank mComPKRank;
	}
}

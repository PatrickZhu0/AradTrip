using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010A9 RID: 4265
	internal class DungeonLoadingFrame : ClientFrame
	{
		// Token: 0x0600A0D3 RID: 41171 RVA: 0x00207F44 File Offset: 0x00206344
		protected override void _bindExUI()
		{
			this.mLoadingParent = this.mBind.GetGameObject("LoadingParent");
			this.mLoadProcess = this.mBind.GetCom<Slider>("loadProcess");
			this.mLoadText = this.mBind.GetCom<Text>("loadText");
			this.mTipsText = this.mBind.GetCom<Text>("TipsText");
			this.mBackRoot = this.mBind.GetGameObject("backRoot");
			this.mBack = this.mBind.GetCom<Image>("back");
			this.mOthers[0] = this.mBind.GetCom<ComDungeonPlayerLoadProgress>("other0");
			this.mOthers[1] = this.mBind.GetCom<ComDungeonPlayerLoadProgress>("other1");
			this.mLevel = this.mBind.GetCom<Text>("level");
			this.mIcon = this.mBind.GetCom<Image>("icon");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mTeamRoot = this.mBind.GetGameObject("teamRoot");
			this.mSingleLoadProcess = this.mBind.GetCom<Slider>("singleLoadProcess");
			this.mSingleRoot = this.mBind.GetGameObject("singleRoot");
			this.mReplaceHeadPortraitFrame = this.mBind.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
		}

		// Token: 0x0600A0D4 RID: 41172 RVA: 0x002080A0 File Offset: 0x002064A0
		protected override void _unbindExUI()
		{
			this.mLoadingParent = null;
			this.mLoadProcess = null;
			this.mLoadText = null;
			this.mTipsText = null;
			this.mBackRoot = null;
			this.mBack = null;
			this.mOthers[0] = null;
			this.mOthers[1] = null;
			this.mLevel = null;
			this.mIcon = null;
			this.mName = null;
			this.mTeamRoot = null;
			this.mSingleLoadProcess = null;
			this.mSingleRoot = null;
			this.mReplaceHeadPortraitFrame = null;
		}

		// Token: 0x0600A0D5 RID: 41173 RVA: 0x0020811A File Offset: 0x0020651A
		protected override bool _IsLoadingFrame()
		{
			return true;
		}

		// Token: 0x0600A0D6 RID: 41174 RVA: 0x00208120 File Offset: 0x00206520
		private void LoadTips()
		{
			string randomDugeonLoadingRes = LoadingResourceManager.GetRandomDugeonLoadingRes();
			if (!string.IsNullOrEmpty(randomDugeonLoadingRes))
			{
				if (null != this._tips)
				{
					Object.Destroy(this._tips);
				}
				this._tips = Singleton<AssetLoader>.instance.LoadResAsGameObject(randomDugeonLoadingRes, true, 0U);
				GameObject gameObject = this.mBind.GetGameObject("LoadingParent");
				if (gameObject && this._tips)
				{
					this._tips.transform.SetParent(gameObject.transform, false);
					this.SetBackgroundImg(this._tips);
				}
			}
		}

		// Token: 0x0600A0D7 RID: 41175 RVA: 0x002081BC File Offset: 0x002065BC
		protected override void _OnOpenFrame()
		{
			this.LoadTips();
			this._UpdateSpeed = Global.Settings.loadingProgressStep;
			this.m_openTime = Utility.GetTimeStamp();
			Object.DontDestroyOnLoad(this.frame);
			this.strBuilder = StringBuilderCache.Acquire(256);
			this._targetProgress = 0;
			this._currentProgress = -1;
			base.StartCoroutine(this.UpdateProgress());
			this._loadDungeonLoadingMap();
			this._updateBackground();
			int tableItemCount = Singleton<TableManager>.GetInstance().GetTableItemCount<TipsTable>();
			DungeonLoadingFrame.sIndex += Random.Range(1, tableItemCount);
			DungeonLoadingFrame.sIndex *= 4660;
			DungeonLoadingFrame.sIndex %= tableItemCount;
			DungeonLoadingFrame.sIndex++;
			TipsTable tableItemByIndex = Singleton<TableManager>.GetInstance().GetTableItemByIndex<TipsTable>(DungeonLoadingFrame.sIndex);
			if (tableItemByIndex != null)
			{
				this.mTipsText.text = "温馨提示:" + tableItemByIndex.ObjectName;
			}
			if (this.userData != null)
			{
				string path = string.Empty;
				int id = (int)this.userData;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.JobType == 0)
				{
					path = tableItem.LoadingPrefab;
				}
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
				if (gameObject != null && this.mBackRoot != null)
				{
					Utility.AttachTo(gameObject, this.mBackRoot, false);
				}
			}
			else
			{
				string randomDugeonLoadingRes = LoadingResourceManager.GetRandomDugeonLoadingRes();
				if (!string.IsNullOrEmpty(randomDugeonLoadingRes))
				{
					GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(randomDugeonLoadingRes, true, 0U);
					if (this.mLoadingParent && gameObject2)
					{
						gameObject2.transform.SetParent(this.mLoadingParent.transform, false);
						this.SetBackgroundImg(gameObject2);
					}
				}
			}
			this._setAllOtherPlayerSeat();
			this._loadMainPlayer();
			this._updateModeByDungeonMode();
		}

		// Token: 0x0600A0D8 RID: 41176 RVA: 0x002083A4 File Offset: 0x002067A4
		private void _updateModeByDungeonMode()
		{
			this.mTeamRoot.SetActive(this._isTeamFight());
			this.mSingleRoot.SetActive(!this._isTeamFight());
			if (BattleMain.instance == null)
			{
				return;
			}
			RaidBattle raidBattle = BattleMain.instance.GetBattle() as RaidBattle;
			if (raidBattle != null)
			{
				this.mTeamRoot.SetActive(true);
				this.mSingleRoot.SetActive(false);
			}
		}

		// Token: 0x0600A0D9 RID: 41177 RVA: 0x0020840F File Offset: 0x0020680F
		private bool _isTeamFight()
		{
			return DataManager<TeamDataManager>.GetInstance() != null && DataManager<TeamDataManager>.GetInstance().HasTeam();
		}

		// Token: 0x0600A0DA RID: 41178 RVA: 0x00208428 File Offset: 0x00206828
		private void _loadMainPlayer()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer == null)
			{
				return;
			}
			this.mName.text = mainPlayer.playerInfo.name;
			this.mLevel.text = mainPlayer.playerInfo.level.ToString();
			this._getMainPlayerSprite(ref this.mIcon, (int)mainPlayer.playerInfo.occupation);
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (mainPlayer.playerInfo.playerLabelInfo.headFrame != 0U)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame((int)mainPlayer.playerInfo.playerLabelInfo.headFrame);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x0600A0DB RID: 41179 RVA: 0x002084FC File Offset: 0x002068FC
		private void _getMainPlayerSprite(ref Image image, int id)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref image, tableItem2.IconPath, true);
		}

		// Token: 0x0600A0DC RID: 41180 RVA: 0x00208558 File Offset: 0x00206958
		private void _setAllOtherPlayerSeat()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			int num = 0;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].playerInfo.accid != ClientApplication.playerinfo.accid && num < this.mOthers.Length)
				{
					this.mOthers[num++].SetSeat(allPlayers[i].playerInfo.seat);
				}
			}
			for (int j = num; j < this.mOthers.Length; j++)
			{
				this.mOthers[j].gameObject.SetActive(false);
			}
		}

		// Token: 0x0600A0DD RID: 41181 RVA: 0x00208618 File Offset: 0x00206A18
		private void _updateBackground()
		{
			int dungeonId = DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId;
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.mBack, tableItem.LoadingBgPath, true);
			}
		}

		// Token: 0x0600A0DE RID: 41182 RVA: 0x00208664 File Offset: 0x00206A64
		private void _loadDungeonLoadingMap()
		{
			int dungeonId = DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId;
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DDungeonMapData ddungeonMapData = Singleton<AssetLoader>.instance.LoadRes(tableItem.DungeonLoadingConfig, true, 0U).obj as DDungeonMapData;
				if (ddungeonMapData == null)
				{
				}
				this.dName = tableItem.Name;
			}
		}

		// Token: 0x0600A0DF RID: 41183 RVA: 0x002086DC File Offset: 0x00206ADC
		protected override void _OnCloseFrame()
		{
			StringBuilderCache.Release(this.strBuilder);
			this.mIcon.sprite = null;
			this.mIcon.material = null;
			this.mBack.sprite = null;
			this.mBack.material = null;
			if (null != this._tips)
			{
				Object.Destroy(this._tips);
				this._tips = null;
			}
		}

		// Token: 0x0600A0E0 RID: 41184 RVA: 0x00208747 File Offset: 0x00206B47
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Loading/DungeonLoadingFrame";
		}

		// Token: 0x0600A0E1 RID: 41185 RVA: 0x00208750 File Offset: 0x00206B50
		public IEnumerator UpdateProgress()
		{
			while (this._targetProgress <= 100)
			{
				while (this._currentProgress < this._targetProgress)
				{
					this._currentProgress += this._UpdateSpeed;
					if (this._currentProgress > this._targetProgress)
					{
						this._currentProgress = this._targetProgress;
					}
					this._SetProgress(this._currentProgress);
					yield return Yielders.EndOfFrame;
				}
				if (this._targetProgress == 100)
				{
					yield return MonoSingleton<GameFrameWork>.instance.OpenFadeFrame(delegate
					{
						this.frameMgr.CloseFrame<DungeonLoadingFrame>(this, false);
					}, null, null, 0.4f, 0.6f);
					MonoSingleton<GameFrameWork>.instance.TownNameShow(this.dName);
					break;
				}
				yield return Yielders.EndOfFrame;
				this._targetProgress = (int)(Singleton<ClientSystemManager>.GetInstance().SwitchProgress * 100f);
			}
			yield break;
		}

		// Token: 0x0600A0E2 RID: 41186 RVA: 0x0020876C File Offset: 0x00206B6C
		protected void _SetProgress(int progress)
		{
			if (progress < 0)
			{
				progress = 0;
			}
			if (progress > 100)
			{
				progress = 100;
			}
			this.mLoadProcess.value = (float)progress / 100f;
			this.mSingleLoadProcess.value = this.mLoadProcess.value;
			MyExtensionMethods.Clear(this.strBuilder);
			this.strBuilder.AppendFormat("{0}%", progress);
			this.mLoadText.text = this.strBuilder.ToString();
		}

		// Token: 0x0600A0E3 RID: 41187 RVA: 0x002087F0 File Offset: 0x00206BF0
		private void SetBackgroundImg(GameObject tips)
		{
			if (tips)
			{
				ComCommonBind component = tips.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Image com = component.GetCom<Image>("BgImg");
				if (com != null)
				{
					string sdklogoPath = PluginManager.GetSDKLogoPath(SDKInterface.SDKLogoType.LoadingLogo);
					if (string.IsNullOrEmpty(sdklogoPath))
					{
						return;
					}
					ETCImageLoader.LoadSprite(ref com, sdklogoPath, true);
				}
			}
		}

		// Token: 0x0400595D RID: 22877
		protected StringBuilder strBuilder;

		// Token: 0x0400595E RID: 22878
		protected int _UpdateSpeed = 10;

		// Token: 0x0400595F RID: 22879
		protected int _targetProgress;

		// Token: 0x04005960 RID: 22880
		protected int _currentProgress = -1;

		// Token: 0x04005961 RID: 22881
		protected GameObject _tips;

		// Token: 0x04005962 RID: 22882
		private GameObject mLoadingParent;

		// Token: 0x04005963 RID: 22883
		private Slider mLoadProcess;

		// Token: 0x04005964 RID: 22884
		private Text mLoadText;

		// Token: 0x04005965 RID: 22885
		private Text mTipsText;

		// Token: 0x04005966 RID: 22886
		private GameObject mBackRoot;

		// Token: 0x04005967 RID: 22887
		private Image mBack;

		// Token: 0x04005968 RID: 22888
		private ComDungeonPlayerLoadProgress[] mOthers = new ComDungeonPlayerLoadProgress[2];

		// Token: 0x04005969 RID: 22889
		private Text mLevel;

		// Token: 0x0400596A RID: 22890
		private Image mIcon;

		// Token: 0x0400596B RID: 22891
		private Text mName;

		// Token: 0x0400596C RID: 22892
		private GameObject mTeamRoot;

		// Token: 0x0400596D RID: 22893
		private Slider mSingleLoadProcess;

		// Token: 0x0400596E RID: 22894
		private GameObject mSingleRoot;

		// Token: 0x0400596F RID: 22895
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x04005970 RID: 22896
		private static int sIndex;

		// Token: 0x04005971 RID: 22897
		private double m_openTime;

		// Token: 0x04005972 RID: 22898
		private string dName;
	}
}

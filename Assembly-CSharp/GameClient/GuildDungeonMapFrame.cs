using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200161C RID: 5660
	public class GuildDungeonMapFrame : ClientFrame
	{
		// Token: 0x0600DE21 RID: 56865 RVA: 0x00386EDF File Offset: 0x003852DF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonMap";
		}

		// Token: 0x0600DE22 RID: 56866 RVA: 0x00386EE8 File Offset: 0x003852E8
		protected override void _OnOpenFrame()
		{
			this.buffAddInfo = new Dictionary<int, int>();
			this.BindUIEvent();
			DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonCopyReq();
			this._OnUpdateMapInfo(null);
			this._OnUpdateBufInfo(null);
			this._OnUpdateActivityData(null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonShowFireworks, null, null, null, null);
		}

		// Token: 0x0600DE23 RID: 56867 RVA: 0x00386F38 File Offset: 0x00385338
		protected override void _OnCloseFrame()
		{
			this.buffAddInfo = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DE24 RID: 56868 RVA: 0x00386F48 File Offset: 0x00385348
		protected override void _bindExUI()
		{
			this.btnClose = this.mBind.GetCom<Button>("BtnClose");
			if (this.btnClose != null)
			{
				this.btnClose.onClick.RemoveAllListeners();
				this.btnClose.onClick.AddListener(delegate()
				{
					DataManager<GuildDataManager>.GetInstance().SwitchToGuildScene();
					this.frameMgr.CloseFrame<GuildDungeonMapFrame>(this, false);
				});
			}
			this.Junior0 = this.mBind.GetCom<JuniorGuildDungeon>("Junior0");
			this.Junior1 = this.mBind.GetCom<JuniorGuildDungeon>("Junior1");
			this.Junior2 = this.mBind.GetCom<JuniorGuildDungeon>("Junior2");
			this.Medium0 = this.mBind.GetCom<MediumGuildDungeon>("Medium0");
			this.Medium1 = this.mBind.GetCom<MediumGuildDungeon>("Medium1");
			this.Medium2 = this.mBind.GetCom<MediumGuildDungeon>("Medium2");
			this.BOSS = this.mBind.GetCom<BossGuildDungeon>("BOSS");
			this.buf1 = this.mBind.GetCom<Text>("buf1");
			this.buffers = this.mBind.GetGameObject("buffers");
			this.txtNoBuf = this.mBind.GetCom<Text>("txtNoBuf");
			this.btLookUp = this.mBind.GetCom<Button>("btLookUp");
			if (this.btLookUp != null)
			{
				this.btLookUp.onClick.RemoveAllListeners();
				this.btLookUp.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonBufAddUpDetailFrame>(FrameLayer.Middle, null, string.Empty);
				});
			}
			this.txtKillInfo = this.mBind.GetCom<Text>("txtKillInfo");
			this.process = this.mBind.GetCom<Slider>("process");
		}

		// Token: 0x0600DE25 RID: 56869 RVA: 0x00387114 File Offset: 0x00385514
		protected override void _unbindExUI()
		{
			this.btnClose = null;
			this.Junior0 = null;
			this.Junior1 = null;
			this.Junior2 = null;
			this.Medium0 = null;
			this.Medium1 = null;
			this.Medium2 = null;
			this.BOSS = null;
			this.buf1 = null;
			this.buffers = null;
			this.btLookUp = null;
			this.txtKillInfo = null;
			this.process = null;
			this.txtNoBuf = null;
		}

		// Token: 0x0600DE26 RID: 56870 RVA: 0x00387184 File Offset: 0x00385584
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateDungeonMapInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateMapInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateDungeonBufInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateBufInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
		}

		// Token: 0x0600DE27 RID: 56871 RVA: 0x003871E4 File Offset: 0x003855E4
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateDungeonMapInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateMapInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateDungeonBufInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateBufInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
		}

		// Token: 0x0600DE28 RID: 56872 RVA: 0x00387244 File Offset: 0x00385644
		private void UpdateKillInfo()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				if (this.txtKillInfo != null)
				{
					this.txtKillInfo.text = string.Format("{0}/{1}", guildDungeonActivityData.nBossOddHp, guildDungeonActivityData.nBossMaxHp);
				}
				if (this.process != null && guildDungeonActivityData.nBossMaxHp > 0UL)
				{
					this.process.value = guildDungeonActivityData.nBossOddHp / guildDungeonActivityData.nBossMaxHp;
				}
			}
		}

		// Token: 0x0600DE29 RID: 56873 RVA: 0x003872D8 File Offset: 0x003856D8
		private void CalBufAddInfo()
		{
			if (this.buffAddInfo == null)
			{
				return;
			}
			this.buffAddInfo.Clear();
		}

		// Token: 0x0600DE2A RID: 56874 RVA: 0x003872F1 File Offset: 0x003856F1
		private string GetBufAddType(int iType)
		{
			return string.Empty;
		}

		// Token: 0x0600DE2B RID: 56875 RVA: 0x003872F8 File Offset: 0x003856F8
		private void _OnUpdateBufInfo(UIEvent uiEvent)
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData == null)
			{
				return;
			}
			if (this.buffers != null && this.buf1 != null)
			{
				for (int i = 0; i < this.buffers.transform.childCount; i++)
				{
					GameObject gameObject = this.buffers.transform.GetChild(i).gameObject;
					Object.Destroy(gameObject);
				}
				for (int j = 0; j < guildDungeonActivityData.buffAddUpInfos.Count; j++)
				{
					GuildDataManager.BuffAddUpInfo buffAddUpInfo = guildDungeonActivityData.buffAddUpInfos[j];
					if (buffAddUpInfo != null)
					{
						GameObject gameObject2 = Object.Instantiate<GameObject>(this.buf1.gameObject);
						Utility.AttachTo(gameObject2, this.buffers, false);
						gameObject2.CustomActive(true);
						Text component = gameObject2.GetComponent<Text>();
						if (component != null)
						{
							component.text = GuildDataManager.GetBuffAddUpInfo((int)buffAddUpInfo.nBuffID, (int)buffAddUpInfo.nBuffLv);
						}
					}
				}
				this.txtNoBuf.CustomActive(guildDungeonActivityData.buffAddUpInfos.Count == 0);
			}
		}

		// Token: 0x0600DE2C RID: 56876 RVA: 0x00387420 File Offset: 0x00385820
		private void _OnUpdateMapInfo(UIEvent uiEvent)
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData == null)
			{
				return;
			}
			List<JuniorGuildDungeon> list = new List<JuniorGuildDungeon>();
			list.Add(this.Junior0);
			list.Add(this.Junior1);
			list.Add(this.Junior2);
			List<MediumGuildDungeon> list2 = new List<MediumGuildDungeon>();
			list2.Add(this.Medium0);
			list2.Add(this.Medium1);
			list2.Add(this.Medium2);
			for (int i = 0; i < guildDungeonActivityData.juniorDungeonDamgeInfos.Count; i++)
			{
				if (i < list.Count)
				{
					JuniorGuildDungeon juniorGuildDungeon = list[i];
					if (juniorGuildDungeon != null)
					{
						juniorGuildDungeon.SetUp(guildDungeonActivityData.juniorDungeonDamgeInfos[i]);
					}
				}
			}
			for (int j = 0; j < guildDungeonActivityData.mediumDungeonDamgeInfos.Count; j++)
			{
				if (j < list2.Count)
				{
					MediumGuildDungeon mediumGuildDungeon = list2[j];
					if (mediumGuildDungeon != null)
					{
						mediumGuildDungeon.SetUp(guildDungeonActivityData.mediumDungeonDamgeInfos[j]);
					}
				}
			}
			if (guildDungeonActivityData.bossDungeonDamageInfos.Count > 0 && this.BOSS != null)
			{
				this.BOSS.SetUp(guildDungeonActivityData.bossDungeonDamageInfos[0]);
			}
		}

		// Token: 0x0600DE2D RID: 56877 RVA: 0x00387575 File Offset: 0x00385975
		private void _OnUpdateActivityData(UIEvent uiEvent)
		{
			this.UpdateKillInfo();
		}

		// Token: 0x0400838C RID: 33676
		private Dictionary<int, int> buffAddInfo;

		// Token: 0x0400838D RID: 33677
		private Button btnClose;

		// Token: 0x0400838E RID: 33678
		private JuniorGuildDungeon Junior0;

		// Token: 0x0400838F RID: 33679
		private JuniorGuildDungeon Junior1;

		// Token: 0x04008390 RID: 33680
		private JuniorGuildDungeon Junior2;

		// Token: 0x04008391 RID: 33681
		private MediumGuildDungeon Medium0;

		// Token: 0x04008392 RID: 33682
		private MediumGuildDungeon Medium1;

		// Token: 0x04008393 RID: 33683
		private MediumGuildDungeon Medium2;

		// Token: 0x04008394 RID: 33684
		private BossGuildDungeon BOSS;

		// Token: 0x04008395 RID: 33685
		private Text buf1;

		// Token: 0x04008396 RID: 33686
		private GameObject buffers;

		// Token: 0x04008397 RID: 33687
		private Text txtNoBuf;

		// Token: 0x04008398 RID: 33688
		private Button btLookUp;

		// Token: 0x04008399 RID: 33689
		private Text txtKillInfo;

		// Token: 0x0400839A RID: 33690
		private Slider process;
	}
}

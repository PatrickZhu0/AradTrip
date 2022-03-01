using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020011E0 RID: 4576
	public class ArtifactDataManager : DataManager<ArtifactDataManager>
	{
		// Token: 0x17001AB7 RID: 6839
		// (get) Token: 0x0600AFFA RID: 45050 RVA: 0x0026A6AC File Offset: 0x00268AAC
		// (set) Token: 0x0600AFFB RID: 45051 RVA: 0x0026A6B4 File Offset: 0x00268AB4
		public bool isNotNotify { get; set; }

		// Token: 0x17001AB8 RID: 6840
		// (get) Token: 0x0600AFFC RID: 45052 RVA: 0x0026A6BD File Offset: 0x00268ABD
		// (set) Token: 0x0600AFFD RID: 45053 RVA: 0x0026A6C5 File Offset: 0x00268AC5
		public bool isArtifactRecordNew { get; set; }

		// Token: 0x0600AFFE RID: 45054 RVA: 0x0026A6CE File Offset: 0x00268ACE
		public List<ItemReward> GetArtifactJarLotteryRewards(uint jarID)
		{
			if (this.artifactJarLotteryRewardDic == null)
			{
				return new List<ItemReward>();
			}
			if (this.artifactJarLotteryRewardDic.ContainsKey(jarID))
			{
				return this.artifactJarLotteryRewardDic[jarID];
			}
			return new List<ItemReward>();
		}

		// Token: 0x0600AFFF RID: 45055 RVA: 0x0026A704 File Offset: 0x00268B04
		public override void Initialize()
		{
			this.artifactJarRecordDic.Clear();
			this.artifactJarBuyData.Clear();
			this.artifactJarDiscountData = new ArtifactJarDiscountData();
			this.isNotNotify = false;
			this.isArtifactRecordNew = true;
			this._RegisterNetHandler();
			this.artifactJarLotteryRewardDic = new Dictionary<uint, List<ItemReward>>();
		}

		// Token: 0x0600B000 RID: 45056 RVA: 0x0026A751 File Offset: 0x00268B51
		public override void Clear()
		{
			this._UnRegisterNetHandler();
			this.artifactJarLotteryRewardDic = null;
		}

		// Token: 0x0600B001 RID: 45057 RVA: 0x0026A760 File Offset: 0x00268B60
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B002 RID: 45058 RVA: 0x0026A764 File Offset: 0x00268B64
		private void _RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(501047U, new Action<MsgDATA>(this._OnSceneArtifactJarBuyCntRes));
			NetProcess.AddMsgHandler(700902U, new Action<MsgDATA>(this._OnGASArtifactJarLotteryRecordRes));
			NetProcess.AddMsgHandler(507403U, new Action<MsgDATA>(this._OnSceneArtifactJarDiscountInfoSync));
			NetProcess.AddMsgHandler(507405U, new Action<MsgDATA>(this._OnSceneArtifactJarExtractDiscountRes));
			NetProcess.AddMsgHandler(700904U, new Action<MsgDATA>(this._OnGASArtifactJarLotteryNotify));
			NetProcess.AddMsgHandler(700906U, new Action<MsgDATA>(this._OnGASArtifactJarLotteryCfgRes));
		}

		// Token: 0x0600B003 RID: 45059 RVA: 0x0026A7F8 File Offset: 0x00268BF8
		private void _UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(501047U, new Action<MsgDATA>(this._OnSceneArtifactJarBuyCntRes));
			NetProcess.RemoveMsgHandler(700902U, new Action<MsgDATA>(this._OnGASArtifactJarLotteryRecordRes));
			NetProcess.RemoveMsgHandler(507403U, new Action<MsgDATA>(this._OnSceneArtifactJarDiscountInfoSync));
			NetProcess.RemoveMsgHandler(507405U, new Action<MsgDATA>(this._OnSceneArtifactJarExtractDiscountRes));
			NetProcess.RemoveMsgHandler(700904U, new Action<MsgDATA>(this._OnGASArtifactJarLotteryNotify));
			NetProcess.RemoveMsgHandler(700906U, new Action<MsgDATA>(this._OnGASArtifactJarLotteryCfgRes));
		}

		// Token: 0x0600B004 RID: 45060 RVA: 0x0026A88C File Offset: 0x00268C8C
		public List<ArtifactJarBuy> getArtiFactJarBuyData()
		{
			List<ArtifactJarBuy> list = new List<ArtifactJarBuy>();
			for (int i = 0; i < this.artifactJarBuyData.Count; i++)
			{
				list.Add(this.artifactJarBuyData[i]);
			}
			return list;
		}

		// Token: 0x0600B005 RID: 45061 RVA: 0x0026A8D0 File Offset: 0x00268CD0
		public List<ArtifactJarLotteryRecord> getArtifactRecord(int jarID)
		{
			foreach (KeyValuePair<int, List<ArtifactJarLotteryRecord>> keyValuePair in this.artifactJarRecordDic)
			{
				if (keyValuePair.Key == jarID)
				{
					Dictionary<int, List<ArtifactJarLotteryRecord>>.Enumerator enumerator;
					KeyValuePair<int, List<ArtifactJarLotteryRecord>> keyValuePair2 = enumerator.Current;
					return keyValuePair2.Value;
				}
			}
			return null;
		}

		// Token: 0x0600B006 RID: 45062 RVA: 0x0026A920 File Offset: 0x00268D20
		public Dictionary<int, List<ArtifactJarLotteryRecord>> getArtifactRecordDic()
		{
			return this.artifactJarRecordDic;
		}

		// Token: 0x0600B007 RID: 45063 RVA: 0x0026A928 File Offset: 0x00268D28
		public OpActivityData getArtifactJarActData()
		{
			return DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_ARTIFACT_JAR);
		}

		// Token: 0x0600B008 RID: 45064 RVA: 0x0026A948 File Offset: 0x00268D48
		public OpActivityData getArtifactAwardActData()
		{
			return DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_JAR_DRAW_LOTTERY);
		}

		// Token: 0x0600B009 RID: 45065 RVA: 0x0026A968 File Offset: 0x00268D68
		public bool IsArtifactActivityOpen()
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_ARTIFACT_JAR_SHOW);
			return activeDataFromType != null && activeDataFromType.state == 1;
		}

		// Token: 0x0600B00A RID: 45066 RVA: 0x0026A99A File Offset: 0x00268D9A
		public ArtifactJarDiscountData getArtifactDiscountData()
		{
			return this.artifactJarDiscountData;
		}

		// Token: 0x0600B00B RID: 45067 RVA: 0x0026A9A4 File Offset: 0x00268DA4
		public void SendArtifactJar()
		{
			SceneArtifactJarBuyCntReq cmd = new SceneArtifactJarBuyCntReq();
			NetManager.Instance().SendCommand<SceneArtifactJarBuyCntReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B00C RID: 45068 RVA: 0x0026A9C4 File Offset: 0x00268DC4
		public void SendArtifactJarRecord(int jarId)
		{
			GASArtifactJarLotteryRecordReq gasartifactJarLotteryRecordReq = new GASArtifactJarLotteryRecordReq();
			gasartifactJarLotteryRecordReq.jarId = (uint)jarId;
			NetManager.Instance().SendCommand<GASArtifactJarLotteryRecordReq>(ServerType.GATE_SERVER, gasartifactJarLotteryRecordReq);
		}

		// Token: 0x0600B00D RID: 45069 RVA: 0x0026A9EC File Offset: 0x00268DEC
		public void SendGetDiscount()
		{
			SceneArtifactJarExtractDiscountReq sceneArtifactJarExtractDiscountReq = new SceneArtifactJarExtractDiscountReq();
			OpActivityData artifactJarActData = this.getArtifactJarActData();
			if (artifactJarActData.state == 1)
			{
				sceneArtifactJarExtractDiscountReq.opActId = artifactJarActData.dataId;
				NetManager.Instance().SendCommand<SceneArtifactJarExtractDiscountReq>(ServerType.GATE_SERVER, sceneArtifactJarExtractDiscountReq);
			}
		}

		// Token: 0x0600B00E RID: 45070 RVA: 0x0026AA2C File Offset: 0x00268E2C
		public void SendGASArtifactJarLotteryCfgReq()
		{
			GASArtifactJarLotteryCfgReq cmd = new GASArtifactJarLotteryCfgReq();
			NetManager.Instance().SendCommand<GASArtifactJarLotteryCfgReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B00F RID: 45071 RVA: 0x0026AA4C File Offset: 0x00268E4C
		private void _OnSceneArtifactJarBuyCntRes(MsgDATA msgData)
		{
			SceneArtifactJarBuyCntRes sceneArtifactJarBuyCntRes = new SceneArtifactJarBuyCntRes();
			if (sceneArtifactJarBuyCntRes == null)
			{
				return;
			}
			sceneArtifactJarBuyCntRes.decode(msgData.bytes);
			this.artifactJarBuyData.Clear();
			for (int i = 0; i < sceneArtifactJarBuyCntRes.artifactJarBuyList.Length; i++)
			{
				this.artifactJarBuyData.Add(sceneArtifactJarBuyCntRes.artifactJarBuyList[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ArtifactDailyRewardUpdate, null, null, null, null);
		}

		// Token: 0x0600B010 RID: 45072 RVA: 0x0026AABC File Offset: 0x00268EBC
		private void _OnGASArtifactJarLotteryRecordRes(MsgDATA msgData)
		{
			GASArtifactJarLotteryRecordRes gasartifactJarLotteryRecordRes = new GASArtifactJarLotteryRecordRes();
			if (gasartifactJarLotteryRecordRes == null)
			{
				return;
			}
			gasartifactJarLotteryRecordRes.decode(msgData.bytes);
			this.artifactJarRecordDic[(int)gasartifactJarLotteryRecordRes.jarId] = gasartifactJarLotteryRecordRes.lotteryRecordList.ToList<ArtifactJarLotteryRecord>();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ArtifactDailyRecordUpdate, (int)gasartifactJarLotteryRecordRes.jarId, null, null, null);
		}

		// Token: 0x0600B011 RID: 45073 RVA: 0x0026AB1C File Offset: 0x00268F1C
		private void _OnSceneArtifactJarDiscountInfoSync(MsgDATA msgData)
		{
			SceneArtifactJarDiscountInfoSync sceneArtifactJarDiscountInfoSync = new SceneArtifactJarDiscountInfoSync();
			if (sceneArtifactJarDiscountInfoSync == null)
			{
				return;
			}
			sceneArtifactJarDiscountInfoSync.decode(msgData.bytes);
			this.artifactJarDiscountData = new ArtifactJarDiscountData();
			this.artifactJarDiscountData.opActId = (int)sceneArtifactJarDiscountInfoSync.opActId;
			this.artifactJarDiscountData.extractDiscountStatus = (ArtifactJarDiscountExtractStatus)sceneArtifactJarDiscountInfoSync.extractDiscountStatus;
			this.artifactJarDiscountData.discountRate = (int)sceneArtifactJarDiscountInfoSync.discountRate;
			this.artifactJarDiscountData.discountEffectTimes = (int)sceneArtifactJarDiscountInfoSync.discountEffectTimes;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ArtifactJarDataUpdate, null, null, null, null);
		}

		// Token: 0x0600B012 RID: 45074 RVA: 0x0026ABA4 File Offset: 0x00268FA4
		private void _OnSceneArtifactJarExtractDiscountRes(MsgDATA msgData)
		{
			SceneArtifactJarExtractDiscountRes sceneArtifactJarExtractDiscountRes = new SceneArtifactJarExtractDiscountRes();
			if (sceneArtifactJarExtractDiscountRes == null)
			{
				return;
			}
			sceneArtifactJarExtractDiscountRes.decode(msgData.bytes);
			if (sceneArtifactJarExtractDiscountRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneArtifactJarExtractDiscountRes.errorCode, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowArtifactJarDiscountFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B013 RID: 45075 RVA: 0x0026ABF8 File Offset: 0x00268FF8
		private void _OnGASArtifactJarLotteryNotify(MsgDATA msgData)
		{
			if (new GASArtifactJarLotteryNotify() == null)
			{
				return;
			}
			this.isArtifactRecordNew = true;
		}

		// Token: 0x0600B014 RID: 45076 RVA: 0x0026AC1C File Offset: 0x0026901C
		private void _OnGASArtifactJarLotteryCfgRes(MsgDATA msgData)
		{
			GASArtifactJarLotteryCfgRes gasartifactJarLotteryCfgRes = new GASArtifactJarLotteryCfgRes();
			if (gasartifactJarLotteryCfgRes == null)
			{
				return;
			}
			gasartifactJarLotteryCfgRes.decode(msgData.bytes);
			if (this.artifactJarLotteryRewardDic != null && gasartifactJarLotteryCfgRes.artifactJarCfgList != null)
			{
				this.artifactJarLotteryRewardDic.Clear();
				for (int i = 0; i < gasartifactJarLotteryCfgRes.artifactJarCfgList.Length; i++)
				{
					if (this.artifactJarLotteryRewardDic.ContainsKey(gasartifactJarLotteryCfgRes.artifactJarCfgList[i].jarId))
					{
						if (gasartifactJarLotteryCfgRes.artifactJarCfgList[i].rewardList != null)
						{
							this.artifactJarLotteryRewardDic[gasartifactJarLotteryCfgRes.artifactJarCfgList[i].jarId] = gasartifactJarLotteryCfgRes.artifactJarCfgList[i].rewardList.ToList<ItemReward>();
						}
					}
					else if (gasartifactJarLotteryCfgRes.artifactJarCfgList[i].rewardList != null)
					{
						this.artifactJarLotteryRewardDic.Add(gasartifactJarLotteryCfgRes.artifactJarCfgList[i].jarId, gasartifactJarLotteryCfgRes.artifactJarCfgList[i].rewardList.ToList<ItemReward>());
					}
				}
			}
		}

		// Token: 0x04006272 RID: 25202
		private ArtifactJarDiscountData artifactJarDiscountData = new ArtifactJarDiscountData();

		// Token: 0x04006273 RID: 25203
		private List<ArtifactJarBuy> artifactJarBuyData = new List<ArtifactJarBuy>();

		// Token: 0x04006274 RID: 25204
		private Dictionary<int, List<ArtifactJarLotteryRecord>> artifactJarRecordDic = new Dictionary<int, List<ArtifactJarLotteryRecord>>();

		// Token: 0x04006277 RID: 25207
		private Dictionary<uint, List<ItemReward>> artifactJarLotteryRewardDic = new Dictionary<uint, List<ItemReward>>();
	}
}

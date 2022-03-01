using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200124B RID: 4683
	public class EquipRecoveryDataManager : DataManager<EquipRecoveryDataManager>
	{
		// Token: 0x17001AC8 RID: 6856
		// (get) Token: 0x0600B3F3 RID: 46067 RVA: 0x00283317 File Offset: 0x00281717
		// (set) Token: 0x0600B3F4 RID: 46068 RVA: 0x0028331F File Offset: 0x0028171F
		public bool HaveWeekRedPoint { get; set; }

		// Token: 0x0600B3F5 RID: 46069 RVA: 0x00283328 File Offset: 0x00281728
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B3F6 RID: 46070 RVA: 0x0028332C File Offset: 0x0028172C
		public sealed override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
		}

		// Token: 0x0600B3F7 RID: 46071 RVA: 0x0028333A File Offset: 0x0028173A
		public sealed override void Clear()
		{
			this._UnBindNetMsg();
			this.m_bNetBind = false;
		}

		// Token: 0x0600B3F8 RID: 46072 RVA: 0x0028334C File Offset: 0x0028174C
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(501009U, new Action<MsgDATA>(this._OnSceneEquipRecSubcmt));
				NetProcess.AddMsgHandler(501013U, new Action<MsgDATA>(this._OnSceneEquipRecUpscore));
				NetProcess.AddMsgHandler(501015U, new Action<MsgDATA>(this._OnSceneEquipRecRedeemTmRes));
				NetProcess.AddMsgHandler(501016U, new Action<MsgDATA>(this._OnSceneEquipRecNotifyReset));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600B3F9 RID: 46073 RVA: 0x002833C4 File Offset: 0x002817C4
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(501009U, new Action<MsgDATA>(this._OnSceneEquipRecSubcmt));
			NetProcess.RemoveMsgHandler(501013U, new Action<MsgDATA>(this._OnSceneEquipRecUpscore));
			NetProcess.RemoveMsgHandler(501015U, new Action<MsgDATA>(this._OnSceneEquipRecRedeemTmRes));
			NetProcess.RemoveMsgHandler(501016U, new Action<MsgDATA>(this._OnSceneEquipRecNotifyReset));
		}

		// Token: 0x0600B3FA RID: 46074 RVA: 0x00283429 File Offset: 0x00281829
		private void _OnSceneEquipRecEvaRes(MsgDATA msg)
		{
		}

		// Token: 0x0600B3FB RID: 46075 RVA: 0x0028342C File Offset: 0x0028182C
		public void _SubmitEquip(List<ulong> submitList)
		{
			SceneEquipRecSubcmtReq sceneEquipRecSubcmtReq = new SceneEquipRecSubcmtReq();
			ulong[] array = new ulong[submitList.Count];
			for (int i = 0; i < submitList.Count; i++)
			{
				array[i] = submitList[i];
			}
			sceneEquipRecSubcmtReq.itemUids = array;
			NetManager.Instance().SendCommand<SceneEquipRecSubcmtReq>(ServerType.GATE_SERVER, sceneEquipRecSubcmtReq);
		}

		// Token: 0x0600B3FC RID: 46076 RVA: 0x00283480 File Offset: 0x00281880
		public void _SendReturnTimeReq()
		{
			SceneEquipRecRedeemTmReq cmd = new SceneEquipRecRedeemTmReq();
			NetManager.Instance().SendCommand<SceneEquipRecRedeemTmReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B3FD RID: 46077 RVA: 0x002834A0 File Offset: 0x002818A0
		public void _RedeemEquip(ulong uid)
		{
			SceneEquipRecRedeemReq sceneEquipRecRedeemReq = new SceneEquipRecRedeemReq();
			sceneEquipRecRedeemReq.equid = uid;
			NetManager.Instance().SendCommand<SceneEquipRecRedeemReq>(ServerType.GATE_SERVER, sceneEquipRecRedeemReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEquipRecRedeemRes>(delegate(SceneEquipRecRedeemRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipRedeemSuccess, null, null, null, null);
				EquipReturnResultItem equipReturnResultItem = new EquipReturnResultItem();
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(uid);
				if (item != null)
				{
					equipReturnResultItem.itemdata = item;
					equipReturnResultItem.Score = (int)msgRet.consScore;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipReturnResultFrame>(FrameLayer.Middle, equipReturnResultItem, string.Empty);
				}
			}, false, 15f, null);
		}

		// Token: 0x0600B3FE RID: 46078 RVA: 0x002834F8 File Offset: 0x002818F8
		public void _UpgradeEquip(ulong uid)
		{
			SceneEquipRecUpscoreReq sceneEquipRecUpscoreReq = new SceneEquipRecUpscoreReq();
			sceneEquipRecUpscoreReq.equid = uid;
			NetManager.Instance().SendCommand<SceneEquipRecUpscoreReq>(ServerType.GATE_SERVER, sceneEquipRecUpscoreReq);
		}

		// Token: 0x0600B3FF RID: 46079 RVA: 0x00283520 File Offset: 0x00281920
		private void _OnSceneEquipRecSubcmt(MsgDATA msg)
		{
			SceneEquipRecSubcmtRes sceneEquipRecSubcmtRes = new SceneEquipRecSubcmtRes();
			sceneEquipRecSubcmtRes.decode(msg.bytes);
			if (sceneEquipRecSubcmtRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipRecSubcmtRes.code, string.Empty);
				return;
			}
			this.submitResult.Clear();
			for (int i = 0; i < sceneEquipRecSubcmtRes.items.Length; i++)
			{
				this.submitResult.Add(sceneEquipRecSubcmtRes.items[i]);
			}
			if (this.submitResult.Count != 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipSubmitSuccess, sceneEquipRecSubcmtRes.score, sceneEquipRecSubcmtRes.items, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.EquipRecovery, null, null, null);
			}
		}

		// Token: 0x0600B400 RID: 46080 RVA: 0x002835DD File Offset: 0x002819DD
		private void _OnSceneEquipRecRedeem(MsgDATA msg)
		{
		}

		// Token: 0x0600B401 RID: 46081 RVA: 0x002835E0 File Offset: 0x002819E0
		private void _OnSceneEquipRecUpscore(MsgDATA msg)
		{
			SceneEquipRecUpscoreRes sceneEquipRecUpscoreRes = new SceneEquipRecUpscoreRes();
			sceneEquipRecUpscoreRes.decode(msg.bytes);
			if (sceneEquipRecUpscoreRes.code != 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipUpgradeFail, null, null, null, null);
				SystemNotifyManager.SystemNotify((int)sceneEquipRecUpscoreRes.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipUpgradeSuccess, (int)sceneEquipRecUpscoreRes.upscore, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.EquipRecovery, null, null, null);
		}

		// Token: 0x0600B402 RID: 46082 RVA: 0x00283664 File Offset: 0x00281A64
		private void _OnSceneEquipRecRedeemTmRes(MsgDATA msg)
		{
			SceneEquipRecRedeemTmRes sceneEquipRecRedeemTmRes = new SceneEquipRecRedeemTmRes();
			sceneEquipRecRedeemTmRes.decode(msg.bytes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipRecoveryUpdateTime, sceneEquipRecRedeemTmRes.timestmap, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.EquipRecovery, null, null, null);
		}

		// Token: 0x0600B403 RID: 46083 RVA: 0x002836B9 File Offset: 0x00281AB9
		private void _OnSceneEquipRecNotifyReset(MsgDATA msg)
		{
			this.HaveWeekRedPoint = true;
		}

		// Token: 0x0600B404 RID: 46084 RVA: 0x002836C4 File Offset: 0x00281AC4
		public void _OpenRewardJar(int id, int count = 1)
		{
			JarData jarData = DataManager<JarDataManager>.GetInstance().GetJarData(id);
			JarBuyInfo jarBuyInfo = new JarBuyInfo();
			jarBuyInfo.nBuyCount = count;
			DataManager<JarDataManager>.GetInstance().RequestBuyJar(jarData, jarBuyInfo, 0U, 0U);
		}

		// Token: 0x0600B405 RID: 46085 RVA: 0x002836F8 File Offset: 0x00281AF8
		public List<ulong> GetItemForType(int level, ItemTable.eColor color, int minLevel)
		{
			List<ulong> list = new List<ulong>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			list.AddRange(itemsByPackageType);
			list.RemoveAll(delegate(ulong x)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(x);
				return item == null || item.DeadTimestamp != 0 || item.isInSidePack || item.LevelLimit < minLevel || this.needItem(item, level, color);
			});
			return list;
		}

		// Token: 0x0600B406 RID: 46086 RVA: 0x00283754 File Offset: 0x00281B54
		private bool needItem(ItemData data, int level, ItemTable.eColor color)
		{
			if (level != 0 && color != ItemTable.eColor.CL_NONE)
			{
				return data.Quality != color || data.LevelLimit != level;
			}
			if (level != 0 && color == ItemTable.eColor.CL_NONE)
			{
				return (data.Quality != ItemTable.eColor.BLUE && data.Quality != ItemTable.eColor.PINK && data.Quality != ItemTable.eColor.PURPLE) || data.LevelLimit != level;
			}
			if (level == 0 && color != ItemTable.eColor.CL_NONE)
			{
				return data.Quality != color;
			}
			return data.Quality != ItemTable.eColor.BLUE && data.Quality != ItemTable.eColor.PINK && data.Quality != ItemTable.eColor.PURPLE;
		}

		// Token: 0x0600B407 RID: 46087 RVA: 0x00283809 File Offset: 0x00281C09
		public void _ClearJarKeyList()
		{
			this.jarKeyList.Clear();
		}

		// Token: 0x0600B408 RID: 46088 RVA: 0x00283816 File Offset: 0x00281C16
		public void _AddJarKeyList(int key)
		{
			this.jarKeyList.Add(key);
		}

		// Token: 0x0600B409 RID: 46089 RVA: 0x00283824 File Offset: 0x00281C24
		public string _GetEquipPrice(ItemData itemData)
		{
			int levelLimit = itemData.LevelLimit;
			ItemTable.eColor quality = itemData.Quality;
			string result = string.Empty;
			EquipRecoveryPriceTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipRecoveryPriceTable>(levelLimit, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (quality == ItemTable.eColor.BLUE)
				{
					result = tableItem.Blue;
				}
				if (quality == ItemTable.eColor.PURPLE)
				{
					result = tableItem.Purple;
				}
				if (quality == ItemTable.eColor.PINK)
				{
					result = tableItem.Pink;
				}
			}
			return result;
		}

		// Token: 0x0600B40A RID: 46090 RVA: 0x0028388C File Offset: 0x00281C8C
		public int _GetEquipPrice(ItemData itemData, bool getMin)
		{
			if (itemData == null)
			{
				return 0;
			}
			int levelLimit = itemData.LevelLimit;
			ItemTable.eColor quality = itemData.Quality;
			int result = 0;
			EquipRecoveryPriceTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipRecoveryPriceTable>(levelLimit, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string text = string.Empty;
				if (quality == ItemTable.eColor.BLUE)
				{
					text = tableItem.Blue;
				}
				if (quality == ItemTable.eColor.PURPLE)
				{
					text = tableItem.Purple;
				}
				if (quality == ItemTable.eColor.PINK)
				{
					text = tableItem.Pink;
				}
				string[] array = text.Split(new char[]
				{
					'-'
				});
				if (array.Length != 2)
				{
					return 0;
				}
				if (getMin)
				{
					int.TryParse(array[0], out result);
				}
				else
				{
					int.TryParse(array[1], out result);
				}
			}
			return result;
		}

		// Token: 0x0600B40B RID: 46091 RVA: 0x00283948 File Offset: 0x00281D48
		public RewardJarStatic _GetJarState(int index)
		{
			string name = "eqreco_jarstate_" + index;
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_REWARD_SCORE);
			int count2 = DataManager<CountDataManager>.GetInstance().GetCount(name);
			RewardJarStatic result = RewardJarStatic.None;
			if (count2 != 0)
			{
				if (count2 != 1)
				{
					if (count2 == 2)
					{
						result = RewardJarStatic.HaveOpen;
					}
				}
				else
				{
					result = RewardJarStatic.CanOpen;
				}
			}
			else
			{
				result = RewardJarStatic.UnOpen;
			}
			return result;
		}

		// Token: 0x0600B40C RID: 46092 RVA: 0x002839B4 File Offset: 0x00281DB4
		public void RequestJarRecord(List<int> jarIDList)
		{
			WorldEquipRecoOpenJarsRecordReq cmd = new WorldEquipRecoOpenJarsRecordReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldEquipRecoOpenJarsRecordReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldEquipRecoOpenJarsRecordRes>(delegate(WorldEquipRecoOpenJarsRecordRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipJarListUpdate, msgRet, null, null, null);
			}, false, 15f, null);
		}

		// Token: 0x0600B40D RID: 46093 RVA: 0x00283A08 File Offset: 0x00281E08
		public bool HaveRedPoint()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipRecoveryRewardTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 1;
			bool flag = false;
			while (enumerator.MoveNext())
			{
				RewardJarStatic rewardJarStatic = DataManager<EquipRecoveryDataManager>.GetInstance()._GetJarState(num);
				if (rewardJarStatic == RewardJarStatic.CanOpen)
				{
					flag = true;
					break;
				}
				num++;
			}
			return flag || this.HaveWeekRedPoint;
		}

		// Token: 0x04006579 RID: 25977
		private bool m_bNetBind;

		// Token: 0x0400657A RID: 25978
		public bool isUpgradeing;

		// Token: 0x0400657B RID: 25979
		public List<EqRecScoreItem> submitResult = new List<EqRecScoreItem>();

		// Token: 0x0400657C RID: 25980
		public List<int> jarKeyList = new List<int>();

		// Token: 0x0400657D RID: 25981
		private bool haveWeekRedPoint;
	}
}

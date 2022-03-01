using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001522 RID: 5410
	public class ChapterBattlePotionSetUtiilty
	{
		// Token: 0x0600D282 RID: 53890 RVA: 0x0034125C File Offset: 0x0033F65C
		private static void _send(int idx, uint id)
		{
			SceneSetDungeonPotionReq cmd = new SceneSetDungeonPotionReq
			{
				potionId = id,
				pos = (byte)idx
			};
			MonoSingleton<NetManager>.instance.SendCommand<SceneSetDungeonPotionReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600D283 RID: 53891 RVA: 0x00341290 File Offset: 0x0033F690
		public static int _getItemIdx(uint id)
		{
			if (id == 0U)
			{
				return -1;
			}
			List<uint> potionSets = DataManager<PlayerBaseData>.GetInstance().potionSets;
			for (int i = 0; i < potionSets.Count; i++)
			{
				if (potionSets[i] == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600D284 RID: 53892 RVA: 0x003412D7 File Offset: 0x0033F6D7
		public static void Cancel(int idx)
		{
			ChapterBattlePotionSetUtiilty._send(idx, 0U);
		}

		// Token: 0x0600D285 RID: 53893 RVA: 0x003412E0 File Offset: 0x0033F6E0
		public static void Save(int idx, uint id)
		{
			int num = ChapterBattlePotionSetUtiilty._getItemIdx(id);
			if (num >= 0)
			{
				ChapterBattlePotionSetUtiilty.Swap(idx, num);
			}
			else
			{
				ChapterBattlePotionSetUtiilty._send(idx, id);
			}
		}

		// Token: 0x0600D286 RID: 53894 RVA: 0x00341310 File Offset: 0x0033F710
		public static bool Swap(int fstIdx, int sndIdx)
		{
			if (fstIdx < 0 || fstIdx >= DataManager<PlayerBaseData>.GetInstance().potionSets.Count)
			{
				Logger.LogErrorFormat("[PotionSet] 第1个参数越界 {0}", new object[]
				{
					fstIdx
				});
				return false;
			}
			if (sndIdx < 0 || sndIdx >= DataManager<PlayerBaseData>.GetInstance().potionSets.Count)
			{
				Logger.LogErrorFormat("[PotionSet] 第2个参数越界 {0}", new object[]
				{
					sndIdx
				});
				return false;
			}
			if (fstIdx == sndIdx)
			{
				return false;
			}
			List<uint> potionSets = DataManager<PlayerBaseData>.GetInstance().potionSets;
			uint id = potionSets[fstIdx];
			uint id2 = potionSets[sndIdx];
			ChapterBattlePotionSetUtiilty._send(fstIdx, id2);
			ChapterBattlePotionSetUtiilty._send(sndIdx, id);
			return true;
		}

		// Token: 0x0600D287 RID: 53895 RVA: 0x003413C0 File Offset: 0x0033F7C0
		public static ItemConfigTable GetItemConfigTalbeByID(int itemid)
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ItemConfigTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ItemConfigTable itemConfigTable = keyValuePair.Value as ItemConfigTable;
				if (itemConfigTable != null && itemConfigTable.ItemID == itemid)
				{
					return itemConfigTable;
				}
			}
			return null;
		}

		// Token: 0x0600D288 RID: 53896 RVA: 0x0034141C File Offset: 0x0033F81C
		public static IEnumerator QuickBuyPostion(int id, int count)
		{
			QuickBuyFrame quickBuyFrame = QuickBuyFrame.Open(QuickBuyFrame.eQuickBuyType.BuffDrug);
			quickBuyFrame.SetQuickBuyItem(id, count);
			yield return null;
			while (!QuickBuyFrame.IsOpen(QuickBuyFrame.eQuickBuyType.BuffDrug))
			{
				yield return null;
			}
			while (quickBuyFrame.state == QuickBuyFrame.eState.None)
			{
				yield return null;
			}
			if (quickBuyFrame.state == QuickBuyFrame.eState.Success)
			{
				MessageEvents events = new MessageEvents();
				SceneQuickBuyReq req = new SceneQuickBuyReq();
				SceneQuickBuyRes res = new SceneQuickBuyRes();
				req.type = 1;
				req.param1 = (ulong)((long)id);
				req.param2 = (ulong)count;
				yield return MessageUtility.Wait<SceneQuickBuyReq, SceneQuickBuyRes>(ServerType.GATE_SERVER, events, req, res, false, 30f);
				if (events.IsAllMessageReceived())
				{
					if (res.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonQuickBuyPotionFail, null, null, null, null);
					}
					else
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonQuickBuyPotionSuccess, null, null, null, null);
					}
				}
				else
				{
					Logger.LogErrorFormat("[PostinSet] 快速购买{0} {1} 失败, 消息超时", new object[]
					{
						id,
						count
					});
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonQuickBuyPotionFail, null, null, null, null);
				}
			}
			else
			{
				Logger.LogErrorFormat("[PostinSet] 快速购买{0} {1} 失败, 用户取消", new object[]
				{
					id,
					count
				});
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonQuickBuyPotionFail, null, null, null, null);
			}
			yield break;
		}
	}
}

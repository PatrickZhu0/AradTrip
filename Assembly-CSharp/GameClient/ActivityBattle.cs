using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020045AF RID: 17839
	public class ActivityBattle : PVEBattle
	{
		// Token: 0x06018F71 RID: 102257 RVA: 0x007D8CA5 File Offset: 0x007D70A5
		public ActivityBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018F72 RID: 102258 RVA: 0x007D8CB0 File Offset: 0x007D70B0
		protected override void _onAreaClear(object[] args)
		{
		}

		// Token: 0x06018F73 RID: 102259 RVA: 0x007D8CB2 File Offset: 0x007D70B2
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x06018F74 RID: 102260 RVA: 0x007D8CC1 File Offset: 0x007D70C1
		protected override void _onPostStart()
		{
			if (DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				SystemNotifyManager.SystemNotify(1033, string.Empty);
			}
		}

		// Token: 0x06018F75 RID: 102261 RVA: 0x007D8CE4 File Offset: 0x007D70E4
		protected void _openFinishFrame<T>() where T : ClientFrame
		{
			T t = Singleton<ClientSystemManager>.instance.OpenFrame<T>(FrameLayer.Middle, null, string.Empty) as T;
			if (t != null)
			{
				this.mFinishFrame = (t as IDungeonFinish);
			}
		}

		// Token: 0x06018F76 RID: 102262 RVA: 0x007D8D29 File Offset: 0x007D7129
		private void _setName()
		{
			if (this.mFinishFrame != null)
			{
				this.mFinishFrame.SetName(this.mDungeonManager.GetDungeonDataManager().table.Name);
			}
		}

		// Token: 0x06018F77 RID: 102263 RVA: 0x007D8D56 File Offset: 0x007D7156
		protected void _setFinish(bool finish)
		{
			this._setName();
			if (this.mFinishFrame != null)
			{
				this.mFinishFrame.SetFinish(finish);
			}
		}

		// Token: 0x06018F78 RID: 102264 RVA: 0x007D8D75 File Offset: 0x007D7175
		protected void _setDrop(ComItemList.Items[] items)
		{
			if (this.mFinishFrame != null)
			{
				this.mFinishFrame.SetDrops(items);
			}
		}

		// Token: 0x06018F79 RID: 102265 RVA: 0x007D8D8E File Offset: 0x007D718E
		protected void _setExp(ulong exp)
		{
			if (this.mFinishFrame != null)
			{
				this.mFinishFrame.SetExp(exp);
			}
		}

		// Token: 0x06018F7A RID: 102266 RVA: 0x007D8DA8 File Offset: 0x007D71A8
		protected ComItemList.Items[] _convertComItemList(SceneDungeonDropItem[] items)
		{
			List<ComItemList.Items> list = new List<ComItemList.Items>();
			for (int i = 0; i < items.Length; i++)
			{
				list.Add(new ComItemList.Items
				{
					count = items[i].num,
					id = (int)items[i].typeId,
					type = ComItemList.eItemType.Custom,
					equipType = (EEquipType)items[i].equipType
				});
			}
			return list.ToArray();
		}

		// Token: 0x06018F7B RID: 102267 RVA: 0x007D8E14 File Offset: 0x007D7214
		protected IEnumerator _endDropIter(int multi, DungeonDeadTowerFinishFrame frame, bool isNorth)
		{
			if (!base._isNeedSendNet())
			{
				frame.SetComItemList(null);
				yield break;
			}
			MessageEvents msg = new MessageEvents();
			SceneDungeonEndDropReq req = new SceneDungeonEndDropReq();
			SceneDungeonEndDropRes res = new SceneDungeonEndDropRes();
			req.multi = (byte)multi;
			if (!isNorth)
			{
				req = null;
			}
			yield return base._sendMsgWithResend<SceneDungeonEndDropReq, SceneDungeonEndDropRes>(ServerType.GATE_SERVER, msg, req, res, true, 10f, 3, 3);
			if (msg.IsAllMessageReceived())
			{
				if (res.multi == 0)
				{
					Logger.LogError("fail to get the resutle drop item");
					this._setDrop(new ComItemList.Items[0]);
					frame.SetComItemList(null);
					yield break;
				}
				frame.SetComItemList(this._convertComItemList(res.items));
			}
			yield break;
		}

		// Token: 0x04011F01 RID: 73473
		private IDungeonFinish mFinishFrame;
	}
}

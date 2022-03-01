using System;
using System.Collections;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x02000F66 RID: 3942
	internal class BaseActivityConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098D5 RID: 39125 RVA: 0x001D5E3D File Offset: 0x001D423D
		public BaseActivityConsume(int id, ClientFrameBinder comFrameBinder = null) : base(comFrameBinder)
		{
			this.mData = new NormalActivityConsumeData(id);
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnCountValueChange
			};
		}

		// Token: 0x060098D6 RID: 39126 RVA: 0x001D5E66 File Offset: 0x001D4266
		public void OnChange()
		{
			base.cnt = (ulong)this.mData.GetLeftCount();
			base.sumCnt = (ulong)this.mData.GetSumCount();
		}

		// Token: 0x060098D7 RID: 39127 RVA: 0x001D5E8C File Offset: 0x001D428C
		public void OnAdd()
		{
			if (this.mData.IsCanBuyCount())
			{
				int costItemID = this.mData.GetCostItemID();
				int costItemCount = this.mData.GetCostItemCount();
				byte costItemType = this.mData.GetCostItemType();
				int num = (int)this.mData.GetHasBuyCount();
				int leftcount = (int)this.mData.GetLeftBuyCount();
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._quickBuyTimes(costItemID, costItemCount, leftcount, costItemType));
			}
			else
			{
				SystemNotifyManager.SystemNotify(8200, string.Empty);
			}
		}

		// Token: 0x060098D8 RID: 39128 RVA: 0x001D5F14 File Offset: 0x001D4314
		private IEnumerator _quickBuyTimes(int id, int count, int leftcount, byte type)
		{
			QuickBuyTimesFrame frame = Singleton<ClientSystemManager>.instance.OpenFrame<QuickBuyTimesFrame>(FrameLayer.Middle, null, string.Empty) as QuickBuyTimesFrame;
			if (frame != null)
			{
				frame.SetLeftCount(leftcount);
				frame.SetCostItem(id, count);
				while (frame.state == QuickBuyTimesFrame.eState.None)
				{
					yield return Yielders.EndOfFrame;
				}
				if (frame.state == QuickBuyTimesFrame.eState.Success)
				{
					yield return this._buy(type);
				}
			}
			yield break;
		}

		// Token: 0x060098D9 RID: 39129 RVA: 0x001D5F4C File Offset: 0x001D434C
		private IEnumerator _buy(byte subType)
		{
			MessageEvents msg = new MessageEvents();
			SceneDungeonBuyTimesRes res = new SceneDungeonBuyTimesRes();
			SceneDungeonBuyTimesReq req = new SceneDungeonBuyTimesReq
			{
				subType = subType
			};
			yield return MessageUtility.Wait<SceneDungeonBuyTimesReq, SceneDungeonBuyTimesRes>(ServerType.GATE_SERVER, msg, req, res, true, 20f);
			if (msg.IsAllMessageReceived() && res.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
			}
			yield break;
		}

		// Token: 0x04004EB8 RID: 20152
		protected IActivityConsumeData mData;
	}
}

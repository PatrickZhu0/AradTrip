using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x02001258 RID: 4696
	public class GiftPackDataManager : DataManager<GiftPackDataManager>
	{
		// Token: 0x0600B463 RID: 46179 RVA: 0x00285712 File Offset: 0x00283B12
		public static GiftPackItemData GetGiftDataFromNet(GiftSyncInfo netData)
		{
			return new GiftPackItemData(netData);
		}

		// Token: 0x0600B464 RID: 46180 RVA: 0x0028571A File Offset: 0x00283B1A
		public override void Initialize()
		{
			this.Clear();
			NetProcess.AddMsgHandler(503212U, new Action<MsgDATA>(this.OnGetGiftPackInfoResp));
		}

		// Token: 0x0600B465 RID: 46181 RVA: 0x00285738 File Offset: 0x00283B38
		public override void Clear()
		{
			this.mGiftPackItems.Clear();
			NetProcess.RemoveMsgHandler(503212U, new Action<MsgDATA>(this.OnGetGiftPackInfoResp));
		}

		// Token: 0x0600B466 RID: 46182 RVA: 0x0028575C File Offset: 0x00283B5C
		public void GetGiftPackItem(int giftPackId)
		{
			if (this.mGiftPackItems.ContainsKey(giftPackId))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GetGiftData, this.mGiftPackItems[giftPackId], null, null, null);
			}
			else
			{
				SceneGiftPackInfoReq sceneGiftPackInfoReq = new SceneGiftPackInfoReq
				{
					giftPackIds = new uint[1]
				};
				sceneGiftPackInfoReq.giftPackIds[0] = (uint)giftPackId;
				NetManager.Instance().SendCommand<SceneGiftPackInfoReq>(ServerType.GATE_SERVER, sceneGiftPackInfoReq);
			}
		}

		// Token: 0x0600B467 RID: 46183 RVA: 0x002857C8 File Offset: 0x00283BC8
		private void OnGetGiftPackInfoResp(MsgDATA data)
		{
			int num = 0;
			SceneGiftPackInfoRes sceneGiftPackInfoRes = new SceneGiftPackInfoRes();
			sceneGiftPackInfoRes.decode(data.bytes, ref num);
			if (sceneGiftPackInfoRes.giftPacks == null || sceneGiftPackInfoRes.giftPacks.Length == 0)
			{
				return;
			}
			if (!this.mGiftPackItems.ContainsKey((int)sceneGiftPackInfoRes.giftPacks[0].id))
			{
				this.mGiftPackItems.Add((int)sceneGiftPackInfoRes.giftPacks[0].id, sceneGiftPackInfoRes.giftPacks[0]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GetGiftData, sceneGiftPackInfoRes.giftPacks[0], null, null, null);
		}

		// Token: 0x040065A9 RID: 26025
		private readonly Dictionary<int, GiftPackSyncInfo> mGiftPackItems = new Dictionary<int, GiftPackSyncInfo>();
	}
}

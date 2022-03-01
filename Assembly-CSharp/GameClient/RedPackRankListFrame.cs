using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019DC RID: 6620
	public class RedPackRankListFrame : ClientFrame
	{
		// Token: 0x06010387 RID: 66439 RVA: 0x004891E5 File Offset: 0x004875E5
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RedPack/RedPackRankListFrame";
		}

		// Token: 0x06010388 RID: 66440 RVA: 0x004891EC File Offset: 0x004875EC
		protected sealed override void _OnOpenFrame()
		{
			this._InitBuyTableData();
			this.InitInterface();
			this.BindUIEvent();
			this.StartCoroutine();
		}

		// Token: 0x06010389 RID: 66441 RVA: 0x00489206 File Offset: 0x00487606
		protected sealed override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
			this.StopCoroutine();
			this.StopTimeCoroutine();
		}

		// Token: 0x0601038A RID: 66442 RVA: 0x00489220 File Offset: 0x00487620
		private IEnumerator WaitTime(float time)
		{
			yield return Yielders.GetWaitForSeconds(time);
			this.StartCoroutine();
			yield break;
		}

		// Token: 0x0601038B RID: 66443 RVA: 0x00489244 File Offset: 0x00487644
		private IEnumerator WaitHttp()
		{
			BaseWaitHttpRequest req = new BaseWaitHttpRequest();
			req.url = ClientApplication.redPackRankServerPath;
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				this.mRedPackRankList = req.GetResultJson<List<RedPackRankListData>>();
				this.RefreshRankListCount(this.mRedPackRankList);
				this.selfRankData = this.FindSelfRankData(this.mRedPackRankList);
				this.UpdateSelfRankInfo(this.selfRankData);
			}
			yield break;
		}

		// Token: 0x0601038C RID: 66444 RVA: 0x00489260 File Offset: 0x00487660
		private RedPackRankListData FindSelfRankData(List<RedPackRankListData> data)
		{
			RedPackRankListData result = null;
			if (data == null)
			{
				Logger.LogErrorFormat("全平台发红包网页拉取数据失败...", new object[0]);
			}
			for (int i = 0; i < data.Count; i++)
			{
				RedPackRankListData redPackRankListData = data[i];
				if (redPackRankListData != null)
				{
					if ((long)redPackRankListData.zone_id == (long)((ulong)ClientApplication.playerinfo.serverID))
					{
						ulong num = 0UL;
						ulong.TryParse(redPackRankListData.role_id, out num);
						if (num == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							result = redPackRankListData;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0601038D RID: 66445 RVA: 0x004892F9 File Offset: 0x004876F9
		private void StartCoroutine()
		{
			this.StopCoroutine();
			this.mCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.WaitHttp());
		}

		// Token: 0x0601038E RID: 66446 RVA: 0x00489317 File Offset: 0x00487717
		private void StartTimeCoroutine()
		{
			this.StopTimeCoroutine();
			this.mTimeCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.WaitTime(0.2f));
		}

		// Token: 0x0601038F RID: 66447 RVA: 0x0048933A File Offset: 0x0048773A
		private void StopCoroutine()
		{
			if (this.mCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCoroutine);
			}
			this.mCoroutine = null;
		}

		// Token: 0x06010390 RID: 66448 RVA: 0x0048935E File Offset: 0x0048775E
		private void StopTimeCoroutine()
		{
			if (this.mTimeCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mTimeCoroutine);
			}
			this.mTimeCoroutine = null;
		}

		// Token: 0x06010391 RID: 66449 RVA: 0x00489384 File Offset: 0x00487784
		private void ClearData()
		{
			this.TimeIntrval = 0f;
			this.LeftTimeIntrval = 0f;
			this.m_arrBuyTable.Clear();
			this.RedPackRankList.Clear();
			this.selfEntry.name = string.Empty;
			this.selfEntry.id = 0UL;
			this.selfEntry.ranking = 0;
			this.selfRankData = null;
			this.mRedPackRankList.Clear();
		}

		// Token: 0x06010392 RID: 66450 RVA: 0x004893F8 File Offset: 0x004877F8
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketSendSuccess, new ClientEventSystem.UIEventHandler(this._OnSendSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdate));
		}

		// Token: 0x06010393 RID: 66451 RVA: 0x00489430 File Offset: 0x00487830
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketSendSuccess, new ClientEventSystem.UIEventHandler(this._OnSendSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdate));
		}

		// Token: 0x06010394 RID: 66452 RVA: 0x00489468 File Offset: 0x00487868
		private void _OnSendSuccess(UIEvent iEvent)
		{
			this.StartTimeCoroutine();
		}

		// Token: 0x06010395 RID: 66453 RVA: 0x00489470 File Offset: 0x00487870
		private void _OnActivityUpdate(UIEvent iEvent)
		{
			this.UpdateSendRedPackButton();
			this.UpdateShowLeftTime();
		}

		// Token: 0x06010396 RID: 66454 RVA: 0x00489480 File Offset: 0x00487880
		private void OnShowItem1DetailData()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.Item1ID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x06010397 RID: 66455 RVA: 0x004894B4 File Offset: 0x004878B4
		private void OnShowItem2DetailData()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.Item2ID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x06010398 RID: 66456 RVA: 0x004894E8 File Offset: 0x004878E8
		private void InitInterface()
		{
			this.TimeIntrval = 0f;
			this.LeftTimeIntrval = 0f;
			this.InitRankListScrollBind();
			this.InitItem1();
			this.InitItem2();
			this.mRankDes.text = TR.Value("RedPackRankDesc", this.RankIng);
			this.mActivityEndDesc.text = TR.Value("RedPackRankActivityEndDesc", this.RankIng);
			this.mTittleNeedTicketNum.text = this.TicketNum.ToString();
			this.UpdateSendRedPackButton();
			this.UpdateShowLeftTime();
		}

		// Token: 0x06010399 RID: 66457 RVA: 0x00489588 File Offset: 0x00487988
		private void InitItem1()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.Item1ID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			ComItem comItem = this.mItem1Pos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mItem1Pos);
			}
			comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
			{
				this.OnShowItem1DetailData();
			});
		}

		// Token: 0x0601039A RID: 66458 RVA: 0x004895E4 File Offset: 0x004879E4
		private void InitItem2()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.Item2ID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			ComItem comItem = this.mItem2Pos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mItem2Pos);
			}
			comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
			{
				this.OnShowItem2DetailData();
			});
		}

		// Token: 0x0601039B RID: 66459 RVA: 0x00489640 File Offset: 0x00487A40
		private void _InitBuyTableData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(333, string.Empty, string.Empty);
			this.Item1ID = tableItem.Value;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(331, string.Empty, string.Empty);
			this.Item2ID = tableItem2.Value;
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(332, string.Empty, string.Empty);
			this.TicketNum = tableItem3.Value;
			SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(511, string.Empty, string.Empty);
			if (tableItem4 != null)
			{
				this.RankIng = tableItem4.Value;
			}
			SystemValueTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(518, string.Empty, string.Empty);
			if (tableItem5 != null)
			{
				this.RequestTimeIntrval = (float)tableItem5.Value;
			}
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<RedPacketTable>())
			{
				RedPacketTable redPacketTable = keyValuePair.Value as RedPacketTable;
				if (redPacketTable.Type == RedPacketTable.eType.NEW_YEAR && redPacketTable.SubType == RedPacketTable.eSubType.Buy)
				{
					this.m_arrBuyTable.Add(redPacketTable);
				}
			}
			if (this.m_arrBuyTable.Count > 0)
			{
				this.m_arrBuyTable.Sort((RedPacketTable a, RedPacketTable b) => a.TotalMoney - b.TotalMoney);
			}
		}

		// Token: 0x0601039C RID: 66460 RVA: 0x004897B4 File Offset: 0x00487BB4
		private void InitRankListScrollBind()
		{
			this.mRankListScript.Initialize();
			this.mRankListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdateRankListScrollBind(item);
				}
			};
		}

		// Token: 0x0601039D RID: 66461 RVA: 0x004897D8 File Offset: 0x00487BD8
		private void UpdateRankListScrollBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.mRedPackRankList.Count || this.mRedPackRankList == null)
			{
				return;
			}
			RedPackRankListData redPackRankListData = this.mRedPackRankList[item.m_index];
			Image com = component.GetCom<Image>("RankImg");
			Text com2 = component.GetCom<Text>("Rank");
			Text com3 = component.GetCom<Text>("Name");
			Text com4 = component.GetCom<Text>("Num");
			GameObject gameObject = component.GetGameObject("EffectPos");
			if (redPackRankListData.rank >= 1 && redPackRankListData.rank <= 3)
			{
				this.LoadSpriteByRank(redPackRankListData.rank, ref com);
			}
			com.gameObject.CustomActive(redPackRankListData.rank >= 1 && redPackRankListData.rank <= 3);
			if (redPackRankListData.rank > 3 && redPackRankListData.rank <= this.RankIng)
			{
				com2.text = TR.Value("color_green", redPackRankListData.rank);
			}
			else if (redPackRankListData.rank > this.RankIng)
			{
				com2.text = redPackRankListData.rank.ToString();
			}
			else
			{
				com2.text = string.Empty;
			}
			com3.text = TR.Value("RedPackRankServerNameOrRoleName", redPackRankListData.server_name, redPackRankListData.role_name);
			com4.text = redPackRankListData.total_money.ToString();
		}

		// Token: 0x0601039E RID: 66462 RVA: 0x00489976 File Offset: 0x00487D76
		private void RefreshRankListCount(List<RedPackRankListData> mRedPackRankList)
		{
			if (mRedPackRankList == null)
			{
				return;
			}
			this.mRankListScript.SetElementAmount(mRedPackRankList.Count);
			this.mTips.gameObject.CustomActive(mRedPackRankList.Count <= 0);
		}

		// Token: 0x0601039F RID: 66463 RVA: 0x004899AC File Offset: 0x00487DAC
		private void UpdateSelfRankInfo(RedPackRankListData selfData)
		{
			if (selfData == null)
			{
				this.mSelfRankImg.gameObject.CustomActive(false);
				this.mSelfRank.text = "未上榜";
				this.mSelfRedPackNum.text = DataManager<CountDataManager>.GetInstance().GetCount("new_year_red_packet_num").ToString();
			}
			else
			{
				if (selfData.rank > 3 && selfData.rank <= this.RankIng)
				{
					this.mSelfRank.text = TR.Value("color_green", selfData.rank);
				}
				else if (selfData.rank > this.RankIng)
				{
					this.mSelfRank.text = selfData.rank.ToString();
				}
				else
				{
					this.mSelfRank.text = string.Empty;
					this.LoadSpriteByRank(selfData.rank, ref this.mSelfRankImg);
				}
				this.mSelfRedPackNum.text = selfData.total_money.ToString();
				this.mSelfRankImg.gameObject.CustomActive(selfData.rank >= 1 && selfData.rank <= 3);
			}
			this.mSelfName.text = TR.Value("RedPackRankServerNameOrRoleName", ClientApplication.adminServer.name, DataManager<PlayerBaseData>.GetInstance().Name);
		}

		// Token: 0x060103A0 RID: 66464 RVA: 0x00489B1C File Offset: 0x00487F1C
		private void UpdateSendRedPackButton()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(DataManager<RedPackDataManager>.GetInstance().NewYearRedPackActivityID);
			if (activeData != null && activeData.mainInfo.state == 1)
			{
				this.mSendRedPackGray.gameObject.CustomActive(false);
				this.mSendRedPackEffect.gameObject.CustomActive(true);
			}
			else
			{
				this.mSendRedPackGray.gameObject.CustomActive(true);
				this.mSendRedPackEffect.gameObject.CustomActive(false);
			}
		}

		// Token: 0x060103A1 RID: 66465 RVA: 0x00489BA0 File Offset: 0x00487FA0
		private void UpdateShowLeftTime()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(DataManager<RedPackDataManager>.GetInstance().NewYearRedPackActivityID);
			if (activeData != null && activeData.mainInfo.state == 1)
			{
				this.mLeftTime.text = Function.GetLeftTimeStr(activeData.mainInfo.dueTime, ShowtimeType.NewYearRedPack);
			}
			this.mLeftTime.gameObject.CustomActive(activeData != null && activeData.mainInfo.state == 1);
		}

		// Token: 0x060103A2 RID: 66466 RVA: 0x00489C20 File Offset: 0x00488020
		private void LoadSpriteByRank(int iRank, ref Image img)
		{
			if (iRank == 1)
			{
				ETCImageLoader.LoadSprite(ref img, "UI/Image/Packed/p_UI_RedEnvelope.png:UI_Hongbao_Tubiao_Biaoshi_01", true);
			}
			else if (iRank == 2)
			{
				ETCImageLoader.LoadSprite(ref img, "UI/Image/Packed/p_UI_RedEnvelope.png:UI_Hongbao_Tubiao_Biaoshi_02", true);
			}
			else
			{
				ETCImageLoader.LoadSprite(ref img, "UI/Image/Packed/p_UI_RedEnvelope.png:UI_Hongbao_Tubiao_Biaoshi_03", true);
			}
		}

		// Token: 0x060103A3 RID: 66467 RVA: 0x00489C6C File Offset: 0x0048806C
		private void LoadRankEffect(GameObject child, GameObject Parent, int Rank)
		{
			child = Singleton<AssetLoader>.instance.LoadResAsGameObject(string.Format("Effects/UI/Prefab/EffUI_Xinnian/EffUI_Xinnian_ph0{0}", Rank), true, 0U);
			if (child != null)
			{
				Utility.AttachTo(child, Parent, false);
			}
		}

		// Token: 0x060103A4 RID: 66468 RVA: 0x00489CA0 File Offset: 0x004880A0
		private void SendRankListReq()
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = 8;
			worldSortListReq.start = 0;
			worldSortListReq.num = 50;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
		}

		// Token: 0x060103A5 RID: 66469 RVA: 0x00489CD8 File Offset: 0x004880D8
		[MessageHandle(602602U, false, 0)]
		private void OnRankListRes(MsgDATA msg)
		{
			WorldSortListRet stream = new WorldSortListRet();
			stream.decode(msg.bytes);
			int num = 0;
			BaseSortList baseSortList = SortListDecoder.Decode(msg.bytes, ref num, msg.bytes.Length, false);
			if (baseSortList == null)
			{
				Logger.LogError("arrRecods decode fail");
				return;
			}
			this.RedPackRankList.Clear();
			this.RedPackRankList = baseSortList.entries;
			this.selfEntry = baseSortList.selfEntry;
		}

		// Token: 0x060103A6 RID: 66470 RVA: 0x00489D44 File Offset: 0x00488144
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060103A7 RID: 66471 RVA: 0x00489D48 File Offset: 0x00488148
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			this.TimeIntrval += timeElapsed;
			this.LeftTimeIntrval += timeElapsed;
			if (this.TimeIntrval >= this.RequestTimeIntrval)
			{
				this.TimeIntrval = 0f;
				this.StartCoroutine();
			}
			if (this.LeftTimeIntrval >= this.LeftRequestTimeIntrval)
			{
				this.LeftTimeIntrval = 0f;
				this.UpdateShowLeftTime();
			}
		}

		// Token: 0x060103A8 RID: 66472 RVA: 0x00489DB8 File Offset: 0x004881B8
		protected sealed override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtSendRedPack = this.mBind.GetCom<Button>("btSendRedPack");
			this.mBtSendRedPack.onClick.AddListener(new UnityAction(this._onBtSendRedPackButtonClick));
			this.mLeftTime = this.mBind.GetCom<Text>("LeftTime");
			this.mRankListScript = this.mBind.GetCom<ComUIListScript>("RankListScript");
			this.mSelfRankImg = this.mBind.GetCom<Image>("SelfRankImg");
			this.mSelfRank = this.mBind.GetCom<Text>("SelfRank");
			this.mSelfName = this.mBind.GetCom<Text>("SelfName");
			this.mSelfRedPackNum = this.mBind.GetCom<Text>("SelfRedPackNum");
			this.mItem1Pos = this.mBind.GetGameObject("Item1Pos");
			this.mItem2Pos = this.mBind.GetGameObject("Item2Pos");
			this.mTittleNeedTicketNum = this.mBind.GetCom<Text>("TittleNeedTicketNum");
			this.mTips = this.mBind.GetCom<Text>("Tips");
			this.mSendRedPackGray = this.mBind.GetCom<Image>("SendRedPackGray");
			this.mSendRedPackEffect = this.mBind.GetGameObject("SendRedPackEffect");
			this.mRankDes = this.mBind.GetCom<Text>("RankDes");
			this.mActivityEndDesc = this.mBind.GetCom<Text>("ActivityEndDesc");
		}

		// Token: 0x060103A9 RID: 66473 RVA: 0x00489F60 File Offset: 0x00488360
		protected sealed override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mBtSendRedPack.onClick.RemoveListener(new UnityAction(this._onBtSendRedPackButtonClick));
			this.mBtSendRedPack = null;
			this.mLeftTime = null;
			this.mRankListScript = null;
			this.mSelfRankImg = null;
			this.mSelfRank = null;
			this.mSelfName = null;
			this.mSelfRedPackNum = null;
			this.mItem1Pos = null;
			this.mItem2Pos = null;
			this.mTittleNeedTicketNum = null;
			this.mTips = null;
			this.mSendRedPackGray = null;
			this.mSendRedPackEffect = null;
			this.mRankDes = null;
			this.mActivityEndDesc = null;
		}

		// Token: 0x060103AA RID: 66474 RVA: 0x0048A015 File Offset: 0x00488415
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<RedPackRankListFrame>(this, false);
		}

		// Token: 0x060103AB RID: 66475 RVA: 0x0048A024 File Offset: 0x00488424
		private void _onBtSendRedPackButtonClick()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(DataManager<RedPackDataManager>.GetInstance().NewYearRedPackActivityID);
			if (activeData == null)
			{
				return;
			}
			if (activeData.mainInfo.state != 1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("发送红包活动已结束", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level < activeData.mainInfo.level)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("等级不足{0}级,无法发送红包", activeData.mainInfo.level), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.m_arrBuyTable.Count <= 0)
			{
				return;
			}
			SendRedPacketFrame.sendRedPackType = SendRedPackType.NewYear;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SendRedPacketFrame>(FrameLayer.Middle, this.m_arrBuyTable, string.Empty);
		}

		// Token: 0x0400A40A RID: 41994
		private int Item1ID;

		// Token: 0x0400A40B RID: 41995
		private int Item2ID;

		// Token: 0x0400A40C RID: 41996
		private int TicketNum;

		// Token: 0x0400A40D RID: 41997
		private int RankIng;

		// Token: 0x0400A40E RID: 41998
		private float RequestTimeIntrval = 300f;

		// Token: 0x0400A40F RID: 41999
		private float TimeIntrval;

		// Token: 0x0400A410 RID: 42000
		private float LeftRequestTimeIntrval = 20f;

		// Token: 0x0400A411 RID: 42001
		private float LeftTimeIntrval;

		// Token: 0x0400A412 RID: 42002
		private List<RedPacketTable> m_arrBuyTable = new List<RedPacketTable>();

		// Token: 0x0400A413 RID: 42003
		private List<BaseSortListEntry> RedPackRankList = new List<BaseSortListEntry>();

		// Token: 0x0400A414 RID: 42004
		private BaseSortListEntry selfEntry = new BaseSortListEntry();

		// Token: 0x0400A415 RID: 42005
		private RedPackRankListData selfRankData;

		// Token: 0x0400A416 RID: 42006
		private List<RedPackRankListData> mRedPackRankList = new List<RedPackRankListData>();

		// Token: 0x0400A417 RID: 42007
		private Coroutine mCoroutine;

		// Token: 0x0400A418 RID: 42008
		private Coroutine mTimeCoroutine;

		// Token: 0x0400A419 RID: 42009
		private Button mBtClose;

		// Token: 0x0400A41A RID: 42010
		private Button mBtSendRedPack;

		// Token: 0x0400A41B RID: 42011
		private Text mLeftTime;

		// Token: 0x0400A41C RID: 42012
		private ComUIListScript mRankListScript;

		// Token: 0x0400A41D RID: 42013
		private Image mSelfRankImg;

		// Token: 0x0400A41E RID: 42014
		private Text mSelfRank;

		// Token: 0x0400A41F RID: 42015
		private Text mSelfName;

		// Token: 0x0400A420 RID: 42016
		private Text mSelfRedPackNum;

		// Token: 0x0400A421 RID: 42017
		private GameObject mItem1Pos;

		// Token: 0x0400A422 RID: 42018
		private GameObject mItem2Pos;

		// Token: 0x0400A423 RID: 42019
		private Text mTittleNeedTicketNum;

		// Token: 0x0400A424 RID: 42020
		private Text mTips;

		// Token: 0x0400A425 RID: 42021
		private Image mSendRedPackGray;

		// Token: 0x0400A426 RID: 42022
		private GameObject mSendRedPackEffect;

		// Token: 0x0400A427 RID: 42023
		private Text mRankDes;

		// Token: 0x0400A428 RID: 42024
		private Text mActivityEndDesc;
	}
}

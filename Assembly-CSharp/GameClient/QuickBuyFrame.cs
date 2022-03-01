using System;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019C1 RID: 6593
	public class QuickBuyFrame : ClientFrame
	{
		// Token: 0x17001D2A RID: 7466
		// (get) Token: 0x06010258 RID: 66136 RVA: 0x0047FAA8 File Offset: 0x0047DEA8
		// (set) Token: 0x06010257 RID: 66135 RVA: 0x0047FA9F File Offset: 0x0047DE9F
		public QuickBuyFrame.eState state { get; private set; }

		// Token: 0x06010259 RID: 66137 RVA: 0x0047FAB0 File Offset: 0x0047DEB0
		public static string _getFrameName(QuickBuyFrame.eQuickBuyType type)
		{
			if (type == QuickBuyFrame.eQuickBuyType.BuffDrug)
			{
				return "QuickBuyFrame_BuffDrug";
			}
			if (type != QuickBuyFrame.eQuickBuyType.FullScreen)
			{
				return "QuickBuyFrame_Defaulte";
			}
			return "QuickBuyFrame_FullScreen";
		}

		// Token: 0x0601025A RID: 66138 RVA: 0x0047FAD8 File Offset: 0x0047DED8
		public static QuickBuyFrame Open(QuickBuyFrame.eQuickBuyType type)
		{
			if (type != QuickBuyFrame.eQuickBuyType.BuffDrug)
			{
				if (type == QuickBuyFrame.eQuickBuyType.FullScreen)
				{
					QuickBuyFrame.sPrefabPath = "UIFlatten/Prefabs/Common/CommonQuickBuy";
				}
			}
			else
			{
				QuickBuyFrame.sPrefabPath = "UIFlatten/Prefabs/Common/ChapterPostionQuickBuy";
			}
			QuickBuyFrame.mQuickBuyType = type;
			return Singleton<ClientSystemManager>.instance.OpenFrame<QuickBuyFrame>(FrameLayer.High, null, QuickBuyFrame._getFrameName(type)) as QuickBuyFrame;
		}

		// Token: 0x0601025B RID: 66139 RVA: 0x0047FB33 File Offset: 0x0047DF33
		public static bool IsOpen(QuickBuyFrame.eQuickBuyType type)
		{
			return Singleton<ClientSystemManager>.instance.IsFrameOpen(QuickBuyFrame._getFrameName(type));
		}

		// Token: 0x0601025C RID: 66140 RVA: 0x0047FB48 File Offset: 0x0047DF48
		protected override void _bindExUI()
		{
			this.mTypename = this.mBind.GetCom<Text>("typename");
			this.mCoincount = this.mBind.GetCom<Text>("coincount");
			this.mCointype = this.mBind.GetCom<Text>("cointype");
			this.mCancel = this.mBind.GetCom<Button>("cancel");
			this.mCancel.onClick.AddListener(new UnityAction(this._onCancelButtonClick));
			this.mOk = this.mBind.GetCom<Button>("ok");
			this.mOk.onClick.AddListener(new UnityAction(this._onOkButtonClick));
			this.mIcon = this.mBind.GetCom<Image>("icon");
			this.mBuycount = this.mBind.GetCom<Text>("buycount");
			this.mScoreMallRoot = this.mBind.GetGameObject("scoreMallRoot");
			this.mScoreMallDesc = this.mBind.GetCom<Text>("scoreMallDesc");
		}

		// Token: 0x0601025D RID: 66141 RVA: 0x0047FC54 File Offset: 0x0047E054
		protected override void _unbindExUI()
		{
			this.mTypename = null;
			this.mCoincount = null;
			this.mCointype = null;
			this.mCancel.onClick.RemoveListener(new UnityAction(this._onCancelButtonClick));
			this.mCancel = null;
			this.mOk.onClick.RemoveListener(new UnityAction(this._onOkButtonClick));
			this.mOk = null;
			this.mIcon = null;
			this.mBuycount = null;
			this.mScoreMallRoot = null;
			this.mScoreMallDesc = null;
		}

		// Token: 0x0601025E RID: 66142 RVA: 0x0047FCD8 File Offset: 0x0047E0D8
		private void _onCancelButtonClick()
		{
			this._onCancel();
		}

		// Token: 0x0601025F RID: 66143 RVA: 0x0047FCE0 File Offset: 0x0047E0E0
		private void _onOkButtonClick()
		{
			this._onOK();
		}

		// Token: 0x06010260 RID: 66144 RVA: 0x0047FCE8 File Offset: 0x0047E0E8
		public override string GetPrefabPath()
		{
			return QuickBuyFrame.sPrefabPath;
		}

		// Token: 0x06010261 RID: 66145 RVA: 0x0047FCEF File Offset: 0x0047E0EF
		protected override void _OnOpenFrame()
		{
			this.state = QuickBuyFrame.eState.None;
			if (QuickBuyFrame.mQuickBuyType == QuickBuyFrame.eQuickBuyType.FullScreen)
			{
				this._RegisterUIEvent();
			}
		}

		// Token: 0x06010262 RID: 66146 RVA: 0x0047FD09 File Offset: 0x0047E109
		protected override void _OnCloseFrame()
		{
			if (QuickBuyFrame.mQuickBuyType == QuickBuyFrame.eQuickBuyType.FullScreen)
			{
				this._UnRegisterUIEvent();
			}
			this.mRebornCoroutine = null;
		}

		// Token: 0x06010263 RID: 66147 RVA: 0x0047FD24 File Offset: 0x0047E124
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonRebornSuccess, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonRebornFail, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonFinishRebornFail, new ClientEventSystem.UIEventHandler(this._onDungoneFinishRebornFail));
		}

		// Token: 0x06010264 RID: 66148 RVA: 0x0047FD84 File Offset: 0x0047E184
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonRebornSuccess, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonRebornFail, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonFinishRebornFail, new ClientEventSystem.UIEventHandler(this._onDungoneFinishRebornFail));
		}

		// Token: 0x06010265 RID: 66149 RVA: 0x0047FDE2 File Offset: 0x0047E1E2
		public QuickBuyFrame.eType GetMoneyType()
		{
			return this.mType;
		}

		// Token: 0x06010266 RID: 66150 RVA: 0x0047FDEA File Offset: 0x0047E1EA
		public void SetRebornPlayerSeat(byte seat)
		{
			this.mRebornSeat = seat;
		}

		// Token: 0x06010267 RID: 66151 RVA: 0x0047FDF3 File Offset: 0x0047E1F3
		public void SetRebornCoroutine(Coroutine c)
		{
			this.mRebornCoroutine = c;
		}

		// Token: 0x06010268 RID: 66152 RVA: 0x0047FDFC File Offset: 0x0047E1FC
		public void SetQuickBuyItem(int id, int buyCount)
		{
			this.mType = QuickBuyFrame.eType.None;
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mTypename.text = tableItem.Name;
			}
			this.mQuicktable = Singleton<TableManager>.instance.GetTableItem<QuickBuyTable>(id, string.Empty, string.Empty);
			int costItemID = this.mQuicktable.CostItemID;
			if (this.mQuicktable != null)
			{
				this.mCount = this.mQuicktable.CostNum * buyCount;
			}
			ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(costItemID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, tableItem2.Icon, true);
			}
			this.mCoincount.text = string.Format("{0}", this.mCount);
			if (null != this.mBuycount)
			{
				this.mBuycount.text = buyCount.ToString();
			}
			ItemTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(costItemID, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				ItemTable.eSubType subType = tableItem3.SubType;
				if (subType != ItemTable.eSubType.GOLD)
				{
					if (subType != ItemTable.eSubType.POINT)
					{
						if (subType == ItemTable.eSubType.BindGOLD)
						{
							goto IL_15A;
						}
						if (subType != ItemTable.eSubType.BindPOINT)
						{
							goto IL_176;
						}
					}
					this.mType = QuickBuyFrame.eType.Point;
					this.mCointype.text = "点券";
					goto IL_176;
				}
				IL_15A:
				this.mType = QuickBuyFrame.eType.Gold;
				this.mCointype.text = "金币";
			}
			IL_176:
			this.multiple = this.mQuicktable.multiple;
			MallItemMultipleIntegralData mallItemMultipleIntegralData = DataManager<MallNewDataManager>.GetInstance().CheckMallItemMultipleIntegral(this.mQuicktable.ID);
			if (mallItemMultipleIntegralData != null)
			{
				this.multiple += mallItemMultipleIntegralData.multiple;
				this.endTime = mallItemMultipleIntegralData.endTime;
			}
			if (this.endTime > 0)
			{
				this.isTimer = ((long)this.endTime - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()) > 0L);
			}
			if (this.mScoreMallRoot != null)
			{
				this.mScoreMallRoot.CustomActive(this.multiple > 0);
			}
			if (this.mScoreMallDesc != null && this.multiple > 0)
			{
				int num = MallNewUtility.GetTicketConvertIntergalNumnber(this.mCount) * this.multiple;
				string text = string.Empty;
				if (this.multiple <= 1)
				{
					text = TR.Value("mall_fast_buy_intergral_single_multiple_desc", num);
				}
				else
				{
					text = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num, this.multiple, string.Empty);
				}
				if (this.isTimer)
				{
					text = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num, this.multiple, TR.Value("mall_fast_buy_intergral_many_multiple_remain_time_desc", Function.SetShowTimeDay(this.endTime)));
				}
				this.mScoreMallDesc.text = text;
			}
		}

		// Token: 0x06010269 RID: 66153 RVA: 0x004800E8 File Offset: 0x0047E4E8
		private void _onOK()
		{
			bool flag = false;
			QuickBuyFrame.eType eType = this.mType;
			if (eType != QuickBuyFrame.eType.Gold)
			{
				if (eType == QuickBuyFrame.eType.Point)
				{
					flag = DataManager<PlayerBaseData>.GetInstance().CanUseTicket((ulong)((long)this.mCount));
				}
			}
			else
			{
				flag = DataManager<PlayerBaseData>.GetInstance().CanUseGold((ulong)((long)this.mCount));
			}
			if (this.mType == QuickBuyFrame.eType.Point && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (flag)
			{
				if (this.mType == QuickBuyFrame.eType.Point)
				{
					if (this.multiple > 0)
					{
						string text = string.Empty;
						if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
						{
							text = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
							string content = text;
							if (QuickBuyFrame.<>f__mg$cache0 == null)
							{
								QuickBuyFrame.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
							}
							MallNewUtility.CommonIntergralMallPopupWindow(content, QuickBuyFrame.<>f__mg$cache0, new Action(this.SetState));
						}
						else
						{
							int num = MallNewUtility.GetTicketConvertIntergalNumnber(this.mCount) * this.multiple;
							int num2 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num;
							if (num2 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
							{
								text = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
								string content2 = text;
								if (QuickBuyFrame.<>f__mg$cache1 == null)
								{
									QuickBuyFrame.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
								}
								MallNewUtility.CommonIntergralMallPopupWindow(content2, QuickBuyFrame.<>f__mg$cache1, new Action(this.SetState));
							}
							else
							{
								this.SetState();
							}
						}
					}
					else
					{
						this.SetState();
					}
				}
				else
				{
					this.SetState();
				}
			}
			else
			{
				this.state = QuickBuyFrame.eState.Fail;
				QuickBuyFrame.eType eType2 = this.mType;
				if (eType2 != QuickBuyFrame.eType.Gold)
				{
					if (eType2 == QuickBuyFrame.eType.Point)
					{
						SystemNotifyManager.SystemNotify(1000027, string.Empty);
					}
				}
				else
				{
					SystemNotifyManager.SystemNotify(1000014, string.Empty);
				}
			}
			this.frameMgr.CloseFrame<QuickBuyFrame>(this, false);
		}

		// Token: 0x0601026A RID: 66154 RVA: 0x0048031F File Offset: 0x0047E71F
		private void _onCancel()
		{
			this.state = QuickBuyFrame.eState.Cancel;
			this.frameMgr.CloseFrame<QuickBuyFrame>(this, false);
		}

		// Token: 0x0601026B RID: 66155 RVA: 0x00480335 File Offset: 0x0047E735
		private void _onDungoneFinishRebornFail(UIEvent ui)
		{
			this.state = QuickBuyFrame.eState.Cancel;
			this.frameMgr.CloseFrame<QuickBuyFrame>(this, false);
		}

		// Token: 0x0601026C RID: 66156 RVA: 0x0048034B File Offset: 0x0047E74B
		private void SetState()
		{
			this.state = QuickBuyFrame.eState.Success;
		}

		// Token: 0x0601026D RID: 66157 RVA: 0x00480354 File Offset: 0x0047E754
		private void _onBattlePlayerRebornSuccess(UIEvent ui)
		{
			this._stopRebornCoroutine();
			byte b = (byte)ui.Param1;
			if (b == this.mRebornSeat)
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<QuickBuyFrame>(this, false);
			}
		}

		// Token: 0x0601026E RID: 66158 RVA: 0x0048038B File Offset: 0x0047E78B
		private void _onBattlePlayerRebornFail(UIEvent ui)
		{
			this._stopRebornCoroutine();
		}

		// Token: 0x0601026F RID: 66159 RVA: 0x00480393 File Offset: 0x0047E793
		private void _stopRebornCoroutine()
		{
			if (this.mRebornCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mRebornCoroutine);
				this.mRebornCoroutine = null;
			}
		}

		// Token: 0x0400A302 RID: 41730
		private static string sPrefabPath = "UIFlatten/Prefabs/Common/CommonQuickBuy";

		// Token: 0x0400A303 RID: 41731
		private Text mTypename;

		// Token: 0x0400A304 RID: 41732
		private Text mCoincount;

		// Token: 0x0400A305 RID: 41733
		private Text mCointype;

		// Token: 0x0400A306 RID: 41734
		private Button mCancel;

		// Token: 0x0400A307 RID: 41735
		private Button mOk;

		// Token: 0x0400A308 RID: 41736
		private Image mIcon;

		// Token: 0x0400A309 RID: 41737
		private Text mBuycount;

		// Token: 0x0400A30A RID: 41738
		private GameObject mScoreMallRoot;

		// Token: 0x0400A30B RID: 41739
		private Text mScoreMallDesc;

		// Token: 0x0400A30C RID: 41740
		private QuickBuyFrame.eType mType;

		// Token: 0x0400A30D RID: 41741
		private int mCount;

		// Token: 0x0400A30E RID: 41742
		private QuickBuyTable mQuicktable;

		// Token: 0x0400A30F RID: 41743
		private int multiple;

		// Token: 0x0400A310 RID: 41744
		private int endTime;

		// Token: 0x0400A311 RID: 41745
		private bool isTimer;

		// Token: 0x0400A312 RID: 41746
		private byte mRebornSeat = byte.MaxValue;

		// Token: 0x0400A313 RID: 41747
		private static QuickBuyFrame.eQuickBuyType mQuickBuyType;

		// Token: 0x0400A314 RID: 41748
		private Coroutine mRebornCoroutine;

		// Token: 0x0400A315 RID: 41749
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x0400A316 RID: 41750
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;

		// Token: 0x020019C2 RID: 6594
		public enum eState
		{
			// Token: 0x0400A318 RID: 41752
			None,
			// Token: 0x0400A319 RID: 41753
			Success,
			// Token: 0x0400A31A RID: 41754
			Fail,
			// Token: 0x0400A31B RID: 41755
			Cancel
		}

		// Token: 0x020019C3 RID: 6595
		public enum eType
		{
			// Token: 0x0400A31D RID: 41757
			None,
			// Token: 0x0400A31E RID: 41758
			Gold,
			// Token: 0x0400A31F RID: 41759
			Point
		}

		// Token: 0x020019C4 RID: 6596
		public enum eQuickBuyType
		{
			// Token: 0x0400A321 RID: 41761
			Default,
			// Token: 0x0400A322 RID: 41762
			FullScreen,
			// Token: 0x0400A323 RID: 41763
			BuffDrug
		}
	}
}

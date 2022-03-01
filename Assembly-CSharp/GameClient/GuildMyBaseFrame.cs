using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001638 RID: 5688
	internal class GuildMyBaseFrame : ClientFrame
	{
		// Token: 0x0600DF72 RID: 57202 RVA: 0x0039045B File Offset: 0x0038E85B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMyBase";
		}

		// Token: 0x0600DF73 RID: 57203 RVA: 0x00390462 File Offset: 0x0038E862
		protected override void _OnOpenFrame()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				return;
			}
			this._UpdateLeftBaseInfo();
			this._UpdateNotice();
			this._UpdateDeclaration();
			this._UpdatePermission();
			this._UpdateSetJoinLvInfo();
			this._UpdateGuildTips();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DF74 RID: 57204 RVA: 0x0039049E File Offset: 0x0038E89E
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DF75 RID: 57205 RVA: 0x003904A6 File Offset: 0x0038E8A6
		public override bool IsNeedUpdate()
		{
			return this.isUpdate;
		}

		// Token: 0x0600DF76 RID: 57206 RVA: 0x003904B0 File Offset: 0x0038E8B0
		protected override void _OnUpdate(float timeElapsed)
		{
			this.m_fUpdateTime -= timeElapsed;
			if (this.m_fUpdateTime <= 0f && this.m_objTime != null)
			{
				this.m_labTime.text = this._GetFreeTimeCDDesc((int)DataManager<GuildDataManager>.GetInstance().myGuild.nDismissTime);
			}
		}

		// Token: 0x0600DF77 RID: 57207 RVA: 0x0039050C File Offset: 0x0038E90C
		protected override void _bindExUI()
		{
			this.joinLv = this.mBind.GetCom<Text>("joinLv");
			this.setJoinLv = this.mBind.GetCom<Button>("setLv");
			this.setJoinLv.SafeAddOnClickListener(new UnityAction(this._onSetLvButtonClick));
			this.guildTips = this.mBind.GetCom<Button>("guildTips");
			this.guildTips.SafeAddOnClickListener(delegate
			{
				this.guildTips.CustomActive(false);
			});
			this.mGuildMergeBtn = this.mBind.GetCom<Button>("GuildMerge");
			this.mGuildMergeBtn.SafeAddOnClickListener(new UnityAction(this.OnGuildMergeBtnClick));
			if (this.mGuildMergeBtn != null)
			{
				this.mGuildMergeGray = this.mGuildMergeBtn.GetComponent<UIGray>();
			}
			this.mGuildMergeRedPointGo = this.mBind.GetGameObject("GuildMergerRedPoint");
			this.mLastWeekCashTxt = this.mBind.GetCom<Text>("LastWeekCashTxt");
			this.mThisWeekCashTxt = this.mBind.GetCom<Text>("thisWeekCashTxt");
		}

		// Token: 0x0600DF78 RID: 57208 RVA: 0x0039061C File Offset: 0x0038EA1C
		protected override void _unbindExUI()
		{
			this.joinLv = null;
			this.setJoinLv = null;
			this.guildTips = null;
			this.mGuildMergeBtn.SafeRemoveOnClickListener(new UnityAction(this.OnGuildMergeBtnClick));
			this.mGuildMergeBtn = null;
			this.mGuildMergeGray = null;
			this.mLastWeekCashTxt = null;
			this.mThisWeekCashTxt = null;
		}

		// Token: 0x0600DF79 RID: 57209 RVA: 0x00390671 File Offset: 0x0038EA71
		private void _onSetLvButtonClick()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ChangeJoinLv, EGuildDuty.Invalid))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildSetJoinLvFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DF7A RID: 57210 RVA: 0x0039069C File Offset: 0x0038EA9C
		private void OnGuildMergeBtnClick()
		{
			GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
			if (myGuild != null)
			{
				if (myGuild.prosperity == 3)
				{
					DataManager<RedPointDataManager>.GetInstance().ClearRedPoint(ERedPoint.GuildMerger);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildListFrame>(FrameLayer.Middle, EShowGuildType.CanMerged, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildmerge_lackselect"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
		}

		// Token: 0x0600DF7B RID: 57211 RVA: 0x00390700 File Offset: 0x0038EB00
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildLeaveGuildSuccess, new ClientEventSystem.UIEventHandler(this._OnLeaveGuildSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestDismissGuildSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestCancelDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestCancelDismissGuildSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildChangeNoticeSuccess, new ClientEventSystem.UIEventHandler(this._OnChangeNoticeSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildChangeDeclarationSuccess, new ClientEventSystem.UIEventHandler(this._OnChangeDeclarationSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildChangeNameSuccess, new ClientEventSystem.UIEventHandler(this._OnChangeNameSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildSendMailSuccess, new ClientEventSystem.UIEventHandler(this._OnSendMailSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildJoinLvUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildJoinLvUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildChangeDutySuccess, new ClientEventSystem.UIEventHandler(this._OnChangeDutySuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnSyncActivityState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBaseInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildBaseInfoUpdated));
		}

		// Token: 0x0600DF7C RID: 57212 RVA: 0x00390850 File Offset: 0x0038EC50
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildLeaveGuildSuccess, new ClientEventSystem.UIEventHandler(this._OnLeaveGuildSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestDismissGuildSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestCancelDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestCancelDismissGuildSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildChangeNoticeSuccess, new ClientEventSystem.UIEventHandler(this._OnChangeNoticeSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildChangeDeclarationSuccess, new ClientEventSystem.UIEventHandler(this._OnChangeDeclarationSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildChangeNameSuccess, new ClientEventSystem.UIEventHandler(this._OnChangeNameSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildSendMailSuccess, new ClientEventSystem.UIEventHandler(this._OnSendMailSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildJoinLvUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildJoinLvUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildChangeDutySuccess, new ClientEventSystem.UIEventHandler(this._OnChangeDutySuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnSyncActivityState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBaseInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildBaseInfoUpdated));
		}

		// Token: 0x0600DF7D RID: 57213 RVA: 0x003909A0 File Offset: 0x0038EDA0
		private void _UpdateGuildMergeRedPointGo()
		{
			if (this.mGuildMergeGray != null)
			{
				if (this.mGuildMergeGray.enabled)
				{
					this.mGuildMergeRedPointGo.CustomActive(false);
				}
				else
				{
					this.mGuildMergeRedPointGo.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildMerger));
				}
			}
			else
			{
				this.mGuildMergeRedPointGo.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildMerger));
			}
		}

		// Token: 0x0600DF7E RID: 57214 RVA: 0x00390A14 File Offset: 0x0038EE14
		private void _UpdateLeftBaseInfo()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				this.m_labLevel.text = myGuild.nLevel.ToString();
				this.m_labFund.text = myGuild.nFund.ToString();
				this.m_labLeader.text = TR.Value("guild_leader", myGuild.leaderData.strName);
				this.m_labMemberCount.text = string.Format("{0}/{1}", myGuild.nMemberCount, myGuild.nMemberMaxCount);
				this.m_labName.text = myGuild.strName;
				this.mLastWeekCashTxt.SafeSetText(myGuild.lastWeekFunValue.ToString());
				this.mThisWeekCashTxt.SafeSetText(myGuild.thisWeekFunValue.ToString());
			}
		}

		// Token: 0x0600DF7F RID: 57215 RVA: 0x00390B08 File Offset: 0x0038EF08
		private void _UpdateNotice()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this.m_labNotice.text = DataManager<GuildDataManager>.GetInstance().myGuild.strNotice;
				this.m_labNoticeWordsCount.text = TR.Value("guild_worlds_count", DataManager<GuildDataManager>.GetInstance().myGuild.strNotice.Length, Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(118, string.Empty, string.Empty).Value);
			}
		}

		// Token: 0x0600DF80 RID: 57216 RVA: 0x00390B8C File Offset: 0x0038EF8C
		private void _UpdateDeclaration()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this.m_labDeclaration.text = DataManager<GuildDataManager>.GetInstance().myGuild.strDeclaration;
				this.m_labDeclarationWordsCount.text = TR.Value("guild_worlds_count", DataManager<GuildDataManager>.GetInstance().myGuild.strDeclaration.Length, Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(119, string.Empty, string.Empty).Value);
			}
		}

		// Token: 0x0600DF81 RID: 57217 RVA: 0x00390C10 File Offset: 0x0038F010
		private string _GetFreeTimeCDDesc(int a_timeStamp)
		{
			int num = a_timeStamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num < 0)
			{
				num = 0;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = num % 60;
			int num5 = num / 60;
			if (num5 > 0)
			{
				num2 = num5 % 60;
				num3 = num5 / 60;
			}
			return TR.Value("guild_dissolutionguild_success", num3, num2, num4);
		}

		// Token: 0x0600DF82 RID: 57218 RVA: 0x00390C74 File Offset: 0x0038F074
		private void _UpdatePermission()
		{
			this.m_objMail.SetActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.SendMail, EGuildDuty.Invalid));
			this.m_objChangeNotice.SetActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ChangeNotice, EGuildDuty.Invalid));
			this.m_objChangeDeclaration.SetActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ChangeDeclaration, EGuildDuty.Invalid));
			this.m_objChangeName.SetActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ChangeName, EGuildDuty.Invalid));
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICR_GUILDMERGER))
			{
				if (DataManager<GuildDataManager>.GetInstance().IsCanGuildMerger())
				{
					this.mGuildMergeBtn.CustomActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.GuildMeger, EGuildDuty.Invalid));
				}
				else
				{
					this.mGuildMergeBtn.CustomActive(false);
				}
			}
			else
			{
				this.mGuildMergeBtn.CustomActive(false);
			}
			if (this.mGuildMergeGray != null)
			{
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				if (myGuild != null)
				{
					if (myGuild.prosperity != 3)
					{
						this.mGuildMergeGray.enabled = true;
					}
					else
					{
						this.mGuildMergeGray.enabled = false;
					}
				}
			}
			this._UpdateGuildMergeRedPointGo();
		}

		// Token: 0x0600DF83 RID: 57219 RVA: 0x00390D9E File Offset: 0x0038F19E
		private void _UpdateSetJoinLvInfo()
		{
			this.setJoinLv.CustomActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ChangeJoinLv, EGuildDuty.Invalid));
			this._OnGuildJoinLvUpdate(null);
		}

		// Token: 0x0600DF84 RID: 57220 RVA: 0x00390DC2 File Offset: 0x0038F1C2
		private void _OnLeaveGuildSuccess(UIEvent a_event)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
			this.frameMgr.OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DF85 RID: 57221 RVA: 0x00390DEA File Offset: 0x0038F1EA
		private void _OnRequestDismissGuildSuccess(UIEvent a_event)
		{
			this._UpdatePermission();
		}

		// Token: 0x0600DF86 RID: 57222 RVA: 0x00390DF2 File Offset: 0x0038F1F2
		private void _OnRequestCancelDismissGuildSuccess(UIEvent a_event)
		{
			this._UpdatePermission();
		}

		// Token: 0x0600DF87 RID: 57223 RVA: 0x00390DFA File Offset: 0x0038F1FA
		private void _OnChangeNoticeSuccess(UIEvent a_event)
		{
			this._UpdateNotice();
			this.frameMgr.CloseFrame<GuildCommonModifyFrame>(null, false);
		}

		// Token: 0x0600DF88 RID: 57224 RVA: 0x00390E0F File Offset: 0x0038F20F
		private void _OnChangeDeclarationSuccess(UIEvent a_event)
		{
			this._UpdateDeclaration();
			this.frameMgr.CloseFrame<GuildCommonModifyFrame>(null, false);
		}

		// Token: 0x0600DF89 RID: 57225 RVA: 0x00390E24 File Offset: 0x0038F224
		private void _OnChangeNameSuccess(UIEvent a_event)
		{
			this._UpdateLeftBaseInfo();
			this.frameMgr.CloseFrame<GuildCommonModifyFrame>(null, false);
		}

		// Token: 0x0600DF8A RID: 57226 RVA: 0x00390E39 File Offset: 0x0038F239
		private void _OnSendMailSuccess(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildCommonModifyFrame>(null, false);
		}

		// Token: 0x0600DF8B RID: 57227 RVA: 0x00390E48 File Offset: 0x0038F248
		private void _OnGuildJoinLvUpdate(UIEvent a_event)
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this.joinLv.SafeSetText(DataManager<GuildDataManager>.GetInstance().myGuild.nJoinLevel.ToString());
			}
		}

		// Token: 0x0600DF8C RID: 57228 RVA: 0x00390E7E File Offset: 0x0038F27E
		private void _OnChangeDutySuccess(UIEvent a_event)
		{
			this.setJoinLv.CustomActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ChangeJoinLv, EGuildDuty.Invalid));
		}

		// Token: 0x0600DF8D RID: 57229 RVA: 0x00390E9B File Offset: 0x0038F29B
		private void _OnSyncActivityState(UIEvent uiEvent)
		{
			this._UpdateGuildTips();
		}

		// Token: 0x0600DF8E RID: 57230 RVA: 0x00390EA3 File Offset: 0x0038F2A3
		private void _UpdateGuildTips()
		{
			this.guildTips.CustomActive(DataManager<GuildDataManager>.GetInstance().IsGuildDungeonActivityOpen());
		}

		// Token: 0x0600DF8F RID: 57231 RVA: 0x00390EBA File Offset: 0x0038F2BA
		private void _OnRedPointChanged(UIEvent uiEvent)
		{
			this._UpdateGuildMergeRedPointGo();
		}

		// Token: 0x0600DF90 RID: 57232 RVA: 0x00390EC4 File Offset: 0x0038F2C4
		private void _OnGuildBaseInfoUpdated(UIEvent uiEvent)
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				this.mLastWeekCashTxt.SafeSetText(myGuild.lastWeekFunValue.ToString());
				this.mThisWeekCashTxt.SafeSetText(myGuild.thisWeekFunValue.ToString());
			}
		}

		// Token: 0x0600DF91 RID: 57233 RVA: 0x00390F23 File Offset: 0x0038F323
		[UIEventHandle("Bottom/Func/GuildList")]
		private void _OnGuildListClicked()
		{
			this.frameMgr.OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DF92 RID: 57234 RVA: 0x00390F38 File Offset: 0x0038F338
		[UIEventHandle("Right/Notice/Title/Change")]
		private void _OnChangeNoticeClicked()
		{
			GuildCommonModifyData guildCommonModifyData = new GuildCommonModifyData();
			guildCommonModifyData.bHasCost = false;
			guildCommonModifyData.nMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(118, string.Empty, string.Empty).Value;
			guildCommonModifyData.onOkClicked = delegate(string a_strValue)
			{
				DataManager<GuildDataManager>.GetInstance().ChangeNotice(a_strValue);
			};
			guildCommonModifyData.strTitle = TR.Value("guild_change_notice");
			guildCommonModifyData.strEmptyDesc = TR.Value("guild_change_notice_desc");
			guildCommonModifyData.strDefultContent = DataManager<GuildDataManager>.GetInstance().myGuild.strNotice;
			guildCommonModifyData.eMode = EGuildCommonModifyMode.Long;
			this.frameMgr.OpenFrame<GuildCommonModifyFrame>(FrameLayer.Middle, guildCommonModifyData, string.Empty);
		}

		// Token: 0x0600DF93 RID: 57235 RVA: 0x00390FE8 File Offset: 0x0038F3E8
		[UIEventHandle("Right/Declaration/Title/Change")]
		private void _OnChangeDeclarationClicked()
		{
			GuildCommonModifyData guildCommonModifyData = new GuildCommonModifyData();
			if (guildCommonModifyData == null)
			{
				return;
			}
			if (DataManager<GuildDataManager>.GetInstance().myGuild == null)
			{
				return;
			}
			guildCommonModifyData.bHasCost = false;
			guildCommonModifyData.nMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(119, string.Empty, string.Empty).Value;
			guildCommonModifyData.onOkClicked = delegate(string a_strValue)
			{
				DataManager<GuildDataManager>.GetInstance().ChangeDeclaration(a_strValue);
			};
			guildCommonModifyData.strTitle = TR.Value("guild_change_declaration");
			guildCommonModifyData.strEmptyDesc = TR.Value("guild_change_declaration_desc");
			guildCommonModifyData.strDefultContent = DataManager<GuildDataManager>.GetInstance().myGuild.strDeclaration;
			guildCommonModifyData.eMode = EGuildCommonModifyMode.Long;
			this.frameMgr.OpenFrame<GuildCommonModifyFrame>(FrameLayer.Middle, guildCommonModifyData, string.Empty);
		}

		// Token: 0x0600DF94 RID: 57236 RVA: 0x003910AC File Offset: 0x0038F4AC
		[UIEventHandle("Left/Name/Change")]
		private void _OnChangeNameClicked()
		{
			ItemData changeCard = null;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null && item.SubType == 53 && item.ThirdType == ItemTable.eThirdType.ChangeGuildName)
					{
						changeCard = item;
						break;
					}
				}
			}
			GuildCommonModifyData guildCommonModifyData = new GuildCommonModifyData();
			if (guildCommonModifyData != null)
			{
				guildCommonModifyData.bHasCost = false;
				guildCommonModifyData.nMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(120, string.Empty, string.Empty).Value;
				guildCommonModifyData.onOkClicked = delegate(string a_strValue)
				{
					if (changeCard != null)
					{
						DataManager<GuildDataManager>.GetInstance().ChangeName((uint)changeCard.TableID, changeCard.GUID, a_strValue);
					}
					else
					{
						QuickBuyTable costTableData = Singleton<TableManager>.GetInstance().GetTableItem<QuickBuyTable>(230000303, string.Empty, string.Empty);
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(costTableData.CostItemID);
						string text = TR.Value("guild_change_name_ask", commonItemTableDataByID.GetColorName(string.Empty, false), costTableData.CostNum);
						int multiple = costTableData.multiple;
						int num = 0;
						bool flag = false;
						MallItemMultipleIntegralData mallItemMultipleIntegralData = DataManager<MallNewDataManager>.GetInstance().CheckMallItemMultipleIntegral(costTableData.ID);
						if (mallItemMultipleIntegralData != null)
						{
							multiple += mallItemMultipleIntegralData.multiple;
							num = mallItemMultipleIntegralData.endTime;
						}
						if (num > 0)
						{
							flag = ((long)num - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()) > 0L);
						}
						if (multiple > 0)
						{
							int num2 = MallNewUtility.GetTicketConvertIntergalNumnber(costTableData.CostNum) * multiple;
							string str = string.Empty;
							if (multiple <= 1)
							{
								str = TR.Value("mall_fast_buy_intergral_single_multiple_desc", num2);
							}
							else
							{
								str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num2, multiple, string.Empty);
							}
							if (flag)
							{
								str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num2, multiple, TR.Value("mall_fast_buy_intergral_many_multiple_remain_time_desc", Function.SetShowTimeDay(num)));
							}
							text += str;
						}
						SystemNotifyManager.SysNotifyMsgBoxOkCancel(text, delegate()
						{
							if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
							{
								return;
							}
							if (multiple > 0)
							{
								string text2 = string.Empty;
								if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
								{
									text2 = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
									string content = text2;
									if (GuildMyBaseFrame.<>f__mg$cache0 == null)
									{
										GuildMyBaseFrame.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
									}
									MallNewUtility.CommonIntergralMallPopupWindow(content, GuildMyBaseFrame.<>f__mg$cache0, delegate
									{
										DataManager<GuildDataManager>.GetInstance().ChangeName(0U, 0UL, a_strValue);
									});
								}
								else
								{
									int num3 = MallNewUtility.GetTicketConvertIntergalNumnber(costTableData.CostNum) * multiple;
									int num4 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num3;
									if (num4 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
									{
										text2 = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
										string content2 = text2;
										if (GuildMyBaseFrame.<>f__mg$cache1 == null)
										{
											GuildMyBaseFrame.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
										}
										MallNewUtility.CommonIntergralMallPopupWindow(content2, GuildMyBaseFrame.<>f__mg$cache1, delegate
										{
											DataManager<GuildDataManager>.GetInstance().ChangeName(0U, 0UL, a_strValue);
										});
									}
									else
									{
										DataManager<GuildDataManager>.GetInstance().ChangeName(0U, 0UL, a_strValue);
									}
								}
							}
							else
							{
								DataManager<GuildDataManager>.GetInstance().ChangeName(0U, 0UL, a_strValue);
							}
						}, null, 0f, false);
					}
				};
				guildCommonModifyData.strTitle = TR.Value("guild_change_name");
				guildCommonModifyData.strEmptyDesc = TR.Value("guild_change_name_desc");
				guildCommonModifyData.strDefultContent = DataManager<GuildDataManager>.GetInstance().myGuild.strName;
				guildCommonModifyData.eMode = EGuildCommonModifyMode.Short;
				this.frameMgr.OpenFrame<GuildCommonModifyFrame>(FrameLayer.Middle, guildCommonModifyData, string.Empty);
			}
		}

		// Token: 0x0600DF95 RID: 57237 RVA: 0x003911D0 File Offset: 0x0038F5D0
		[UIEventHandle("Bottom/Func/Mail")]
		private void _OnMailClicked()
		{
			GuildCommonModifyData guildCommonModifyData = new GuildCommonModifyData();
			guildCommonModifyData.bHasCost = false;
			guildCommonModifyData.nMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(121, string.Empty, string.Empty).Value;
			guildCommonModifyData.onOkClicked = delegate(string a_strValue)
			{
				DataManager<GuildDataManager>.GetInstance().SendMail(a_strValue);
			};
			guildCommonModifyData.strTitle = TR.Value("guild_send_mail");
			guildCommonModifyData.strEmptyDesc = TR.Value("guild_send_mail_desc");
			guildCommonModifyData.eMode = EGuildCommonModifyMode.Long;
			this.frameMgr.OpenFrame<GuildCommonModifyFrame>(FrameLayer.Middle, guildCommonModifyData, string.Empty);
		}

		// Token: 0x0600DF96 RID: 57238 RVA: 0x00391268 File Offset: 0x0038F668
		[UIEventHandle("Bottom/Func/GuildScene")]
		private void _OnSwitchToGuildScene()
		{
			DataManager<GuildDataManager>.GetInstance().SwitchToGuildScene();
		}

		// Token: 0x040084B1 RID: 33969
		[UIControl("Left/Level", null, 0)]
		private Text m_labLevel;

		// Token: 0x040084B2 RID: 33970
		[UIControl("Left/Name", null, 0)]
		private Text m_labName;

		// Token: 0x040084B3 RID: 33971
		[UIControl("Left/Fund", null, 0)]
		private Text m_labFund;

		// Token: 0x040084B4 RID: 33972
		[UIControl("Left/MemberCount", null, 0)]
		private Text m_labMemberCount;

		// Token: 0x040084B5 RID: 33973
		[UIControl("Left/Leader", null, 0)]
		private Text m_labLeader;

		// Token: 0x040084B6 RID: 33974
		[UIControl("Right/Notice/Text", null, 0)]
		private Text m_labNotice;

		// Token: 0x040084B7 RID: 33975
		[UIControl("Right/Notice/Title/CountLimit", null, 0)]
		private Text m_labNoticeWordsCount;

		// Token: 0x040084B8 RID: 33976
		[UIControl("Right/Declaration/Text", null, 0)]
		private Text m_labDeclaration;

		// Token: 0x040084B9 RID: 33977
		[UIControl("Right/Declaration/Title/CountLimit", null, 0)]
		private Text m_labDeclarationWordsCount;

		// Token: 0x040084BA RID: 33978
		[UIObject("Bottom/Func/Mail")]
		private GameObject m_objMail;

		// Token: 0x040084BB RID: 33979
		[UIObject("Right/Notice/Title/Change")]
		private GameObject m_objChangeNotice;

		// Token: 0x040084BC RID: 33980
		[UIObject("Right/Declaration/Title/Change")]
		private GameObject m_objChangeDeclaration;

		// Token: 0x040084BD RID: 33981
		[UIObject("Left/Name/Change")]
		private GameObject m_objChangeName;

		// Token: 0x040084BE RID: 33982
		[UIObject("Left/time")]
		private GameObject m_objTime;

		// Token: 0x040084BF RID: 33983
		[UIControl("Left/time", null, 0)]
		private Text m_labTime;

		// Token: 0x040084C0 RID: 33984
		private float m_fUpdateTime;

		// Token: 0x040084C1 RID: 33985
		private bool isUpdate;

		// Token: 0x040084C2 RID: 33986
		private Text joinLv;

		// Token: 0x040084C3 RID: 33987
		private Button setJoinLv;

		// Token: 0x040084C4 RID: 33988
		private Button guildTips;

		// Token: 0x040084C5 RID: 33989
		private Button mGuildMergeBtn;

		// Token: 0x040084C6 RID: 33990
		private UIGray mGuildMergeGray;

		// Token: 0x040084C7 RID: 33991
		private GameObject mGuildMergeRedPointGo;

		// Token: 0x040084C8 RID: 33992
		private Text mLastWeekCashTxt;

		// Token: 0x040084C9 RID: 33993
		private Text mThisWeekCashTxt;

		// Token: 0x040084CC RID: 33996
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x040084CD RID: 33997
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;
	}
}

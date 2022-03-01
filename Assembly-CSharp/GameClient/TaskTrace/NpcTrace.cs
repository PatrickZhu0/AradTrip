using System;
using System.Collections;
using System.Text.RegularExpressions;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient.TaskTrace
{
	// Token: 0x02001C00 RID: 7168
	internal class NpcTrace
	{
		// Token: 0x06011906 RID: 71942 RVA: 0x0051CF4D File Offset: 0x0051B34D
		public void OnMoveStateChanged(BeTownPlayerMain.EMoveState ePre, BeTownPlayerMain.EMoveState eCur)
		{
		}

		// Token: 0x06011907 RID: 71943 RVA: 0x0051CF50 File Offset: 0x0051B350
		public void OnMoveSuccess()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
				BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
			}
			if (this.onReached != null)
			{
				this.onReached();
				this.onReached = null;
			}
			else
			{
				this.OnTriggerNpc();
			}
			if (this.onSucceed != null)
			{
				this.onSucceed.Invoke();
				this.onSucceed = null;
			}
			this.onFailed = null;
		}

		// Token: 0x06011908 RID: 71944 RVA: 0x0051D00C File Offset: 0x0051B40C
		public void OnAutoMoveFail()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
				BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
			}
			if (this.onFailed != null)
			{
				this.onFailed.Invoke();
				this.onFailed = null;
			}
			this.onSucceed = null;
			this.onReached = null;
		}

		// Token: 0x06011909 RID: 71945 RVA: 0x0051D0A8 File Offset: 0x0051B4A8
		private void OnTriggerNpc()
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.iTaskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("MissionID is wrong MissionID = {0}", new object[]
				{
					this.iTaskID
				});
				return;
			}
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (!DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)tableItem.ID, out singleMissionInfo))
			{
				return;
			}
			if (singleMissionInfo.status == 0)
			{
				if (tableItem.AcceptType == MissionTable.eAcceptType.ACT_NPC && this.iNpcID == tableItem.MissionTakeNpc)
				{
					TalkTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(tableItem.BefTaskDlgID, string.Empty, string.Empty);
					if (this.bNeedDialog && tableItem2 != null)
					{
						TaskDialogFrame.OnDialogOver callback = null;
						ClientSystemTown clientSystem = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
						if (clientSystem != null)
						{
							clientSystem.PlayNpcSound(this.iNpcID, NpcVoiceComponent.SoundEffectType.SET_Start);
							callback = new TaskDialogFrame.OnDialogOver().AddListener(delegate
							{
								clientSystem.PlayNpcSound(this.iNpcID, NpcVoiceComponent.SoundEffectType.SET_End);
							});
						}
						DataManager<MissionManager>.GetInstance().CloseAllDialog();
						DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.BefTaskDlgID, this.iTaskID, callback);
					}
					else
					{
						DataManager<MissionManager>.GetInstance().sendCmdAcceptTask((uint)this.iTaskID, (TaskSubmitType)tableItem.AcceptType, (uint)tableItem.MissionTakeNpc);
					}
				}
				return;
			}
			if (singleMissionInfo.status == 1)
			{
				if (tableItem.TaskFinishType == MissionTable.eTaskFinishType.TFT_ACCESS_SHOP)
				{
					NpcTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this.iNpcID, string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.Function == NpcTable.eFunction.shopping && tableItem3.FunctionIntParam.Count > 0)
					{
						ShopTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(tableItem3.FunctionIntParam[0], string.Empty, string.Empty);
						if (tableItem4 != null)
						{
							int shopLinkID = 0;
							Regex regex = new Regex("<a href=item>\\[(\\d+)\\]</a>", RegexOptions.Singleline);
							IEnumerator enumerator = regex.Matches(tableItem.TaskFinishText).GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									Match match = (Match)obj;
									if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value))
									{
										if (!int.TryParse(match.Groups[1].Value, out shopLinkID))
										{
											shopLinkID = 0;
										}
										break;
									}
								}
							}
							finally
							{
								IDisposable disposable;
								if ((disposable = (enumerator as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
							DataManager<ShopDataManager>.GetInstance().OpenShop(tableItem4.ID, shopLinkID, -1, null, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
						}
					}
					return;
				}
				TalkTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(tableItem.BefTaskDlgID, string.Empty, string.Empty);
				if (this.bNeedDialog && tableItem5 != null)
				{
					TaskDialogFrame.OnDialogOver callback2 = null;
					ClientSystemTown clientSystem = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
					if (clientSystem != null)
					{
						clientSystem.PlayNpcSound(this.iNpcID, NpcVoiceComponent.SoundEffectType.SET_Start);
						callback2 = new TaskDialogFrame.OnDialogOver().AddListener(delegate
						{
							clientSystem.PlayNpcSound(this.iNpcID, NpcVoiceComponent.SoundEffectType.SET_End);
						});
					}
					DataManager<MissionManager>.GetInstance().CloseAllDialog();
					DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.BefTaskDlgID, this.iTaskID, callback2);
				}
			}
			if (singleMissionInfo.status == 2)
			{
				if (tableItem.FinishType == MissionTable.eFinishType.FINISH_TYPE_NPC && this.iNpcID == tableItem.MissionFinishNpc)
				{
					TalkTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(tableItem.AftTaskDlgID, string.Empty, string.Empty);
					if (this.bNeedDialog && tableItem6 != null)
					{
						TaskDialogFrame.OnDialogOver callback3 = null;
						ClientSystemTown clientSystem = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
						if (clientSystem != null)
						{
							clientSystem.PlayNpcSound(this.iNpcID, NpcVoiceComponent.SoundEffectType.SET_Start);
							callback3 = new TaskDialogFrame.OnDialogOver().AddListener(delegate
							{
								clientSystem.PlayNpcSound(this.iNpcID, NpcVoiceComponent.SoundEffectType.SET_End);
							});
						}
						DataManager<MissionManager>.GetInstance().CloseAllDialog();
						DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.AftTaskDlgID, this.iTaskID, callback3);
					}
					else
					{
						DataManager<MissionManager>.GetInstance().OpenAwardFrame((uint)this.iTaskID);
					}
				}
				return;
			}
		}

		// Token: 0x0400B6B5 RID: 46773
		public int iNpcID;

		// Token: 0x0400B6B6 RID: 46774
		public int iTaskID;

		// Token: 0x0400B6B7 RID: 46775
		public bool bNeedDialog;

		// Token: 0x0400B6B8 RID: 46776
		public OnReached onReached;

		// Token: 0x0400B6B9 RID: 46777
		public UnityAction onSucceed;

		// Token: 0x0400B6BA RID: 46778
		public UnityAction onFailed;
	}
}

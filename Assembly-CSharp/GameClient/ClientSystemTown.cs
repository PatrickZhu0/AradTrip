using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Battle;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020011A2 RID: 4514
	internal class ClientSystemTown : ClientSystem
	{
		// Token: 0x0600ACA3 RID: 44195 RVA: 0x002532C8 File Offset: 0x002516C8
		public ClientSystemTown()
		{
			this._InitSceneNodeGraph();
			this._InitDungeonMap();
		}

		// Token: 0x17001A6B RID: 6763
		// (get) Token: 0x0600ACA5 RID: 44197 RVA: 0x00253432 File Offset: 0x00251832
		// (set) Token: 0x0600ACA4 RID: 44196 RVA: 0x0025342A File Offset: 0x0025182A
		public static bool ChangeJobEnd
		{
			get
			{
				return ClientSystemTown._changeJobEnd;
			}
			set
			{
				ClientSystemTown._changeJobEnd = value;
			}
		}

		// Token: 0x0600ACA6 RID: 44198 RVA: 0x00253439 File Offset: 0x00251839
		protected sealed override string _GetLevelName()
		{
			return "Town";
		}

		// Token: 0x0600ACA7 RID: 44199 RVA: 0x00253440 File Offset: 0x00251840
		protected void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this._OnJobIDChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PopChatMsg, new ClientEventSystem.UIEventHandler(this._OnOpopChatMsg));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._OnPkRankChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetChanged, new ClientEventSystem.UIEventHandler(this._OnPetChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NameChanged, new ClientEventSystem.UIEventHandler(this._OnNameChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildTownStatueUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildTownStatueUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildGuardStatueUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildGuardStatueUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonUpdateActivityData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonUpdateActivityData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowTownPlayerHalo, new ClientEventSystem.UIEventHandler(this._OnShowTownOtherPlayerHalo));
		}

		// Token: 0x0600ACA8 RID: 44200 RVA: 0x00253558 File Offset: 0x00251958
		protected void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this._OnJobIDChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PopChatMsg, new ClientEventSystem.UIEventHandler(this._OnOpopChatMsg));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._OnPkRankChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetChanged, new ClientEventSystem.UIEventHandler(this._OnPetChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NameChanged, new ClientEventSystem.UIEventHandler(this._OnNameChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildTownStatueUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildTownStatueUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildGuardStatueUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildGuardStatueUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonUpdateActivityData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonUpdateActivityData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowTownPlayerHalo, new ClientEventSystem.UIEventHandler(this._OnShowTownOtherPlayerHalo));
		}

		// Token: 0x0600ACA9 RID: 44201 RVA: 0x00253670 File Offset: 0x00251A70
		private void _OnShowTownOtherPlayerHalo(UIEvent iEvent)
		{
			bool valueWithDefault = Singleton<SettingManager>.GetInstance().GetValueWithDefault("SETTING_ACTOR_HALO", true);
			this.SetHaloVisible(valueWithDefault);
		}

		// Token: 0x0600ACAA RID: 44202 RVA: 0x00253695 File Offset: 0x00251A95
		private void _OnJobIDChanged(UIEvent iEvent)
		{
			this.DestroyMainPlayer();
			this.CreateMainPlayer();
			this._InitializeCameraController();
		}

		// Token: 0x0600ACAB RID: 44203 RVA: 0x002536AC File Offset: 0x00251AAC
		private void _OnOpopChatMsg(UIEvent uiEvent)
		{
			if (!(uiEvent.Param1 is ChatBlock))
			{
				return;
			}
			ChatData chatData = (uiEvent.Param1 as ChatBlock).chatData;
			if (chatData != null && !string.IsNullOrEmpty(chatData.word))
			{
				if (this._beTownPlayerMain != null && (this._beTownPlayerMain.ActorData as BeTownPlayerData).GUID == chatData.objid)
				{
					this._ExecutePopChatMsg(this._beTownPlayerMain, chatData.word, chatData.bLink == 1);
					return;
				}
				if (this._beTownPlayers.ContainsKey(chatData.objid))
				{
					this._ExecutePopChatMsg(this._beTownPlayers[chatData.objid], chatData.word, chatData.bLink == 1);
				}
			}
		}

		// Token: 0x0600ACAC RID: 44204 RVA: 0x00253774 File Offset: 0x00251B74
		private void _OnPkRankChanged(UIEvent a_event)
		{
			if (this.MainPlayer != null)
			{
				this.MainPlayer.SetPlayerPKRank(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonStar);
			}
		}

		// Token: 0x0600ACAD RID: 44205 RVA: 0x002537A0 File Offset: 0x00251BA0
		private void _OnNameChanged(UIEvent a_event)
		{
			if (this.MainPlayer != null)
			{
				this.MainPlayer.SetPlayerName(DataManager<PlayerBaseData>.GetInstance().Name);
			}
		}

		// Token: 0x0600ACAE RID: 44206 RVA: 0x002537C4 File Offset: 0x00251BC4
		private void _OnGuildTownStatueUpdate(UIEvent a_event)
		{
			if (this._levelData == null)
			{
				return;
			}
			for (int i = 0; i < this._levelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this._levelData.GetNpcInfo(i);
				if (npcInfo != null)
				{
					NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcInfo.GetEntityInfo().GetResid(), string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.Function == NpcTable.eFunction.Townstatue)
						{
							BeTownNPCData data = new BeTownNPCData
							{
								NpcID = npcInfo.GetEntityInfo().GetResid(),
								ResourceID = 0
							};
							int num = 0;
							List<FigureStatueInfo> townStatueInfo = DataManager<GuildDataManager>.GetInstance().GetTownStatueInfo();
							bool flag = false;
							for (int j = 0; j < townStatueInfo.Count; j++)
							{
								FigureStatueInfo figureStatueInfo = townStatueInfo[j];
								if (figureStatueInfo.statueType == (byte)tableItem.SubType)
								{
									JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)figureStatueInfo.occu, string.Empty, string.Empty);
									if (tableItem2 == null)
									{
										Logger.LogErrorFormat("can not find JobTable with TownStatue NPC occu ID:{0} when InitTown", new object[]
										{
											figureStatueInfo.occu
										});
									}
									else
									{
										ResTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem2.Mode, string.Empty, string.Empty);
										if (tableItem3 != null)
										{
											data.ResourceID = tableItem3.ID;
											data.JobID = (int)figureStatueInfo.occu;
											data.avatorInfo = figureStatueInfo.avatar;
											data.StatueName = figureStatueInfo.name;
											num = tableItem2.TownStatueFace;
											flag = true;
											break;
										}
										Logger.LogErrorFormat("can not find ResTable with TownStatue NPC mod id:{0} when InitTown", new object[]
										{
											tableItem2.Mode
										});
									}
								}
							}
							if (!flag)
							{
								data.ResourceID = tableItem.ResID;
							}
							data.MoveData.PosLogicToGraph = this._logicToGraph;
							data.MoveData.PosServerToClient = this._serverToClient;
							data.MoveData.Position = npcInfo.GetEntityInfo().GetPosition();
							data.Name = tableItem.NpcName;
							data.NameColor = PlayerInfoColor.TOWN_NPC;
							BeTownNPC beTownNPC = new BeTownNPC(data, this);
							beTownNPC.InitGeActor(this._geScene);
							if (beTownNPC.GraphicActor != null)
							{
								beTownNPC.GraphicActor.SetScale(npcInfo.GetEntityInfo().GetScale());
								Quaternion rotation = Quaternion.Euler(0f, (float)num, 0f);
								beTownNPC.GraphicActor.SetRotation(rotation);
							}
							beTownNPC.AddActorPostLoadCommand(delegate
							{
								this.OnNPCLoadFinished(data.NpcID, beTownNPC.GraphicActor);
							});
							for (int k = 0; k < this._beTownNPCs.Count; k++)
							{
								BeTownNPC beTownNPC2 = this._beTownNPCs[k];
								if (beTownNPC2 != null)
								{
									BeTownNPCData beTownNPCData = beTownNPC2.ActorData as BeTownNPCData;
									if (beTownNPCData != null)
									{
										if (beTownNPCData.NpcID == npcInfo.GetEntityInfo().GetResid())
										{
											beTownNPC2.Dispose();
											this._beTownNPCs.RemoveAt(k);
											break;
										}
									}
								}
							}
							this._beTownNPCs.Add(beTownNPC);
						}
					}
				}
			}
		}

		// Token: 0x0600ACAF RID: 44207 RVA: 0x00253B5C File Offset: 0x00251F5C
		private void _OnGuildGuardStatueUpdate(UIEvent a_event)
		{
			if (this._levelData == null)
			{
				return;
			}
			for (int i = 0; i < this._levelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this._levelData.GetNpcInfo(i);
				if (npcInfo != null)
				{
					NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcInfo.GetEntityInfo().GetResid(), string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.Function == NpcTable.eFunction.guildGuardStatue)
						{
							BeTownNPCData data = new BeTownNPCData
							{
								NpcID = npcInfo.GetEntityInfo().GetResid(),
								ResourceID = 0
							};
							int num = 0;
							List<FigureStatueInfo> guildGuardStatueInfo = DataManager<GuildDataManager>.GetInstance().GetGuildGuardStatueInfo();
							bool flag = false;
							for (int j = 0; j < guildGuardStatueInfo.Count; j++)
							{
								FigureStatueInfo figureStatueInfo = guildGuardStatueInfo[j];
								if (figureStatueInfo.statueType == (byte)tableItem.SubType)
								{
									JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)figureStatueInfo.occu, string.Empty, string.Empty);
									if (tableItem2 == null)
									{
										Logger.LogErrorFormat("can not find JobTable with TownStatue NPC occu ID:{0} when InitTown", new object[]
										{
											figureStatueInfo.occu
										});
									}
									else
									{
										ResTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem2.Mode, string.Empty, string.Empty);
										if (tableItem3 != null)
										{
											data.ResourceID = tableItem3.ID;
											data.JobID = (int)figureStatueInfo.occu;
											data.avatorInfo = figureStatueInfo.avatar;
											data.StatueName = figureStatueInfo.name;
											num = tableItem2.TownStatueFace;
											flag = true;
											break;
										}
										Logger.LogErrorFormat("can not find ResTable with TownStatue NPC mod id:{0} when InitTown", new object[]
										{
											tableItem2.Mode
										});
									}
								}
							}
							if (!flag)
							{
								data.ResourceID = tableItem.ResID;
							}
							data.MoveData.PosLogicToGraph = this._logicToGraph;
							data.MoveData.PosServerToClient = this._serverToClient;
							data.MoveData.Position = npcInfo.GetEntityInfo().GetPosition();
							data.Name = tableItem.NpcName;
							data.NameColor = PlayerInfoColor.TOWN_NPC;
							BeTownNPC beTownNPC = new BeTownNPC(data, this);
							beTownNPC.InitGeActor(this._geScene);
							if (beTownNPC.GraphicActor != null)
							{
								beTownNPC.GraphicActor.SetScale(npcInfo.GetEntityInfo().GetScale());
								Quaternion rotation = Quaternion.Euler(0f, (float)num, 0f);
								beTownNPC.GraphicActor.SetRotation(rotation);
							}
							beTownNPC.AddActorPostLoadCommand(delegate
							{
								this.OnNPCLoadFinished(data.NpcID, beTownNPC.GraphicActor);
							});
							for (int k = 0; k < this._beTownNPCs.Count; k++)
							{
								BeTownNPC beTownNPC2 = this._beTownNPCs[k];
								if (beTownNPC2 != null)
								{
									BeTownNPCData beTownNPCData = beTownNPC2.ActorData as BeTownNPCData;
									if (beTownNPCData != null)
									{
										if (beTownNPCData.NpcID == npcInfo.GetEntityInfo().GetResid())
										{
											beTownNPC2.Dispose();
											this._beTownNPCs.RemoveAt(k);
											break;
										}
									}
								}
							}
							this._beTownNPCs.Add(beTownNPC);
						}
					}
				}
			}
		}

		// Token: 0x0600ACB0 RID: 44208 RVA: 0x00253EF8 File Offset: 0x002522F8
		private void _OnGuildDungeonUpdateActivityData(UIEvent a_event)
		{
			bool flag = DataManager<GuildDataManager>.GetInstance().IsShowChestModel();
			if (this._levelData == null)
			{
				return;
			}
			for (int i = 0; i < this._levelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this._levelData.GetNpcInfo(i);
				if (npcInfo != null)
				{
					NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcInfo.GetEntityInfo().GetResid(), string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.Function == NpcTable.eFunction.guildDungeonActivityChest)
						{
							if (!flag)
							{
								for (int j = 0; j < this._beTownNPCs.Count; j++)
								{
									BeTownNPC beTownNPC3 = this._beTownNPCs[j];
									if (beTownNPC3 != null)
									{
										BeTownNPCData beTownNPCData = beTownNPC3.ActorData as BeTownNPCData;
										if (beTownNPCData != null)
										{
											if (beTownNPCData.NpcID == npcInfo.GetEntityInfo().GetResid())
											{
												beTownNPC3.Dispose();
												this._beTownNPCs.RemoveAt(j);
												break;
											}
										}
									}
								}
								break;
							}
							for (int k = 0; k < this._beTownNPCs.Count; k++)
							{
								BeTownNPC beTownNPC2 = this._beTownNPCs[k];
								if (beTownNPC2 != null)
								{
									BeTownNPCData beTownNPCData2 = beTownNPC2.ActorData as BeTownNPCData;
									if (beTownNPCData2 != null)
									{
										if (beTownNPCData2.NpcID == npcInfo.GetEntityInfo().GetResid())
										{
											return;
										}
									}
								}
							}
							BeTownNPCData data = new BeTownNPCData
							{
								NpcID = npcInfo.GetEntityInfo().GetResid(),
								ResourceID = 0
							};
							int num = 0;
							if (!false)
							{
								data.ResourceID = tableItem.ResID;
							}
							data.MoveData.PosLogicToGraph = this._logicToGraph;
							data.MoveData.PosServerToClient = this._serverToClient;
							data.MoveData.Position = npcInfo.GetEntityInfo().GetPosition();
							data.Name = tableItem.NpcName;
							data.NameColor = PlayerInfoColor.TOWN_NPC;
							BeTownNPC beTownNPC = new BeTownNPC(data, this);
							beTownNPC.InitGeActor(this._geScene);
							if (beTownNPC.GraphicActor != null)
							{
								beTownNPC.GraphicActor.SetScale(npcInfo.GetEntityInfo().GetScale());
								Quaternion rotation = Quaternion.Euler(0f, (float)num, 0f);
								beTownNPC.GraphicActor.SetRotation(rotation);
							}
							beTownNPC.AddActorPostLoadCommand(delegate
							{
								this.OnNPCLoadFinished(data.NpcID, beTownNPC.GraphicActor);
							});
							this._beTownNPCs.Add(beTownNPC);
						}
					}
				}
			}
		}

		// Token: 0x0600ACB1 RID: 44209 RVA: 0x002541E8 File Offset: 0x002525E8
		private void _OnPetChanged(UIEvent a_event)
		{
			if (this.MainPlayer != null)
			{
				uint a_nPetID = (uint)a_event.Param1;
				this.MainPlayer.CreatePet((int)a_nPetID);
			}
		}

		// Token: 0x0600ACB2 RID: 44210 RVA: 0x00254218 File Offset: 0x00252618
		private void _ExecutePopChatMsg(BeTownPlayer actor, string words, bool bLink)
		{
			if (actor != null && actor.GraphicActor != null)
			{
				actor.GraphicActor.ShowHeadDialog(words, false, bLink, true, false, 5f, false);
			}
		}

		// Token: 0x0600ACB3 RID: 44211 RVA: 0x00254241 File Offset: 0x00252641
		public sealed override void GetEnterCoroutine(AddCoroutine enter)
		{
			enter(new loadingCoroutine(base._baseSystemLoadingCoroutine), string.Empty, 1f);
			enter(new loadingCoroutine(this.TownLoadingCoroutine), string.Empty, 1f);
		}

		// Token: 0x0600ACB4 RID: 44212 RVA: 0x0025427D File Offset: 0x0025267D
		public sealed override void OnBeforeEnter()
		{
			Singleton<ClientReconnectManager>.instance.canReconnectGate = true;
			GeAvatarFallback.EnableGlobalAvatarPartFallback = true;
		}

		// Token: 0x0600ACB5 RID: 44213 RVA: 0x00254290 File Offset: 0x00252690
		public sealed override void OnEnter()
		{
			if (Global.Settings.displayHUD)
			{
				MonoSingleton<HUDInfoViewer>.instance.Init();
			}
			base.OnEnter();
			MonoSingleton<NetManager>.instance.ClearReSendData();
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.Asset, true);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.SceneActor, true);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.UIFrame, true);
			this.TryOpenTeamPanel();
			CameraAspectAdjust.MarkDirty();
			Singleton<AssetLoader>.instance.SetAsyncLoadStep(1);
			this._resetIsSwiching();
		}

		// Token: 0x0600ACB6 RID: 44214 RVA: 0x00254308 File Offset: 0x00252708
		private void TryOpenTeamPanel()
		{
			if (ClientSystemBattle.bNeedOpenTeamFrame && !Singleton<NewbieGuideManager>.instance.IsGuiding() && DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
			}
			ClientSystemBattle.bNeedOpenTeamFrame = false;
		}

		// Token: 0x0600ACB7 RID: 44215 RVA: 0x00254358 File Offset: 0x00252758
		public sealed override void OnExit()
		{
			this.OnUnBindExtraSceneNetMessages();
			ClientSystemTown._ClearLoadPetList();
			this._resetIsSwiching();
			if (this.m_BgmHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.m_BgmHandle);
			}
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.Asset, false);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.SceneActor, false);
			Singleton<AssetGabageCollectorHelper>.instance.SetGCPurgeEnable(AssetGCTickType.UIFrame, false);
			this.ClearScene(true);
			BeTownPlayerMain.CommandStopAutoMove();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			Delegate onAddNewMission = instance.onAddNewMission;
			if (ClientSystemTown.<>f__mg$cache0 == null)
			{
				ClientSystemTown.<>f__mg$cache0 = new MissionManager.DelegateAddNewMission(ClientSystemTown._OnAddTask);
			}
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(onAddNewMission, ClientSystemTown.<>f__mg$cache0);
			this._UnBindUIEvent();
			this._ClearData();
			Singleton<ClientSystemManager>.instance.CloseFrame<ClientSystemTownFrame>(null, false);
			SystemNotifyManager.Clear();
			GeAvatarFallback.EnableGlobalAvatarPartFallback = false;
			Singleton<AssetLoader>.instance.SetAsyncLoadStep(4);
			base.OnExit();
		}

		// Token: 0x0600ACB8 RID: 44216 RVA: 0x0025442D File Offset: 0x0025282D
		private void _ClearData()
		{
			ClientSystemTown.ChangeJobBegin = false;
			ClientSystemTown._changeJobEnd = false;
			ClientSystemTown.AwakeBegin = false;
			ClientSystemTown.AwakeEnd = false;
		}

		// Token: 0x0600ACB9 RID: 44217 RVA: 0x00254448 File Offset: 0x00252848
		protected IEnumerator TownLoadingCoroutine(IASyncOperation systemOperation)
		{
			Time.timeScale = 1f;
			Singleton<ClientSystemManager>.instance.delayCaller.Clear();
			Singleton<ClientSystemManager>.instance.OpenFrame<ClientSystemTownFrame>(FrameLayer.Bottom, null, string.Empty);
			if (base.SystemManager.CurrentSystem == null)
			{
				yield return this._SystemInitWithoutNet(systemOperation);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveAllListeners();
				UnityEvent onSwitchSystemFinished = Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished;
				if (ClientSystemTown.<>f__mg$cache1 == null)
				{
					ClientSystemTown.<>f__mg$cache1 = new UnityAction(ClientSystemTown._NextFuncOpen);
				}
				onSwitchSystemFinished.AddListener(ClientSystemTown.<>f__mg$cache1);
				Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(delegate()
				{
					DataManager<DevelopGuidanceManager>.GetInstance().TryOpenGuidanceEntranceFrame();
				});
				this._BindUIEvent();
				MissionManager instance = DataManager<MissionManager>.GetInstance();
				Delegate onAddNewMission = instance.onAddNewMission;
				if (ClientSystemTown.<>f__mg$cache2 == null)
				{
					ClientSystemTown.<>f__mg$cache2 = new MissionManager.DelegateAddNewMission(ClientSystemTown._OnAddTask);
				}
				instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(onAddNewMission, ClientSystemTown.<>f__mg$cache2);
				DataManager<MissionManager>.GetInstance().AddSystemInvoke();
				Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadEnd));
				DataManager<ItemDataManager>.GetInstance().AddSystemInvoke();
				DataManager<TAPDataManager>.GetInstance().AddSystemInvoke();
				Type systemType = base.SystemManager.CurrentSystem.GetType();
				if (systemType == typeof(ClientSystemLogin))
				{
					yield return this._SystemInitEnterGame(systemOperation, false);
				}
				else if (systemType == typeof(ClientSystemBattle))
				{
					yield return this._SystemInitReturnToTown(systemOperation);
				}
				else if (systemType == typeof(ClientSystemGameBattle))
				{
					DataManager<ChijiDataManager>.GetInstance().ClearPrepareSceneData();
					if (MonoSingleton<ManualPoolCollector>.instance != null)
					{
						MonoSingleton<ManualPoolCollector>.instance.Clear();
					}
					yield return this._SystemInitReturnToTown(systemOperation);
				}
			}
			yield return ClientSystemManager._PreloadRes(systemOperation);
			Singleton<RecordServer>.GetInstance().Clear();
			Singleton<ReplayServer>.GetInstance().Clear();
			yield break;
		}

		// Token: 0x0600ACBA RID: 44218 RVA: 0x0025446C File Offset: 0x0025286C
		public void OnSceneLoadEnd()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SceneLoadFinish();
			}
		}

		// Token: 0x0600ACBB RID: 44219 RVA: 0x002544A9 File Offset: 0x002528A9
		public static void _OpenChangeJobTip()
		{
			if (!Utility.CheckCanChangeJob())
			{
				return;
			}
			if (ClientSystemTown.ChangeJobBegin)
			{
				return;
			}
			ClientSystemTown._BeginChangeJobDialog();
			ClientSystemTown.ChangeJobBegin = true;
		}

		// Token: 0x0600ACBC RID: 44220 RVA: 0x002544CC File Offset: 0x002528CC
		public static void _OpenAwakeTip()
		{
			if (!Utility.CheckCanAwake())
			{
				return;
			}
			if (ClientSystemTown.AwakeBegin)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OpenAwakeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenAwakeFrame>(null, false);
			}
			OpenAwakeFrame openAwakeFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<OpenAwakeFrame>(FrameLayer.Middle, null, string.Empty) as OpenAwakeFrame;
			OpenAwakeFrame openAwakeFrame2 = openAwakeFrame;
			if (ClientSystemTown.<>f__mg$cache3 == null)
			{
				ClientSystemTown.<>f__mg$cache3 = new UnityAction(ClientSystemTown._BeginAwakeDialog);
			}
			openAwakeFrame2.AddListener(ClientSystemTown.<>f__mg$cache3);
			ClientSystemTown.AwakeBegin = true;
		}

		// Token: 0x0600ACBD RID: 44221 RVA: 0x0025454B File Offset: 0x0025294B
		public static void _OnAddTask(uint iMissionId)
		{
		}

		// Token: 0x0600ACBE RID: 44222 RVA: 0x0025454D File Offset: 0x0025294D
		public static void _NextFuncOpen()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NextFuncOpen, null, null, null, null);
		}

		// Token: 0x0600ACBF RID: 44223 RVA: 0x00254564 File Offset: 0x00252964
		protected IEnumerator _SystemInitWithoutNet(IASyncOperation systemOperation)
		{
			DataManager<PlayerBaseData>.GetInstance().RoleID = 0UL;
			DataManager<PlayerBaseData>.GetInstance().Name = "PlayerMain";
			DataManager<PlayerBaseData>.GetInstance().JobTableID = 10;
			this.IsNet = false;
			systemOperation.SetProgress(0.7f);
			yield return Yielders.EndOfFrame;
			this.InitializeScene(2233);
			systemOperation.SetProgress(1f);
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600ACC0 RID: 44224 RVA: 0x00254588 File Offset: 0x00252988
		private IEnumerator _systemInitEnterGameProcess(IASyncOperation systemOperation, bool initwithNewbieGuideBattle = false)
		{
			Singleton<PlayerDataManager>.GetInstance().InitiallizeSystem();
			GateEnterGameReq enterGame = new GateEnterGameReq
			{
				roleId = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin().roleId,
				city = string.Empty,
				inviter = 0U,
				option = 0
			};
			NetManager netMgr = NetManager.Instance();
			netMgr.SendCommand<GateEnterGameReq>(ServerType.GATE_SERVER, enterGame);
			EEnterGameState eEnterState = EEnterGameState.Invalid;
			WaitNetMessageManager.NetMessages netMsgs = null;
			List<uint> arrWaitMsgIDs = new List<uint>
			{
				500303U,
				500602U,
				300307U
			};
			arrWaitMsgIDs.AddRange(EEnterGameWaitMsg.msgs);
			Singleton<PlayerDataManager>.GetInstance().BindEnterGameMsg(arrWaitMsgIDs);
			WaitNetMessageManager.WaitMulti wait = DataManager<WaitNetMessageManager>.GetInstance().Wait(arrWaitMsgIDs.ToArray(), delegate(WaitNetMessageManager.NetMessages msgRets)
			{
				GateEnterGameRet gateEnterGameRet = new GateEnterGameRet();
				gateEnterGameRet.decode(msgRets.GetMessageData(300307U).bytes);
				if (gateEnterGameRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)gateEnterGameRet.result, string.Empty);
					eEnterState = EEnterGameState.LoginInError;
					return;
				}
				Singleton<PlayerDataManager>.GetInstance().ProcessInitNetMessage(msgRets);
				ChapterChange.Init();
				netMsgs = msgRets;
				eEnterState = EEnterGameState.Success;
				DataManager<PlayerBaseData>.GetInstance().IsRoleEnterGame = true;
			}, true, 120f, delegate()
			{
				eEnterState = EEnterGameState.TimeOut;
			});
			while (eEnterState == EEnterGameState.Invalid)
			{
				yield return Yielders.EndOfFrame;
			}
			if (!initwithNewbieGuideBattle)
			{
				systemOperation.SetProgress(0.6f);
			}
			if (eEnterState == EEnterGameState.TimeOut)
			{
				systemOperation.SetError("[TownEnterGame] 预先消息列表各种消息超时");
				Logger.LogErrorFormat(wait.m_netMessage.GetUnReceivedMessageDesc(), new object[0]);
				yield return new NormalCustomEnumError("[TownEnterGame] 预先消息列表各种消息超时", eEnumError.NetworkErrorDisconnect);
				yield break;
			}
			if (eEnterState == EEnterGameState.LoginInError)
			{
				systemOperation.SetError(string.Empty);
				yield return new NormalCustomEnumError("[TownEnterGame] 进入游戏等待消息结果错误", eEnumError.ProcessError);
				yield break;
			}
			this.IsNet = true;
			if (!initwithNewbieGuideBattle)
			{
				systemOperation.SetProgress(0.7f);
			}
			yield return Yielders.EndOfFrame;
			SceneNotifyEnterScene msgEnterScene = new SceneNotifyEnterScene();
			msgEnterScene.decode(netMsgs.GetMessageData(500303U).bytes);
			if (msgEnterScene.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgEnterScene.result, string.Empty);
				yield break;
			}
			if (msgEnterScene.mapid == 0U)
			{
				yield return new NormalCustomEnumError("[TownEnterGame] mapID无效", eEnumError.ProcessError);
				yield break;
			}
			DataManager<PlayerBaseData>.GetInstance().Pos = new Vector3(msgEnterScene.pos.x / DataManager<PlayerBaseData>.GetInstance().AxisScale, 0f, msgEnterScene.pos.y / DataManager<PlayerBaseData>.GetInstance().AxisScale);
			this._InitOtherPlayerData(netMsgs.GetMessageData(500602U), msgEnterScene.mapid);
			this.InitializeScene((int)msgEnterScene.mapid);
			SDKInterface.instance.UpdateRoleInfo(1, ClientApplication.adminServer.id, ClientApplication.adminServer.name, DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(), DataManager<PlayerBaseData>.GetInstance().Name, DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)DataManager<PlayerBaseData>.GetInstance().Level, DataManager<PlayerBaseData>.GetInstance().VipLevel, (int)DataManager<PlayerBaseData>.GetInstance().Ticket);
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600ACC1 RID: 44225 RVA: 0x002545B4 File Offset: 0x002529B4
		protected IEnumerator _errorProcess(eEnumError type, string msg)
		{
			Logger.LogErrorFormat("城镇错误 {0}, {1}", new object[]
			{
				type,
				msg
			});
			Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
			yield break;
		}

		// Token: 0x0600ACC2 RID: 44226 RVA: 0x002545D8 File Offset: 0x002529D8
		protected IEnumerator _SystemInitEnterGame(IASyncOperation systemOperation, bool initwithNewbieGuideBattle = false)
		{
			IEnumerator process = this._systemInitEnterGameProcess(systemOperation, initwithNewbieGuideBattle);
			ThreeStepProcess threeStepprocess = new ThreeStepProcess("SystemInitEnterGame", Singleton<ClientSystemManager>.instance.enumeratorManager, process, null, null);
			threeStepprocess.SetErrorProcessHandle(new ThreeStepProcess.ErrorProcessHandle(this._errorProcess));
			yield return threeStepprocess;
			yield break;
		}

		// Token: 0x0600ACC3 RID: 44227 RVA: 0x00254604 File Offset: 0x00252A04
		protected IEnumerator _SystemInitReturnToTown(IASyncOperation systemOperation)
		{
			MonoSingleton<NetManager>.instance.Disconnect(ServerType.RELAY_SERVER);
			DataManager<BattleDataManager>.GetInstance().PkRaceType = RaceType.Dungeon;
			if (Global.Settings.isGuide && BattleMain.IsLastNewbieGuideBattle())
			{
				yield return this._SystemInitEnterGame(systemOperation, true);
			}
			else if (Singleton<ReplayServer>.GetInstance().IsLastPlaying())
			{
				this.InitializeScene(this._lastSceneId);
			}
			else if (BattleMain.CheckLastBattleMode(BattleType.Training) || BattleMain.CheckLastBattleMode(BattleType.TrainingPVE))
			{
				this.InitializeScene(this._lastSceneId);
				BattleMain.battleType = BattleType.Single;
			}
			else
			{
				MessageEvents msgEvents = new MessageEvents();
				msgEvents.AddMessage(500602U, true);
				SceneNotifyEnterScene msgEnterScene = new SceneNotifyEnterScene();
				SceneReturnToTown returnScene = new SceneReturnToTown();
				yield return MessageUtility.WaitWithResend<SceneReturnToTown, SceneNotifyEnterScene>(ServerType.GATE_SERVER, msgEvents, returnScene, msgEnterScene, true, 8f, null);
				systemOperation.SetProgress(0.5f);
				if (!msgEvents.IsAllMessageReceived())
				{
					Logger.LogErrorFormat("[SystemInitReturnToTown] 错误，没有收到返回城镇相关的消息 {0}", new object[]
					{
						msgEnterScene.mapid
					});
					systemOperation.SetError(string.Empty);
					Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
					for (;;)
					{
						yield return null;
					}
				}
				else if (msgEnterScene.result != 0U)
				{
					Logger.LogErrorFormat("[SystemInitReturnToTown] 错误，没有收到返回城镇相关的消息 {0}", new object[]
					{
						msgEnterScene.result
					});
					Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
					for (;;)
					{
						yield return null;
					}
				}
				else if (msgEnterScene.mapid <= 0U)
				{
					Logger.LogErrorFormat("[SystemInitReturnToTown] 错误，没有收到返回城镇相关的消息 {0}", new object[]
					{
						msgEnterScene.mapid
					});
					systemOperation.SetError(string.Empty);
					Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8501);
					for (;;)
					{
						yield return null;
					}
				}
				else
				{
					this.IsNet = true;
					int currentSceneID = 0;
					currentSceneID = (int)msgEnterScene.mapid;
					DataManager<PlayerBaseData>.GetInstance().Pos = new Vector3(msgEnterScene.pos.x / DataManager<PlayerBaseData>.GetInstance().AxisScale, 0f, msgEnterScene.pos.y / DataManager<PlayerBaseData>.GetInstance().AxisScale);
					this._InitOtherPlayerData(msgEvents.GetMessageData(500602U), msgEnterScene.mapid);
					systemOperation.SetProgress(0.7f);
					yield return Yielders.EndOfFrame;
					this.InitializeScene(currentSceneID);
				}
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600ACC4 RID: 44228 RVA: 0x00254626 File Offset: 0x00252A26
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			this.UpdateScene(timeElapsed);
			this._UpdateData(timeElapsed);
			this._UpdateNpcDialog(timeElapsed);
			this._OnUpdateDelayCreateCache();
		}

		// Token: 0x0600ACC5 RID: 44229 RVA: 0x00254644 File Offset: 0x00252A44
		private void _UpdateData(float delta)
		{
			List<Battle.DungeonBuff> buffList = DataManager<PlayerBaseData>.GetInstance().buffList;
			bool flag = false;
			for (int i = 0; i < buffList.Count; i++)
			{
				Battle.DungeonBuff dungeonBuff = buffList[i];
				if (dungeonBuff.type == Battle.DungeonBuff.eBuffDurationType.Town || dungeonBuff.type == Battle.DungeonBuff.eBuffDurationType.SpecialTown)
				{
					dungeonBuff.lefttime -= delta;
					if (dungeonBuff.lefttime < 0f)
					{
						dungeonBuff.readymove = true;
						flag = true;
					}
				}
			}
			if (flag)
			{
				buffList.RemoveAll(new Predicate<Battle.DungeonBuff>(this.CheckCanRemoveBuff));
			}
		}

		// Token: 0x0600ACC6 RID: 44230 RVA: 0x002546D4 File Offset: 0x00252AD4
		private bool CheckCanRemoveBuff(Battle.DungeonBuff x)
		{
			if (x.readymove)
			{
				DataManager<PlayerBaseData>.GetInstance().removedBuffList.Add(x);
			}
			return x.readymove;
		}

		// Token: 0x17001A6C RID: 6764
		// (get) Token: 0x0600ACC7 RID: 44231 RVA: 0x002546F7 File Offset: 0x00252AF7
		// (set) Token: 0x0600ACC8 RID: 44232 RVA: 0x002546FF File Offset: 0x00252AFF
		public int CurrentSceneID
		{
			get
			{
				return this._currentSceneId;
			}
			private set
			{
				if (this._fromSceneId != this._currentSceneId && this._currentSceneId != -1)
				{
					this._fromSceneId = this._currentSceneId;
				}
				this._currentSceneId = value;
			}
		}

		// Token: 0x17001A6D RID: 6765
		// (get) Token: 0x0600ACC9 RID: 44233 RVA: 0x00254731 File Offset: 0x00252B31
		public int FromSceneID
		{
			get
			{
				return this._fromSceneId;
			}
		}

		// Token: 0x17001A6E RID: 6766
		// (get) Token: 0x0600ACCA RID: 44234 RVA: 0x00254739 File Offset: 0x00252B39
		public BeTownPlayerMain MainPlayer
		{
			get
			{
				return this._beTownPlayerMain;
			}
		}

		// Token: 0x0600ACCB RID: 44235 RVA: 0x00254744 File Offset: 0x00252B44
		public void SetHaloVisible(bool flag)
		{
			foreach (KeyValuePair<ulong, BeTownPlayer> keyValuePair in this._beTownPlayers)
			{
				BeTownPlayer value = keyValuePair.Value;
				if (value != null && value.GraphicActor != null)
				{
					GeAttach attachment = value.GraphicActor.GetAttachment("halo");
					if (attachment != null)
					{
						attachment.SetVisible(flag);
					}
				}
			}
		}

		// Token: 0x17001A6F RID: 6767
		// (get) Token: 0x0600ACCC RID: 44236 RVA: 0x002547D0 File Offset: 0x00252BD0
		public ISceneData LevelData
		{
			get
			{
				return this._levelData;
			}
		}

		// Token: 0x17001A70 RID: 6768
		// (get) Token: 0x0600ACCD RID: 44237 RVA: 0x002547D8 File Offset: 0x00252BD8
		// (set) Token: 0x0600ACCE RID: 44238 RVA: 0x002547E0 File Offset: 0x00252BE0
		public PathFinding.GridInfo GridInfo { get; private set; }

		// Token: 0x0600ACCF RID: 44239 RVA: 0x002547EC File Offset: 0x00252BEC
		public static bool GetCurrentSceneSubType(out CitySceneTable.eSceneSubType subType)
		{
			subType = CitySceneTable.eSceneSubType.NULL;
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			subType = tableItem.SceneSubType;
			return true;
		}

		// Token: 0x0600ACD0 RID: 44240 RVA: 0x00254840 File Offset: 0x00252C40
		public void OnGraphicSettingChange(int displayNum)
		{
			this._beDisplayNum = displayNum;
			if (this._beDisplayNum < this._beDisplayPlayerList.Count)
			{
				List<ulong> list = ListPool<ulong>.Get();
				int i = this._beDisplayNum;
				int count = this._beDisplayPlayerList.Count;
				while (i < count)
				{
					list.Add(this._beDisplayPlayerList[i]);
					i++;
				}
				int j = 0;
				int count2 = list.Count;
				while (j < count2)
				{
					this._RemoveDisplayActor(list[j]);
					j++;
				}
				ListPool<ulong>.Release(list);
			}
			else if (this._beDisplayNum > this._beDisplayPlayerList.Count)
			{
				foreach (KeyValuePair<ulong, BeTownPlayer> keyValuePair in this._beTownPlayers)
				{
					BeTownPlayer value = keyValuePair.Value;
					if (value != null)
					{
						Dictionary<ulong, BeTownPlayer>.Enumerator enumerator;
						KeyValuePair<ulong, BeTownPlayer> keyValuePair2 = enumerator.Current;
						this._AddDisplayActor(keyValuePair2.Key);
					}
					if (this._beDisplayPlayerList.Count == this._beDisplayNum)
					{
						break;
					}
				}
			}
		}

		// Token: 0x0600ACD1 RID: 44241 RVA: 0x00254958 File Offset: 0x00252D58
		private int _Locate(List<ClientSystemTown.SceneNode> nodes, int sceneID)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				if (nodes[i].SceneID == sceneID)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600ACD2 RID: 44242 RVA: 0x00254994 File Offset: 0x00252D94
		private void _InitSceneNodeGraph()
		{
			this.m_sceneNodes.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<CitySceneTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				CitySceneTable citySceneTable = keyValuePair.Value as CitySceneTable;
				if (citySceneTable != null)
				{
					ISceneData sceneData = DungeonUtility.LoadSceneData(citySceneTable.ResPath);
					if (sceneData != null)
					{
						ClientSystemTown.SceneNode sceneNode = new ClientSystemTown.SceneNode
						{
							SceneID = citySceneTable.ID,
							DoorNodes = new List<ClientSystemTown.DoorNode>()
						};
						for (int i = 0; i < sceneData.GetTownDoorLength(); i++)
						{
							ClientSystemTown.DoorNode item = new ClientSystemTown.DoorNode
							{
								TargetSceneIndex = -1,
								Door = sceneData.GetTownDoor(i)
							};
							sceneNode.DoorNodes.Add(item);
						}
						this.m_sceneNodes.Add(sceneNode);
					}
				}
			}
			for (int j = 0; j < this.m_sceneNodes.Count; j++)
			{
				ClientSystemTown.SceneNode sceneNode2 = this.m_sceneNodes[j];
				for (int k = 0; k < sceneNode2.DoorNodes.Count; k++)
				{
					ClientSystemTown.DoorNode doorNode = sceneNode2.DoorNodes[k];
					doorNode.TargetSceneIndex = this._Locate(this.m_sceneNodes, doorNode.Door.GetTargetSceneID());
					if (doorNode.TargetSceneIndex < 0)
					{
						Logger.LogErrorFormat("Scene:{0} door-{1} targetScene {2} is not exist!", new object[]
						{
							sceneNode2.SceneID,
							doorNode.Door.GetDoorID(),
							doorNode.Door.GetTargetSceneID()
						});
					}
				}
			}
		}

		// Token: 0x0600ACD3 RID: 44243 RVA: 0x00254B50 File Offset: 0x00252F50
		private bool _DFS(List<ClientSystemTown.SceneNode> nodes, int current, int target, ref List<Vector3> path, ClientSystemTown.DoorNode door, ref List<int> SceneIDList, ref List<int> DoorIDList)
		{
			ClientSystemTown.SceneNode sceneNode = nodes[current];
			sceneNode.HasVisited = true;
			if (current == target)
			{
				if (door != null)
				{
					path.Add(door.Door.GetRegionInfo().GetEntityInfo().GetPosition());
					SceneIDList.Add(sceneNode.SceneID);
					DoorIDList.Add(door.Door.GetDoorID());
				}
				return true;
			}
			if (door != null)
			{
				path.Add(door.Door.GetRegionInfo().GetEntityInfo().GetPosition());
				SceneIDList.Add(sceneNode.SceneID);
				DoorIDList.Add(door.Door.GetDoorID());
			}
			for (int i = 0; i < sceneNode.DoorNodes.Count; i++)
			{
				ClientSystemTown.DoorNode doorNode = sceneNode.DoorNodes[i];
				ClientSystemTown.SceneNode sceneNode2 = nodes[doorNode.TargetSceneIndex];
				if (!sceneNode2.HasVisited && this._DFS(nodes, doorNode.TargetSceneIndex, target, ref path, doorNode, ref SceneIDList, ref DoorIDList))
				{
					return true;
				}
			}
			if (door != null)
			{
				path.RemoveAt(path.Count - 1);
				SceneIDList.RemoveAt(SceneIDList.Count - 1);
				DoorIDList.RemoveAt(DoorIDList.Count - 1);
			}
			return false;
		}

		// Token: 0x0600ACD4 RID: 44244 RVA: 0x00254CA0 File Offset: 0x002530A0
		public List<Vector3> GetMovePath(int targetSceneID)
		{
			List<Vector3> result = new List<Vector3>();
			int num = this._Locate(this.m_sceneNodes, targetSceneID);
			if (num >= 0)
			{
				for (int i = 0; i < this.m_sceneNodes.Count; i++)
				{
					this.m_sceneNodes[i].HasVisited = false;
				}
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				int current = this._Locate(this.m_sceneNodes, this.CurrentSceneID);
				this._DFS(this.m_sceneNodes, current, num, ref result, null, ref list, ref list2);
				for (int j = 0; j < list.Count; j++)
				{
				}
			}
			return result;
		}

		// Token: 0x0600ACD5 RID: 44245 RVA: 0x00254D50 File Offset: 0x00253150
		public Vector3 GetNpcPostion(int NpcID)
		{
			Vector3 result = Vector3.zero;
			for (int i = 0; i < this.LevelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this.LevelData.GetNpcInfo(i);
				if (npcInfo.GetEntityInfo().GetResid() == NpcID)
				{
					result = npcInfo.GetEntityInfo().GetPosition();
					break;
				}
			}
			return result;
		}

		// Token: 0x0600ACD6 RID: 44246 RVA: 0x00254DB0 File Offset: 0x002531B0
		public ISceneNPCInfoData GetNpcInfo(int NpcID)
		{
			ISceneNPCInfoData result = null;
			if (this.LevelData != null && this.LevelData.GetNpcInfoLength() >= 0)
			{
				for (int i = 0; i < this.LevelData.GetNpcInfoLength(); i++)
				{
					ISceneNPCInfoData npcInfo = this.LevelData.GetNpcInfo(i);
					if (npcInfo.GetEntityInfo().GetResid() == NpcID)
					{
						result = npcInfo;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600ACD7 RID: 44247 RVA: 0x00254E20 File Offset: 0x00253220
		public Vector3 GetValidTargetPosition(Vector3 a_currentPos, Vector3 a_targetPos, Vector2 a_minRange, Vector2 a_maxRange)
		{
			PathFinding.Grid grid = new PathFinding.Grid(this.GridInfo, a_targetPos);
			int x = (grid.X <= this.GridInfo.GridMaxX) ? ((grid.X >= this.GridInfo.GridMinX) ? grid.X : this.GridInfo.GridMinX) : this.GridInfo.GridMaxX;
			int y = (grid.Y <= this.GridInfo.GridMaxY) ? ((grid.Y >= this.GridInfo.GridMinY) ? grid.Y : this.GridInfo.GridMinY) : this.GridInfo.GridMaxX;
			PathFinding.Grid grid2 = new PathFinding.Grid(this.GridInfo, x, y);
			Vector3 vector;
			vector..ctor(a_minRange.x * 0.5f, 0f, a_minRange.y * 0.5f);
			Vector3 vector2;
			vector2..ctor(a_maxRange.x * 0.5f, 0f, a_maxRange.y * 0.5f);
			PathFinding.Grid grid3 = new PathFinding.Grid(this.GridInfo, grid2.RealPos + vector);
			PathFinding.Grid grid4 = new PathFinding.Grid(this.GridInfo, grid2.RealPos - vector);
			PathFinding.Grid grid5 = new PathFinding.Grid(this.GridInfo, grid2.RealPos + vector2);
			PathFinding.Grid grid6 = new PathFinding.Grid(this.GridInfo, grid2.RealPos - vector2);
			List<PathFinding.Grid> list = new List<PathFinding.Grid>();
			int num = (grid5.X >= grid6.X) ? grid6.X : grid5.X;
			int num2 = (grid5.X >= grid6.X) ? grid5.X : grid6.X;
			int num3 = (grid5.Y >= grid6.Y) ? grid6.Y : grid5.Y;
			int num4 = (grid5.Y >= grid6.Y) ? grid5.Y : grid6.Y;
			int num5 = (grid3.X >= grid4.X) ? grid4.X : grid3.X;
			int num6 = (grid3.X >= grid4.X) ? grid3.X : grid4.X;
			int num7 = (grid3.Y >= grid4.Y) ? grid4.Y : grid3.Y;
			int num8 = (grid3.Y >= grid4.Y) ? grid3.Y : grid4.Y;
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					if ((i < num5 || i > num6 || j < num7 || j > num8) && i >= this.GridInfo.GridMinX && i < this.GridInfo.GridMaxX && j >= this.GridInfo.GridMinY && j < this.GridInfo.GridMaxY)
					{
						int num9 = i - this.GridInfo.GridMinX;
						int num10 = j - this.GridInfo.GridMinY;
						int num11 = (this.GridInfo.GridMaxX - this.GridInfo.GridMinX) * num10 + num9;
						if (num11 >= 0 && num11 < this.GridInfo.GridBlockLayer.Length)
						{
							if (this.GridInfo.GridBlockLayer[num11] == 0)
							{
								list.Add(new PathFinding.Grid(this.GridInfo, i, j));
							}
						}
					}
				}
			}
			if (list.Count > 0)
			{
				PathFinding.Grid grid7 = new PathFinding.Grid(this.GridInfo, a_currentPos);
				for (int k = 0; k < list.Count; k++)
				{
					if (grid7.X == list[k].X && grid7.Y == list[k].Y)
					{
						return list[k].RealPos;
					}
				}
				int index = Random.Range(0, list.Count - 1);
				return list[index].RealPos;
			}
			return a_targetPos;
		}

		// Token: 0x0600ACD8 RID: 44248 RVA: 0x002552D4 File Offset: 0x002536D4
		private void _InitDungeonMap()
		{
			this.m_mapDungeonSceneID.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<CitySceneTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			DungeonID dungeonID = new DungeonID(0);
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				CitySceneTable citySceneTable = keyValuePair.Value as CitySceneTable;
				if (citySceneTable != null && citySceneTable.SceneType == CitySceneTable.eSceneType.DUNGEON_ENTRY)
				{
					for (int i = 0; i < citySceneTable.ChapterData.Count; i++)
					{
						DChapterData dchapterData = Singleton<AssetLoader>.instance.LoadRes(citySceneTable.ChapterData[i], true, 0U).obj as DChapterData;
						if (dchapterData != null && dchapterData.chapterList.Length > 0)
						{
							for (int j = 0; j < dchapterData.chapterList.Length; j++)
							{
								int dungeonID2 = dchapterData.chapterList[j].dungeonID;
								dungeonID.dungeonID = dungeonID2;
								if (!this.m_mapDungeonSceneID.ContainsKey(dungeonID.dungeonIDWithOutDiff))
								{
									this.m_mapDungeonSceneID.Add(dungeonID.dungeonIDWithOutDiff, citySceneTable.ID);
								}
								else
								{
									Logger.LogErrorFormat("地下城ID {0} 在表 城镇副本表 {1} 中重复 ", new object[]
									{
										dungeonID.dungeonID,
										citySceneTable.ID
									});
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600ACD9 RID: 44249 RVA: 0x00255438 File Offset: 0x00253838
		public int GetDungenSceneID(int dungenID)
		{
			DungeonID dungeonID = new DungeonID(dungenID);
			int result;
			if (this.m_mapDungeonSceneID.TryGetValue(dungeonID.dungeonIDWithOutPrestory, out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x0600ACDA RID: 44250 RVA: 0x00255468 File Offset: 0x00253868
		public Vector3 GetPathFindingDirection(Vector3 src, Vector3 target)
		{
			Vector3 result = Vector3.zero;
			result = target - src;
			if (Mathf.Abs(result.x) >= 1f)
			{
				result.z = 0f;
			}
			result.y = 0f;
			result.Normalize();
			return result;
		}

		// Token: 0x0600ACDB RID: 44251 RVA: 0x002554B9 File Offset: 0x002538B9
		public void OnNPCLoadFinished(int npcID, GeActorEx actor)
		{
			if (actor != null)
			{
				actor.AddVoiceListener(NpcVoiceComponent.SoundEffectType.SET_Random);
			}
		}

		// Token: 0x0600ACDC RID: 44252 RVA: 0x002554C8 File Offset: 0x002538C8
		protected void InitializeScene(int currentSceneId)
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(currentSceneId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("scene id {0} is not exist!", new object[]
				{
					currentSceneId
				});
				return;
			}
			bool bNeedGC = true;
			if (this.CurrentSceneID > 0)
			{
				CitySceneTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					bNeedGC = (tableItem.AreaID != tableItem2.AreaID);
				}
			}
			this.ClearScene(bNeedGC);
			this._RegisterEvent();
			this.CurrentSceneID = currentSceneId;
			this._lastSceneId = this.CurrentSceneID;
			this._levelData = DungeonUtility.LoadSceneData(tableItem.ResPath);
			if (this._levelData == null)
			{
				Logger.LogErrorFormat("_level data is nil, currentSceneId = {0}, CurrentSceneID = {1}, targetCityTable.ResPath = {2}", new object[]
				{
					currentSceneId,
					this.CurrentSceneID,
					tableItem.ResPath
				});
				return;
			}
			this._logicToGraph = this._levelData.GetLogicPos();
			this._serverToClient = new Vector3(this._levelData.GetLogicXSize().x, 0f, this._levelData.GetLogicZSize().x);
			this.GridInfo = new PathFinding.GridInfo
			{
				GridSize = this._levelData.GetGridSize(),
				GridMinX = this._levelData.GetLogicXmin(),
				GridMaxX = this._levelData.GetLogicXmax(),
				GridMinY = this._levelData.GetLogicZmin(),
				GridMaxY = this._levelData.GetLogicZmax(),
				GridBlockLayer = this._levelData.GetRawBlockLayer()
			};
			this.GridInfo.GridDiagonalLength = this.GridInfo.GridSize.magnitude;
			this._geScene = new GeSceneEx();
			this._geScene.LoadScene(this._levelData, true, false);
			Singleton<GeWeatherManager>.instance.ChangeWeather(this._levelData.GetWeatherMode());
			Singleton<GeGraphicSetting>.instance.GetSetting("PlayerDisplayNum", ref this._beDisplayNum);
			this.CreateSceneObjects();
			this._InitializeCameraController();
			this._InitializeBGM(tableItem.BGMPath);
			this.AddExtraOtherPlayerData();
			this._BindSceneNetMsgs();
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
			{
				Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom = true;
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom = false;
			}
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SceneJumpFinished, this.CurrentSceneID, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TownSceneInited, null, null, null, null);
		}

		// Token: 0x0600ACDD RID: 44253 RVA: 0x00255760 File Offset: 0x00253B60
		public void ChangeScene(int targetSceneId, int targetDoorId, int currentSceneId = 0, int currentDoorId = 0, SceneParams.OnSceneLoadFinish sceneLoadFinish = null)
		{
			bool bReturnScene = targetSceneId <= 0;
			SceneParams data = new SceneParams(currentSceneId, currentDoorId, targetSceneId, targetDoorId)
			{
				onSceneLoadFinish = sceneLoadFinish
			};
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NetSyncChangeScene(data, bReturnScene));
		}

		// Token: 0x0600ACDE RID: 44254 RVA: 0x002557A0 File Offset: 0x00253BA0
		public void ReturnToTown()
		{
			if (this._backTownDoor != null)
			{
				SceneParams data = new SceneParams(this._backTownDoor.SceneID, this._backTownDoor.DoorID, this._backTownDoor.TargetSceneID, this._backTownDoor.TargetDoorID);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NetSyncChangeScene(data, false));
				this._backTownDoor = null;
			}
		}

		// Token: 0x0600ACDF RID: 44255 RVA: 0x00255804 File Offset: 0x00253C04
		public void QuickEnter()
		{
			if (this._enterTownDoor != null)
			{
				SceneParams data = new SceneParams(this._enterTownDoor.SceneID, this._enterTownDoor.DoorID, this._enterTownDoor.TargetSceneID, this._enterTownDoor.TargetDoorID);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NetSyncChangeScene(data, false));
				this._enterTownDoor = null;
			}
		}

		// Token: 0x0600ACE0 RID: 44256 RVA: 0x00255868 File Offset: 0x00253C68
		public void SwitchToTargetScene(int targetSceneId, int targetDoorId, SceneParams.OnSceneLoadFinish onOk)
		{
			if (this._isSwithScene)
			{
				return;
			}
			if (targetSceneId == this.CurrentSceneID)
			{
				if (onOk != null)
				{
					onOk();
				}
				return;
			}
			this._isSwithScene = true;
			SceneParams data = new SceneParams(this.CurrentSceneID, 0, targetSceneId, targetDoorId);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NetSyncChangeScene(data, false));
		}

		// Token: 0x17001A71 RID: 6769
		// (get) Token: 0x0600ACE1 RID: 44257 RVA: 0x002558C3 File Offset: 0x00253CC3
		// (set) Token: 0x0600ACE2 RID: 44258 RVA: 0x002558CB File Offset: 0x00253CCB
		private bool isTownSceneSwitching
		{
			get
			{
				return this.mIsTownSceneSwitching;
			}
			set
			{
				this.mIsTownSceneSwitching = value;
			}
		}

		// Token: 0x0600ACE3 RID: 44259 RVA: 0x002558D4 File Offset: 0x00253CD4
		private void _resetIsSwiching()
		{
			this.isTownSceneSwitching = false;
			this._isSwithScene = false;
		}

		// Token: 0x0600ACE4 RID: 44260 RVA: 0x002558E4 File Offset: 0x00253CE4
		private void SetTownSceneSwitchState(bool flag)
		{
			this.isTownSceneSwitching = flag;
			Singleton<ClientSystemManager>.GetInstance().SendSceneNotifyLoadingInfoByTownSwitchScene(flag);
			if (!this.isTownSceneSwitching)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SceneChangedLoadingFinish, null, null, null, null);
			}
		}

		// Token: 0x0600ACE5 RID: 44261 RVA: 0x00255916 File Offset: 0x00253D16
		public bool GetTownSceneSwitchState()
		{
			return this.isTownSceneSwitching;
		}

		// Token: 0x0600ACE6 RID: 44262 RVA: 0x00255920 File Offset: 0x00253D20
		public IEnumerator _NetSyncChangeScene(SceneParams data, bool bReturnScene = false)
		{
			uint startTime = Utility.GetCurrentTimeUnix();
			if (this.isTownSceneSwitching)
			{
				yield break;
			}
			this.SetTownSceneSwitchState(true);
			Singleton<AsyncLoadTaskManager>.instance.ClearAllAsyncTasks();
			bool isUseLoadingFrame = false;
			if (!bReturnScene)
			{
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(data.currSceneID, string.Empty, string.Empty);
				CitySceneTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(data.targetSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem2 != null)
				{
					isUseLoadingFrame = (tableItem.AreaID != tableItem2.AreaID);
					if (tableItem.SceneType == CitySceneTable.eSceneType.NORMAL && tableItem2.SceneType == CitySceneTable.eSceneType.NORMAL && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem2.LevelLimit)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("town_lock_desc", tableItem2.Name, tableItem2.LevelLimit), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						this._isSwithScene = false;
						this.SetTownSceneSwitchState(false);
						yield break;
					}
				}
			}
			if (this.MainPlayer != null)
			{
				this.MainPlayer.SetEnable(false);
			}
			bool bNeedHideBottomLayer = data.targetSceneID == 6090;
			if (bNeedHideBottomLayer && Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
			{
				Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(false);
			}
			this._UnBindSceneNetMsgs();
			this.OnBindExtraSceneNetMessages();
			MessageEvents msgEvents = new MessageEvents();
			msgEvents.AddMessage(500602U, true);
			SceneNotifyEnterScene msgEnterScene = new SceneNotifyEnterScene();
			if (bReturnScene)
			{
				SceneReturnToTown returnScene = new SceneReturnToTown();
				yield return MessageUtility.WaitWithResend<SceneReturnToTown, SceneNotifyEnterScene>(ServerType.GATE_SERVER, msgEvents, returnScene, msgEnterScene, true, 8f, null);
			}
			else
			{
				ScenePlayerChangeSceneReq changeScene = new ScenePlayerChangeSceneReq
				{
					curDoorId = (uint)data.currDoorID,
					dstSceneId = (uint)data.targetSceneID,
					dstDoorId = (uint)data.targetDoorID
				};
				yield return MessageUtility.WaitWithResend<ScenePlayerChangeSceneReq, SceneNotifyEnterScene>(ServerType.GATE_SERVER, msgEvents, changeScene, msgEnterScene, true, 8f, null);
			}
			if (!msgEvents.IsAllMessageReceived())
			{
				if (this.MainPlayer != null)
				{
					this.MainPlayer.SetEnable(true);
					if (data.type == eSceneChangeType.eDungeonChapterSelect)
					{
						this.MainPlayer.CommandMoveTo(data.birthPostion);
					}
				}
				this._BindSceneNetMsgs();
				this._isSwithScene = false;
				this.SetTownSceneSwitchState(false);
				if (Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
				{
					Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(true);
				}
				yield break;
			}
			if (msgEnterScene.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgEnterScene.result, string.Empty);
				if (this.MainPlayer != null)
				{
					this.MainPlayer.SetEnable(true);
				}
				if (Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
				{
					Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(true);
				}
				this._BindSceneNetMsgs();
				this._isSwithScene = false;
				this.SetTownSceneSwitchState(false);
				Logger.LogErrorFormat("[城镇] 切换场景失败(返回错误码) 待在原地. 当前场景ID : {0}, 当前门 : {1}, 目标场景: {2}, 目标门ID {3},msgEnterScene.result = {4}", new object[]
				{
					data.currSceneID,
					data.currDoorID,
					data.targetSceneID,
					data.targetDoorID,
					msgEnterScene.result
				});
				yield break;
			}
			if (msgEnterScene.mapid <= 0U)
			{
				if (this.MainPlayer != null)
				{
					this.MainPlayer.SetEnable(true);
					if (data.type == eSceneChangeType.eDungeonChapterSelect)
					{
						this.MainPlayer.CommandMoveTo(data.birthPostion);
					}
				}
				this._BindSceneNetMsgs();
				this._isSwithScene = false;
				this.SetTownSceneSwitchState(false);
				Logger.LogErrorFormat("[城镇] 切换场景失败(场景id无效) 待在原地. 当前场景ID : {0}, 当前门 : {1}, 目标场景: {2}, 目标门ID {3}", new object[]
				{
					data.currSceneID,
					data.currDoorID,
					data.targetSceneID,
					data.targetDoorID
				});
				yield break;
			}
			ITownFadingFrame loadingFrame = this.OpenTownFadingFrame(isUseLoadingFrame);
			if (loadingFrame != null)
			{
				loadingFrame.FadingIn(0.4f);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame != null)
				{
					clientSystemTownFrame.StopMainPlayerMoveAndStopFizzyCheck();
				}
			}
			msgEnterScene.decode(msgEvents.GetMessageData(500303U).bytes);
			this._InitOtherPlayerData(msgEvents.GetMessageData(500602U), msgEnterScene.mapid);
			if (loadingFrame != null)
			{
				while (!loadingFrame.IsOpened())
				{
					yield return Yielders.EndOfFrame;
				}
			}
			else
			{
				Logger.LogErrorFormat("[城镇] 切换场景, loadingFrame is null. 当前场景ID : {0}, 当前门 : {1}, 目标场景: {2}, 目标门ID {3}", new object[]
				{
					data.currSceneID,
					data.currDoorID,
					data.targetSceneID,
					data.targetDoorID
				});
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrames();
			CitySceneTable tableData = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>((int)msgEnterScene.mapid, string.Empty, string.Empty);
			if (tableData != null)
			{
				Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom = false;
				if (tableData.SceneType == CitySceneTable.eSceneType.DUNGEON_ENTRY)
				{
					this.ClearScene(false);
					this._BindSceneNetMsgs();
					this.ShowDugeonEntryFrame(data, (int)msgEnterScene.mapid);
				}
				else
				{
					DataManager<PlayerBaseData>.GetInstance().Pos = new Vector3(msgEnterScene.pos.x / DataManager<PlayerBaseData>.GetInstance().AxisScale, 0f, msgEnterScene.pos.y / DataManager<PlayerBaseData>.GetInstance().AxisScale);
					this.InitializeScene((int)msgEnterScene.mapid);
					this.ClearBaseMainFrame();
					if (tableData.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
					{
						this.ShowPkPrePareFrame(tableData);
					}
					else if (tableData.SceneType == CitySceneTable.eSceneType.TEAMDUPLICATION)
					{
						this.ShowTeamDuplicationFrame(tableData);
					}
					else if (tableData.SceneType == CitySceneTable.eSceneType.CHAMPIONSHIP)
					{
						CommonUtility.SetClientSystemTownFrameForbidFadeIn(true);
						ChampionshipUtility.OnOpenChampionshipMainFrame();
					}
					else if (tableData.SceneType == CitySceneTable.eSceneType.NORMAL && tableData.SceneSubType == CitySceneTable.eSceneSubType.Guild)
					{
						GuildArenaData userData = new GuildArenaData
						{
							SceneSubType = tableData.SceneSubType,
							CurrentSceneID = tableData.ID,
							TargetTownSceneID = tableData.TraditionSceneID
						};
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildArenaFrame>(FrameLayer.Bottom, userData, string.Empty);
					}
					UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent.EventParams.CurrentSceneID = (int)msgEnterScene.mapid;
					idleUIEvent.EventID = EUIEventID.SceneChangedFinish;
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
				}
			}
			if (loadingFrame != null)
			{
				loadingFrame.FadingOut(0.2f);
			}
			if (loadingFrame != null)
			{
				while (!loadingFrame.IsClosed())
				{
					yield return Yielders.EndOfFrame;
				}
			}
			this.DealWithExtraShowFrame();
			if (tableData != null && tableData.SceneType != CitySceneTable.eSceneType.DUNGEON_ENTRY)
			{
				if (tableData.SceneType != CitySceneTable.eSceneType.PK_PREPARE)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchToMainScene, null, null, null, null);
				}
				MonoSingleton<GameFrameWork>.instance.TownNameShow(tableData.Name);
				GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SceneChangedFinish, null, null, null, null);
			}
			if (bNeedHideBottomLayer && Singleton<ClientSystemManager>.GetInstance().BottomLayer != null)
			{
				Singleton<ClientSystemManager>.GetInstance().BottomLayer.CustomActive(true);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame2 = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame2 != null)
				{
					clientSystemTownFrame2.StartFizzyCheckAndResumeJoystickMove();
				}
			}
			if (data.onSceneLoadFinish != null)
			{
				data.onSceneLoadFinish();
			}
			this._isSwithScene = false;
			this.SetTownSceneSwitchState(false);
			if (data.targetSceneID == 5007)
			{
				DataManager<Pk3v3CrossDataManager>.GetInstance()._BindNetMsg();
				DataManager<Pk3v3DataManager>.GetInstance().UnBindNetMsg();
			}
			else
			{
				DataManager<Pk3v3DataManager>.GetInstance().BindNetMsg();
			}
			yield break;
		}

		// Token: 0x0600ACE7 RID: 44263 RVA: 0x0025594C File Offset: 0x00253D4C
		private void DealWithExtraShowFrame()
		{
			if (!DataManager<PlayerBaseData>.GetInstance().bPkClickVipCharge)
			{
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().bPkClickVipCharge = false;
			VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			if (vipFrame != null)
			{
				vipFrame.SwitchPage(VipTabType.PAY, true);
			}
		}

		// Token: 0x0600ACE8 RID: 44264 RVA: 0x0025599C File Offset: 0x00253D9C
		private void ShowDugeonEntryFrame(SceneParams data, int enterSceneId)
		{
			this._enterTownDoor = new DTownDoor
			{
				SceneID = data.currSceneID,
				DoorID = data.currDoorID,
				TargetSceneID = data.targetSceneID,
				TargetDoorID = data.targetDoorID
			};
			this._backTownDoor = new DTownDoor
			{
				SceneID = data.targetSceneID,
				DoorID = data.targetDoorID,
				TargetSceneID = data.currSceneID,
				TargetDoorID = data.currDoorID
			};
			ChapterSelectFrame.SetSceneID(enterSceneId);
			if (enterSceneId == 6031)
			{
				this.CurrentSceneID = data.currSceneID;
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildArenaFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonMapFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterSelectFrame>(FrameLayer.Middle, null, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EnterDungeon, null, null, null, null);
			}
		}

		// Token: 0x0600ACE9 RID: 44265 RVA: 0x00255A88 File Offset: 0x00253E88
		private void ShowPkPrePareFrame(CitySceneTable tableData)
		{
			switch (tableData.SceneSubType)
			{
			case CitySceneTable.eSceneSubType.TRADITION:
			{
				Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom = true;
				if (Singleton<NewbieGuideManager>.GetInstance().IsGuiding() && !Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.DuelGuide))
				{
					Singleton<NewbieGuideManager>.GetInstance().ManagerFinishGuide(Singleton<NewbieGuideManager>.GetInstance().mGuideControl.GuideTaskID);
				}
				PkWaitingRoomData userData = new PkWaitingRoomData
				{
					SceneSubType = tableData.SceneSubType,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkWaitingRoom>(FrameLayer.Bottom, userData, string.Empty);
				break;
			}
			case CitySceneTable.eSceneSubType.BUDO:
			{
				BudoArenaFrameData data = new BudoArenaFrameData
				{
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.BirthCity
				};
				BudoArenaFrame.Open(data);
				break;
			}
			case CitySceneTable.eSceneSubType.GuildBattle:
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleFrame>(FrameLayer.Bottom, null, string.Empty);
				break;
			case CitySceneTable.eSceneSubType.MoneyRewards:
			{
				MoneyRewardsMainFrameData argv = new MoneyRewardsMainFrameData
				{
					citySceneItem = tableData,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.BirthCity
				};
				MoneyRewardsMainFrame.CommandOpen(argv);
				break;
			}
			case CitySceneTable.eSceneSubType.Pk3v3:
			{
				PkWaitingRoomData userData2 = new PkWaitingRoomData
				{
					SceneSubType = tableData.SceneSubType,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.TraditionSceneID
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3WaitingRoom>(FrameLayer.Bottom, userData2, string.Empty);
				break;
			}
			case CitySceneTable.eSceneSubType.CrossGuildBattle:
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleFrame>(FrameLayer.Bottom, null, string.Empty);
				break;
			case CitySceneTable.eSceneSubType.CrossPk3v3:
			{
				PkWaitingRoomData userData3 = new PkWaitingRoomData
				{
					SceneSubType = tableData.SceneSubType,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossWaitingRoom>(FrameLayer.Bottom, userData3, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamMainFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossTeamMainFrame)).GetFrame().CustomActive(true);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamMainMenuFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossTeamMainMenuFrame)).GetFrame().CustomActive(true);
				if (DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossMyTeamFrame)).GetFrame().CustomActive(true);
				}
				break;
			}
			case CitySceneTable.eSceneSubType.FairDuelPrepare:
			{
				FairDueliRoomData userData4 = new FairDueliRoomData
				{
					SceneSubType = tableData.SceneSubType,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.TraditionSceneID
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelWaitingRoomFrame>(FrameLayer.Bottom, userData4, string.Empty);
				break;
			}
			case CitySceneTable.eSceneSubType.Melee2v2Cross:
			{
				PkWaitingRoomData userData5 = new PkWaitingRoomData
				{
					SceneSubType = tableData.SceneSubType,
					CurrentSceneID = tableData.ID,
					TargetTownSceneID = tableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk2v2CrossWaitingRoomFrame>(FrameLayer.Bottom, userData5, string.Empty);
				break;
			}
			}
		}

		// Token: 0x0600ACEA RID: 44266 RVA: 0x00255DD4 File Offset: 0x002541D4
		private void ShowTeamDuplicationFrame(CitySceneTable tableData)
		{
			CitySceneTable.eSceneSubType sceneSubType = tableData.SceneSubType;
			if (sceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationBuid)
			{
				if (sceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
				{
					TeamDuplicationUtility.OnOpenTeamDuplicationMainFightFrame();
				}
			}
			else
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationMainBuildFrame();
			}
		}

		// Token: 0x0600ACEB RID: 44267 RVA: 0x00255E16 File Offset: 0x00254216
		private ITownFadingFrame OpenTownFadingFrame(bool isUseLoadingFrame)
		{
			if (!isUseLoadingFrame)
			{
				return Singleton<ClientSystemManager>.GetInstance().OpenGlobalFrame<FadingFrame>(FrameLayer.Top, null) as ITownFadingFrame;
			}
			return Singleton<ClientSystemManager>.GetInstance().OpenGlobalFrame<TownLoadingFrame>(FrameLayer.Top, null) as ITownFadingFrame;
		}

		// Token: 0x0600ACEC RID: 44268 RVA: 0x00255E44 File Offset: 0x00254244
		private void ClearBaseMainFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<BudoArenaFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildBattleFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<MoneyRewardsMainFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3WaitingRoom>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildArenaFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationMainBuildFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationMainFightFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipMainFrame>(null, false);
		}

		// Token: 0x0600ACED RID: 44269 RVA: 0x00255EC0 File Offset: 0x002542C0
		protected void ClearScene(bool bNeedGC = true)
		{
			List<BeBaseActor> actors = BeBaseActor.Actors;
			while (actors.Count > 0)
			{
				actors[0].Dispose();
			}
			this._beTownNPCs.Clear();
			this._beTownPlayerMain = null;
			this._beTownDoors.Clear();
			this._beTownPlayers.Clear();
			this._beTownAttackCityMonsters.Clear();
			this._beDisplayPlayerList.Clear();
			this._beDisplayNum = 0;
			this._levelData = null;
			this.GridInfo = null;
			if (this._geScene != null)
			{
				this._geScene.UnloadScene(bNeedGC, false);
				this._geScene = null;
			}
			this._inputTimeElapsed = 0f;
			this.CurrentSceneID = -1;
			this._UnBindSceneNetMsgs();
			this._UnRegisterEvent();
			this._OnClearDelayCreateCache();
		}

		// Token: 0x0600ACEE RID: 44270 RVA: 0x00255F88 File Offset: 0x00254388
		protected void UpdateScene(float timeElapsed)
		{
			List<BeBaseActor> actors = BeBaseActor.Actors;
			for (int i = 0; i < actors.Count; i++)
			{
				BeBaseActor beBaseActor = actors[i];
				if (beBaseActor != null)
				{
					beBaseActor.Update(timeElapsed);
				}
			}
			if (this._geScene != null)
			{
				this._geScene.Update((int)(timeElapsed * (float)GlobalLogic.VALUE_1000));
			}
			if (this._beTownPlayerMain != null)
			{
				DataManager<PlayerBaseData>.GetInstance().Pos = this._beTownPlayerMain.ActorData.MoveData.ServerPosition;
				DataManager<PlayerBaseData>.GetInstance().FaceRight = this._beTownPlayerMain.ActorData.MoveData.FaceRight;
			}
		}

		// Token: 0x0600ACEF RID: 44271 RVA: 0x00256030 File Offset: 0x00254430
		protected void _InitializeCameraController()
		{
			if (this._beTownPlayerMain == null)
			{
				Logger.LogError("_InitializeCameraController ==> _beTownPlayerMain == null");
				return;
			}
			if (this._levelData == null)
			{
				Logger.LogError("_InitializeCameraController ==> _levelData == null");
				return;
			}
			this._geScene.GetCamera().GetController().AttachTo(this._beTownPlayerMain.GraphicActor, this._levelData.GetCameraLookHeight(), this._levelData.GetCameraAngle(), this._levelData.GetCameraDistance());
			this._geScene.initScrollScript();
		}

		// Token: 0x0600ACF0 RID: 44272 RVA: 0x002560B8 File Offset: 0x002544B8
		protected void _InitializeBGM(string path)
		{
			if (this.m_BgmHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.m_BgmHandle);
			}
			this.m_BgmHandle = MonoSingleton<AudioManager>.instance.PlaySound(path, AudioType.AudioStream, 1f, true, null, false, false, null, 1f);
		}

		// Token: 0x0600ACF1 RID: 44273 RVA: 0x00256102 File Offset: 0x00254502
		private void CreateSceneObjects()
		{
			this.CreateSceneNpcs();
			this.CreateMainPlayer();
			this.CreateSceneOtherPlayers();
			this.CreateSceneDoors();
			this.CreateAttackCityMonsters();
			this.CreatBlackMarketMerchant();
		}

		// Token: 0x0600ACF2 RID: 44274 RVA: 0x00256128 File Offset: 0x00254528
		private void CreateMainPlayer()
		{
			Vec3 vec = (!Global.Settings.townPlayerRun) ? Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townWalkSpeed) : Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townRunSpeed);
			PetInfo followPet = DataManager<PetDataManager>.GetInstance().GetFollowPet();
			BeTownPlayerData beTownPlayerData = new BeTownPlayerData
			{
				GUID = DataManager<PlayerBaseData>.GetInstance().RoleID,
				Name = DataManager<PlayerBaseData>.GetInstance().Name,
				JobID = DataManager<PlayerBaseData>.GetInstance().JobTableID,
				RoleLv = DataManager<PlayerBaseData>.GetInstance().Level,
				pkRank = DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				NameColor = PlayerInfoColor.TOWN_PLAYER,
				tittle = DataManager<PlayerBaseData>.GetInstance().iTittle,
				GuildPost = DataManager<PlayerBaseData>.GetInstance().guildDuty,
				GuildName = DataManager<PlayerBaseData>.GetInstance().guildName,
				petID = (int)((followPet == null) ? 0U : followPet.dataId),
				ZoneID = DataManager<PlayerBaseData>.GetInstance().ZoneID,
				AdventureTeamName = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamName(),
				WearedTitleInfo = DataManager<PlayerBaseData>.GetInstance().WearedTitleInfo,
				GuildEmblemLv = (int)DataManager<PlayerBaseData>.GetInstance().GuildEmblemLv
			};
			beTownPlayerData.MoveData.PosLogicToGraph = this._logicToGraph;
			beTownPlayerData.MoveData.PosServerToClient = this._serverToClient;
			beTownPlayerData.MoveData.ServerPosition = DataManager<PlayerBaseData>.GetInstance().Pos;
			beTownPlayerData.MoveData.FaceRight = DataManager<PlayerBaseData>.GetInstance().FaceRight;
			beTownPlayerData.MoveData.MoveSpeed = new Vector3(vec.x, vec.z, vec.y) * DataManager<PlayerBaseData>.GetInstance().MoveSpeedRate;
			this._beTownPlayerMain = new BeTownPlayerMain(beTownPlayerData, this);
			this._beTownPlayerMain.InitGeActor(this._geScene);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FunctionFrameUpdate, null, null, null, null);
			BeTownPlayerMain.OnMoveing.RemoveListener(new UnityAction<Vector3>(this._onMainPlayerMoveing));
			BeTownPlayerMain.OnMoveing.AddListener(new UnityAction<Vector3>(this._onMainPlayerMoveing));
			BeTownPlayerMain.OnAutoMoving.RemoveListener(new UnityAction<Vector3>(this._onMainPlayerAutoMoving));
			BeTownPlayerMain.OnAutoMoving.AddListener(new UnityAction<Vector3>(this._onMainPlayerAutoMoving));
			BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this._onMainPlayerAutoMoveFail));
			BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(this._onMainPlayerAutoMoveFail));
			BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this._onMainPlayerAutoMoveSucc));
			BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(this._onMainPlayerAutoMoveSucc));
		}

		// Token: 0x0600ACF3 RID: 44275 RVA: 0x002563C5 File Offset: 0x002547C5
		private void _SetMainPlayerShowFindPath(bool isShow)
		{
			if (this._beTownPlayerMain != null && this._beTownPlayerMain.GraphicActor != null)
			{
				this._beTownPlayerMain.GraphicActor.ShowFindPath(isShow);
			}
		}

		// Token: 0x0600ACF4 RID: 44276 RVA: 0x002563F3 File Offset: 0x002547F3
		private void _onMainPlayerAutoMoveSucc()
		{
			this._SetMainPlayerShowFindPath(false);
		}

		// Token: 0x0600ACF5 RID: 44277 RVA: 0x002563FC File Offset: 0x002547FC
		private void _onMainPlayerAutoMoveFail()
		{
			this._SetMainPlayerShowFindPath(false);
		}

		// Token: 0x0600ACF6 RID: 44278 RVA: 0x00256405 File Offset: 0x00254805
		private void _onMainPlayerAutoMoving(Vector3 pos)
		{
			this._SetMainPlayerShowFindPath(true);
		}

		// Token: 0x0600ACF7 RID: 44279 RVA: 0x0025640E File Offset: 0x0025480E
		private void _onMainPlayerMoveing(Vector3 pos)
		{
			this._SetMainPlayerShowFindPath(false);
		}

		// Token: 0x0600ACF8 RID: 44280 RVA: 0x00256417 File Offset: 0x00254817
		private void TriggerMainPlayerAutoMoveEvent()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<DevelopGuidanceMainFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<DevelopGuidanceMainFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MissionFrameNew>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MissionFrameNew>(null, false);
			}
		}

		// Token: 0x0600ACF9 RID: 44281 RVA: 0x00256451 File Offset: 0x00254851
		private void DestroyMainPlayer()
		{
			if (this._beTownPlayerMain != null)
			{
				this._beTownPlayerMain.Dispose();
				this._beTownPlayerMain = null;
			}
		}

		// Token: 0x0600ACFA RID: 44282 RVA: 0x00256470 File Offset: 0x00254870
		private void CreateSceneNpcs()
		{
			for (int i = 0; i < this._levelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this._levelData.GetNpcInfo(i);
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcInfo.GetEntityInfo().GetResid(), string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("[npc]data.NpcID = {0} is not existed! to 国庆!", new object[]
					{
						npcInfo.GetEntityInfo().GetResid()
					});
				}
				else if (tableItem.Function != NpcTable.eFunction.guildDungeonActivityChest || DataManager<GuildDataManager>.GetInstance().IsShowChestModel())
				{
					BeTownNPCData data = new BeTownNPCData
					{
						NpcID = npcInfo.GetEntityInfo().GetResid(),
						ResourceID = 0,
						Name = tableItem.NpcName,
						NameColor = PlayerInfoColor.TOWN_NPC
					};
					bool flag = false;
					int num = 0;
					if (tableItem.Function == NpcTable.eFunction.Townstatue || tableItem.Function == NpcTable.eFunction.guildGuardStatue)
					{
						List<FigureStatueInfo> list = new List<FigureStatueInfo>();
						if (tableItem.Function == NpcTable.eFunction.Townstatue)
						{
							list = DataManager<GuildDataManager>.GetInstance().GetTownStatueInfo();
						}
						else if (tableItem.Function == NpcTable.eFunction.guildGuardStatue)
						{
							list = DataManager<GuildDataManager>.GetInstance().GetGuildGuardStatueInfo();
						}
						bool flag2 = false;
						for (int j = 0; j < list.Count; j++)
						{
							FigureStatueInfo figureStatueInfo = list[j];
							if (figureStatueInfo.statueType == (byte)tableItem.SubType)
							{
								JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)figureStatueInfo.occu, string.Empty, string.Empty);
								if (tableItem2 == null)
								{
									Logger.LogErrorFormat("can not find JobTable with TownStatue NPC occu ID:{0} when InitTown", new object[]
									{
										figureStatueInfo.occu
									});
								}
								else
								{
									ResTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem2.Mode, string.Empty, string.Empty);
									if (tableItem3 != null)
									{
										data.ResourceID = tableItem3.ID;
										data.JobID = (int)figureStatueInfo.occu;
										data.avatorInfo = figureStatueInfo.avatar;
										data.StatueName = figureStatueInfo.name;
										flag = true;
										num = tableItem2.TownStatueFace;
										flag2 = true;
										break;
									}
									Logger.LogErrorFormat("can not find ResTable with TownStatue NPC mod id:{0} when InitTown", new object[]
									{
										tableItem2.Mode
									});
								}
							}
						}
						if (!flag2)
						{
							data.ResourceID = tableItem.ResID;
						}
					}
					else
					{
						data.ResourceID = tableItem.ResID;
					}
					data.MoveData.PosLogicToGraph = this._logicToGraph;
					data.MoveData.PosServerToClient = this._serverToClient;
					data.MoveData.Position = npcInfo.GetEntityInfo().GetPosition();
					BeTownNPC beTownNpc = new BeTownNPC(data, this);
					beTownNpc.InitGeActor(this._geScene);
					if (beTownNpc.GraphicActor != null)
					{
						beTownNpc.GraphicActor.SetScale(npcInfo.GetEntityInfo().GetScale());
						if (flag)
						{
							Quaternion rotation = Quaternion.Euler(0f, (float)num, 0f);
							beTownNpc.GraphicActor.SetRotation(rotation);
						}
					}
					beTownNpc.AddActorPostLoadCommand(delegate
					{
						this.OnNPCLoadFinished(data.NpcID, beTownNpc.GraphicActor);
					});
					this._beTownNPCs.Add(beTownNpc);
				}
			}
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_ANNIBERPARTY);
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (activeDataFromType != null)
			{
				uint startTime = activeDataFromType.startTime;
				uint endTime = activeDataFromType.endTime;
				if (serverTime < startTime || serverTime > endTime)
				{
					this.DisposeNPC(NpcTable.eFunction.AnniersaryParty);
				}
			}
			else
			{
				this.DisposeNPC(NpcTable.eFunction.AnniersaryParty);
			}
		}

		// Token: 0x0600ACFB RID: 44283 RVA: 0x00256870 File Offset: 0x00254C70
		private void CreateNPC(NpcTable.eFunction function)
		{
			for (int i = 0; i < this._levelData.GetNpcInfoLength(); i++)
			{
				ISceneNPCInfoData npcInfo = this._levelData.GetNpcInfo(i);
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcInfo.GetEntityInfo().GetResid(), string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.Function == function)
					{
						BeTownNPCData data = new BeTownNPCData
						{
							NpcID = npcInfo.GetEntityInfo().GetResid(),
							ResourceID = 0,
							Name = tableItem.NpcName,
							NameColor = PlayerInfoColor.TOWN_NPC
						};
						bool flag = false;
						int num = 0;
						data.ResourceID = tableItem.ResID;
						data.MoveData.PosLogicToGraph = this._logicToGraph;
						data.MoveData.PosServerToClient = this._serverToClient;
						data.MoveData.Position = npcInfo.GetEntityInfo().GetPosition();
						BeTownNPC beTownNpc = new BeTownNPC(data, this);
						beTownNpc.InitGeActor(this._geScene);
						if (beTownNpc.GraphicActor != null)
						{
							beTownNpc.GraphicActor.SetScale(npcInfo.GetEntityInfo().GetScale());
							if (flag)
							{
								Quaternion rotation = Quaternion.Euler(0f, (float)num, 0f);
								beTownNpc.GraphicActor.SetRotation(rotation);
							}
						}
						beTownNpc.AddActorPostLoadCommand(delegate
						{
							this.OnNPCLoadFinished(data.NpcID, beTownNpc.GraphicActor);
						});
						if (!this._beTownNPCs.Contains(beTownNpc))
						{
							this._beTownNPCs.Add(beTownNpc);
						}
					}
				}
			}
		}

		// Token: 0x0600ACFC RID: 44284 RVA: 0x00256A44 File Offset: 0x00254E44
		private void DisposeNPC(NpcTable.eFunction eFunction)
		{
			BeTownNPC beTownNPC = null;
			for (int i = 0; i < this._beTownNPCs.Count; i++)
			{
				BeTownNPCData beTownNPCData = this._beTownNPCs[i].ActorData as BeTownNPCData;
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(beTownNPCData.NpcID, string.Empty, string.Empty);
				if (tableItem.Function == eFunction)
				{
					beTownNPC = this._beTownNPCs[i];
					break;
				}
			}
			if (beTownNPC != null && this._beTownNPCs.Contains(beTownNPC))
			{
				this._beTownNPCs.Remove(beTownNPC);
				beTownNPC.Dispose();
			}
		}

		// Token: 0x0600ACFD RID: 44285 RVA: 0x00256AEC File Offset: 0x00254EEC
		private void CreateSceneOtherPlayers()
		{
			if (this.PlayerOthersData == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, SceneObject> keyValuePair in this.PlayerOthersData)
			{
				SceneObject value = keyValuePair.Value;
				BeTownPlayer beTownPlayer = this._CreateTownPlayer(value, this.CurrentSceneID);
				if (beTownPlayer != null)
				{
					this._beTownPlayers.Add(beTownPlayer.ActorData.GUID, beTownPlayer);
					this._AddDisplayActor(beTownPlayer.ActorData.GUID);
					beTownPlayer.Init3v3RoomPlayerJiaoDiGuangQuan();
				}
			}
		}

		// Token: 0x0600ACFE RID: 44286 RVA: 0x00256B74 File Offset: 0x00254F74
		private void CreateSceneDoors()
		{
			for (int i = 0; i < this._levelData.GetTownDoorLength(); i++)
			{
				ISceneTownDoorData townDoor = this._levelData.GetTownDoor(i);
				BeTownDoor beTownDoor = new BeTownDoor(new BeTownDoorData
				{
					MoveData = 
					{
						Position = townDoor.GetRegionInfo().GetEntityInfo().GetPosition()
					},
					Door = townDoor
				}, this);
				beTownDoor.InitGeActor(this._geScene);
				beTownDoor.OnTrigger.AddListener(delegate(ISceneTownDoorData doorData)
				{
					if (doorData.GetDoorTargetType() == DoorTargetType.Normal)
					{
						SceneParams data = new SceneParams(doorData.GetSceneID(), doorData.GetDoorID(), doorData.GetTargetSceneID(), doorData.GetTargetDoorID())
						{
							type = eSceneChangeType.eDungeonChapterSelect,
							birthPostion = doorData.GetBirthPos()
						};
						GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
						bool flag = true;
						if (doorData != null && doorData.GetTargetSceneID() == 6031)
						{
							if (!GuildDataManager.CheckActivityLimit())
							{
								flag = false;
							}
							else if (guildDungeonActivityData != null && guildDungeonActivityData.nActivityState != 2U)
							{
								flag = false;
							}
						}
						if (flag)
						{
							MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NetSyncChangeScene(data, false));
						}
					}
					else if (doorData.GetDoorTargetType() == DoorTargetType.PVEPracticeCourt)
					{
						if (DataManager<TeamDataManager>.GetInstance().HasTeam())
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_cannot_enter_pve_training"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						}
						else
						{
							BattleMain.OpenBattle(BattleType.TrainingPVE, eDungeonMode.LocalFrame, 0, "1000");
							Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
						}
					}
				});
				this._beTownDoors.Add(beTownDoor);
			}
		}

		// Token: 0x0600ACFF RID: 44287 RVA: 0x00256C0C File Offset: 0x0025500C
		protected BeTownPlayer _CreateTownPlayer(SceneObject sceneObj, int a_nSceneID)
		{
			BeTownPlayer result = null;
			try
			{
				if ((ulong)sceneObj.sceneId != (ulong)((long)a_nSceneID))
				{
					return null;
				}
				if (sceneObj.dir == null)
				{
					return null;
				}
				if (sceneObj.pos == null)
				{
					return null;
				}
				BeTownPlayerData beTownPlayerData = new BeTownPlayerData
				{
					GUID = sceneObj.id,
					Name = sceneObj.name,
					NameColor = PlayerInfoColor.TOWN_OTHER_PLAYER,
					JobID = (int)sceneObj.occu,
					RoleLv = sceneObj.level,
					pkRank = (int)sceneObj.seasonLevel,
					pkStar = (int)sceneObj.seasonStar,
					tittle = sceneObj.title,
					State = (int)sceneObj.state,
					petID = (int)sceneObj.followPetDataId,
					avatorInfo = sceneObj.avatar,
					GuildName = sceneObj.guildName,
					GuildPost = sceneObj.guildPost,
					ZoneID = (int)sceneObj.zoneId,
					AdventureTeamName = sceneObj.adventureTeamName,
					WearedTitleInfo = sceneObj.wearedTitleInfo,
					GuildEmblemLv = (int)sceneObj.guildEmblemLvl
				};
				if (sceneObj.vip != null)
				{
					beTownPlayerData.vip = (int)sceneObj.vip.level;
				}
				beTownPlayerData.MoveData.PosLogicToGraph = this._logicToGraph;
				beTownPlayerData.MoveData.PosServerToClient = this._serverToClient;
				beTownPlayerData.MoveData.ServerPosition = new Vector3(sceneObj.pos.x / this._axisScale, 0f, sceneObj.pos.y / this._axisScale);
				beTownPlayerData.MoveData.FaceRight = (sceneObj.dir.faceRight >= 1);
				Vec3 vec = (!Global.Settings.townPlayerRun) ? Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townWalkSpeed) : Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townRunSpeed);
				beTownPlayerData.MoveData.MoveSpeed = new Vector3(vec.x, vec.z, vec.y) * ((float)sceneObj.moveSpeed / (float)GlobalLogic.VALUE_1000);
				beTownPlayerData.MoveData.TargetDirection = new Vector3((float)sceneObj.dir.x / this._axisScale, 0f, (float)sceneObj.dir.y / this._axisScale);
				result = new BeTownPlayer(beTownPlayerData, this);
			}
			catch (Exception ex)
			{
				Logger.LogError("TownPlayer Create Error!");
			}
			return result;
		}

		// Token: 0x0600AD00 RID: 44288 RVA: 0x00256EA8 File Offset: 0x002552A8
		public BeTownNPC GetTownNpcByNpcId(int iNpcId)
		{
			for (int i = 0; i < this._beTownNPCs.Count; i++)
			{
				if (this._beTownNPCs[i] != null)
				{
					BeTownNPCData beTownNPCData = this._beTownNPCs[i].ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						if (beTownNPCData.NpcID == iNpcId)
						{
							return this._beTownNPCs[i];
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600AD01 RID: 44289 RVA: 0x00256F24 File Offset: 0x00255324
		public void AddVoiceListenerForAllNpc()
		{
			for (int i = 0; i < this._beTownNPCs.Count; i++)
			{
				if (this._beTownNPCs[i] != null && this._beTownNPCs[i].GraphicActor != null)
				{
					if (this._beTownNPCs[i].ActorData is BeTownNPCData)
					{
						if (this._beTownNPCs[i].GraphicActor != null)
						{
							this._beTownNPCs[i].GraphicActor.AddVoiceListener(NpcVoiceComponent.SoundEffectType.SET_Random);
						}
					}
				}
			}
		}

		// Token: 0x0600AD02 RID: 44290 RVA: 0x00256FC4 File Offset: 0x002553C4
		public void PlayNpcSound(int iNpcID, NpcVoiceComponent.SoundEffectType eSoundEffect)
		{
			for (int i = 0; i < this._beTownNPCs.Count; i++)
			{
				if (this._beTownNPCs[i] != null && this._beTownNPCs[i].GraphicActor != null)
				{
					BeTownNPCData beTownNPCData = this._beTownNPCs[i].ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						if (beTownNPCData.NpcID == iNpcID)
						{
							GameObject entityNode = this._beTownNPCs[i].GraphicActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
							if (!(entityNode == null))
							{
								Transform transform = entityNode.transform.Find("VoiceParent");
								if (!(transform == null))
								{
									NpcVoiceComponent component = transform.GetComponent<NpcVoiceComponent>();
									if (component != null)
									{
										component.PlaySound(eSoundEffect);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AD03 RID: 44291 RVA: 0x002570B0 File Offset: 0x002554B0
		public void AddDialogListenerForAllNpc()
		{
			for (int i = 0; i < this._beTownNPCs.Count; i++)
			{
				if (this._beTownNPCs[i] != null && this._beTownNPCs[i].GraphicActor != null)
				{
					BeTownNPCData beTownNPCData = this._beTownNPCs[i].ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						this.AddDialogListener(beTownNPCData.NpcID);
					}
				}
			}
		}

		// Token: 0x0600AD04 RID: 44292 RVA: 0x0025712E File Offset: 0x0025552E
		public void AddDialogListener(int iNpcID)
		{
		}

		// Token: 0x0600AD05 RID: 44293 RVA: 0x00257130 File Offset: 0x00255530
		public void AddMissionListenerForNpc(int iNpcID, int iTaskID)
		{
		}

		// Token: 0x0600AD06 RID: 44294 RVA: 0x00257134 File Offset: 0x00255534
		public void AddFunctionListenerForAllNpc()
		{
			for (int i = 0; i < this._beTownNPCs.Count; i++)
			{
				if (this._beTownNPCs[i] != null && this._beTownNPCs[i].GraphicActor != null)
				{
					BeTownNPCData beTownNPCData = this._beTownNPCs[i].ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(beTownNPCData.NpcID, string.Empty, string.Empty);
						if (tableItem != null && tableItem.Function != NpcTable.eFunction.none && tableItem.Function < NpcTable.eFunction.clicknpc)
						{
							GameObject entityNode = this._beTownNPCs[i].GraphicActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
							if (!(entityNode == null))
							{
								Transform transform = entityNode.transform.Find("PlayerInfo_Head");
								if (!(null == transform))
								{
									NpcInteraction component = transform.gameObject.GetComponent<NpcInteraction>();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AD07 RID: 44295 RVA: 0x0025723C File Offset: 0x0025563C
		public void OnNotifyTownPlayerLvChanged(uint iPlayerID, int iLevel)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnLevelChanged(iLevel);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.OnLevelChanged((int)DataManager<PlayerBaseData>.GetInstance().Level);
			}
		}

		// Token: 0x0600AD08 RID: 44296 RVA: 0x002572DC File Offset: 0x002556DC
		public void OnNotifyTownPlayerTittleChanged(uint iPlayerID, int iTittle)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnTittleChanged(iTittle);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.OnTittleChanged(iTittle);
			}
		}

		// Token: 0x0600AD09 RID: 44297 RVA: 0x00257374 File Offset: 0x00255774
		public void OnNotifyTownPlayerGuildNameChanged(uint iPlayerID, string name)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnGuildNameChanged(name);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.OnGuildNameChanged(name);
			}
		}

		// Token: 0x0600AD0A RID: 44298 RVA: 0x0025740C File Offset: 0x0025580C
		public void OnNotifyTownPlayerAdventTeamNameChanged(uint iPlayerID, string name)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateAdventTeamName(name);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.UpdateAdventTeamName(name);
			}
		}

		// Token: 0x0600AD0B RID: 44299 RVA: 0x002574A4 File Offset: 0x002558A4
		public void OnNotifyTownPlayerTitleNameChanged(uint iPlayerID, PlayerWearedTitleInfo playerWearedTitleInfoe)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateTitleName(playerWearedTitleInfoe);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.UpdateTitleName(playerWearedTitleInfoe);
			}
		}

		// Token: 0x0600AD0C RID: 44300 RVA: 0x0025753C File Offset: 0x0025593C
		public void OnNotifyTownPlayerNameChanged(uint iPlayerID, string name)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateName(name);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.UpdateName(name);
			}
		}

		// Token: 0x0600AD0D RID: 44301 RVA: 0x002575D4 File Offset: 0x002559D4
		public void OnNotifyTownPlayerGuildLvChanged(uint iPlayerID, uint guildEmblemLv)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.UpdateGuidLv((int)guildEmblemLv);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.UpdateGuidLv((int)guildEmblemLv);
			}
		}

		// Token: 0x0600AD0E RID: 44302 RVA: 0x0025766C File Offset: 0x00255A6C
		public void OnNotifyTownPlayerGuildDutyChanged(uint iPlayerID, byte duty)
		{
			if (this.MainPlayer != null)
			{
				BeTownPlayerData beTownPlayerData = this.MainPlayer.ActorData as BeTownPlayerData;
				if (beTownPlayerData != null && (beTownPlayerData.GUID == (ulong)iPlayerID || iPlayerID == 0U))
				{
					if (this.MainPlayer.GraphicActor != null)
					{
						this.MainPlayer.GraphicActor.OnGuildPostChanged(duty);
					}
					return;
				}
			}
			BeTownPlayer beTownPlayer = null;
			if (this._beTownPlayers.TryGetValue((ulong)iPlayerID, out beTownPlayer) && beTownPlayer != null && beTownPlayer.GraphicActor != null)
			{
				beTownPlayer.GraphicActor.OnGuildPostChanged(duty);
			}
		}

		// Token: 0x0600AD0F RID: 44303 RVA: 0x00257704 File Offset: 0x00255B04
		private void _RegisterEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MoveSpeedChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerMainSpeedChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3ChangePosition, new ClientEventSystem.UIEventHandler(this._OnPk3v3ChangePosition));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SyncAttackCityMonsterDel, new ClientEventSystem.UIEventHandler(this.OnDeleteAttackCityMonsterByUiEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SyncAttackCityMonsterAdd, new ClientEventSystem.UIEventHandler(this.OnAddAttackCityMonsterByUiEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SyncAttackCityMonsterList, new ClientEventSystem.UIEventHandler(this.OnResetAttackCityMonsterByUiEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SyncBlackMarketMerchantNPCType, new ClientEventSystem.UIEventHandler(this.OnSyncBlackMarketMerchantNPCType));
			NetProcess.AddMsgHandler(501149U, new Action<MsgDATA>(this._OnSyncActivityStateChange));
		}

		// Token: 0x0600AD10 RID: 44304 RVA: 0x002577C8 File Offset: 0x00255BC8
		private void _UnRegisterEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MoveSpeedChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerMainSpeedChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3ChangePosition, new ClientEventSystem.UIEventHandler(this._OnPk3v3ChangePosition));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SyncAttackCityMonsterDel, new ClientEventSystem.UIEventHandler(this.OnDeleteAttackCityMonsterByUiEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SyncAttackCityMonsterAdd, new ClientEventSystem.UIEventHandler(this.OnAddAttackCityMonsterByUiEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SyncAttackCityMonsterList, new ClientEventSystem.UIEventHandler(this.OnResetAttackCityMonsterByUiEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SyncBlackMarketMerchantNPCType, new ClientEventSystem.UIEventHandler(this.OnSyncBlackMarketMerchantNPCType));
			NetProcess.RemoveMsgHandler(501149U, new Action<MsgDATA>(this._OnSyncActivityStateChange));
		}

		// Token: 0x0600AD11 RID: 44305 RVA: 0x0025788C File Offset: 0x00255C8C
		private void _OnSyncActivityStateChange(MsgDATA data)
		{
			SyncOpActivityStateChange syncOpActivityStateChange = new SyncOpActivityStateChange();
			syncOpActivityStateChange.decode(data.bytes);
			OpActivityData data2 = syncOpActivityStateChange.data;
			if (data2 == null)
			{
				return;
			}
			if (data2.tmpType == 6200U)
			{
				OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_ANNIBERPARTY);
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				if (activeDataFromType != null)
				{
					uint startTime = activeDataFromType.startTime;
					uint endTime = activeDataFromType.endTime;
					if (serverTime < startTime || serverTime > endTime)
					{
						this.DisposeNPC(NpcTable.eFunction.AnniersaryParty);
					}
					else
					{
						this.CreateNPC(NpcTable.eFunction.AnniersaryParty);
					}
				}
				else
				{
					this.DisposeNPC(NpcTable.eFunction.AnniersaryParty);
				}
			}
		}

		// Token: 0x0600AD12 RID: 44306 RVA: 0x00257938 File Offset: 0x00255D38
		private void _OnPlayerMainSpeedChanged(UIEvent a_event)
		{
			if (this.MainPlayer != null)
			{
				Vec3 vec = (!Global.Settings.townPlayerRun) ? Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townWalkSpeed) : Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.townRunSpeed);
				this.MainPlayer.ActorData.MoveData.MoveSpeed = new Vector3(vec.x, vec.z, vec.y) * DataManager<PlayerBaseData>.GetInstance().MoveSpeedRate;
			}
		}

		// Token: 0x0600AD13 RID: 44307 RVA: 0x002579CC File Offset: 0x00255DCC
		private void _OnPk3v3ChangePosition(UIEvent a_event)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3)
			{
				return;
			}
			ulong num = (ulong)a_event.Param1;
			byte group = (byte)a_event.Param2;
			if (num == this._beTownPlayerMain.ActorData.GUID)
			{
				this._beTownPlayerMain.Update3v3RoomPlayerJiaoDiGuangQuan(group);
			}
			else
			{
				foreach (KeyValuePair<ulong, BeTownPlayer> keyValuePair in this._beTownPlayers)
				{
					BeTownPlayer value = keyValuePair.Value;
					if (value != null)
					{
						if (value.ActorData.GUID == num)
						{
							value.Update3v3RoomPlayerJiaoDiGuangQuan(group);
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600AD14 RID: 44308 RVA: 0x00257AC0 File Offset: 0x00255EC0
		protected void _BindSceneNetMsgs()
		{
			this.OnUnBindExtraSceneNetMessages();
			if (this.IsNet)
			{
				this._UnBindSceneNetMsgs();
				this._mapBindMsgHandle.Add(500603U, new Action<MsgDATA>(this._OnSyncPlayerOthers));
				this._mapBindMsgHandle.Add(500602U, new Action<MsgDATA>(this._OnSyncAddPlayerOthers));
				this._mapBindMsgHandle.Add(500604U, new Action<MsgDATA>(this._OnSyncRemovePlayerOthers));
				this._mapBindMsgHandle.Add(500502U, new Action<MsgDATA>(this._OnSyncMovePlayerOthers));
				Dictionary<uint, Action<MsgDATA>>.KeyCollection keys = this._mapBindMsgHandle.Keys;
				foreach (object obj in keys)
				{
					uint num = (uint)obj;
					NetProcess.AddMsgHandler(num, this._mapBindMsgHandle[num]);
				}
			}
		}

		// Token: 0x0600AD15 RID: 44309 RVA: 0x00257B9C File Offset: 0x00255F9C
		protected void _UnBindSceneNetMsgs()
		{
			if (this.IsNet)
			{
				Dictionary<uint, Action<MsgDATA>>.KeyCollection keys = this._mapBindMsgHandle.Keys;
				foreach (object obj in keys)
				{
					uint num = (uint)obj;
					NetProcess.RemoveMsgHandler(num, this._mapBindMsgHandle[num]);
				}
				this._mapBindMsgHandle.Clear();
			}
		}

		// Token: 0x0600AD16 RID: 44310 RVA: 0x00257C08 File Offset: 0x00256008
		protected void _OnSyncPlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncPlayerOthers ==>> msg is nil");
				return;
			}
			int num = 0;
			ulong num2 = 0UL;
			BaseDLL.decode_uint64(msg.bytes, ref num, ref num2);
			SceneObject sceneObject = null;
			if (!this.PlayerOthersData.TryGetValue(num2, out sceneObject))
			{
				return;
			}
			if (sceneObject == null)
			{
				return;
			}
			StreamObjectDecoder<SceneObject>.DecodePropertys(ref sceneObject, msg.bytes, ref num, msg.bytes.Length);
			if (this._beTownPlayers.ContainsKey(num2))
			{
				BeTownPlayer beTownPlayer = this._beTownPlayers[num2];
				for (int i = 0; i < sceneObject.dirtyFields.Count; i++)
				{
					SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)sceneObject.dirtyFields[i];
					if (sceneObjectAttr == SceneObjectAttr.SOA_LEVEL)
					{
						this._beTownPlayers[num2].SetPlayerRoleLv(sceneObject.level);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_LEVEL)
					{
						this._beTownPlayers[num2].SetPlayerPKRank((int)sceneObject.seasonLevel, (int)sceneObject.seasonStar);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_SEASON_STAR)
					{
						this._beTownPlayers[num2].SetPlayerPKRank((int)sceneObject.seasonLevel, (int)sceneObject.seasonStar);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_TITLE)
					{
						this._beTownPlayers[num2].SetPlayerTittle(sceneObject.title);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_NAME)
					{
						this._beTownPlayers[num2].SetPlayerGuildName(sceneObject.guildName);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_POST)
					{
						this._beTownPlayers[num2].SetPlayerGuildDuty(sceneObject.guildPost);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_PET_FOLLOW)
					{
						this._beTownPlayers[num2].CreatePet((int)sceneObject.followPetDataId);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_NAME)
					{
						this._beTownPlayers[num2].SetPlayerName(sceneObject.name);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_ZONEID)
					{
						this._beTownPlayers[num2].SetPlayerZoneID((int)sceneObject.zoneId);
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_ADVENTURE_TEAM_NAME)
					{
						if (beTownPlayer != null)
						{
							beTownPlayer.SetAdventureTeamName(sceneObject.adventureTeamName);
						}
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_NEW_TITLE_NAME)
					{
						if (beTownPlayer != null)
						{
							beTownPlayer.SetTitleName(sceneObject.wearedTitleInfo);
						}
					}
					else if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_EMBLEM && beTownPlayer != null)
					{
						beTownPlayer.SetGuildEmblemLv((int)sceneObject.guildEmblemLvl);
					}
				}
			}
			else
			{
				BeTownPlayer beTownPlayer = this._CreateTownPlayer(this.PlayerOthersData[num2], this.CurrentSceneID);
				if (beTownPlayer != null)
				{
					this._beTownPlayers.Add(num2, beTownPlayer);
					beTownPlayer.Init3v3RoomPlayerJiaoDiGuangQuan();
				}
				this._AddDisplayActor(num2);
			}
		}

		// Token: 0x0600AD17 RID: 44311 RVA: 0x00257EBC File Offset: 0x002562BC
		protected void _CreateTownPlayer(SceneObject sceneObj)
		{
			if (sceneObj == null)
			{
				return;
			}
			BeTownPlayer beTownPlayer = this._CreateTownPlayer(sceneObj, this.CurrentSceneID);
			if (beTownPlayer != null)
			{
				ulong id = sceneObj.id;
				if (this.PlayerOthersData.ContainsKey(id))
				{
					this.PlayerOthersData[id] = sceneObj;
					if (this._beTownPlayers.ContainsKey(id))
					{
						this._beTownPlayers[id].Dispose();
						this._beTownPlayers[id] = beTownPlayer;
					}
					if (this._beDisplayPlayerList.Contains(beTownPlayer.ActorData.GUID))
					{
						beTownPlayer.InitGeActor(this._geScene);
						beTownPlayer.Init3v3RoomPlayerJiaoDiGuangQuan();
					}
					else
					{
						beTownPlayer.RemoveGeActor();
					}
				}
				else
				{
					this.PlayerOthersData.Add(id, sceneObj);
					if (!this._beTownPlayers.ContainsKey(id))
					{
						this._beTownPlayers.Add(id, beTownPlayer);
						beTownPlayer.Init3v3RoomPlayerJiaoDiGuangQuan();
					}
					this._AddDisplayActor(id);
				}
			}
		}

		// Token: 0x0600AD18 RID: 44312 RVA: 0x00257FAD File Offset: 0x002563AD
		protected void _OnAddDelayCreateCache(SceneObject obj)
		{
			this.mObjQueue.Add(obj);
		}

		// Token: 0x0600AD19 RID: 44313 RVA: 0x00257FBC File Offset: 0x002563BC
		protected void _OnUpdateDelayCreateCache()
		{
			if (this.mObjQueue.Count > 0)
			{
				SceneObject sceneObj = this.mObjQueue[0];
				this.mObjQueue.RemoveAt(0);
				this._CreateTownPlayer(sceneObj);
			}
		}

		// Token: 0x0600AD1A RID: 44314 RVA: 0x00257FFC File Offset: 0x002563FC
		protected void _OnRemoveDelayCreateCache(ulong objID)
		{
			this.mObjQueue.RemoveAll((SceneObject item) => item.id == objID);
		}

		// Token: 0x0600AD1B RID: 44315 RVA: 0x0025802E File Offset: 0x0025642E
		protected void _OnClearDelayCreateCache()
		{
			this.mObjQueue.Clear();
		}

		// Token: 0x0600AD1C RID: 44316 RVA: 0x0025803C File Offset: 0x0025643C
		protected void _OnSyncAddPlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncAddPlayerOthers ==>> msg is nil");
				return;
			}
			int num = 0;
			Dictionary<ulong, SceneObject> dictionary = SceneObjectDecoder.DecodeSyncSceneObjectMsg(msg.bytes, ref num, msg.bytes.Length);
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, SceneObject> keyValuePair in dictionary)
			{
				ulong key = keyValuePair.Key;
				if (DataManager<PlayerBaseData>.GetInstance().RoleID == key)
				{
					Logger.LogErrorFormat("出现这个提示，请通知小月月！！", new object[0]);
				}
				else
				{
					Dictionary<ulong, SceneObject>.Enumerator enumerator;
					KeyValuePair<ulong, SceneObject> keyValuePair2 = enumerator.Current;
					this._OnAddDelayCreateCache(keyValuePair2.Value);
				}
			}
		}

		// Token: 0x0600AD1D RID: 44317 RVA: 0x002580E0 File Offset: 0x002564E0
		protected void _OnSyncRemovePlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncRemovePlayerOthers ==>> msg is nil");
				return;
			}
			int num = 0;
			while (msg.bytes.Length - num > 8)
			{
				ulong num2 = 0UL;
				BaseDLL.decode_uint64(msg.bytes, ref num, ref num2);
				this.PlayerOthersData.Remove(num2);
				BeTownPlayer beTownPlayer;
				this._beTownPlayers.TryGetValue(num2, out beTownPlayer);
				if (beTownPlayer != null)
				{
					this._RemoveDisplayActor(num2);
					beTownPlayer.Dispose();
					this._beTownPlayers.Remove(num2);
				}
				if (this._beDisplayPlayerList.Count < this._beDisplayNum && this._beDisplayPlayerList.Count < this._beTownPlayers.Count)
				{
					foreach (KeyValuePair<ulong, BeTownPlayer> keyValuePair in this._beTownPlayers)
					{
						BeTownPlayer value = keyValuePair.Value;
						if (value != null)
						{
							this._AddDisplayActor(num2);
						}
						if (this._beDisplayPlayerList.Count == this._beDisplayNum)
						{
							break;
						}
					}
				}
				this._OnRemoveDelayCreateCache(num2);
			}
		}

		// Token: 0x0600AD1E RID: 44318 RVA: 0x002581F4 File Offset: 0x002565F4
		protected void _OnSyncMovePlayerOthers(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncMovePlayers ==>> msg is nil");
				return;
			}
			SceneSyncPlayerMove sceneSyncPlayerMove = new SceneSyncPlayerMove();
			sceneSyncPlayerMove.decode(msg.bytes);
			if (sceneSyncPlayerMove.dir.x != 0 || sceneSyncPlayerMove.dir.y != 0 || sceneSyncPlayerMove.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
			}
			if (this._beTownPlayers.ContainsKey(sceneSyncPlayerMove.id))
			{
				BeTownPlayer beTownPlayer = this._beTownPlayers[sceneSyncPlayerMove.id];
				beTownPlayer.AddMoveCommand(new Vector3(sceneSyncPlayerMove.pos.x / this._axisScale, 0f, sceneSyncPlayerMove.pos.y / this._axisScale) + beTownPlayer.ActorData.MoveData.PosServerToClient, new Vector3((float)sceneSyncPlayerMove.dir.x / this._axisScale, 0f, (float)sceneSyncPlayerMove.dir.y / this._axisScale), sceneSyncPlayerMove.dir.faceRight >= 1);
			}
		}

		// Token: 0x0600AD1F RID: 44319 RVA: 0x00258314 File Offset: 0x00256714
		private void _InitOtherPlayerData(MsgDATA a_msg, uint a_sceneID)
		{
			this.PlayerOthersData.Clear();
			if (a_msg != null)
			{
				int num = 0;
				Dictionary<ulong, SceneObject> dictionary = SceneObjectDecoder.DecodeSyncSceneObjectMsg(a_msg.bytes, ref num, a_msg.bytes.Length);
				if (dictionary != null)
				{
					foreach (KeyValuePair<ulong, SceneObject> keyValuePair in dictionary)
					{
						ulong key = keyValuePair.Key;
						Dictionary<ulong, SceneObject>.Enumerator enumerator;
						KeyValuePair<ulong, SceneObject> keyValuePair2 = enumerator.Current;
						if (keyValuePair2.Value.sceneId == a_sceneID)
						{
							if (this.PlayerOthersData.ContainsKey(key))
							{
								Dictionary<ulong, SceneObject> playerOthersData = this.PlayerOthersData;
								ulong key2 = key;
								KeyValuePair<ulong, SceneObject> keyValuePair3 = enumerator.Current;
								playerOthersData[key2] = keyValuePair3.Value;
							}
							else
							{
								Dictionary<ulong, SceneObject> playerOthersData2 = this.PlayerOthersData;
								ulong key3 = key;
								KeyValuePair<ulong, SceneObject> keyValuePair4 = enumerator.Current;
								playerOthersData2.Add(key3, keyValuePair4.Value);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AD20 RID: 44320 RVA: 0x002583E2 File Offset: 0x002567E2
		public static void _BeginChangeJobDialog()
		{
			ClientSystemTown._OpenJobChangeSelectFrame();
		}

		// Token: 0x0600AD21 RID: 44321 RVA: 0x002583E9 File Offset: 0x002567E9
		public static void _BeginAwakeDialog()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			int dialogID = 10007;
			int iCurTaskId = 0;
			TaskDialogFrame.OnDialogOver onDialogOver = new TaskDialogFrame.OnDialogOver();
			if (ClientSystemTown.<>f__mg$cache4 == null)
			{
				ClientSystemTown.<>f__mg$cache4 = new UnityAction(ClientSystemTown._OpenAwakeFrame);
			}
			instance.CreateDialogFrame(dialogID, iCurTaskId, onDialogOver.AddListener(ClientSystemTown.<>f__mg$cache4));
		}

		// Token: 0x0600AD22 RID: 44322 RVA: 0x00258424 File Offset: 0x00256824
		public sealed override void OnStart(SystemContent systemContent)
		{
			Singleton<SystemSwitchEventManager>.GetInstance().RemoveEvent(SystemEventType.SYSETM_EVENT_SELECT_ROLE);
			Singleton<SystemSwitchEventManager>.GetInstance().RemoveEvent(SystemEventType.SYSTEM_EVENT_ON_SWITCH_FAILED);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
				{
					if (DataManager<BudoManager>.GetInstance().CanAcqured)
					{
						BudoResultFrameData data = new BudoResultFrameData
						{
							bOver = true,
							bNeedOpenBudoInfo = true
						};
						BudoResultFrame.Open(data);
					}
					else if (DataManager<BudoManager>.GetInstance().ReturnFromPk)
					{
						BudoResultFrameData data2 = new BudoResultFrameData
						{
							bOver = false,
							bNeedOpenBudoInfo = false,
							eResult = DataManager<BudoManager>.GetInstance().pkResult
						};
						BudoResultFrame.Open(data2);
						DataManager<BudoManager>.GetInstance().ReturnFromPk = false;
					}
				}
			}
			if (systemContent != null && systemContent.onStart != null)
			{
				systemContent.onStart();
				systemContent.onStart = null;
			}
		}

		// Token: 0x0600AD23 RID: 44323 RVA: 0x0025852D File Offset: 0x0025692D
		public static void _OpenJobChangeSelectFrame()
		{
			ChangeJobSelectFrame.Create(DataManager<PlayerBaseData>.GetInstance().JobTableID, true);
		}

		// Token: 0x0600AD24 RID: 44324 RVA: 0x0025853F File Offset: 0x0025693F
		public static void _OpenAwakeFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AwakeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AwakeFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AwakeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600AD25 RID: 44325 RVA: 0x00258570 File Offset: 0x00256970
		private void _UpdateNpcDialog(float timeElapsed)
		{
			float num = 4.8f;
			if (this._beTownPlayerMain != null)
			{
				if (this.m_kCurrentDialogComponent == null)
				{
					for (int i = 0; i < this._beTownNPCs.Count; i++)
					{
						BeTownNPC beTownNPC = this._beTownNPCs[i];
						if (beTownNPC != null && beTownNPC.GraphicActor != null && null != beTownNPC.GraphicActor.NpcDialogComponent)
						{
							NpcDialogComponent npcDialogComponent = beTownNPC.GraphicActor.NpcDialogComponent;
							if (npcDialogComponent != null)
							{
								Vector3 vector = beTownNPC.ActorData.MoveData.Position - this._beTownPlayerMain.ActorData.MoveData.Position;
								vector.y = 0f;
								float num2 = Mathf.Sqrt(vector.sqrMagnitude);
								if (num >= num2 && (this.m_kCurrentDialogComponent == null || this.m_kCurrentDialogComponent.TickPower > npcDialogComponent.TickPower || (this.m_kCurrentDialogComponent.TickPower == npcDialogComponent.TickPower && this.m_kCurrentDialogComponent.NextTick > npcDialogComponent.NextTick)))
								{
									this.m_kCurrentDialogComponent = npcDialogComponent;
								}
							}
						}
					}
					if (this.m_kCurrentDialogComponent != null)
					{
						this.m_kCurrentDialogComponent.BeginTick();
					}
				}
				if (this.m_kCurrentDialogComponent != null)
				{
					if (this.m_kCurrentDialogComponent.InTick)
					{
						this.m_kCurrentDialogComponent.Tick(timeElapsed);
					}
					else
					{
						this.m_kCurrentDialogComponent.EndTick();
						this.m_kCurrentDialogComponent = null;
					}
				}
			}
		}

		// Token: 0x0600AD26 RID: 44326 RVA: 0x00258710 File Offset: 0x00256B10
		public static void AddToAsyncLoadPetList(BeTownPlayer player, int petID)
		{
			if (player != null)
			{
				ClientSystemTown.PetLoadDesc item = new ClientSystemTown.PetLoadDesc
				{
					m_petOwner = player,
					m_petID = petID
				};
				ClientSystemTown.m_PetLoadList.Add(item);
			}
		}

		// Token: 0x0600AD27 RID: 44327 RVA: 0x00258744 File Offset: 0x00256B44
		private static void _UpdateAsyncLoadPetList()
		{
			if (ClientSystemTown.m_PetLoadList.Count > 0)
			{
				ClientSystemTown.PetLoadDesc petLoadDesc = ClientSystemTown.m_PetLoadList[0];
				ClientSystemTown.m_PetLoadList.RemoveAt(0);
				petLoadDesc.m_petOwner.CreatePet(petLoadDesc.m_petID);
				petLoadDesc.m_petOwner.CreateFollow();
			}
		}

		// Token: 0x0600AD28 RID: 44328 RVA: 0x00258794 File Offset: 0x00256B94
		private static void _ClearLoadPetList()
		{
			ClientSystemTown.m_PetLoadList.Clear();
		}

		// Token: 0x0600AD29 RID: 44329 RVA: 0x002587A0 File Offset: 0x00256BA0
		private void _AddDisplayActor(ulong ID)
		{
			if (this._beDisplayPlayerList.Count < this._beDisplayNum && !this._beDisplayPlayerList.Contains(ID))
			{
				BeTownPlayer beTownPlayer = null;
				if (this._beTownPlayers.TryGetValue(ID, out beTownPlayer))
				{
					if (beTownPlayer.GraphicActor == null)
					{
						beTownPlayer.InitGeActor(this._geScene);
						beTownPlayer.Init3v3RoomPlayerJiaoDiGuangQuan();
						if (beTownPlayer.GraphicActor == null)
						{
							BeTownPlayerData beTownPlayerData = beTownPlayer.ActorData as BeTownPlayerData;
							if (beTownPlayerData != null)
							{
								Logger.LogErrorFormat("InitPlayer failed {0} {1} {2} {3}", new object[]
								{
									beTownPlayerData.GUID,
									beTownPlayerData.Name,
									beTownPlayerData.ZoneID,
									beTownPlayerData.JobID
								});
							}
							else
							{
								Logger.LogErrorFormat("InitBasePlayer failed!", new object[0]);
							}
							return;
						}
						if (beTownPlayer.ActorData.ActionData.ActionName.Contains("Idle"))
						{
							beTownPlayer.GraphicActor.ChangeAction(beTownPlayer.ActorData.AniNames[0], 1f, true, true, true);
						}
						else
						{
							string action = (!Global.Settings.townPlayerRun) ? beTownPlayer.ActorData.AniNames[1] : beTownPlayer.ActorData.AniNames[2];
							beTownPlayer.GraphicActor.ChangeAction(action, 1f, true, true, true);
						}
					}
					this._beDisplayPlayerList.Add(ID);
				}
			}
		}

		// Token: 0x0600AD2A RID: 44330 RVA: 0x00258914 File Offset: 0x00256D14
		private void _RemoveDisplayActor(ulong ID)
		{
			if (this._beDisplayPlayerList.Contains(ID))
			{
				BeTownPlayer beTownPlayer = null;
				if (this._beTownPlayers.TryGetValue(ID, out beTownPlayer))
				{
					if (beTownPlayer.GraphicActor != null)
					{
						beTownPlayer.RemoveGeActor();
					}
					this._beDisplayPlayerList.Remove(ID);
				}
			}
		}

		// Token: 0x0600AD2B RID: 44331 RVA: 0x00258968 File Offset: 0x00256D68
		private void AddExtraOtherPlayerData()
		{
			if (this._extraOtherPlayerData == null || this._extraOtherPlayerData.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<ulong, SceneObject> keyValuePair in this._extraOtherPlayerData)
			{
				SceneObject value = keyValuePair.Value;
				Dictionary<ulong, SceneObject>.Enumerator enumerator;
				KeyValuePair<ulong, SceneObject> keyValuePair2 = enumerator.Current;
				ulong key = keyValuePair2.Key;
				if (key != 0UL)
				{
					if (value != null)
					{
						if ((ulong)value.sceneId == (ulong)((long)this.CurrentSceneID))
						{
							this._OnAddDelayCreateCache(value);
						}
					}
				}
			}
			this._extraOtherPlayerData.Clear();
		}

		// Token: 0x0600AD2C RID: 44332 RVA: 0x00258A14 File Offset: 0x00256E14
		private void OnExtraSceneSyncSceneObject(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			int num = 0;
			Dictionary<ulong, SceneObject> dictionary = SceneObjectDecoder.DecodeSyncSceneObjectMsg(msgData.bytes, ref num, msgData.bytes.Length);
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, SceneObject> keyValuePair in dictionary)
			{
				ulong key = keyValuePair.Key;
				if (DataManager<PlayerBaseData>.GetInstance().RoleID != key)
				{
					Dictionary<ulong, SceneObject>.Enumerator enumerator;
					KeyValuePair<ulong, SceneObject> keyValuePair2 = enumerator.Current;
					if (keyValuePair2.Value != null)
					{
						Dictionary<ulong, SceneObject> extraOtherPlayerData = this._extraOtherPlayerData;
						ulong key2 = key;
						KeyValuePair<ulong, SceneObject> keyValuePair3 = enumerator.Current;
						extraOtherPlayerData[key2] = keyValuePair3.Value;
					}
				}
			}
		}

		// Token: 0x0600AD2D RID: 44333 RVA: 0x00258ABC File Offset: 0x00256EBC
		private void OnExtraSceneDeleteSceneObject(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			int num = 0;
			while (msgData.bytes.Length - num > 8)
			{
				ulong key = 0UL;
				BaseDLL.decode_uint64(msgData.bytes, ref num, ref key);
				this._extraOtherPlayerData.Remove(key);
			}
		}

		// Token: 0x0600AD2E RID: 44334 RVA: 0x00258B08 File Offset: 0x00256F08
		private void OnExtraSceneSyncObjectProperty(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			int num = 0;
			ulong key = 0UL;
			BaseDLL.decode_uint64(msgData.bytes, ref num, ref key);
			SceneObject sceneObject = null;
			if (!this._extraOtherPlayerData.TryGetValue(key, out sceneObject))
			{
				return;
			}
			if (sceneObject == null)
			{
				return;
			}
			StreamObjectDecoder<SceneObject>.DecodePropertys(ref sceneObject, msgData.bytes, ref num, msgData.bytes.Length);
			this._extraOtherPlayerData[key] = sceneObject;
		}

		// Token: 0x0600AD2F RID: 44335 RVA: 0x00258B74 File Offset: 0x00256F74
		private void OnBindExtraSceneNetMessages()
		{
			this.OnUnBindExtraSceneNetMessages();
			NetProcess.AddMsgHandler(500602U, new Action<MsgDATA>(this.OnExtraSceneSyncSceneObject));
			NetProcess.AddMsgHandler(500604U, new Action<MsgDATA>(this.OnExtraSceneDeleteSceneObject));
			NetProcess.AddMsgHandler(500603U, new Action<MsgDATA>(this.OnExtraSceneSyncObjectProperty));
		}

		// Token: 0x0600AD30 RID: 44336 RVA: 0x00258BCC File Offset: 0x00256FCC
		private void OnUnBindExtraSceneNetMessages()
		{
			if (this._extraOtherPlayerData != null)
			{
				this._extraOtherPlayerData.Clear();
			}
			NetProcess.RemoveMsgHandler(500602U, new Action<MsgDATA>(this.OnExtraSceneSyncSceneObject));
			NetProcess.RemoveMsgHandler(500604U, new Action<MsgDATA>(this.OnExtraSceneDeleteSceneObject));
			NetProcess.RemoveMsgHandler(500603U, new Action<MsgDATA>(this.OnExtraSceneSyncObjectProperty));
		}

		// Token: 0x0600AD31 RID: 44337 RVA: 0x00258C34 File Offset: 0x00257034
		private void CreateAttackCityMonsters()
		{
			List<SceneNpc> sceneNpcsListBySceneId = DataManager<AttackCityMonsterDataManager>.GetInstance().GetSceneNpcsListBySceneId(this.CurrentSceneID);
			if (sceneNpcsListBySceneId == null || sceneNpcsListBySceneId.Count <= 0)
			{
				return;
			}
			foreach (SceneNpc sceneNpc in sceneNpcsListBySceneId)
			{
				this.CreateAttackCityMonsterBySceneNpc(sceneNpc);
			}
		}

		// Token: 0x0600AD32 RID: 44338 RVA: 0x00258CB0 File Offset: 0x002570B0
		private void OnResetAttackCityMonsterByUiEvent(UIEvent uiEvent)
		{
			this.ResetTownAttackCityMonsterList();
			this.CreateAttackCityMonsters();
		}

		// Token: 0x0600AD33 RID: 44339 RVA: 0x00258CC0 File Offset: 0x002570C0
		private void OnAddAttackCityMonsterByUiEvent(UIEvent uiEvent)
		{
			List<SceneNpc> sceneNpcsListBySceneId = DataManager<AttackCityMonsterDataManager>.GetInstance().GetSceneNpcsListBySceneId(this.CurrentSceneID);
			if (sceneNpcsListBySceneId == null || sceneNpcsListBySceneId.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < sceneNpcsListBySceneId.Count; i++)
			{
				SceneNpc sceneNpc = sceneNpcsListBySceneId[i];
				if (sceneNpc != null)
				{
					bool flag = this.IsAttackCityMonsterAlreadyExist(sceneNpc.guid);
					if (!flag)
					{
						this.CreateAttackCityMonsterBySceneNpc(sceneNpc);
					}
				}
			}
		}

		// Token: 0x0600AD34 RID: 44340 RVA: 0x00258D3C File Offset: 0x0025713C
		private void OnDeleteAttackCityMonsterByUiEvent(UIEvent uiEvent)
		{
			for (int i = this._beTownAttackCityMonsters.Count - 1; i >= 0; i--)
			{
				BeTownNPC beTownNPC = this._beTownAttackCityMonsters[i];
				if (beTownNPC != null)
				{
					BeTownNPCData beTownNPCData = beTownNPC.ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						bool flag = DataManager<AttackCityMonsterDataManager>.GetInstance().IsSceneDataContainNpcData(beTownNPCData.GUID, (uint)this.CurrentSceneID);
						if (!flag)
						{
							beTownNPC.Dispose();
							this._beTownAttackCityMonsters.RemoveAt(i);
						}
					}
				}
			}
		}

		// Token: 0x0600AD35 RID: 44341 RVA: 0x00258DCC File Offset: 0x002571CC
		private void ResetTownAttackCityMonsterList()
		{
			for (int i = 0; i < this._beTownAttackCityMonsters.Count; i++)
			{
				BeTownNPC beTownNPC = this._beTownAttackCityMonsters[i];
				if (beTownNPC != null)
				{
					beTownNPC.Dispose();
				}
			}
			this._beTownAttackCityMonsters.Clear();
		}

		// Token: 0x0600AD36 RID: 44342 RVA: 0x00258E20 File Offset: 0x00257220
		private bool IsAttackCityMonsterAlreadyExist(ulong guid)
		{
			for (int i = 0; i < this._beTownAttackCityMonsters.Count; i++)
			{
				BeTownNPC beTownNPC = this._beTownAttackCityMonsters[i];
				if (beTownNPC != null)
				{
					BeTownNPCData beTownNPCData = beTownNPC.ActorData as BeTownNPCData;
					if (beTownNPCData != null && beTownNPCData.GUID == guid)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600AD37 RID: 44343 RVA: 0x00258E80 File Offset: 0x00257280
		private void CreateAttackCityMonsterBySceneNpc(SceneNpc sceneNpc)
		{
			if (sceneNpc == null)
			{
				return;
			}
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>((int)sceneNpc.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("NpcItem is null, guid is {0} npcId is {1}", new object[]
				{
					sceneNpc.guid,
					sceneNpc.id
				});
				return;
			}
			BeTownNPCData beTownNPCData = new BeTownNPCData
			{
				GUID = sceneNpc.guid,
				NpcID = (int)sceneNpc.id,
				ResourceID = tableItem.ResID,
				Name = tableItem.NpcName,
				NameColor = PlayerInfoColor.TOWN_NPC,
				TownNpcType = ESceneActorType.AttackCityMonster
			};
			beTownNPCData.MoveData.Position = DataManager<AttackCityMonsterDataManager>.GetInstance().GetAttackCityMonsterScenePosition(sceneNpc.pos);
			BeTownAttackCityMonster beTownAttackCityMonster = new BeTownAttackCityMonster(beTownNPCData, this);
			beTownAttackCityMonster.InitGeActor(this._geScene);
			this._beTownAttackCityMonsters.Add(beTownAttackCityMonster);
		}

		// Token: 0x0600AD38 RID: 44344 RVA: 0x00258F64 File Offset: 0x00257364
		public BeTownNPC GetTownAttackCityMonsterByGuid(ulong guid)
		{
			for (int i = 0; i < this._beTownAttackCityMonsters.Count; i++)
			{
				BeTownNPC beTownNPC = this._beTownAttackCityMonsters[i];
				if (beTownNPC != null)
				{
					BeTownNPCData beTownNPCData = beTownNPC.ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						if (beTownNPCData.GUID == guid)
						{
							return beTownNPC;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600AD39 RID: 44345 RVA: 0x00258FCB File Offset: 0x002573CB
		private void OnSyncBlackMarketMerchantNPCType(UIEvent uiEvent)
		{
			this.CreatBlackMarketMerchant();
		}

		// Token: 0x0600AD3A RID: 44346 RVA: 0x00258FD3 File Offset: 0x002573D3
		private void OnResetBlackMarketMerchantNPC()
		{
			if (this._beTownBlackMarketMerchantNpc != null)
			{
				this._beTownBlackMarketMerchantNpc.Dispose();
			}
		}

		// Token: 0x0600AD3B RID: 44347 RVA: 0x00258FEC File Offset: 0x002573EC
		private void CreatBlackMarketMerchant()
		{
			bool flag = DataManager<BlackMarketMerchantDataManager>.GetInstance().CreatBlackMarketMerchantNPC(this.CurrentSceneID);
			if (flag)
			{
				this.OnResetBlackMarketMerchantNPC();
				BlackMarketType blackMarketType = BlackMarketMerchantDataManager.BlackMarketType;
				switch (blackMarketType)
				{
				case BlackMarketType.BmtFixedPrice:
				case BlackMarketType.BmtAuctionPrice:
					this.CreatBlackMarketMerchantNPC(blackMarketType);
					break;
				}
			}
		}

		// Token: 0x0600AD3C RID: 44348 RVA: 0x0025904C File Offset: 0x0025744C
		private void CreatBlackMarketMerchantNPC(BlackMarketType type)
		{
			BlackMarketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BlackMarketTable>((int)type, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("BlackMarketTable is null, Id is {0}", new object[]
				{
					(int)type
				});
				return;
			}
			NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(tableItem.NpcID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("NpcItem is null, npcId is {0}", new object[]
				{
					tableItem.NpcID
				});
				return;
			}
			BeTownNPCData beTownNPCData = new BeTownNPCData
			{
				NpcID = tableItem2.ID,
				ResourceID = tableItem2.ResID,
				Name = tableItem2.NpcName,
				NameColor = PlayerInfoColor.TOWN_NPC,
				TownNpcType = ESceneActorType.BlackMarketMerchanNpc
			};
			beTownNPCData.MoveData.Position = DataManager<BlackMarketMerchantDataManager>.GetInstance().GetBlackMarketMerchantPostion(tableItem2);
			this._beTownBlackMarketMerchantNpc = new BeTownBlackMarketMerchanNPC(beTownNPCData, this);
			this._beTownBlackMarketMerchantNpc.InitGeActor(this._geScene);
		}

		// Token: 0x0600AD3D RID: 44349 RVA: 0x00259140 File Offset: 0x00257540
		public BeTownNPC GetBlackMarketMerchanNpcById(int npcId)
		{
			if (this._beTownBlackMarketMerchantNpc != null)
			{
				BeTownNPCData beTownNPCData = this._beTownBlackMarketMerchantNpc.ActorData as BeTownNPCData;
				if (beTownNPCData == null)
				{
					return null;
				}
				if (beTownNPCData.NpcID == npcId)
				{
					return this._beTownBlackMarketMerchantNpc;
				}
			}
			return null;
		}

		// Token: 0x0600AD3E RID: 44350 RVA: 0x00259188 File Offset: 0x00257588
		private IEnumerator _PrewarmFrames(IASyncOperation systemOperation)
		{
			int i = 0;
			int icnt = this.m_PrewarmList.Length;
			while (i < icnt)
			{
				if (Singleton<AssetLoader>.instance.PreLoadRes(this.m_PrewarmList[i], typeof(GameObject), false, 0U))
				{
					Singleton<AssetLoader>.instance.LockAsset(this.m_PrewarmList[i], 1);
				}
				systemOperation.SetProgress(0.7f + (float)i * 0.3f / (float)this.m_PrewarmList.Length);
				yield return null;
				i++;
			}
			yield break;
		}

		// Token: 0x0600AD3F RID: 44351 RVA: 0x002591AC File Offset: 0x002575AC
		private void _unLockFrames()
		{
			int i = 0;
			int num = this.m_PrewarmList.Length;
			while (i < num)
			{
				Singleton<AssetLoader>.instance.LockAsset(this.m_PrewarmList[i], 0);
				i++;
			}
		}

		// Token: 0x0600AD40 RID: 44352 RVA: 0x002591E8 File Offset: 0x002575E8
		public BeTownPlayer GetTownPlayer(ulong playerID)
		{
			if (playerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return this.MainPlayer;
			}
			BeTownPlayer result = null;
			this._beTownPlayers.TryGetValue(playerID, out result);
			return result;
		}

		// Token: 0x040060DC RID: 24796
		public static int ChangeJobLevel = 15;

		// Token: 0x040060DD RID: 24797
		public static int Awakelevel = 45;

		// Token: 0x040060DE RID: 24798
		public static bool ChangeJobBegin = false;

		// Token: 0x040060DF RID: 24799
		private static bool _changeJobEnd = false;

		// Token: 0x040060E0 RID: 24800
		public static bool AwakeBegin = false;

		// Token: 0x040060E1 RID: 24801
		public static bool AwakeEnd = false;

		// Token: 0x040060E2 RID: 24802
		private int _currentSceneId;

		// Token: 0x040060E3 RID: 24803
		private int _fromSceneId;

		// Token: 0x040060E4 RID: 24804
		private int _lastSceneId;

		// Token: 0x040060E5 RID: 24805
		public Dictionary<ulong, SceneObject> PlayerOthersData = new Dictionary<ulong, SceneObject>();

		// Token: 0x040060E6 RID: 24806
		public bool IsNet = true;

		// Token: 0x040060E7 RID: 24807
		protected List<BeTownNPC> _beTownNPCs = new List<BeTownNPC>();

		// Token: 0x040060E8 RID: 24808
		private List<BeTownNPC> _beTownAttackCityMonsters = new List<BeTownNPC>();

		// Token: 0x040060E9 RID: 24809
		private BeTownNPC _beTownBlackMarketMerchantNpc;

		// Token: 0x040060EA RID: 24810
		protected BeTownPlayerMain _beTownPlayerMain;

		// Token: 0x040060EB RID: 24811
		protected List<BeTownDoor> _beTownDoors = new List<BeTownDoor>();

		// Token: 0x040060EC RID: 24812
		protected List<Vector3> _akFollowPetsPos = new List<Vector3>();

		// Token: 0x040060ED RID: 24813
		protected Dictionary<ulong, BeTownPlayer> _beTownPlayers = new Dictionary<ulong, BeTownPlayer>();

		// Token: 0x040060EE RID: 24814
		protected List<ulong> _beDisplayPlayerList = new List<ulong>();

		// Token: 0x040060EF RID: 24815
		protected int _beDisplayNum;

		// Token: 0x040060F0 RID: 24816
		protected ISceneData _levelData;

		// Token: 0x040060F2 RID: 24818
		protected GeSceneEx _geScene;

		// Token: 0x040060F3 RID: 24819
		protected Vector3 _logicToGraph;

		// Token: 0x040060F4 RID: 24820
		protected Vector3 _serverToClient;

		// Token: 0x040060F5 RID: 24821
		protected float _axisScale = 10000f;

		// Token: 0x040060F6 RID: 24822
		protected float _inputTimeElapsed;

		// Token: 0x040060F7 RID: 24823
		protected Dictionary<int, int> m_mapDungeonSceneID = new Dictionary<int, int>();

		// Token: 0x040060F8 RID: 24824
		protected uint m_BgmHandle = uint.MaxValue;

		// Token: 0x040060F9 RID: 24825
		private List<ClientSystemTown.SceneNode> m_sceneNodes = new List<ClientSystemTown.SceneNode>();

		// Token: 0x040060FA RID: 24826
		private DTownDoor _backTownDoor;

		// Token: 0x040060FB RID: 24827
		private DTownDoor _enterTownDoor;

		// Token: 0x040060FC RID: 24828
		private bool _isSwithScene;

		// Token: 0x040060FD RID: 24829
		private bool mIsTownSceneSwitching;

		// Token: 0x040060FE RID: 24830
		protected Dictionary<uint, Action<MsgDATA>> _mapBindMsgHandle = new Dictionary<uint, Action<MsgDATA>>();

		// Token: 0x040060FF RID: 24831
		private List<SceneObject> mObjQueue = new List<SceneObject>();

		// Token: 0x04006100 RID: 24832
		private NpcDialogComponent m_kCurrentDialogComponent;

		// Token: 0x04006101 RID: 24833
		private static List<ClientSystemTown.PetLoadDesc> m_PetLoadList = new List<ClientSystemTown.PetLoadDesc>();

		// Token: 0x04006102 RID: 24834
		private Dictionary<ulong, SceneObject> _extraOtherPlayerData = new Dictionary<ulong, SceneObject>();

		// Token: 0x04006103 RID: 24835
		private string[] m_PrewarmList = new string[]
		{
			"UIFlatten/Prefabs/Package/PackageNew",
			"UIFlatten/Prefabs/Package/BG",
			"UIFlatten/Prefabs/Package/Bottom",
			"UIFlatten/Prefabs/Package/Tabs",
			"UIFlatten/Prefabs/Skill/SkillTreeFrame",
			"UIFlatten/Prefabs/Skill/JobSkillTree",
			"UIFlatten/Prefabs/Team/TeamList",
			"UIFlatten/Prefabs/Jar/PocketJar",
			"UIFlatten/Prefabs/Jar/ActivityJar",
			"UIFlatten/Prefabs/MallNew/MallNewFrame",
			"UIFlatten/Prefabs/MallNew/PropertyMallView",
			"UIFlatten/Prefabs/Activity/Dungeon/ActivityDungeon",
			"UIFlatten/Prefabs/Mission/MissionDailyFrame",
			"UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionMergeNewFrame",
			"UIFlatten/Prefabs/SmithShop/Smithshop",
			"UIFlatten/Prefabs/Chapter/Select/ChapterSelect",
			"UIFlatten/Prefabs/Chapter/Normal/ChapterNormalHalf",
			"UIFlatten/Prefabs/Chapter/SelectReward/ChapterSelectRewardFrame"
		};

		// Token: 0x04006104 RID: 24836
		[CompilerGenerated]
		private static MissionManager.DelegateAddNewMission <>f__mg$cache0;

		// Token: 0x04006105 RID: 24837
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache1;

		// Token: 0x04006106 RID: 24838
		[CompilerGenerated]
		private static MissionManager.DelegateAddNewMission <>f__mg$cache2;

		// Token: 0x04006107 RID: 24839
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache3;

		// Token: 0x04006108 RID: 24840
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache4;

		// Token: 0x020011A3 RID: 4515
		private class DoorNode
		{
			// Token: 0x04006109 RID: 24841
			public int TargetSceneIndex;

			// Token: 0x0400610A RID: 24842
			public ISceneTownDoorData Door;
		}

		// Token: 0x020011A4 RID: 4516
		private class SceneNode
		{
			// Token: 0x0400610B RID: 24843
			public int SceneID;

			// Token: 0x0400610C RID: 24844
			public List<ClientSystemTown.DoorNode> DoorNodes;

			// Token: 0x0400610D RID: 24845
			public bool HasVisited;
		}

		// Token: 0x020011A5 RID: 4517
		private class PetLoadDesc
		{
			// Token: 0x0400610E RID: 24846
			public BeTownPlayer m_petOwner;

			// Token: 0x0400610F RID: 24847
			public int m_petID;
		}
	}
}

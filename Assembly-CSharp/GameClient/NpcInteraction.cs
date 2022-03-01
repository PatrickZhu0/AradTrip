using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200460E RID: 17934
	public class NpcInteraction : MonoBehaviour
	{
		// Token: 0x06019349 RID: 103241 RVA: 0x007F8FB1 File Offset: 0x007F73B1
		private void OnDisable()
		{
			this.Clear();
		}

		// Token: 0x0601934A RID: 103242 RVA: 0x007F8FBC File Offset: 0x007F73BC
		public void Initialize(int iNpcId, ulong guid = 0UL)
		{
			this.Clear();
			this.bInitialized = true;
			this._iNpcId = iNpcId;
			this._npcGuid = guid;
			this._npcItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcId, string.Empty, string.Empty);
			if (!this.bCreated)
			{
				this.imgIcon = Utility.FindComponent<Image>(base.gameObject, "MissionTrace", true);
				this.btnMissionTrace = Utility.FindComponent<Button>(base.gameObject, "MissionTrace", true);
				this.gray = this.imgIcon.gameObject.GetComponent<UIGray>();
				if (this.gray == null)
				{
					this.gray = this.imgIcon.gameObject.AddComponent<UIGray>();
				}
				this.bCreated = true;
			}
			this.imgIcon.CustomActive(true);
			this.btnMissionTrace.onClick.RemoveAllListeners();
			this.gray.enabled = false;
			this._TryAddFunctionListener();
			this._TryAddDialogListener();
			this._TryAddMissionListener();
			this._TryExchangeShopIsShow();
			this.TryAddAttackCityMonsterListener();
			this._TryAddTAPListener();
			this._TryAddBlackMarketMerchanListener();
			this._TryAddChijiShopListener();
			this._TryAddAnniversaryParyListener();
			this._TryAddSendDoorListener();
			NpcRelationMissionManager instance = DataManager<NpcRelationMissionManager>.GetInstance();
			instance.onNpcRelationMissionChanged = (NpcRelationMissionManager.OnNpcRelationMissionChanged)Delegate.Combine(instance.onNpcRelationMissionChanged, new NpcRelationMissionManager.OnNpcRelationMissionChanged(this.OnNpcRelationMissionChanged));
		}

		// Token: 0x0601934B RID: 103243 RVA: 0x007F9108 File Offset: 0x007F7508
		private void _TryExchangeShopIsShow()
		{
			ComCommonBind component = base.gameObject.GetComponent<ComCommonBind>();
			if (null == component)
			{
				return;
			}
			this.gExchangeShop = component.GetGameObject("ExchangeShop");
			this.gExchangeShop.CustomActive(false);
			ComCommonBind component2 = this.gExchangeShop.GetComponent<ComCommonBind>();
			if (component2 == null)
			{
				return;
			}
			this.iExchangeShopImage = component2.GetCom<Image>("Image");
			if (this._npcItem != null && this._npcItem.ExchangeShopData != string.Empty)
			{
				string[] array = this._npcItem.ExchangeShopData.Split(new char[]
				{
					'|'
				});
				bool flag = int.Parse(array[0]) == 1;
				string path = array[1];
				ETCImageLoader.LoadSprite(ref this.iExchangeShopImage, path, true);
				this.gExchangeShop.CustomActive(!this.imgIcon.enabled && flag);
			}
		}

		// Token: 0x0601934C RID: 103244 RVA: 0x007F91F5 File Offset: 0x007F75F5
		private void OnNpcRelationMissionChanged(int iNpcId)
		{
			if (this._iNpcId == iNpcId)
			{
				this._TryAddMissionListener();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NpcRelationMissionChanged, this._iNpcId, null, null, null);
			}
		}

		// Token: 0x0601934D RID: 103245 RVA: 0x007F9228 File Offset: 0x007F7628
		private void _TryAddFunctionListener()
		{
			if (this._npcItem != null && ((this._npcItem.Function > NpcTable.eFunction.none && this._npcItem.Function < NpcTable.eFunction.clicknpc) || this._npcItem.Function == NpcTable.eFunction.guildDungeonActivityChest || this._npcItem.Function == NpcTable.eFunction.guildGuardStatue))
			{
				NpcInteractionData data = new NpcInteractionData();
				data.icon = this._npcItem.FunctionIcon;
				data.eNpcInteractionType = NpcInteractionType.NIT_FUNCTION;
				data.iParam0 = this._npcItem.ID;
				data.onClickFunction = delegate()
				{
					TaskNpcAccess.OnClickFunctionNpc(data.iParam0, 0UL, string.Empty);
				};
				this.datas.Add(data);
			}
		}

		// Token: 0x0601934E RID: 103246 RVA: 0x007F9300 File Offset: 0x007F7700
		private void _TryAddTAPListener()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this._npcItem.Function != NpcTable.eFunction.TAPGraduation)
			{
				return;
			}
			NpcInteractionData item = new NpcInteractionData
			{
				icon = this._npcItem.FunctionIcon,
				eNpcInteractionType = NpcInteractionType.NIT_FUNCTION,
				iParam0 = this._npcItem.ID,
				onClickFunction = delegate()
				{
					TaskNpcAccess.OnClickFunctionNpc(this._npcItem.ID, 0UL, string.Empty);
				}
			};
			this.datas.Add(item);
		}

		// Token: 0x0601934F RID: 103247 RVA: 0x007F9380 File Offset: 0x007F7780
		private void _TryAddBlackMarketMerchanListener()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this._npcItem.Function != NpcTable.eFunction.BlackMarketMerchan)
			{
				return;
			}
			NpcInteractionData item = new NpcInteractionData
			{
				icon = this._npcItem.FunctionIcon,
				eNpcInteractionType = NpcInteractionType.NIT_FUNCTION,
				iParam0 = this._npcItem.ID,
				onClickFunction = delegate()
				{
					TaskNpcAccess.OnClickFunctionNpc(this._npcItem.ID, 0UL, string.Empty);
				}
			};
			this.datas.Add(item);
		}

		// Token: 0x06019350 RID: 103248 RVA: 0x007F9400 File Offset: 0x007F7800
		private void _TryAddChijiShopListener()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this._npcItem.Function != NpcTable.eFunction.Chiji)
			{
				return;
			}
			NpcInteractionData item = new NpcInteractionData
			{
				icon = this._npcItem.FunctionIcon,
				eNpcInteractionType = NpcInteractionType.NIT_FUNCTION,
				iParam0 = this._npcItem.ID,
				onClickFunction = delegate()
				{
					TaskNpcAccess.OnClickFunctionNpc(this._npcItem.ID, this._npcGuid, string.Empty);
				}
			};
			this.datas.Add(item);
		}

		// Token: 0x06019351 RID: 103249 RVA: 0x007F9480 File Offset: 0x007F7880
		private void TryAddAttackCityMonsterListener()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this._npcGuid <= 0UL)
			{
				return;
			}
			if (this._npcItem.Function != NpcTable.eFunction.attackCityMonster)
			{
				return;
			}
			NpcInteractionData item = new NpcInteractionData
			{
				icon = this._npcItem.FunctionIcon,
				eNpcInteractionType = NpcInteractionType.NIT_Attack_City_Monster,
				iParam0 = this._npcItem.ID,
				onClickFunction = delegate()
				{
					DataManager<AttackCityMonsterDataManager>.GetInstance().SetOpenTalkFrameType(EOpenTalkFrameType.Normal);
					DataManager<AttackCityMonsterDataManager>.GetInstance().ShowAttackCityMonsterDialogFrame(this._npcGuid);
				}
			};
			this.datas.Add(item);
		}

		// Token: 0x06019352 RID: 103250 RVA: 0x007F950C File Offset: 0x007F790C
		private void _TryAddDialogListener()
		{
			if (this._npcItem != null && this._npcItem.Function == NpcTable.eFunction.none && !string.IsNullOrEmpty(this._npcItem.NpcTalk))
			{
				int num = int.Parse(this._npcItem.NpcTalk);
				TalkTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(num, string.Empty, string.Empty);
				if (tableItem != null)
				{
					NpcInteractionData data = new NpcInteractionData();
					data.icon = this._npcItem.FunctionIcon;
					data.eNpcInteractionType = NpcInteractionType.NIT_DIALOG;
					data.iParam0 = num;
					data.onClickFunction = delegate()
					{
						ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
						if (clientSystemTown != null)
						{
							clientSystemTown.PlayNpcSound(this._iNpcId, NpcVoiceComponent.SoundEffectType.SET_Start);
						}
						TaskDialogFrame.OnDialogOver callback = new TaskDialogFrame.OnDialogOver().AddListener(delegate
						{
							ClientSystemTown clientSystemTown2 = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
							if (clientSystemTown2 != null)
							{
								clientSystemTown2.PlayNpcSound(this._iNpcId, NpcVoiceComponent.SoundEffectType.SET_End);
							}
						});
						DataManager<MissionManager>.GetInstance().CreateDialogFrame(data.iParam0, 0, callback);
					};
					this.datas.Add(data);
				}
			}
		}

		// Token: 0x06019353 RID: 103251 RVA: 0x007F95E4 File Offset: 0x007F79E4
		private void _TryAddAnniversaryParyListener()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this._npcItem.Function != NpcTable.eFunction.AnniersaryParty)
			{
				return;
			}
			NpcInteractionData item = new NpcInteractionData
			{
				icon = this._npcItem.FunctionIcon,
				eNpcInteractionType = NpcInteractionType.NIT_FUNCTION,
				iParam0 = this._npcItem.ID,
				onClickFunction = delegate()
				{
					TaskNpcAccess.OnClickFunctionNpc(this._npcItem.ID, 0UL, string.Empty);
				}
			};
			this.datas.Add(item);
		}

		// Token: 0x06019354 RID: 103252 RVA: 0x007F9662 File Offset: 0x007F7A62
		private string _GetMissionInteractionIcon(MissionManager.SingleMissionInfo value)
		{
			return "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Renwu";
		}

		// Token: 0x06019355 RID: 103253 RVA: 0x007F966C File Offset: 0x007F7A6C
		private void _TryAddMissionListener()
		{
			this.datas.RemoveAll((NpcInteractionData x) => x.eNpcInteractionType == NpcInteractionType.NIT_MISSION);
			this.imgIcon.enabled = false;
			this.btnMissionTrace.onClick.RemoveAllListeners();
			List<MissionManager.SingleMissionInfo> npcRelationMissions = DataManager<NpcRelationMissionManager>.GetInstance().GetNpcRelationMissions(this._iNpcId);
			if (npcRelationMissions != null && npcRelationMissions.Count > 0)
			{
				int num = 0;
				if (num < npcRelationMissions.Count)
				{
					NpcInteractionData data = new NpcInteractionData();
					data.icon = this._GetMissionInteractionIcon(npcRelationMissions[num]);
					data.eNpcInteractionType = NpcInteractionType.NIT_MISSION;
					data.iParam0 = npcRelationMissions[num].missionItem.ID;
					data.onClickFunction = delegate()
					{
						DataManager<MissionManager>.GetInstance().AutoTraceTask(data.iParam0, null, null, true);
					};
					int iMissionId = npcRelationMissions[num].missionItem.ID;
					this.btnMissionTrace.onClick.AddListener(delegate()
					{
						DataManager<MissionManager>.GetInstance().AutoTraceTask(iMissionId, null, null, true);
					});
					this.datas.Add(data);
					this._UpdateMissionIcon((uint)npcRelationMissions[num].missionItem.ID);
				}
			}
			this._TryExchangeShopIsShow();
		}

		// Token: 0x06019356 RID: 103254 RVA: 0x007F97C8 File Offset: 0x007F7BC8
		private void _TryAddSendDoorListener()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this._npcItem.Function != NpcTable.eFunction.SendDoor)
			{
				return;
			}
			NpcInteractionData item = new NpcInteractionData
			{
				icon = this._npcItem.FunctionIcon,
				eNpcInteractionType = NpcInteractionType.NIT_FUNCTION,
				iParam0 = this._npcItem.ID,
				onClickFunction = delegate()
				{
					TaskNpcAccess.OnClickFunctionNpc(this._npcItem.ID, this._npcGuid, string.Empty);
				}
			};
			this.datas.Add(item);
		}

		// Token: 0x06019357 RID: 103255 RVA: 0x007F9848 File Offset: 0x007F7C48
		private void _UpdateMissionIcon(uint iTaskId)
		{
			string path = "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubaio_Renwu_Huangse_Wenhao";
			bool enabled = true;
			MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission(iTaskId);
			if (mission != null)
			{
				if (mission.status == 2)
				{
					path = "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubaio_Renwu_Huangse_Wenhao";
					enabled = false;
				}
				if (mission.status == 0)
				{
					path = "UI/Image/Packed/p_MainUI01.png:UI_MainUI_Tubaio_Renwu_01";
					enabled = false;
				}
			}
			ETCImageLoader.LoadSprite(ref this.imgIcon, path, true);
			this.imgIcon.enabled = true;
			this.gray.enabled = enabled;
		}

		// Token: 0x06019358 RID: 103256 RVA: 0x007F98BC File Offset: 0x007F7CBC
		public void Tick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown || Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
				if (clientSystemTown == null && clientSystemGameBattle == null)
				{
					return;
				}
				if (this._iNpcId == 2037)
				{
					return;
				}
				GameObject entityNode;
				if (clientSystemGameBattle != null)
				{
					BeNPC chijiNpc = this.GetChijiNpc(clientSystemGameBattle);
					if (chijiNpc == null)
					{
						return;
					}
					entityNode = chijiNpc.GraphicActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
				}
				else
				{
					BeTownNPC beTownNpc = this.GetBeTownNpc(clientSystemTown);
					if (beTownNpc == null)
					{
						return;
					}
					entityNode = beTownNpc.GraphicActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
				}
				if (this._npcItem == null || this._npcItem.Function == NpcTable.eFunction.invalid || this._npcItem.SubType == NpcTable.eSubType.TownViceOwner_1 || this._npcItem.SubType == NpcTable.eSubType.TownViceOwner_2 || this._npcItem.SubType == NpcTable.eSubType.GuildGuard2 || this._npcItem.SubType == NpcTable.eSubType.GuildGuard3)
				{
					return;
				}
				Vector3 vector = Vector3.zero;
				if (clientSystemGameBattle != null)
				{
					vector = entityNode.transform.position - clientSystemGameBattle.MainPlayer.ActorData.MoveData.Position;
				}
				else
				{
					vector = entityNode.transform.position - clientSystemTown.MainPlayer.ActorData.MoveData.Position;
				}
				vector.y = 0f;
				float num = Mathf.Sqrt(vector.sqrMagnitude);
				float num2 = (this._npcItem.Function != NpcTable.eFunction.SendDoor) ? NpcInteraction.fInMaxDistance : 2.8f;
				if (num > num2)
				{
					NpcInterfaceFrame.TryCloseFrame(this._iNpcId, this._npcGuid);
					this.ShowSendDoorEffect(entityNode, SendDoorAnimationControl.AnimationState.eClose);
				}
				else
				{
					NpcInterfaceFrame.OpenFrame(this._iNpcId, this.datas, this._npcGuid);
					this.ShowSendDoorEffect(entityNode, SendDoorAnimationControl.AnimationState.eOpen);
				}
			}
		}

		// Token: 0x06019359 RID: 103257 RVA: 0x007F9AC0 File Offset: 0x007F7EC0
		private void ShowSendDoorEffect(GameObject obj, SendDoorAnimationControl.AnimationState state)
		{
			if (obj == null)
			{
				Logger.LogError("can`t find goActor");
				return;
			}
			if (this._npcItem != null && this._npcItem.Function == NpcTable.eFunction.SendDoor)
			{
				int functionUnlockLevel = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.SendDoor);
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= functionUnlockLevel)
				{
					GameObject gameObject = Utility.FindThatChild("Scene_Sailiyachuansongmen_spine_created(Clone)", obj, false);
					if (gameObject != null)
					{
						SendDoorAnimationControl component = gameObject.GetComponent<SendDoorAnimationControl>();
						if (component == null)
						{
							gameObject.gameObject.AddComponent<SendDoorAnimationControl>();
						}
						if (component != null)
						{
							component.SetAnimation(state);
						}
					}
				}
			}
		}

		// Token: 0x0601935A RID: 103258 RVA: 0x007F9B68 File Offset: 0x007F7F68
		private BeNPC GetChijiNpc(ClientSystemGameBattle systemTown)
		{
			if (this._npcItem == null)
			{
				return null;
			}
			return systemTown.GetNpcByGuid(this._iNpcId, this._npcGuid);
		}

		// Token: 0x0601935B RID: 103259 RVA: 0x007F9B98 File Offset: 0x007F7F98
		private BeTownNPC GetBeTownNpc(ClientSystemTown systemTown)
		{
			if (this._npcItem == null)
			{
				return null;
			}
			BeTownNPC result;
			if (this._npcGuid > 0UL && this._npcItem.Function == NpcTable.eFunction.attackCityMonster)
			{
				result = systemTown.GetTownAttackCityMonsterByGuid(this._npcGuid);
			}
			else if (this._npcItem.Function == NpcTable.eFunction.BlackMarketMerchan)
			{
				result = systemTown.GetBlackMarketMerchanNpcById(this._iNpcId);
			}
			else
			{
				result = systemTown.GetTownNpcByNpcId(this._iNpcId);
			}
			return result;
		}

		// Token: 0x0601935C RID: 103260 RVA: 0x007F9C1D File Offset: 0x007F801D
		private void OnDestroy()
		{
			this.Clear();
			this.imgIcon = null;
			this.btnMissionTrace = null;
			this.gray = null;
			this.bCreated = false;
			this.bInitialized = false;
			this.gExchangeShop = null;
			this.iExchangeShopImage = null;
		}

		// Token: 0x0601935D RID: 103261 RVA: 0x007F9C58 File Offset: 0x007F8058
		public void Clear()
		{
			NpcInterfaceFrame.TryCloseFrame(this._iNpcId, this._npcGuid);
			this._iNpcId = 0;
			this._npcGuid = 0UL;
			this._npcItem = null;
			if (null != this.imgIcon)
			{
				this.imgIcon.CustomActive(false);
			}
			if (null != this.gray)
			{
				this.gray.enabled = false;
			}
			NpcRelationMissionManager instance = DataManager<NpcRelationMissionManager>.GetInstance();
			instance.onNpcRelationMissionChanged = (NpcRelationMissionManager.OnNpcRelationMissionChanged)Delegate.Remove(instance.onNpcRelationMissionChanged, new NpcRelationMissionManager.OnNpcRelationMissionChanged(this.OnNpcRelationMissionChanged));
			if (this.btnMissionTrace != null)
			{
				this.btnMissionTrace.onClick.RemoveAllListeners();
			}
			foreach (NpcInteractionData npcInteractionData in this.datas)
			{
				npcInteractionData.onClickFunction = null;
			}
			this.datas.Clear();
		}

		// Token: 0x04012100 RID: 73984
		public static float fOutMaxDistance = 2f;

		// Token: 0x04012101 RID: 73985
		private static float fInMaxDistance = 1.9f;

		// Token: 0x04012102 RID: 73986
		private int _iNpcId;

		// Token: 0x04012103 RID: 73987
		private ulong _npcGuid;

		// Token: 0x04012104 RID: 73988
		private NpcTable _npcItem;

		// Token: 0x04012105 RID: 73989
		private List<NpcInteractionData> datas = new List<NpcInteractionData>();

		// Token: 0x04012106 RID: 73990
		private Image imgIcon;

		// Token: 0x04012107 RID: 73991
		private Button btnMissionTrace;

		// Token: 0x04012108 RID: 73992
		private UIGray gray;

		// Token: 0x04012109 RID: 73993
		private bool bInitialized;

		// Token: 0x0401210A RID: 73994
		private bool bCreated;

		// Token: 0x0401210B RID: 73995
		private GameObject gExchangeShop;

		// Token: 0x0401210C RID: 73996
		private Image iExchangeShopImage;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001148 RID: 4424
	public class BeFighterMain : BeFighter
	{
		// Token: 0x0600A8F5 RID: 43253 RVA: 0x00239A74 File Offset: 0x00237E74
		public BeFighterMain(BeFighterData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
			if (BeFighterMain.OnAutoMoveSuccess == null)
			{
				BeFighterMain.OnAutoMoveSuccess = new BeFighterMain.AutoMoveSuccessEvent();
			}
			if (BeFighterMain.OnMoveStateChanged == null)
			{
				BeFighterMain.OnMoveStateChanged = new BeFighterMain.MoveStateChangedEvent();
			}
			if (BeFighterMain.OnAutoMoveFail == null)
			{
				BeFighterMain.OnAutoMoveFail = new BeFighterMain.AutoMoveFailEvent();
			}
			if (BeFighterMain.OnMoveing == null)
			{
				BeFighterMain.OnMoveing = new BeFighterMain.MoveingEvent();
			}
			if (BeFighterMain.OnAutoMoving == null)
			{
				BeFighterMain.OnAutoMoving = new BeFighterMain.AutoMoveingEvent();
			}
			this.MoveState = BeFighterMain.EMoveState.Idle;
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(62, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.xGlobalMinDist = (float)tableItem.ValueA / 1000f;
				this.yGlobalMinDist = (float)tableItem.ValueB / 1000f;
			}
		}

		// Token: 0x17001A16 RID: 6678
		// (get) Token: 0x0600A8F6 RID: 43254 RVA: 0x00239B92 File Offset: 0x00237F92
		// (set) Token: 0x0600A8F7 RID: 43255 RVA: 0x00239B99 File Offset: 0x00237F99
		public static BeFighterMain.MoveStateChangedEvent OnMoveStateChanged { get; set; }

		// Token: 0x17001A17 RID: 6679
		// (get) Token: 0x0600A8F8 RID: 43256 RVA: 0x00239BA1 File Offset: 0x00237FA1
		// (set) Token: 0x0600A8F9 RID: 43257 RVA: 0x00239BA8 File Offset: 0x00237FA8
		public static BeFighterMain.AutoMoveSuccessEvent OnAutoMoveSuccess { get; set; }

		// Token: 0x17001A18 RID: 6680
		// (get) Token: 0x0600A8FA RID: 43258 RVA: 0x00239BB0 File Offset: 0x00237FB0
		// (set) Token: 0x0600A8FB RID: 43259 RVA: 0x00239BB7 File Offset: 0x00237FB7
		public static BeFighterMain.AutoMoveFailEvent OnAutoMoveFail { get; set; }

		// Token: 0x17001A19 RID: 6681
		// (get) Token: 0x0600A8FC RID: 43260 RVA: 0x00239BBF File Offset: 0x00237FBF
		// (set) Token: 0x0600A8FD RID: 43261 RVA: 0x00239BC6 File Offset: 0x00237FC6
		public static BeFighterMain.MoveingEvent OnMoveing { get; set; }

		// Token: 0x17001A1A RID: 6682
		// (get) Token: 0x0600A8FE RID: 43262 RVA: 0x00239BCE File Offset: 0x00237FCE
		// (set) Token: 0x0600A8FF RID: 43263 RVA: 0x00239BD5 File Offset: 0x00237FD5
		public static BeFighterMain.AutoMoveingEvent OnAutoMoving { get; set; }

		// Token: 0x17001A1B RID: 6683
		// (get) Token: 0x0600A900 RID: 43264 RVA: 0x00239BDD File Offset: 0x00237FDD
		// (set) Token: 0x0600A901 RID: 43265 RVA: 0x00239BE5 File Offset: 0x00237FE5
		public BeFighterMain.EMoveState MoveState { get; set; }

		// Token: 0x0600A902 RID: 43266 RVA: 0x00239BEE File Offset: 0x00237FEE
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AvatarChanged, new ClientEventSystem.UIEventHandler(this.UpdateAvatar));
		}

		// Token: 0x0600A903 RID: 43267 RVA: 0x00239C11 File Offset: 0x00238011
		public sealed override void InitGeActor(GeSceneEx geScene)
		{
			base.InitGeActor(geScene);
			if (this._geActor != null)
			{
				base.CreateFootIndicator(BeFighter.FootEffectType.DEFUALT);
				this.UpdateEquip();
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AvatarChanged, new ClientEventSystem.UIEventHandler(this.UpdateAvatar));
			}
		}

		// Token: 0x0600A904 RID: 43268 RVA: 0x00239C50 File Offset: 0x00238050
		public void UpdateEquip()
		{
			PlayerAvatar avatar = DataManager<PlayerBaseData>.GetInstance().avatar;
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			if (avatar != null)
			{
				this.SetGrassStat(BeBaseFighter.GRASS_STATUS.NONE);
				this.m_grassId = 0;
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(null, avatar.equipItemIds, jobTableID, (int)avatar.weaponStrengthen, this._geActor, false, avatar.isShoWeapon, false);
			}
			else
			{
				Logger.LogErrorFormat("avatar is null in BeTownPlayerMain UpdateEquip", new object[0]);
			}
		}

		// Token: 0x0600A905 RID: 43269 RVA: 0x00239CC2 File Offset: 0x002380C2
		private void UpdateAvatar(UIEvent data = null)
		{
			this.UpdateEquip();
		}

		// Token: 0x0600A906 RID: 43270 RVA: 0x00239CCA File Offset: 0x002380CA
		public void SetEnable(bool bEnable)
		{
			this.m_bEnable = bEnable;
		}

		// Token: 0x0600A907 RID: 43271 RVA: 0x00239CD4 File Offset: 0x002380D4
		public List<BeItem> FindNearestTownItems()
		{
			this.mNeareastItems.Clear();
			ClientSystemGameBattle battle = this._battle;
			if (battle == null)
			{
				Logger.LogError("Chiji this._battle == null in [FindNearestTownItems]");
				return this.mNeareastItems;
			}
			if (base.ActorData == null)
			{
				Logger.LogError("Chiji ActorData == null in [FindNearestTownItems]");
				return this.mNeareastItems;
			}
			BeFighterManager<BeItem> items = battle.Items;
			for (int i = 0; i < items.GetFightCount(); i++)
			{
				BeItem fighter = items.GetFighter(i);
				if (fighter != null && !fighter.IsBuffItem)
				{
					BeItemData beItemData = fighter.ActorData as BeItemData;
					if (beItemData == null)
					{
						Logger.LogErrorFormat("Chiji itemData == null in [FindNearestTownItems], ActorData.GUID = {0}, ActorData.Name = {1}", new object[]
						{
							base.ActorData.GUID,
							base.ActorData.Name
						});
					}
					else
					{
						SceneItem mDropItem = beItemData.mDropItem;
						if (mDropItem == null)
						{
							Logger.LogErrorFormat("Chiji dropItem == null in [FindNearestTownItems], ActorData.GUID = {0}, ActorData.Name = {1}", new object[]
							{
								base.ActorData.GUID,
								base.ActorData.Name
							});
						}
						else if (base.ActorData.GUID == 0UL)
						{
							Logger.LogErrorFormat("Chiji ActorData.GUID == 0 in [FindNearestTownItems], ActorData.Name = {0}", new object[]
							{
								base.ActorData.Name
							});
						}
						else if (mDropItem.owner != base.ActorData.GUID && (base.ActorData.MoveData.Position.xz() - fighter.ActorData.MoveData.Position.xz()).magnitude <= 1.5f)
						{
							this.mNeareastItems.Add(fighter);
						}
					}
				}
			}
			return this.mNeareastItems;
		}

		// Token: 0x0600A908 RID: 43272 RVA: 0x00239E94 File Offset: 0x00238294
		public ulong FindNearestPlayer()
		{
			if (this._battle.OtherFighters.GetFightCount() > 0)
			{
				BeFighterManager<BeFighter> otherFighters = this._battle.OtherFighters;
				float num = this.xGlobalMinDist;
				float num2 = this.yGlobalMinDist;
				ulong result = 0UL;
				for (int i = 0; i < otherFighters.GetFightCount(); i++)
				{
					BeFighter fighter = otherFighters.GetFighter(i);
					if (fighter != null && !fighter.IsDead && (fighter.GrassId == 0 || (fighter.GrassId != 0 && base.GrassId == fighter.GrassId)) && this._battle.OtherFighterBuffs.ContainsKey(fighter.ActorData.GUID))
					{
						BeFightBuffManager beFightBuffManager = this._battle.OtherFighterBuffs[fighter.ActorData.GUID];
						if (!beFightBuffManager.HasBuffByID(400000000) && !beFightBuffManager.HasBuffByID(400000001))
						{
							Vector2 vector = base.ActorData.MoveData.Position.xz();
							Vector2 vector2 = fighter.ActorData.MoveData.Position.xz();
							float magnitude = (vector - vector2).magnitude;
							float num3 = Mathf.Abs(vector.x - vector2.x);
							float num4 = Mathf.Abs(vector.y - vector2.y);
							if (num3 <= num && num4 <= num2)
							{
								if (num3 <= num)
								{
									num = num3;
								}
								if (num4 <= num2)
								{
									num2 = num4;
								}
								result = fighter.ActorData.GUID;
							}
						}
					}
				}
				return result;
			}
			return 0UL;
		}

		// Token: 0x0600A909 RID: 43273 RVA: 0x0023A042 File Offset: 0x00238442
		public sealed override void CommandMoveForward(Vector3 targetDirection)
		{
			targetDirection.y = 0f;
			base.CommandMoveForward(targetDirection);
			this._UpdateMoveState();
		}

		// Token: 0x0600A90A RID: 43274 RVA: 0x0023A05D File Offset: 0x0023845D
		public sealed override void CommandDirectMoveTo(Vector3 targetPosition)
		{
			targetPosition.y = 0f;
			base.CommandDirectMoveTo(targetPosition);
			this._UpdateMoveState();
		}

		// Token: 0x0600A90B RID: 43275 RVA: 0x0023A078 File Offset: 0x00238478
		public sealed override void CommandMoveTo(Vector3 targetPosition)
		{
			targetPosition.y = 0f;
			base.CommandMoveTo(targetPosition);
			this._UpdateMoveState();
		}

		// Token: 0x0600A90C RID: 43276 RVA: 0x0023A093 File Offset: 0x00238493
		public sealed override void CommandStopMove()
		{
			base.CommandStopMove();
			this._UpdateMoveState();
		}

		// Token: 0x0600A90D RID: 43277 RVA: 0x0023A0A4 File Offset: 0x002384A4
		protected BeFighterMain.EMoveState _CalculateMoveState()
		{
			BeFighterMain.EMoveState result = BeFighterMain.EMoveState.Idle;
			if (base.ActorData.MoveData.MoveType == EActorMoveType.Invalid)
			{
				result = BeFighterMain.EMoveState.Idle;
			}
			else if (base.ActorData.MoveData.MoveType == EActorMoveType.TargetDir)
			{
				result = BeFighterMain.EMoveState.Moveing;
			}
			else if (base.ActorData.MoveData.MoveType == EActorMoveType.TargetPos)
			{
				result = BeFighterMain.EMoveState.AutoMoving;
			}
			return result;
		}

		// Token: 0x0600A90E RID: 43278 RVA: 0x0023A108 File Offset: 0x00238508
		protected void _UpdateMoveState()
		{
			BeFighterMain.EMoveState emoveState = this._CalculateMoveState();
			if (this.MoveState != emoveState)
			{
				BeFighterMain.EMoveState moveState = this.MoveState;
				this.MoveState = emoveState;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerMoveStateChanged, moveState, this.MoveState, null, null);
			}
		}

		// Token: 0x0600A90F RID: 43279 RVA: 0x0023A158 File Offset: 0x00238558
		public sealed override void UpdateMove(float timeElapsed)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			if (this._battle.IsNet)
			{
				this._SyncMove();
			}
			base.UpdateMove(timeElapsed);
			if (this.MoveState == BeFighterMain.EMoveState.Moveing)
			{
				BeFighterMain.OnMoveing.Invoke(base.ActorData.MoveData.Position);
			}
			else if (this.MoveState == BeFighterMain.EMoveState.AutoMoving)
			{
				BeFighterMain.OnAutoMoving.Invoke(base.ActorData.MoveData.Position);
			}
		}

		// Token: 0x0600A910 RID: 43280 RVA: 0x0023A1E0 File Offset: 0x002385E0
		protected void _SyncMove()
		{
			this.m_syncElapsed += Time.deltaTime;
			if (this.m_syncElapsed < DataManager<ChijiDataManager>.GetInstance().MainRoleSyncPosInterval)
			{
				return;
			}
			this.m_syncElapsed = 0f;
			ActorMoveData moveData = base.ActorData.MoveData;
			if (this.m_oldMoveType != moveData.MoveType)
			{
				if (moveData.MoveType == EActorMoveType.TargetDir)
				{
					this.m_oldMoveDir = moveData.TargetDirection;
					this.m_oldTargetPos = Vector3.zero;
					this.m_moveDir = moveData.TargetDirection;
				}
				else if (moveData.MoveType == EActorMoveType.TargetPos)
				{
					this.m_oldMoveDir = Vector3.zero;
					this.m_oldTargetPos = moveData.TargetPosition;
					this.m_moveDir = (moveData.TargetPosition - moveData.Position).normalized;
				}
				else
				{
					this.m_oldMoveDir = Vector3.zero;
					this.m_oldTargetPos = Vector3.zero;
					this.m_moveDir = Vector3.zero;
				}
				this.m_oldMoveType = moveData.MoveType;
				this._SendSyncMoveMessage();
			}
			else if (moveData.MoveType != EActorMoveType.Invalid)
			{
				bool flag = false;
				if (moveData.MoveType == EActorMoveType.TargetDir && this.m_oldMoveDir != moveData.TargetDirection)
				{
					this.m_oldMoveDir = moveData.TargetDirection;
					this.m_moveDir = moveData.TargetDirection;
					this._SendSyncMoveMessage();
					flag = true;
				}
				else if (moveData.MoveType == EActorMoveType.TargetPos && this.m_oldTargetPos != moveData.TargetPosition)
				{
					this.m_oldTargetPos = moveData.TargetPosition;
					Vector3 normalized = (moveData.TargetPosition - moveData.Position).normalized;
					if (this.m_moveDir != normalized)
					{
						this.m_moveDir = normalized;
						this._SendSyncMoveMessage();
						flag = true;
					}
				}
				if (!flag)
				{
					this._SendSyncMoveMessage();
				}
			}
		}

		// Token: 0x0600A911 RID: 43281 RVA: 0x0023A3B8 File Offset: 0x002387B8
		private bool MoveRequireNeedSend(SceneMoveRequire newRequire)
		{
			if (this.mLastMoveRequire != null && newRequire != null && this.mLastMoveRequire.dir.faceRight == newRequire.dir.faceRight && this.mLastMoveRequire.dir.x == newRequire.dir.x && this.mLastMoveRequire.dir.y == newRequire.dir.y && this.mLastMoveRequire.pos.x == newRequire.pos.x && this.mLastMoveRequire.pos.y == newRequire.pos.y)
			{
				return false;
			}
			this.mLastMoveRequire = newRequire;
			return true;
		}

		// Token: 0x0600A912 RID: 43282 RVA: 0x0023A480 File Offset: 0x00238880
		protected void _SendSyncMoveMessage()
		{
			SceneMoveRequire sceneMoveRequire = new SceneMoveRequire
			{
				dir = new SceneDir
				{
					x = (short)(this.m_moveDir.x * this.m_axisScale),
					y = (short)(this.m_moveDir.z * this.m_axisScale),
					faceRight = ((!base.ActorData.MoveData.FaceRight) ? 0 : 1)
				},
				pos = new ScenePosition
				{
					x = (uint)(base.ActorData.MoveData.ServerPosition.x * this.m_axisScale),
					y = (uint)(base.ActorData.MoveData.ServerPosition.z * this.m_axisScale)
				}
			};
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				sceneMoveRequire.clientSceneId = (uint)clientSystemGameBattle.CurrentSceneID;
			}
			if (!this.MoveRequireNeedSend(sceneMoveRequire))
			{
				return;
			}
			NetManager.Instance().SendCommand<SceneMoveRequire>(ServerType.GATE_SERVER, sceneMoveRequire);
		}

		// Token: 0x0600A913 RID: 43283 RVA: 0x0023A591 File Offset: 0x00238991
		public void CommandMoveToScene(int a_sceneID, Vector3 a_vecPos)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			BeFighterMain.CommandStopAutoMove();
			BeFighterMain.m_autoMoveCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(BeFighterMain._AsyncMoveToScene(this._battle, a_sceneID, a_vecPos));
		}

		// Token: 0x0600A914 RID: 43284 RVA: 0x0023A5C0 File Offset: 0x002389C0
		protected static bool _CheckSystemValid(ClientSystemGameBattle a_system)
		{
			return a_system != null && a_system.MainPlayer != null;
		}

		// Token: 0x0600A915 RID: 43285 RVA: 0x0023A5D8 File Offset: 0x002389D8
		private static IEnumerator _AsyncAcrossScenes(ClientSystemGameBattle systemTown, int a_nTargetSceneID)
		{
			BeFighterMain.m_bAutoMoveSuccessed = true;
			if (!BeFighterMain._CheckSystemValid(systemTown))
			{
				BeFighterMain.m_bAutoMoveSuccessed = false;
				yield break;
			}
			if (systemTown.CurrentSceneID == a_nTargetSceneID)
			{
				BeFighterMain.m_bAutoMoveSuccessed = true;
				yield break;
			}
			List<Vector3> doorList = systemTown.GetMovePath(a_nTargetSceneID);
			if (doorList.Count <= 0)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("common_cannot_auto_move"), null, string.Empty, false);
				Logger.LogErrorFormat("跨地图寻路 >>> 无法自动移动到目标场景（ID:{0}）", new object[]
				{
					a_nTargetSceneID
				});
				BeFighterMain.m_bAutoMoveSuccessed = false;
				yield break;
			}
			while (doorList.Count > 0)
			{
				if (!BeFighterMain._CheckSystemValid(systemTown))
				{
					BeFighterMain.m_bAutoMoveSuccessed = false;
					yield break;
				}
				Vector3 targetPos = doorList[0];
				doorList.RemoveAt(0);
				systemTown.MainPlayer.CommandMoveTo(targetPos);
				if (systemTown.MainPlayer.MoveState != BeFighterMain.EMoveState.AutoMoving)
				{
					BeFighterMain.m_bAutoMoveSuccessed = false;
					yield break;
				}
				int oldSceneID = systemTown.CurrentSceneID;
				while (oldSceneID == systemTown.CurrentSceneID)
				{
					if (!BeFighterMain._CheckSystemValid(systemTown))
					{
						BeFighterMain.m_bAutoMoveSuccessed = false;
						yield break;
					}
					if (systemTown.MainPlayer.MoveState == BeFighterMain.EMoveState.AutoMoving)
					{
						yield return Yielders.EndOfFrame;
					}
					else
					{
						if (systemTown.MainPlayer.MoveState == BeFighterMain.EMoveState.Moveing)
						{
							BeFighterMain.m_bAutoMoveSuccessed = false;
							yield break;
						}
						if (!systemTown.MainPlayer._IsInSameGrid(targetPos, systemTown.MainPlayer.ActorData.MoveData.Position))
						{
							BeFighterMain.m_bAutoMoveSuccessed = false;
							yield break;
						}
						yield return Yielders.EndOfFrame;
					}
				}
			}
			yield break;
		}

		// Token: 0x0600A916 RID: 43286 RVA: 0x0023A5FC File Offset: 0x002389FC
		private static IEnumerator _AsyncMoveToScene(ClientSystemGameBattle a_systemTown, int a_nTargetSceneID, Vector3 a_vecTargetPos)
		{
			yield return BeFighterMain._AsyncAcrossScenes(a_systemTown, a_nTargetSceneID);
			if (!BeFighterMain.m_bAutoMoveSuccessed)
			{
				BeFighterMain.OnAutoMoveFail.Invoke();
				BeFighterMain.m_autoMoveCoroutine = null;
				BeFighterMain.m_bAutoMoveSuccessed = true;
				yield break;
			}
			yield return BeFighterMain._AsyncMoveToTargetPos(a_systemTown, a_vecTargetPos);
			if (!BeFighterMain.m_bAutoMoveSuccessed)
			{
				BeFighterMain.OnAutoMoveFail.Invoke();
			}
			else
			{
				BeFighterMain.OnAutoMoveSuccess.Invoke();
			}
			BeFighterMain.m_autoMoveCoroutine = null;
			BeFighterMain.m_bAutoMoveSuccessed = true;
			yield break;
		}

		// Token: 0x0600A917 RID: 43287 RVA: 0x0023A628 File Offset: 0x00238A28
		private static IEnumerator _AsyncMoveToTargetPos(ClientSystemGameBattle a_systemTown, Vector3 a_pos)
		{
			BeFighterMain.m_bAutoMoveSuccessed = true;
			if (!BeFighterMain._CheckSystemValid(a_systemTown))
			{
				BeFighterMain.m_bAutoMoveSuccessed = false;
				yield break;
			}
			a_systemTown.MainPlayer.CommandMoveTo(a_pos);
			while (BeFighterMain._CheckSystemValid(a_systemTown))
			{
				if (a_systemTown.MainPlayer.MoveState == BeFighterMain.EMoveState.AutoMoving)
				{
					yield return Yielders.EndOfFrame;
				}
				else
				{
					if (a_systemTown.MainPlayer.MoveState == BeFighterMain.EMoveState.Moveing)
					{
						BeFighterMain.m_bAutoMoveSuccessed = false;
						yield break;
					}
					if (a_systemTown.MainPlayer._IsInSameGrid(a_pos, a_systemTown.MainPlayer.ActorData.MoveData.Position))
					{
						BeFighterMain.m_bAutoMoveSuccessed = true;
					}
					else
					{
						BeFighterMain.m_bAutoMoveSuccessed = false;
					}
					yield break;
				}
			}
			BeFighterMain.m_bAutoMoveSuccessed = false;
			yield break;
			yield break;
		}

		// Token: 0x0600A918 RID: 43288 RVA: 0x0023A64C File Offset: 0x00238A4C
		protected bool _IsInSameGrid(Vector3 posA, Vector3 posB)
		{
			PathFinding.Grid grid = new PathFinding.Grid(this._battle.GridInfo, posA);
			PathFinding.Grid grid2 = new PathFinding.Grid(this._battle.GridInfo, posB);
			return grid.X == grid2.X && grid.Y == grid2.Y;
		}

		// Token: 0x0600A919 RID: 43289 RVA: 0x0023A6A5 File Offset: 0x00238AA5
		public static void CommandStopAutoMove()
		{
			if (BeFighterMain.m_autoMoveCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(BeFighterMain.m_autoMoveCoroutine);
				BeFighterMain.m_autoMoveCoroutine = null;
				BeFighterMain.OnAutoMoveFail.Invoke();
			}
		}

		// Token: 0x0600A91A RID: 43290 RVA: 0x0023A6D0 File Offset: 0x00238AD0
		public int GetPKDungeonID()
		{
			Dictionary<int, object>.Enumerator enumerator = Singleton<TableManager>.GetInstance().GetTable<ChiJiPkSceneTable>().GetEnumerator();
			float num = base.ActorData.MoveData.ServerPosition.x * DataManager<PlayerBaseData>.GetInstance().AxisScale;
			float num2 = base.ActorData.MoveData.ServerPosition.z * DataManager<PlayerBaseData>.GetInstance().AxisScale;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				ChiJiPkSceneTable chiJiPkSceneTable = keyValuePair.Value as ChiJiPkSceneTable;
				if (chiJiPkSceneTable != null)
				{
					if (chiJiPkSceneTable.SceneRangeLength == 4)
					{
						int num3 = chiJiPkSceneTable.SceneRangeArray(0);
						int num4 = chiJiPkSceneTable.SceneRangeArray(1);
						int num5 = chiJiPkSceneTable.SceneRangeArray(2);
						int num6 = chiJiPkSceneTable.SceneRangeArray(3);
						if ((float)num3 <= num && num <= (float)num4 && (float)num5 <= num2 && num2 <= (float)num6)
						{
							return chiJiPkSceneTable.DungeonID;
						}
					}
				}
			}
			return 60;
		}

		// Token: 0x04005E5B RID: 24155
		private bool m_bEnable = true;

		// Token: 0x04005E5C RID: 24156
		private List<BeItem> mNeareastItems = new List<BeItem>();

		// Token: 0x04005E5D RID: 24157
		protected Vector3 m_moveDir = Vector3.zero;

		// Token: 0x04005E5E RID: 24158
		protected Vector3 m_oldMoveDir = Vector3.zero;

		// Token: 0x04005E5F RID: 24159
		protected Vector3 m_oldTargetPos = Vector3.zero;

		// Token: 0x04005E60 RID: 24160
		protected EActorMoveType m_oldMoveType = EActorMoveType.Invalid;

		// Token: 0x04005E61 RID: 24161
		protected float m_syncElapsed;

		// Token: 0x04005E62 RID: 24162
		protected float m_axisScale = 10000f;

		// Token: 0x04005E63 RID: 24163
		private static Coroutine m_autoMoveCoroutine;

		// Token: 0x04005E64 RID: 24164
		private static bool m_bAutoMoveSuccessed = true;

		// Token: 0x04005E65 RID: 24165
		private float xGlobalMinDist = 5f;

		// Token: 0x04005E66 RID: 24166
		private float yGlobalMinDist = 8f;

		// Token: 0x04005E67 RID: 24167
		private SceneMoveRequire mLastMoveRequire;

		// Token: 0x02001149 RID: 4425
		public enum EMoveState
		{
			// Token: 0x04005E69 RID: 24169
			Invalid = -1,
			// Token: 0x04005E6A RID: 24170
			Idle,
			// Token: 0x04005E6B RID: 24171
			Moveing,
			// Token: 0x04005E6C RID: 24172
			AutoMoving
		}

		// Token: 0x0200114A RID: 4426
		public class MoveStateChangedEvent : UnityEvent<BeFighterMain.EMoveState, BeFighterMain.EMoveState>
		{
		}

		// Token: 0x0200114B RID: 4427
		public class AutoMoveSuccessEvent : UnityEvent
		{
		}

		// Token: 0x0200114C RID: 4428
		public class AutoMoveFailEvent : UnityEvent
		{
		}

		// Token: 0x0200114D RID: 4429
		public class MoveingEvent : UnityEvent<Vector3>
		{
		}

		// Token: 0x0200114E RID: 4430
		public class AutoMoveingEvent : UnityEvent<Vector3>
		{
		}
	}
}

using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200118C RID: 4492
	internal class BeTownDoor : BeBaseActor
	{
		// Token: 0x0600ABE7 RID: 44007 RVA: 0x0024F038 File Offset: 0x0024D438
		public BeTownDoor(BeTownDoorData data, ClientSystemTown systemTown) : base(data, systemTown)
		{
			this.m_doorData = data.Door;
			if (this._isInRegion(this._systemTown.MainPlayer.ActorData.MoveData.Position))
			{
				this.mState = BeRegionState.In;
			}
			else
			{
				this.mState = BeRegionState.Out;
			}
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(this.m_doorData.GetTargetSceneID(), string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("BeTownDoor targetScene table id {0} is not exist!!", new object[]
				{
					this.m_doorData.GetTargetSceneID()
				});
				return;
			}
			this.opened = ((int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.LevelLimit);
		}

		// Token: 0x17001A50 RID: 6736
		// (get) Token: 0x0600ABE8 RID: 44008 RVA: 0x0024F10F File Offset: 0x0024D50F
		// (set) Token: 0x0600ABE9 RID: 44009 RVA: 0x0024F117 File Offset: 0x0024D517
		private bool opened
		{
			get
			{
				return this.m_bOpened;
			}
			set
			{
				if (this.m_bOpened != value)
				{
					this.m_bOpened = value;
					this.m_bDirty = true;
				}
			}
		}

		// Token: 0x0600ABEA RID: 44010 RVA: 0x0024F134 File Offset: 0x0024D534
		public override void InitGeActor(GeSceneEx geScene)
		{
			if (geScene == null)
			{
				return;
			}
			if (this._geActor == null)
			{
				SceneRegionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SceneRegionTable>(this.m_doorData.GetRegionInfo().GetEntityInfo().GetResid(), string.Empty, string.Empty);
				if (tableItem != null)
				{
					this._geActor = geScene.CreateActor(tableItem.ResID, 0, 0, false, false, true, false);
					GameObject entityNode = this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
					if (null != entityNode)
					{
						this.m_geDoorEffect = entityNode.GetComponentInChildren<GeTownDoorEffect>();
					}
				}
				else
				{
					Logger.LogErrorFormat("door id:{0} can not find!", new object[]
					{
						this.m_doorData.GetRegionInfo().GetEntityInfo().GetResid()
					});
				}
			}
			base.InitGeActor(geScene);
		}

		// Token: 0x0600ABEB RID: 44011 RVA: 0x0024F1FC File Offset: 0x0024D5FC
		public override void Update(float deltaTime)
		{
			if (this.m_bDestroied)
			{
				return;
			}
			this.opened = ((int)DataManager<PlayerBaseData>.GetInstance().Level >= this.m_nLevelLimit);
			if (this._systemTown.MainPlayer == null)
			{
				return;
			}
			if (this.mState == BeRegionState.Out)
			{
				if (this._isInRegion(this._systemTown.MainPlayer.ActorData.MoveData.Position) && this.IsDoorCanTrigger())
				{
					this.OnTrigger.Invoke(this.m_doorData);
					this.mState = BeRegionState.In;
				}
			}
			else if (this.mState == BeRegionState.In && !this._isInRegion(this._systemTown.MainPlayer.ActorData.MoveData.Position))
			{
				this.mState = BeRegionState.Out;
			}
		}

		// Token: 0x0600ABEC RID: 44012 RVA: 0x0024F2D2 File Offset: 0x0024D6D2
		public override void UpdateGeActor(float timeElapsed)
		{
			if (this.m_bDirty && this.m_geDoorEffect != null)
			{
				this.m_geDoorEffect.SetDoorOpen(this.m_bOpened);
				this.m_bDirty = false;
			}
			base.UpdateGeActor(timeElapsed);
		}

		// Token: 0x0600ABED RID: 44013 RVA: 0x0024F30F File Offset: 0x0024D70F
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600ABEE RID: 44014 RVA: 0x0024F318 File Offset: 0x0024D718
		private bool _isInRegion(Vector3 pos)
		{
			Vector3 vector = pos;
			if (this.m_doorData.GetRegionInfo().GetRegiontype() == DRegionInfo.RegionType.Circle)
			{
				float num = Vector3.Distance(this.m_doorData.GetRegionInfo().GetEntityInfo().GetPosition(), vector);
				return num <= this.m_doorData.GetRegionInfo().GetRadius();
			}
			if (this.m_doorData.GetRegionInfo().GetRegiontype() == DRegionInfo.RegionType.Rectangle)
			{
				Vector3 position = this.m_doorData.GetRegionInfo().GetEntityInfo().GetPosition();
				Vector2 rect = this.m_doorData.GetRegionInfo().GetRect();
				Vector2 vector2;
				vector2..ctor(position.x - rect.x / 2f, position.z - rect.y / 2f);
				Vector2 vector3;
				vector3..ctor(position.x + rect.x / 2f, position.z + rect.y / 2f);
				return vector.x >= vector2.x && vector.z >= vector2.y && vector.x <= vector3.x && vector.z <= vector3.y;
			}
			return false;
		}

		// Token: 0x0600ABEF RID: 44015 RVA: 0x0024F468 File Offset: 0x0024D868
		private bool IsDoorCanTrigger()
		{
			if (this._systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving && this._systemTown.MainPlayer.ActorData.MoveData.MoveType == EActorMoveType.TargetPos)
			{
				Vector3 targetPosition = this._systemTown.MainPlayer.ActorData.MoveData.TargetPosition;
				Vector3 position = this.m_doorData.GetRegionInfo().GetEntityInfo().GetPosition();
				if ((double)Vector3.SqrMagnitude(targetPosition - position) > 0.0001)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04006068 RID: 24680
		private ISceneTownDoorData m_doorData;

		// Token: 0x04006069 RID: 24681
		private int m_nLevelLimit;

		// Token: 0x0400606A RID: 24682
		private bool m_bOpened;

		// Token: 0x0400606B RID: 24683
		private bool m_bDirty = true;

		// Token: 0x0400606C RID: 24684
		private BeRegionState mState = BeRegionState.Out;

		// Token: 0x0400606D RID: 24685
		private GeTownDoorEffect m_geDoorEffect;

		// Token: 0x0400606E RID: 24686
		public OnDoorTrigger OnTrigger = new OnDoorTrigger();
	}
}

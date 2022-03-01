using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A34 RID: 6708
	internal class BeTownBlackMarketMerchanNPC : BeTownNPC
	{
		// Token: 0x06010797 RID: 67479 RVA: 0x004A37D8 File Offset: 0x004A1BD8
		public BeTownBlackMarketMerchanNPC(BeTownNPCData data, ClientSystemTown systemTown) : base(data, systemTown)
		{
		}

		// Token: 0x06010798 RID: 67480 RVA: 0x004A382C File Offset: 0x004A1C2C
		public sealed override void InitGeActor(GeSceneEx geScene)
		{
			if (geScene == null)
			{
				return;
			}
			try
			{
				if (this._geActor == null)
				{
					this.mBeTownNPCData = (this._data as BeTownNPCData);
					if (this.mBeTownNPCData != null)
					{
						this.mNpcTable = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this.mBeTownNPCData.NpcID, string.Empty, string.Empty);
						if (this.mNpcTable != null)
						{
							this._geScene = geScene;
							if (EngineConfig.useTMEngine)
							{
								this._geActor = geScene.CreateActorAsyncEx(this.mBeTownNPCData.ResourceID, 0, this.mNpcTable.Height, false, false, true, null);
							}
							else
							{
								this._geActor = geScene.CreateActorAsync(this.mBeTownNPCData.ResourceID, 0, this.mNpcTable.Height, false, false, true);
							}
							if (this._geActor != null)
							{
								base.ActorData.MoveData.TransformDirty = true;
								this.UpdateGeActor(0f);
								this._geActor.SuitAvatar(true, false, 0);
								this.AddBlackMarketMerchanComponent();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._geActor = null;
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x06010799 RID: 67481 RVA: 0x004A3980 File Offset: 0x004A1D80
		protected void AddBlackMarketMerchanComponent()
		{
			if (this.mBeTownNPCData == null || this._geActor == null)
			{
				return;
			}
			this._geActor.PushPostLoadCommand(delegate
			{
				if (this._geActor == null || this.mBeTownNPCData == null || this.mNpcTable == null)
				{
					return;
				}
				this.AddBlackMarketMerchanFunction();
				this.AddBlackMarketMerchanNpcDialog();
				this.SetBlackMarketMerchanMoveStates();
			});
		}

		// Token: 0x0601079A RID: 67482 RVA: 0x004A39B0 File Offset: 0x004A1DB0
		private void AddBlackMarketMerchanFunction()
		{
			this._geActor.AddNpcInteraction(this.mBeTownNPCData.NpcID, 0UL);
			float nameLocalPosY = 0f;
			if (this.mNpcTable.NameLocalPosY > 0)
			{
				nameLocalPosY = (float)this.mNpcTable.NameLocalPosY / 1000f;
			}
			this._geActor.AddNPCFunction(this.mBeTownNPCData.Name, this.mBeTownNPCData.NameColor, 0, null, nameLocalPosY);
		}

		// Token: 0x0601079B RID: 67483 RVA: 0x004A3A24 File Offset: 0x004A1E24
		private void AddBlackMarketMerchanNpcDialog()
		{
			this._geActor.AddComponentDialog(this.mBeTownNPCData.NpcID, NpcDialogComponent.IdBelong2.IdBelong2_NpcTable);
			if (this._geActor.NpcDialogComponent == null)
			{
				return;
			}
			this._geActor.NpcDialogComponent.SetContentText();
			this._dialogComponentController = this._geActor.NpcDialogComponent.transform.gameObject.GetComponent<BeTownAttackCityMonsterDialogComponentController>();
			if (this._dialogComponentController == null)
			{
				this._dialogComponentController = this._geActor.NpcDialogComponent.transform.gameObject.AddComponent<BeTownAttackCityMonsterDialogComponentController>();
			}
			if (this._dialogComponentController == null)
			{
				return;
			}
			this._dialogComponentController.InitController(this.mBeTownNPCData.NpcID);
			Transform parent = this._geActor.NpcDialogComponent.transform.parent;
			if (parent == null)
			{
				return;
			}
			if (this.mNpcTable.NameLocalPosY > 0)
			{
				Vector3 localPosition = parent.transform.localPosition;
				parent.transform.localPosition = new Vector3(localPosition.x, (float)this.mNpcTable.NameLocalPosY / 1000f + 0.5f, localPosition.z);
				Vector3 localPosition2 = this._dialogComponentController.transform.localPosition;
				this._dialogComponentController.transform.localPosition = new Vector3(0f, 0f, localPosition2.z);
			}
			GameObject goInfoBar = this._geActor.goInfoBar;
			if (goInfoBar == null)
			{
				return;
			}
			Vector3 localPosition3 = goInfoBar.transform.localPosition;
			goInfoBar.transform.localPosition = new Vector3(1.3f, localPosition3.y, localPosition3.z);
		}

		// Token: 0x0601079C RID: 67484 RVA: 0x004A3BE0 File Offset: 0x004A1FE0
		private void AdjustNameNpcDialogPostion(bool direction)
		{
			GameObject goInfoBar = this._geActor.goInfoBar;
			if (goInfoBar == null)
			{
				return;
			}
			Transform parent = this._geActor.NpcDialogComponent.transform.parent;
			if (parent == null)
			{
				return;
			}
			if (direction)
			{
				Vector3 localPosition = goInfoBar.transform.localPosition;
				goInfoBar.transform.localPosition = new Vector3(1.3f, localPosition.y, localPosition.z);
				Vector3 localPosition2 = parent.transform.localPosition;
				parent.transform.localPosition = new Vector3(1.1f, localPosition2.y, localPosition2.z);
			}
			else
			{
				Vector3 localPosition3 = goInfoBar.transform.localPosition;
				goInfoBar.transform.localPosition = new Vector3(-1.4f, localPosition3.y, localPosition3.z);
				Vector3 localPosition4 = parent.transform.localPosition;
				parent.transform.localPosition = new Vector3(-1.6f, localPosition4.y, localPosition4.z);
			}
		}

		// Token: 0x0601079D RID: 67485 RVA: 0x004A3CF2 File Offset: 0x004A20F2
		private void AddBlackMarketMerchanNpcFootShadow()
		{
			this._geActor.CreateFootIndicator("Effects/Eff_Tongyong/Prefab/Eff_Tongyong_guaiwugongcheng_quan");
		}

		// Token: 0x0601079E RID: 67486 RVA: 0x004A3D04 File Offset: 0x004A2104
		public sealed override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			this.UpdateDialogComponentController(deltaTime);
		}

		// Token: 0x0601079F RID: 67487 RVA: 0x004A3D14 File Offset: 0x004A2114
		private void UpdateDialogComponentController(float deltaTime)
		{
			if (this._dialogComponentController != null)
			{
				this._dialogComponentController.OnUpdate(deltaTime);
			}
		}

		// Token: 0x060107A0 RID: 67488 RVA: 0x004A3D33 File Offset: 0x004A2133
		private void SetBlackMarketMerchanMoveStates()
		{
			this.InitBlackMarketMerchanMoveStates();
			this.mAnimTownIdle01Interval = this._geActor.GetActionTimeLen("Anim_Town_Idle_01");
		}

		// Token: 0x060107A1 RID: 67489 RVA: 0x004A3D54 File Offset: 0x004A2154
		private void InitBlackMarketMerchanMoveStates()
		{
			if (this.mBeTownNPCData == null)
			{
				return;
			}
			if (this.mBeTownNPCData.TownNpcType != ESceneActorType.BlackMarketMerchanNpc)
			{
				return;
			}
			this.mMoveSpeed = new Vector3(0.4f, 0f, 0f);
			this._geActor.AddSimpleShadow(Vector3.one);
			this.mBeTownNPCData.MoveData.FaceRight = true;
			this.mEndVet3 = new Vector3(BlackMarketMerchantDataManager.BlackMarketMerchantEndPos, 0f, 0f);
			this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
			this.mIdleTime = this.RandomIdleTime();
			this.mBornPosition = this.mBeTownNPCData.MoveData.Position;
			this.SetAnimationAction("Anim_Idle");
			this.SetNpcMoveTarget();
		}

		// Token: 0x060107A2 RID: 67490 RVA: 0x004A3E0E File Offset: 0x004A220E
		private float RandomIdleTime()
		{
			return Random.Range(BlackMarketMerchantDataManager.BlackMarketMerchantRandomPlayerNextAniamtionMinTime, BlackMarketMerchantDataManager.BlackMarketMerchantRandomPlayerNextAniamtionMaxTime);
		}

		// Token: 0x060107A3 RID: 67491 RVA: 0x004A3E20 File Offset: 0x004A2220
		private void SetNpcMoveTarget()
		{
			if (!this.mBeTownNPCData.MoveData.FaceRight)
			{
				this.mTargetPosition = this.mBeTownNPCData.MoveData.Position + new Vector3(-1f * Random.Range(4.1f, 4.3f), 0f, 0f);
				this.mTargetOffsetPosition = this.mTargetPosition - this.mBeTownNPCData.MoveData.Position;
			}
			else
			{
				this.mTargetPosition = this.mBeTownNPCData.MoveData.Position + new Vector3(1f * Random.Range(4.1f, 4.3f), 0f, 0f);
				this.mTargetOffsetPosition = this.mTargetPosition - this.mBeTownNPCData.MoveData.Position;
			}
			this.AdjustNameNpcDialogPostion(this.mBeTownNPCData.MoveData.FaceRight);
		}

		// Token: 0x060107A4 RID: 67492 RVA: 0x004A3F1D File Offset: 0x004A231D
		public override void UpdateMove(float timeElapsed)
		{
			if (this.mETownNpcMoveState == ETownAttackCityMonsterMoveState.Invalid)
			{
				base.UpdateMove(timeElapsed);
			}
			else
			{
				this.UpdateNpcMoveAi(timeElapsed);
			}
		}

		// Token: 0x060107A5 RID: 67493 RVA: 0x004A3F40 File Offset: 0x004A2340
		private void UpdateNpcMoveAi(float timeElapsed)
		{
			if (this.mETownNpcMoveState == ETownAttackCityMonsterMoveState.Invalid)
			{
				return;
			}
			switch (this.mETownNpcMoveState)
			{
			case ETownAttackCityMonsterMoveState.BornIdle:
				this.UpdateBornIdleState(timeElapsed);
				break;
			case ETownAttackCityMonsterMoveState.ForwardMove:
				this.UpdateForwardMoveState(timeElapsed);
				break;
			case ETownAttackCityMonsterMoveState.MoveIdle:
				this.UpdateMoveIdleState(timeElapsed);
				break;
			case ETownAttackCityMonsterMoveState.BackMove:
				this.UpdateBackMoveState(timeElapsed);
				break;
			case ETownAttackCityMonsterMoveState.TownIdle01:
				this.UpdateTownIdle01State(timeElapsed);
				break;
			}
		}

		// Token: 0x060107A6 RID: 67494 RVA: 0x004A3FBC File Offset: 0x004A23BC
		private void UpdateBornIdleState(float timeElapsed)
		{
			if (this.mIdleTime > 0f)
			{
				this.mIdleTime -= timeElapsed;
				return;
			}
			this.SetNextStateOfBornIdle();
		}

		// Token: 0x060107A7 RID: 67495 RVA: 0x004A3FE3 File Offset: 0x004A23E3
		private void SetNextStateOfBornIdle()
		{
			if (this.mBeTownNPCData.MoveData.FaceRight)
			{
				this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.ForwardMove;
			}
			else
			{
				this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.BackMove;
			}
			this.SetAnimationAction("Anim_Walk");
		}

		// Token: 0x060107A8 RID: 67496 RVA: 0x004A4018 File Offset: 0x004A2418
		private void UpdateForwardMoveState(float timeElapsed)
		{
			if (base._CheckPosEqual(this.mTargetPosition, this.mBeTownNPCData.MoveData.Position) || (this.mTargetOffsetPosition.x < 0f && this.mBeTownNPCData.MoveData.Position.x < this.mTargetPosition.x) || (this.mTargetOffsetPosition.x > 0f && this.mBeTownNPCData.MoveData.Position.x > this.mTargetPosition.x))
			{
				this.mBeTownNPCData.MoveData.Position = this.mTargetPosition;
				if ((this.mEndVet3 - this.mBeTownNPCData.MoveData.Position).x <= 0.6f)
				{
					this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.MoveIdle;
					this.mIdleTime = this.RandomIdleTime();
					this.SetAnimationAction("Anim_Idle");
				}
				else
				{
					this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
					this.mIdleTime = this.RandomIdleTime();
					this.SetAnimationAction("Anim_Idle");
					this.SetNpcMoveTarget();
				}
				return;
			}
			this.mBeTownNPCData.MoveData.Position = this.mBeTownNPCData.MoveData.Position + (float)((this.mTargetOffsetPosition.x >= 0f) ? 4 : -4) * timeElapsed * this.mMoveSpeed;
		}

		// Token: 0x060107A9 RID: 67497 RVA: 0x004A41A0 File Offset: 0x004A25A0
		private void UpdateMoveIdleState(float timeElapsed)
		{
			if (this.mIdleTime > 0f)
			{
				this.mIdleTime -= timeElapsed;
				return;
			}
			if (this.mBeTownNPCData.MoveData.FaceRight)
			{
				this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.BackMove;
			}
			else
			{
				this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.ForwardMove;
			}
			this.mBeTownNPCData.MoveData.FaceRight = !this.mBeTownNPCData.MoveData.FaceRight;
			this.SetAnimationAction("Anim_Walk");
			this.SetNpcMoveTarget();
		}

		// Token: 0x060107AA RID: 67498 RVA: 0x004A4228 File Offset: 0x004A2628
		private void UpdateBackMoveState(float timeElapsed)
		{
			if (base._CheckPosEqual(this.mBeTownNPCData.MoveData.Position, this.mTargetPosition) || (this.mTargetOffsetPosition.x < 0f && this.mBeTownNPCData.MoveData.Position.x < this.mTargetPosition.x) || (this.mTargetOffsetPosition.x > 0f && this.mBeTownNPCData.MoveData.Position.x > this.mTargetPosition.x))
			{
				this.mBeTownNPCData.MoveData.Position = this.mTargetPosition;
				if ((this.mBeTownNPCData.MoveData.Position - this.mBornPosition).x <= 0.6f)
				{
					this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.MoveIdle;
					this.mIdleTime = this.RandomIdleTime();
					this.SetAnimationAction("Anim_Idle");
				}
				else
				{
					this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
					this.mIdleTime = this.RandomIdleTime();
					this.SetAnimationAction("Anim_Idle");
					this.SetNpcMoveTarget();
				}
				return;
			}
			this.mBeTownNPCData.MoveData.Position = this.mBeTownNPCData.MoveData.Position + (float)((this.mTargetOffsetPosition.x >= 0f) ? 4 : -4) * timeElapsed * this.mMoveSpeed;
		}

		// Token: 0x060107AB RID: 67499 RVA: 0x004A43B0 File Offset: 0x004A27B0
		private void UpdateTownIdle01State(float timeElapsed)
		{
			if (this.mTownIdle01Time > 0f)
			{
				this.mTownIdle01Time -= timeElapsed;
				return;
			}
			this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
			this.mIdleTime = this.RandomIdleTime();
			this.SetAnimationAction("Anim_Idle");
		}

		// Token: 0x060107AC RID: 67500 RVA: 0x004A43EF File Offset: 0x004A27EF
		private void SetAnimationAction(string animationAction)
		{
			this.mBeTownNPCData.ActionData.ActionName = animationAction;
		}

		// Token: 0x060107AD RID: 67501 RVA: 0x004A4402 File Offset: 0x004A2802
		public sealed override void Dispose()
		{
			base.Dispose();
			this.mBeTownNPCData = null;
			this.mNpcTable = null;
			this.mETownNpcMoveState = ETownAttackCityMonsterMoveState.Invalid;
			this._dialogComponentController = null;
		}

		// Token: 0x0400A787 RID: 42887
		private const string mFootSfxPath = "Effects/Eff_Tongyong/Prefab/Eff_Tongyong_guaiwugongcheng_quan";

		// Token: 0x0400A788 RID: 42888
		private const string mStrAnimTownWalk = "Anim_Walk";

		// Token: 0x0400A789 RID: 42889
		private const string mStrAnimTownIdle = "Anim_Idle";

		// Token: 0x0400A78A RID: 42890
		private const string mStrAnimTownIdle01 = "Anim_Town_Idle_01";

		// Token: 0x0400A78B RID: 42891
		private float mIdleTime;

		// Token: 0x0400A78C RID: 42892
		private ETownAttackCityMonsterMoveState mETownNpcMoveState = ETownAttackCityMonsterMoveState.Invalid;

		// Token: 0x0400A78D RID: 42893
		private Vector3 mBornPosition = Vector3.zero;

		// Token: 0x0400A78E RID: 42894
		private Vector3 mTargetPosition = Vector3.zero;

		// Token: 0x0400A78F RID: 42895
		private Vector3 mTargetOffsetPosition = Vector3.zero;

		// Token: 0x0400A790 RID: 42896
		private float mAnimTownIdle01Interval;

		// Token: 0x0400A791 RID: 42897
		private float mTownIdle01Time;

		// Token: 0x0400A792 RID: 42898
		private Vector3 mMoveSpeed = Vector3.zero;

		// Token: 0x0400A793 RID: 42899
		private Vector3 mEndVet3 = Vector3.zero;

		// Token: 0x0400A794 RID: 42900
		private BeTownNPCData mBeTownNPCData;

		// Token: 0x0400A795 RID: 42901
		private NpcTable mNpcTable;

		// Token: 0x0400A796 RID: 42902
		private BeTownAttackCityMonsterDialogComponentController _dialogComponentController;
	}
}

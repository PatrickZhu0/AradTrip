using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001188 RID: 4488
	internal class BeTownAttackCityMonster : BeTownNPC
	{
		// Token: 0x0600ABCB RID: 43979 RVA: 0x0024E414 File Offset: 0x0024C814
		public BeTownAttackCityMonster(BeTownNPCData data, ClientSystemTown systemTown) : base(data, systemTown)
		{
		}

		// Token: 0x0600ABCC RID: 43980 RVA: 0x0024E454 File Offset: 0x0024C854
		public override void InitGeActor(GeSceneEx geScene)
		{
			if (geScene == null)
			{
				return;
			}
			try
			{
				if (this._geActor == null)
				{
					this._townData = (this._data as BeTownNPCData);
					if (this._townData != null)
					{
						this._npcItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this._townData.NpcID, string.Empty, string.Empty);
						if (this._npcItem != null)
						{
							this._geScene = geScene;
							if (EngineConfig.useTMEngine)
							{
								this._geActor = geScene.CreateActorAsyncEx(this._townData.ResourceID, 0, this._npcItem.Height, false, false, true, null);
							}
							else
							{
								this._geActor = geScene.CreateActorAsync(this._townData.ResourceID, 0, this._npcItem.Height, false, false, true);
							}
							if (this._geActor != null)
							{
								base.ActorData.MoveData.TransformDirty = true;
								this.UpdateGeActor(0f);
								this._geActor.SuitAvatar(true, false, 0);
								this.AddAttackCityMonsterComponent();
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

		// Token: 0x0600ABCD RID: 43981 RVA: 0x0024E5A8 File Offset: 0x0024C9A8
		protected void AddAttackCityMonsterComponent()
		{
			if (this._townData == null || this._geActor == null)
			{
				return;
			}
			this._geActor.PushPostLoadCommand(delegate
			{
				if (this._geActor == null || this._townData == null || this._npcItem == null)
				{
					return;
				}
				this.AddAttackCityMonsterFunction();
				this.AddAttackCityMonsterDialog();
				this.AddAttackCityMonsterFootShadow();
				this.SetAttackCityMonsterMoveStates();
			});
		}

		// Token: 0x0600ABCE RID: 43982 RVA: 0x0024E5D8 File Offset: 0x0024C9D8
		private void AddAttackCityMonsterFunction()
		{
			this._geActor.AddNpcInteraction(this._townData.NpcID, this._townData.GUID);
			float nameLocalPosY = 0f;
			if (this._npcItem.NameLocalPosY > 0)
			{
				nameLocalPosY = (float)this._npcItem.NameLocalPosY / 1000f;
			}
			this._geActor.AddNPCFunction(this._townData.Name, this._townData.NameColor, 0, null, nameLocalPosY);
		}

		// Token: 0x0600ABCF RID: 43983 RVA: 0x0024E654 File Offset: 0x0024CA54
		private void AddAttackCityMonsterDialog()
		{
			this._geActor.AddComponentDialog(this._townData.NpcID, NpcDialogComponent.IdBelong2.IdBelong2_NpcTable);
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
			this._dialogComponentController.InitController(this._townData.NpcID);
			Transform parent = this._geActor.NpcDialogComponent.transform.parent;
			if (parent == null)
			{
				return;
			}
			if (this._npcItem.NameLocalPosY > 0)
			{
				Vector3 localPosition = parent.transform.localPosition;
				parent.transform.localPosition = new Vector3(localPosition.x, (float)this._npcItem.NameLocalPosY / 1000f + 0.5f, localPosition.z);
				Vector3 localPosition2 = this._dialogComponentController.transform.localPosition;
				this._dialogComponentController.transform.localPosition = new Vector3(0f, 0f, localPosition2.z);
			}
		}

		// Token: 0x0600ABD0 RID: 43984 RVA: 0x0024E7C5 File Offset: 0x0024CBC5
		private void AddAttackCityMonsterFootShadow()
		{
			this._geActor.CreateFootIndicator("Effects/Eff_Tongyong/Prefab/Eff_Tongyong_guaiwugongcheng_quan");
		}

		// Token: 0x0600ABD1 RID: 43985 RVA: 0x0024E7D7 File Offset: 0x0024CBD7
		private void SetAttackCityMonsterMoveStates()
		{
			this.InitAttackCityMonsterMoveStates();
			this._animTownIdle01Interval = this._geActor.GetActionTimeLen("Anim_Town_Idle_01");
		}

		// Token: 0x0600ABD2 RID: 43986 RVA: 0x0024E7F5 File Offset: 0x0024CBF5
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			this.UpdateDialogComponentController(deltaTime);
		}

		// Token: 0x0600ABD3 RID: 43987 RVA: 0x0024E805 File Offset: 0x0024CC05
		private void UpdateDialogComponentController(float deltaTime)
		{
			if (this._dialogComponentController != null)
			{
				this._dialogComponentController.OnUpdate(deltaTime);
			}
		}

		// Token: 0x0600ABD4 RID: 43988 RVA: 0x0024E824 File Offset: 0x0024CC24
		private void InitAttackCityMonsterMoveStates()
		{
			if (this._townData == null)
			{
				return;
			}
			if (this._townData.TownNpcType != ESceneActorType.AttackCityMonster)
			{
				return;
			}
			this._moveSpeed = new Vector3(1f, 0f, 0f);
			this._geActor.AddSimpleShadow(Vector3.one);
			this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
			this._idleTime = Random.Range(4f, 8f);
			this._bornPosition = this._townData.MoveData.Position;
			this.SetNpcMoveTarget();
		}

		// Token: 0x0600ABD5 RID: 43989 RVA: 0x0024E8B4 File Offset: 0x0024CCB4
		private void SetNpcMoveTarget()
		{
			int num = Random.Range(1, 7);
			if (num <= 3)
			{
				this._targetPosition = this._bornPosition + new Vector3(-1f * Random.Range(1.1f, 1.3f), 0f, 0f);
				this._targetOffsetPosition = this._targetPosition - this._bornPosition;
			}
			else
			{
				this._targetPosition = this._bornPosition + new Vector3(1f * Random.Range(1.1f, 1.3f), 0f, 0f);
				this._targetOffsetPosition = this._targetPosition - this._bornPosition;
			}
		}

		// Token: 0x0600ABD6 RID: 43990 RVA: 0x0024E96D File Offset: 0x0024CD6D
		public override void UpdateMove(float timeElapsed)
		{
			if (this._eTownNpcMoveState == ETownAttackCityMonsterMoveState.Invalid)
			{
				base.UpdateMove(timeElapsed);
			}
			else
			{
				this.UpdateNpcMoveAi(timeElapsed);
			}
		}

		// Token: 0x0600ABD7 RID: 43991 RVA: 0x0024E990 File Offset: 0x0024CD90
		private void UpdateNpcMoveAi(float timeElapsed)
		{
			if (this._eTownNpcMoveState == ETownAttackCityMonsterMoveState.Invalid)
			{
				return;
			}
			switch (this._eTownNpcMoveState)
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

		// Token: 0x0600ABD8 RID: 43992 RVA: 0x0024EA0C File Offset: 0x0024CE0C
		private void UpdateBornIdleState(float timeElapsed)
		{
			if (this._idleTime > 0f)
			{
				this._idleTime -= timeElapsed;
				return;
			}
			this.SetNextStateOfBornIdle();
		}

		// Token: 0x0600ABD9 RID: 43993 RVA: 0x0024EA34 File Offset: 0x0024CE34
		private void SetNextStateOfBornIdle()
		{
			int num = Random.Range(0, 10);
			if (this._animTownIdle01Interval > 0f && num >= 6)
			{
				this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.TownIdle01;
				this._townIdleO1Time = this._animTownIdle01Interval;
				this.SetAnimationAction("Anim_Town_Idle_01");
			}
			else
			{
				this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.ForwardMove;
				if (this._targetOffsetPosition.x < 0f)
				{
					this._townData.MoveData.FaceRight = false;
				}
				else
				{
					this._townData.MoveData.FaceRight = true;
				}
				this.SetAnimationAction("Anim_Town_Walk");
			}
		}

		// Token: 0x0600ABDA RID: 43994 RVA: 0x0024EAD4 File Offset: 0x0024CED4
		private void UpdateForwardMoveState(float timeElapsed)
		{
			if (base._CheckPosEqual(this._targetPosition, this._townData.MoveData.Position) || (this._targetOffsetPosition.x < 0f && this._townData.MoveData.Position.x < this._targetPosition.x) || (this._targetOffsetPosition.x > 0f && this._townData.MoveData.Position.x > this._targetPosition.x))
			{
				this._townData.MoveData.Position = this._targetPosition;
				this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.MoveIdle;
				this._idleTime = Random.Range(4f, 8f);
				this.SetAnimationAction("Anim_Town_Idle");
				return;
			}
			this._townData.MoveData.Position = this._townData.MoveData.Position + (float)((this._targetOffsetPosition.x >= 0f) ? 1 : -1) * timeElapsed * this._moveSpeed;
		}

		// Token: 0x0600ABDB RID: 43995 RVA: 0x0024EC10 File Offset: 0x0024D010
		private void UpdateMoveIdleState(float timeElapsed)
		{
			if (this._idleTime > 0f)
			{
				this._idleTime -= timeElapsed;
				return;
			}
			this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.BackMove;
			this._townData.MoveData.FaceRight = !this._townData.MoveData.FaceRight;
			this.SetAnimationAction("Anim_Town_Walk");
		}

		// Token: 0x0600ABDC RID: 43996 RVA: 0x0024EC74 File Offset: 0x0024D074
		private void UpdateBackMoveState(float timeElapsed)
		{
			if (base._CheckPosEqual(this._bornPosition, this._townData.MoveData.Position) || (this._targetOffsetPosition.x < 0f && this._townData.MoveData.Position.x > this._bornPosition.x) || (this._targetOffsetPosition.x > 0f && this._townData.MoveData.Position.x < this._bornPosition.x))
			{
				this._townData.MoveData.Position = this._bornPosition;
				this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
				this._idleTime = Random.Range(4f, 8f);
				this.SetAnimationAction("Anim_Town_Idle");
				this.SetNpcMoveTarget();
				return;
			}
			this._townData.MoveData.Position = this._townData.MoveData.Position + (float)((this._targetOffsetPosition.x >= 0f) ? -1 : 1) * timeElapsed * this._moveSpeed;
		}

		// Token: 0x0600ABDD RID: 43997 RVA: 0x0024EDB4 File Offset: 0x0024D1B4
		private void UpdateTownIdle01State(float timeElapsed)
		{
			if (this._townIdleO1Time > 0f)
			{
				this._townIdleO1Time -= timeElapsed;
				return;
			}
			this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.BornIdle;
			this._idleTime = Random.Range(4f, 8f);
			this.SetAnimationAction("Anim_Town_Idle");
		}

		// Token: 0x0600ABDE RID: 43998 RVA: 0x0024EE07 File Offset: 0x0024D207
		private void SetAnimationAction(string animationAction)
		{
			this._townData.ActionData.ActionName = animationAction;
		}

		// Token: 0x0600ABDF RID: 43999 RVA: 0x0024EE1A File Offset: 0x0024D21A
		public sealed override void Dispose()
		{
			base.Dispose();
			this._townData = null;
			this._npcItem = null;
			this._eTownNpcMoveState = ETownAttackCityMonsterMoveState.Invalid;
			this._dialogComponentController = null;
		}

		// Token: 0x04006051 RID: 24657
		private const string FootSfxPath = "Effects/Eff_Tongyong/Prefab/Eff_Tongyong_guaiwugongcheng_quan";

		// Token: 0x04006052 RID: 24658
		private const string AnimTownWalkStr = "Anim_Town_Walk";

		// Token: 0x04006053 RID: 24659
		private const string AnimTownIdleStr = "Anim_Town_Idle";

		// Token: 0x04006054 RID: 24660
		private const string AnimTownIdle01Str = "Anim_Town_Idle_01";

		// Token: 0x04006055 RID: 24661
		private float _idleTime;

		// Token: 0x04006056 RID: 24662
		private ETownAttackCityMonsterMoveState _eTownNpcMoveState = ETownAttackCityMonsterMoveState.Invalid;

		// Token: 0x04006057 RID: 24663
		private Vector3 _bornPosition = Vector3.zero;

		// Token: 0x04006058 RID: 24664
		private Vector3 _targetPosition = Vector3.zero;

		// Token: 0x04006059 RID: 24665
		private Vector3 _targetOffsetPosition = Vector3.zero;

		// Token: 0x0400605A RID: 24666
		private float _animTownIdle01Interval;

		// Token: 0x0400605B RID: 24667
		private float _townIdleO1Time;

		// Token: 0x0400605C RID: 24668
		private Vector3 _moveSpeed = Vector3.zero;

		// Token: 0x0400605D RID: 24669
		private BeTownNPCData _townData;

		// Token: 0x0400605E RID: 24670
		private NpcTable _npcItem;

		// Token: 0x0400605F RID: 24671
		private BeTownAttackCityMonsterDialogComponentController _dialogComponentController;
	}
}

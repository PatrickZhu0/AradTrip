using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001186 RID: 4486
	internal class BeBaseActor : IDisposable
	{
		// Token: 0x0600ABB1 RID: 43953 RVA: 0x0024D085 File Offset: 0x0024B485
		public BeBaseActor(BeBaseActorData data, ClientSystemTown systemTown)
		{
			this._data = data;
			this._systemTown = systemTown;
			BeBaseActor.ms_actors.Add(this);
		}

		// Token: 0x17001A4D RID: 6733
		// (get) Token: 0x0600ABB2 RID: 43954 RVA: 0x0024D0B1 File Offset: 0x0024B4B1
		public GeActorEx GraphicActor
		{
			get
			{
				return this._geActor;
			}
		}

		// Token: 0x17001A4E RID: 6734
		// (get) Token: 0x0600ABB3 RID: 43955 RVA: 0x0024D0B9 File Offset: 0x0024B4B9
		public BeBaseActorData ActorData
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x17001A4F RID: 6735
		// (get) Token: 0x0600ABB4 RID: 43956 RVA: 0x0024D0C1 File Offset: 0x0024B4C1
		public static List<BeBaseActor> Actors
		{
			get
			{
				return BeBaseActor.ms_actors;
			}
		}

		// Token: 0x0600ABB5 RID: 43957 RVA: 0x0024D0C8 File Offset: 0x0024B4C8
		public virtual void Dispose()
		{
			this.m_bDestroied = true;
			if (this._geActor != null)
			{
				this._geScene.DestroyActor(this._geActor);
				this._geActor = null;
			}
			BeBaseActor.ms_actors.Remove(this);
		}

		// Token: 0x0600ABB6 RID: 43958 RVA: 0x0024D100 File Offset: 0x0024B500
		public virtual bool IsValid()
		{
			return !this.m_bDestroied;
		}

		// Token: 0x0600ABB7 RID: 43959 RVA: 0x0024D10C File Offset: 0x0024B50C
		public void SetTargetDirection(Vector3 kTarget)
		{
			if (this._geActor != null)
			{
				GameObject entityNode = this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Charactor);
				if (entityNode != null)
				{
					kTarget -= this._data.MoveData.Position;
					entityNode.transform.localScale = new Vector3((kTarget.x <= 0f) ? -1f : 1f, 1f, 1f);
				}
			}
		}

		// Token: 0x0600ABB8 RID: 43960 RVA: 0x0024D18F File Offset: 0x0024B58F
		public virtual void Update(float timeElapsed)
		{
			this.delayCaller.Update((int)(timeElapsed * 1000f));
			this.UpdateMove(timeElapsed);
			this.UpdateGeActor(timeElapsed);
		}

		// Token: 0x0600ABB9 RID: 43961 RVA: 0x0024D1B4 File Offset: 0x0024B5B4
		public void SetAction(ActorActionType eActorActionType, float fSpeed = 1f, bool bLoop = false)
		{
			if (eActorActionType >= ActorActionType.AT_IDLE && eActorActionType < ActorActionType.AT_COUNT)
			{
				this.ActorData.ActionData.ActionName = eActorActionType.GetDescription(true);
				this.ActorData.ActionData.ActionSpeed = fSpeed;
				this.ActorData.ActionData.ActionLoop = bLoop;
			}
		}

		// Token: 0x0600ABBA RID: 43962 RVA: 0x0024D210 File Offset: 0x0024B610
		public virtual void CommandMoveTo(Vector3 targetPosition)
		{
			targetPosition.y = 0f;
			this.ActorData.MoveData.MoveType = EActorMoveType.TargetPos;
			this.ActorData.MoveData.MovePath = PathFinding.FindPath(this.ActorData.MoveData.Position, targetPosition, this._systemTown.GridInfo);
			this.ActorData.MoveData.TargetPosition = this.ActorData.MoveData.Position;
			this._TryFollowPath();
		}

		// Token: 0x0600ABBB RID: 43963 RVA: 0x0024D294 File Offset: 0x0024B694
		public virtual void CommandDirectMoveTo(Vector3 targetPosition)
		{
			targetPosition.y = 0f;
			this.ActorData.MoveData.MoveType = EActorMoveType.TargetPos;
			this.ActorData.MoveData.MovePath = new List<Vector3>();
			this.ActorData.MoveData.MovePath.Add(targetPosition);
			this.ActorData.MoveData.TargetPosition = this.ActorData.MoveData.Position;
			this._TryFollowPath();
		}

		// Token: 0x0600ABBC RID: 43964 RVA: 0x0024D310 File Offset: 0x0024B710
		public virtual void CommandMoveForward(Vector3 targetDirection)
		{
			targetDirection.y = 0f;
			this.ActorData.MoveData.MoveType = EActorMoveType.TargetDir;
			this.ActorData.MoveData.TargetDirection = targetDirection;
			if (targetDirection.x > 0f)
			{
				this.ActorData.MoveData.FaceRight = true;
			}
			else if (targetDirection.x < 0f)
			{
				this.ActorData.MoveData.FaceRight = false;
			}
			this.DoActionWalk();
		}

		// Token: 0x0600ABBD RID: 43965 RVA: 0x0024D39C File Offset: 0x0024B79C
		public virtual void CommandStopMove()
		{
			this.ActorData.MoveData.MoveType = EActorMoveType.Invalid;
			this.ActorData.MoveData.TargetPosition = Vector3.zero;
			this.ActorData.MoveData.TargetDirection = Vector3.zero;
			this.ActorData.MoveData.MovePath = null;
			this.DoActionIdle();
		}

		// Token: 0x0600ABBE RID: 43966 RVA: 0x0024D3FC File Offset: 0x0024B7FC
		public virtual void UpdateMove(float timeElapsed)
		{
			ActorMoveData moveData = this.ActorData.MoveData;
			if (moveData.MoveType == EActorMoveType.Invalid)
			{
				return;
			}
			if (moveData.MoveType == EActorMoveType.TargetDir)
			{
				Vector3 targetDirection = moveData.TargetDirection;
				targetDirection.x *= moveData.MoveSpeed.x;
				targetDirection.y *= moveData.MoveSpeed.y;
				targetDirection.z *= moveData.MoveSpeed.z;
				Vector3 position = moveData.Position + targetDirection * timeElapsed;
				if (this._TryMove(ref position, moveData.Position))
				{
					moveData.Position = position;
				}
			}
			else if (moveData.MoveType == EActorMoveType.TargetPos)
			{
				if (this._CheckPosEqual(moveData.TargetPosition, moveData.Position) && !this._TryFollowPath())
				{
					return;
				}
				Vector3 vector = moveData.TargetPosition - moveData.Position;
				Vector3 normalized = vector.normalized;
				normalized.x *= moveData.MoveSpeed.x;
				normalized.y *= moveData.MoveSpeed.y;
				normalized.z *= moveData.MoveSpeed.z;
				Vector3 vector2 = moveData.Position + normalized * timeElapsed;
				Vector3 vector3 = moveData.TargetPosition - vector2;
				if (vector.x * vector3.x <= 0f)
				{
					vector2.x = moveData.TargetPosition.x;
				}
				vector2.y = 0f;
				if (vector.z * vector3.z <= 0f)
				{
					vector2.z = moveData.TargetPosition.z;
				}
				moveData.Position = vector2;
				if (this._CheckPosEqual(moveData.TargetPosition, moveData.Position) && !this._TryFollowPath())
				{
					return;
				}
			}
		}

		// Token: 0x0600ABBF RID: 43967 RVA: 0x0024D618 File Offset: 0x0024BA18
		protected bool _TryFollowPath()
		{
			List<Vector3> movePath = this.ActorData.MoveData.MovePath;
			if (movePath == null || movePath.Count <= 0)
			{
				this.CommandStopMove();
				return false;
			}
			bool flag = true;
			while (movePath.Count > 0)
			{
				this.ActorData.MoveData.TargetPosition = movePath[0];
				movePath.RemoveAt(0);
				if (!this._CheckPosEqual(this.ActorData.MoveData.TargetPosition, this.ActorData.MoveData.Position))
				{
					IL_93:
					if (flag)
					{
						if (this.ActorData.MoveData.TargetPosition.x > this.ActorData.MoveData.Position.x)
						{
							this.ActorData.MoveData.FaceRight = true;
						}
						else if (this.ActorData.MoveData.TargetPosition.x < this.ActorData.MoveData.Position.x)
						{
							this.ActorData.MoveData.FaceRight = false;
						}
						this.DoActionWalk();
						return true;
					}
					this.CommandStopMove();
					return false;
				}
			}
			flag = false;
			goto IL_93;
		}

		// Token: 0x0600ABC0 RID: 43968 RVA: 0x0024D760 File Offset: 0x0024BB60
		protected bool _TryMove(ref Vector3 newPos, Vector3 currentPos)
		{
			ISceneData levelData = this._systemTown.LevelData;
			float x = levelData.GetGridSize().x;
			float y = levelData.GetGridSize().y;
			if (x <= 0.01f || y <= 0.01f)
			{
				Logger.LogErrorFormat("level: {0} gridsize can not less than 0.01!!", new object[]
				{
					levelData.GetName()
				});
				return false;
			}
			Vector3 vector = currentPos;
			Vector3 vector2 = currentPos;
			Vector3 vector3 = newPos;
			int num = 32;
			while (--num > 0)
			{
				int num2 = 1;
				int num3 = 1;
				float num4 = vector3.x - vector2.x;
				while (Mathf.Abs(num4) >= x)
				{
					num4 *= 0.5f;
					num2 *= 2;
				}
				float num5 = vector3.z - vector2.z;
				while (Mathf.Abs(num5) >= y)
				{
					num5 *= 0.5f;
					num3 *= 2;
				}
				Vector3 vector4 = vector3 - vector2;
				vector3 = vector2 + vector4 / (float)((num2 <= num3) ? num3 : num2);
				if (!this._TryMoveOneGrid(ref vector3, vector2))
				{
					break;
				}
				vector = vector3;
				if (num2 == 1 && num3 == 1)
				{
					break;
				}
				vector2 = vector3;
				vector3 = newPos;
			}
			newPos = vector;
			return !this._CheckPosEqual(newPos, currentPos);
		}

		// Token: 0x0600ABC1 RID: 43969 RVA: 0x0024D8E0 File Offset: 0x0024BCE0
		protected bool _TryMoveOneGrid(ref Vector3 newPos, Vector3 currentPos)
		{
			if (this._CheckPosEqual(newPos, currentPos))
			{
				return false;
			}
			ISceneData levelData = this._systemTown.LevelData;
			float x = levelData.GetGridSize().x;
			float y = levelData.GetGridSize().y;
			float num = (float)((int)Math.Floor((double)(currentPos.x / x))) * x;
			float num2 = num + x;
			float num3 = (float)((int)Math.Floor((double)(currentPos.z / y))) * y;
			float num4 = num3 + y;
			if (num <= newPos.x && newPos.x <= num2 - 0.01f && num3 <= newPos.z && newPos.z <= num4 - 0.01f)
			{
				return true;
			}
			int num5 = (int)Math.Floor((double)(newPos.x / x));
			int num6 = (int)Math.Floor((double)(newPos.z / y));
			int num7 = (int)Math.Floor((double)(currentPos.x / x));
			int num8 = (int)Math.Floor((double)(currentPos.z / y));
			if (Mathf.Abs(newPos.x - currentPos.x) > 1E-06f)
			{
				bool flag = newPos.x < currentPos.x;
				Vector3 cc;
				cc..ctor((!flag) ? num2 : num, 0f, num3);
				Vector3 dd;
				dd..ctor((!flag) ? num2 : num, 0f, num4);
				if (this._Intersect(currentPos, newPos, cc, dd))
				{
					if (this._GridCanMove(num5, num8))
					{
						if (this._GridCanMove(num5, num6))
						{
							newPos.x = Mathf.Clamp(newPos.x, newPos.x, (float)(num5 + 1) * x - 0.01f);
							newPos.z = Mathf.Clamp(newPos.z, newPos.z, (float)(num6 + 1) * y - 0.01f);
							return !this._CheckPosEqual(newPos, currentPos);
						}
						newPos.z = ((num6 >= num8) ? (num4 - 0.01f) : num3);
					}
					else
					{
						newPos.x = ((!flag) ? (num2 - 0.01f) : num);
					}
				}
			}
			if (Mathf.Abs(newPos.z - currentPos.z) > 1E-06f)
			{
				bool flag2 = newPos.z < currentPos.z;
				Vector3 cc2;
				cc2..ctor(num, 0f, (!flag2) ? num4 : num3);
				Vector3 dd2;
				dd2..ctor(num2, 0f, (!flag2) ? num4 : num3);
				if (this._Intersect(currentPos, newPos, cc2, dd2))
				{
					if (this._GridCanMove(num7, num6))
					{
						if (this._GridCanMove(num5, num6))
						{
							newPos.x = Mathf.Clamp(newPos.x, newPos.x, (float)(num5 + 1) * x - 0.01f);
							newPos.z = Mathf.Clamp(newPos.z, newPos.z, (float)(num6 + 1) * y - 0.01f);
							return !this._CheckPosEqual(newPos, currentPos);
						}
						newPos.x = ((num5 >= num7) ? (num2 - 0.01f) : num);
					}
					else
					{
						newPos.z = ((!flag2) ? (num4 - 0.01f) : num3);
					}
				}
			}
			return !this._CheckPosEqual(newPos, currentPos);
		}

		// Token: 0x0600ABC2 RID: 43970 RVA: 0x0024DC68 File Offset: 0x0024C068
		protected bool _CheckPosEqual(Vector3 posA, Vector3 posB)
		{
			posA.y = 0f;
			posB.y = 0f;
			return (posA - posB).sqrMagnitude <= 2E-06f;
		}

		// Token: 0x0600ABC3 RID: 43971 RVA: 0x0024DCAC File Offset: 0x0024C0AC
		protected bool _GridCanMove(int gridX, int gridZ)
		{
			ISceneData levelData = this._systemTown.LevelData;
			if (gridX < levelData.GetLogicXmin() || gridX >= levelData.GetLogicXmax())
			{
				return false;
			}
			if (gridZ < levelData.GetLogicZmin() || gridZ >= levelData.GetLogicZmax())
			{
				return false;
			}
			int num = gridX - levelData.GetLogicXmin();
			int num2 = gridZ - levelData.GetLogicZmin();
			int num3 = (levelData.GetLogicXmax() - levelData.GetLogicXmin()) * num2 + num;
			return num3 >= 0 && num3 < levelData.GetBlockLayerLength() && levelData.GetBlockLayer(num3) == 0;
		}

		// Token: 0x0600ABC4 RID: 43972 RVA: 0x0024DD3C File Offset: 0x0024C13C
		protected double _Mult(Vector3 a, Vector3 b, Vector3 c)
		{
			return (double)((a.x - c.x) * (b.y - c.y) - (b.x - c.x) * (a.y - c.y));
		}

		// Token: 0x0600ABC5 RID: 43973 RVA: 0x0024DD8C File Offset: 0x0024C18C
		protected bool _Intersect(Vector3 aa, Vector3 bb, Vector3 cc, Vector3 dd)
		{
			return Mathf.Max(aa.x, bb.x) >= Mathf.Min(cc.x, dd.x) && Mathf.Max(aa.y, bb.y) >= Mathf.Min(cc.y, dd.y) && Mathf.Max(cc.x, dd.x) >= Mathf.Min(aa.x, bb.x) && Mathf.Max(cc.y, dd.y) >= Mathf.Min(aa.y, bb.y) && this._Mult(cc, bb, aa) * this._Mult(bb, dd, aa) >= 0.0 && this._Mult(aa, dd, cc) * this._Mult(dd, bb, cc) >= 0.0;
		}

		// Token: 0x0600ABC6 RID: 43974 RVA: 0x0024DE97 File Offset: 0x0024C297
		public virtual void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			this.ActorData.MoveData.TransformDirty = true;
			this.UpdateGeActor(0f);
		}

		// Token: 0x0600ABC7 RID: 43975 RVA: 0x0024DEBC File Offset: 0x0024C2BC
		public virtual void UpdateGeActor(float timeElapsed)
		{
			if (this._geActor != null)
			{
				if (this.ActorData.MoveData.TransformDirty)
				{
					this._geActor.SetPosition(this.ActorData.MoveData.GraphPosition);
					this._geActor.SetFaceLeft(!this.ActorData.MoveData.FaceRight);
					this.ActorData.MoveData.TransformDirty = false;
				}
				if (this.ActorData.ActionData.isDirty)
				{
					this._geActor.ChangeAction(this.ActorData.ActionData.ActionName, this.ActorData.ActionData.ActionSpeed, this.ActorData.ActionData.ActionLoop, false, false);
					this.ActorData.ActionData.isDirty = false;
				}
				for (int i = 0; i < this.ActorData.arrAttachmentData.Count; i++)
				{
					AttachmentPlayData attachmentPlayData = this.ActorData.arrAttachmentData[i];
					if (attachmentPlayData.isDirty)
					{
						this._geActor.SetAttachmentVisible(attachmentPlayData.attachmentName, attachmentPlayData.visible);
						attachmentPlayData.isDirty = false;
					}
				}
				if (this._geActor != null)
				{
					this._geActor.Update((int)(timeElapsed * (float)GlobalLogic.VALUE_1000), 63, 0f, 0);
				}
			}
		}

		// Token: 0x0600ABC8 RID: 43976 RVA: 0x0024E01A File Offset: 0x0024C41A
		public virtual void DoActionIdle()
		{
			this.ActorData.ActionData.ActionName = this.ActorData.AniNames[0];
			this.ActorData.ActionData.ActionSpeed = 1f;
		}

		// Token: 0x0600ABC9 RID: 43977 RVA: 0x0024E050 File Offset: 0x0024C450
		public virtual void DoActionWalk()
		{
			this.ActorData.ActionData.ActionName = ((!Global.Settings.townPlayerRun) ? this.ActorData.AniNames[1] : this.ActorData.AniNames[2]);
			this.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
		}

		// Token: 0x04006043 RID: 24643
		protected GeActorEx _geActor;

		// Token: 0x04006044 RID: 24644
		protected GeSceneEx _geScene;

		// Token: 0x04006045 RID: 24645
		protected BeBaseActorData _data;

		// Token: 0x04006046 RID: 24646
		public DelayCaller delayCaller = new DelayCaller();

		// Token: 0x04006047 RID: 24647
		protected ClientSystemTown _systemTown;

		// Token: 0x04006048 RID: 24648
		private static List<BeBaseActor> ms_actors = new List<BeBaseActor>();

		// Token: 0x04006049 RID: 24649
		protected bool m_bDestroied;
	}
}

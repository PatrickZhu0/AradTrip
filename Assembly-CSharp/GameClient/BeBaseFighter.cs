using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200113D RID: 4413
	public class BeBaseFighter : IDisposable
	{
		// Token: 0x0600A858 RID: 43096 RVA: 0x002368D5 File Offset: 0x00234CD5
		public BeBaseFighter(BeBaseActorData data, ClientSystemGameBattle systemTown)
		{
			this._data = data;
			this._battle = systemTown;
		}

		// Token: 0x0600A859 RID: 43097 RVA: 0x002368FD File Offset: 0x00234CFD
		public virtual void Dispose()
		{
			this.m_bDestroyed = true;
			if (this._geActor != null)
			{
				this._geActor.Destroy();
				this._geScene.DestroyActor(this._geActor);
				this._geActor = null;
			}
		}

		// Token: 0x170019F9 RID: 6649
		// (get) Token: 0x0600A85A RID: 43098 RVA: 0x00236934 File Offset: 0x00234D34
		public bool IsRemoved
		{
			get
			{
				return this.m_bRemoved;
			}
		}

		// Token: 0x170019FA RID: 6650
		// (get) Token: 0x0600A85B RID: 43099 RVA: 0x0023693C File Offset: 0x00234D3C
		public BeBaseActorData ActorData
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x0600A85C RID: 43100 RVA: 0x00236944 File Offset: 0x00234D44
		public void Remove()
		{
			this.m_bRemoved = true;
		}

		// Token: 0x0600A85D RID: 43101 RVA: 0x0023694D File Offset: 0x00234D4D
		public void CancelRemove()
		{
			this.m_bRemoved = false;
		}

		// Token: 0x0600A85E RID: 43102 RVA: 0x00236956 File Offset: 0x00234D56
		public virtual void OnRemove()
		{
		}

		// Token: 0x170019FB RID: 6651
		// (get) Token: 0x0600A85F RID: 43103 RVA: 0x00236958 File Offset: 0x00234D58
		// (set) Token: 0x0600A860 RID: 43104 RVA: 0x00236960 File Offset: 0x00234D60
		public ulong GUID { get; set; }

		// Token: 0x0600A861 RID: 43105 RVA: 0x00236969 File Offset: 0x00234D69
		public virtual bool IsValid()
		{
			return !this.m_bDestroyed;
		}

		// Token: 0x170019FC RID: 6652
		// (get) Token: 0x0600A862 RID: 43106 RVA: 0x00236974 File Offset: 0x00234D74
		public GeActorEx GraphicActor
		{
			get
			{
				return this._geActor;
			}
		}

		// Token: 0x0600A863 RID: 43107 RVA: 0x0023697C File Offset: 0x00234D7C
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

		// Token: 0x0600A864 RID: 43108 RVA: 0x00236A08 File Offset: 0x00234E08
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

		// Token: 0x170019FD RID: 6653
		// (get) Token: 0x0600A865 RID: 43109 RVA: 0x00236A8B File Offset: 0x00234E8B
		public BeBaseFighter.GRASS_STATUS GrassStatus
		{
			get
			{
				return this.m_grassStat;
			}
		}

		// Token: 0x0600A866 RID: 43110 RVA: 0x00236A94 File Offset: 0x00234E94
		public virtual void SetGrassStat(BeBaseFighter.GRASS_STATUS stat)
		{
			if (this.m_grassStat == stat)
			{
				return;
			}
			BeBaseFighter.GRASS_STATUS grassStat = this.m_grassStat;
			this.m_grassStat = stat;
			if (this._geActor == null)
			{
				return;
			}
			if (grassStat != BeBaseFighter.GRASS_STATUS.IN_GRASS)
			{
				if (grassStat == BeBaseFighter.GRASS_STATUS.SAME_WITH_MAINROLE_IN_GRASS || grassStat == BeBaseFighter.GRASS_STATUS.MAIN_ROLE_IN_GRASS)
				{
					this._geActor.RemoveSurface(this.alphaEffectHandle);
					this.alphaEffectHandle = uint.MaxValue;
				}
			}
			else
			{
				this._geActor.HideActor(false);
				if (this.ActorData.ActionData.ActionName.Contains("Idle"))
				{
					this._geActor.ChangeAction(this.ActorData.AniNames[0], 1f, true, true, true);
				}
				else
				{
					string action = this.ActorData.AniNames[2];
					this._geActor.ChangeAction(action, 1f, true, true, true);
				}
			}
			BeBaseFighter.GRASS_STATUS grassStat2 = this.m_grassStat;
			if (grassStat2 != BeBaseFighter.GRASS_STATUS.IN_GRASS)
			{
				if (grassStat2 == BeBaseFighter.GRASS_STATUS.SAME_WITH_MAINROLE_IN_GRASS || grassStat2 == BeBaseFighter.GRASS_STATUS.MAIN_ROLE_IN_GRASS)
				{
					this.alphaEffectHandle = this._geActor.ChangeSurface("隐匿", 0f, true, true);
				}
			}
			else
			{
				this._geActor.HideActor(true);
			}
		}

		// Token: 0x0600A867 RID: 43111 RVA: 0x00236BCC File Offset: 0x00234FCC
		public virtual void Update(float deltaTime)
		{
			this.delayCaller.Update((int)(deltaTime * 1000f));
			if (this.IsRemoved)
			{
				return;
			}
			this.UpdateMove(deltaTime);
			this.UpdateGeActor(deltaTime);
		}

		// Token: 0x0600A868 RID: 43112 RVA: 0x00236BFC File Offset: 0x00234FFC
		public virtual void CommandMoveTo(Vector3 targetPosition)
		{
			targetPosition.y = 0f;
			this.ActorData.MoveData.MoveType = EActorMoveType.TargetPos;
			this.ActorData.MoveData.MovePath = PathFinding.FindPath(this.ActorData.MoveData.Position, targetPosition, this._battle.GridInfo);
			this.ActorData.MoveData.TargetPosition = this.ActorData.MoveData.Position;
			this._TryFollowPath();
		}

		// Token: 0x0600A869 RID: 43113 RVA: 0x00236C80 File Offset: 0x00235080
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

		// Token: 0x0600A86A RID: 43114 RVA: 0x00236E9C File Offset: 0x0023529C
		public virtual void CommandStopMove()
		{
			this.ActorData.MoveData.MoveType = EActorMoveType.Invalid;
			this.ActorData.MoveData.TargetPosition = Vector3.zero;
			this.ActorData.MoveData.TargetDirection = Vector3.zero;
			this.ActorData.MoveData.MovePath = null;
			this.DoActionIdle();
		}

		// Token: 0x0600A86B RID: 43115 RVA: 0x00236EFC File Offset: 0x002352FC
		public void ResetMoveCommand()
		{
			this.ActorData.MoveData.MoveType = EActorMoveType.Invalid;
			this.ActorData.MoveData.TargetPosition = Vector3.zero;
			this.ActorData.MoveData.TargetDirection = Vector3.zero;
			this.ActorData.MoveData.MovePath = null;
		}

		// Token: 0x0600A86C RID: 43116 RVA: 0x00236F58 File Offset: 0x00235358
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

		// Token: 0x0600A86D RID: 43117 RVA: 0x002370A0 File Offset: 0x002354A0
		protected bool _TryMove(ref Vector3 newPos, Vector3 currentPos)
		{
			ISceneData levelData = this._battle.LevelData;
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
			for (;;)
			{
				int num = 1;
				int num2 = 1;
				float num3 = vector3.x - vector2.x;
				while (Mathf.Abs(num3) >= x)
				{
					num3 *= 0.5f;
					num *= 2;
				}
				float num4 = vector3.z - vector2.z;
				while (Mathf.Abs(num4) >= y)
				{
					num4 *= 0.5f;
					num2 *= 2;
				}
				Vector3 vector4 = vector3 - vector2;
				vector3 = vector2 + vector4 / (float)((num <= num2) ? num2 : num);
				if (!this._TryMoveOneGrid(ref vector3, vector2))
				{
					break;
				}
				vector = vector3;
				if (num == 1 && num2 == 1)
				{
					break;
				}
				vector2 = vector3;
				vector3 = newPos;
			}
			newPos = vector;
			return !this._CheckPosEqual(newPos, currentPos);
		}

		// Token: 0x0600A86E RID: 43118 RVA: 0x0023720C File Offset: 0x0023560C
		protected bool _TryMoveOneGrid(ref Vector3 newPos, Vector3 currentPos)
		{
			if (this._CheckPosEqual(newPos, currentPos))
			{
				return false;
			}
			ISceneData levelData = this._battle.LevelData;
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

		// Token: 0x0600A86F RID: 43119 RVA: 0x00237594 File Offset: 0x00235994
		protected bool _CheckPosEqual(Vector3 posA, Vector3 posB)
		{
			posA.y = 0f;
			posB.y = 0f;
			return (posA - posB).sqrMagnitude <= 2E-06f;
		}

		// Token: 0x0600A870 RID: 43120 RVA: 0x002375D8 File Offset: 0x002359D8
		protected bool _GridCanMove(int gridX, int gridZ)
		{
			ISceneData levelData = this._battle.LevelData;
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

		// Token: 0x0600A871 RID: 43121 RVA: 0x00237668 File Offset: 0x00235A68
		protected double _Mult(Vector3 a, Vector3 b, Vector3 c)
		{
			return (double)((a.x - c.x) * (b.y - c.y) - (b.x - c.x) * (a.y - c.y));
		}

		// Token: 0x0600A872 RID: 43122 RVA: 0x002376B8 File Offset: 0x00235AB8
		protected bool _Intersect(Vector3 aa, Vector3 bb, Vector3 cc, Vector3 dd)
		{
			return Mathf.Max(aa.x, bb.x) >= Mathf.Min(cc.x, dd.x) && Mathf.Max(aa.y, bb.y) >= Mathf.Min(cc.y, dd.y) && Mathf.Max(cc.x, dd.x) >= Mathf.Min(aa.x, bb.x) && Mathf.Max(cc.y, dd.y) >= Mathf.Min(aa.y, bb.y) && this._Mult(cc, bb, aa) * this._Mult(bb, dd, aa) >= 0.0 && this._Mult(aa, dd, cc) * this._Mult(dd, bb, cc) >= 0.0;
		}

		// Token: 0x0600A873 RID: 43123 RVA: 0x002377C3 File Offset: 0x00235BC3
		public virtual void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			this.alphaEffectHandle = uint.MaxValue;
			this.ActorData.MoveData.TransformDirty = true;
			this.UpdateGeActor(0f);
		}

		// Token: 0x0600A874 RID: 43124 RVA: 0x002377F0 File Offset: 0x00235BF0
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

		// Token: 0x0600A875 RID: 43125 RVA: 0x0023794E File Offset: 0x00235D4E
		public virtual void DoActionIdle()
		{
			this.ActorData.ActionData.ActionName = this.ActorData.AniNames[0];
			this.ActorData.ActionData.ActionSpeed = 1f;
		}

		// Token: 0x0600A876 RID: 43126 RVA: 0x00237982 File Offset: 0x00235D82
		public virtual void DoActionWalk()
		{
			this.ActorData.ActionData.ActionName = this.ActorData.AniNames[2];
			this.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
		}

		// Token: 0x0600A877 RID: 43127 RVA: 0x002379BC File Offset: 0x00235DBC
		public virtual void DoActionDead()
		{
			this.ActorData.ActionData.ActionName = this.ActorData.AniNames[3];
			this.ActorData.ActionData.ActionSpeed = 1f;
			this.ActorData.ActionData.ActionLoop = false;
		}

		// Token: 0x0600A878 RID: 43128 RVA: 0x00237A0C File Offset: 0x00235E0C
		public virtual void CommandDirectMoveTo(Vector3 targetPosition)
		{
			targetPosition.y = 0f;
			this.ActorData.MoveData.MoveType = EActorMoveType.TargetPos;
			this.ActorData.MoveData.MovePath = new List<Vector3>();
			this.ActorData.MoveData.MovePath.Add(targetPosition);
			this.ActorData.MoveData.TargetPosition = this.ActorData.MoveData.Position;
			this._TryFollowPath();
		}

		// Token: 0x04005E0F RID: 24079
		public DelayCaller delayCaller = new DelayCaller();

		// Token: 0x04005E10 RID: 24080
		protected GeActorEx _geActor;

		// Token: 0x04005E11 RID: 24081
		protected GeSceneEx _geScene;

		// Token: 0x04005E12 RID: 24082
		protected bool m_bDestroyed;

		// Token: 0x04005E13 RID: 24083
		protected BeBaseActorData _data;

		// Token: 0x04005E14 RID: 24084
		protected ClientSystemGameBattle _battle;

		// Token: 0x04005E15 RID: 24085
		private bool m_bRemoved;

		// Token: 0x04005E17 RID: 24087
		private uint alphaEffectHandle = uint.MaxValue;

		// Token: 0x04005E18 RID: 24088
		private const string alphaEffectshaderName = "隐匿";

		// Token: 0x04005E19 RID: 24089
		private BeBaseFighter.GRASS_STATUS m_grassStat;

		// Token: 0x0200113E RID: 4414
		public enum GRASS_STATUS
		{
			// Token: 0x04005E1B RID: 24091
			NONE,
			// Token: 0x04005E1C RID: 24092
			MAIN_ROLE_IN_GRASS,
			// Token: 0x04005E1D RID: 24093
			SAME_WITH_MAINROLE_IN_GRASS,
			// Token: 0x04005E1E RID: 24094
			IN_GRASS
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001182 RID: 4482
	public class ActorMoveData
	{
		// Token: 0x17001A33 RID: 6707
		// (get) Token: 0x0600AB7C RID: 43900 RVA: 0x0024CDD1 File Offset: 0x0024B1D1
		// (set) Token: 0x0600AB7D RID: 43901 RVA: 0x0024CDD9 File Offset: 0x0024B1D9
		public Vector3 Position
		{
			get
			{
				return this._position;
			}
			set
			{
				if (this._position != value)
				{
					this._position = value;
					this._graphPosition = this._position + this._posLogicToGraph;
					this._transformDirty = true;
				}
			}
		}

		// Token: 0x17001A34 RID: 6708
		// (get) Token: 0x0600AB7E RID: 43902 RVA: 0x0024CE14 File Offset: 0x0024B214
		public MovingDirectionType MovingDirection
		{
			get
			{
				Vector3 normalized = (this._targetPosition - this._position).normalized;
				if (Mathf.Abs(normalized.x) > Mathf.Abs(normalized.y))
				{
					return (normalized.x >= 0f) ? MovingDirectionType.MDT_RIGHT : MovingDirectionType.MDT_LEFT;
				}
				return (normalized.y >= 0f) ? MovingDirectionType.MDT_DOWN : MovingDirectionType.MDT_UP;
			}
		}

		// Token: 0x17001A35 RID: 6709
		// (get) Token: 0x0600AB7F RID: 43903 RVA: 0x0024CE89 File Offset: 0x0024B289
		public Vector3 GraphPosition
		{
			get
			{
				return this._graphPosition;
			}
		}

		// Token: 0x17001A36 RID: 6710
		// (get) Token: 0x0600AB81 RID: 43905 RVA: 0x0024CEB8 File Offset: 0x0024B2B8
		// (set) Token: 0x0600AB80 RID: 43904 RVA: 0x0024CE91 File Offset: 0x0024B291
		public Vector3 PosLogicToGraph
		{
			get
			{
				return this._posLogicToGraph;
			}
			set
			{
				this._posLogicToGraph = value;
				this._graphPosition = this._position + this._posLogicToGraph;
				this._transformDirty = true;
			}
		}

		// Token: 0x17001A37 RID: 6711
		// (get) Token: 0x0600AB82 RID: 43906 RVA: 0x0024CEC0 File Offset: 0x0024B2C0
		// (set) Token: 0x0600AB83 RID: 43907 RVA: 0x0024CEC8 File Offset: 0x0024B2C8
		public Vector3 PosServerToClient { get; set; }

		// Token: 0x17001A38 RID: 6712
		// (get) Token: 0x0600AB85 RID: 43909 RVA: 0x0024CEE5 File Offset: 0x0024B2E5
		// (set) Token: 0x0600AB84 RID: 43908 RVA: 0x0024CED1 File Offset: 0x0024B2D1
		public Vector3 ServerPosition
		{
			get
			{
				return this.Position - this.PosServerToClient;
			}
			set
			{
				this.Position = value + this.PosServerToClient;
			}
		}

		// Token: 0x17001A39 RID: 6713
		// (get) Token: 0x0600AB86 RID: 43910 RVA: 0x0024CEF8 File Offset: 0x0024B2F8
		// (set) Token: 0x0600AB87 RID: 43911 RVA: 0x0024CF00 File Offset: 0x0024B300
		public bool FaceRight
		{
			get
			{
				return this._faceRight;
			}
			set
			{
				if (this._faceRight != value)
				{
					this._faceRight = value;
					this._transformDirty = true;
				}
			}
		}

		// Token: 0x17001A3A RID: 6714
		// (get) Token: 0x0600AB88 RID: 43912 RVA: 0x0024CF1C File Offset: 0x0024B31C
		// (set) Token: 0x0600AB89 RID: 43913 RVA: 0x0024CF24 File Offset: 0x0024B324
		public bool TransformDirty
		{
			get
			{
				return this._transformDirty;
			}
			set
			{
				this._transformDirty = value;
			}
		}

		// Token: 0x17001A3B RID: 6715
		// (get) Token: 0x0600AB8A RID: 43914 RVA: 0x0024CF2D File Offset: 0x0024B32D
		// (set) Token: 0x0600AB8B RID: 43915 RVA: 0x0024CF35 File Offset: 0x0024B335
		public Vector3 MoveSpeed
		{
			get
			{
				return this._moveSpeed;
			}
			set
			{
				this._moveSpeed = value;
			}
		}

		// Token: 0x17001A3C RID: 6716
		// (get) Token: 0x0600AB8C RID: 43916 RVA: 0x0024CF3E File Offset: 0x0024B33E
		// (set) Token: 0x0600AB8D RID: 43917 RVA: 0x0024CF46 File Offset: 0x0024B346
		public EActorMoveType MoveType
		{
			get
			{
				return this._moveType;
			}
			set
			{
				this._moveType = value;
			}
		}

		// Token: 0x17001A3D RID: 6717
		// (get) Token: 0x0600AB8E RID: 43918 RVA: 0x0024CF4F File Offset: 0x0024B34F
		// (set) Token: 0x0600AB8F RID: 43919 RVA: 0x0024CF57 File Offset: 0x0024B357
		public Vector3 TargetPosition
		{
			get
			{
				return this._targetPosition;
			}
			set
			{
				this._targetPosition = value;
			}
		}

		// Token: 0x17001A3E RID: 6718
		// (get) Token: 0x0600AB90 RID: 43920 RVA: 0x0024CF60 File Offset: 0x0024B360
		// (set) Token: 0x0600AB91 RID: 43921 RVA: 0x0024CF68 File Offset: 0x0024B368
		public Vector3 TargetDirection
		{
			get
			{
				return this._targetDirection;
			}
			set
			{
				this._targetDirection = value.normalized;
			}
		}

		// Token: 0x17001A3F RID: 6719
		// (get) Token: 0x0600AB92 RID: 43922 RVA: 0x0024CF77 File Offset: 0x0024B377
		// (set) Token: 0x0600AB93 RID: 43923 RVA: 0x0024CF7F File Offset: 0x0024B37F
		public List<Vector3> MovePath { get; set; }

		// Token: 0x04006029 RID: 24617
		protected Vector3 _position = Vector3.zero;

		// Token: 0x0400602A RID: 24618
		protected Vector3 _graphPosition = Vector3.zero;

		// Token: 0x0400602B RID: 24619
		protected Vector3 _posLogicToGraph = Vector3.zero;

		// Token: 0x0400602C RID: 24620
		protected bool _transformDirty = true;

		// Token: 0x0400602D RID: 24621
		protected bool _faceRight = true;

		// Token: 0x0400602E RID: 24622
		protected Vector3 _moveSpeed = Vector3.zero;

		// Token: 0x0400602F RID: 24623
		protected EActorMoveType _moveType = EActorMoveType.Invalid;

		// Token: 0x04006030 RID: 24624
		protected Vector3 _targetPosition = Vector3.zero;

		// Token: 0x04006031 RID: 24625
		protected Vector3 _targetDirection = Vector3.zero;

		// Token: 0x04006032 RID: 24626
		protected List<Vector3> _targetPath = new List<Vector3>();
	}
}

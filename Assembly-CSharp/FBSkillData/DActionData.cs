using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B39 RID: 19257
	public sealed class DActionData : Table
	{
		// Token: 0x0601C328 RID: 115496 RVA: 0x008952DE File Offset: 0x008936DE
		public static DActionData GetRootAsDActionData(ByteBuffer _bb)
		{
			return DActionData.GetRootAsDActionData(_bb, new DActionData());
		}

		// Token: 0x0601C329 RID: 115497 RVA: 0x008952EB File Offset: 0x008936EB
		public static DActionData GetRootAsDActionData(ByteBuffer _bb, DActionData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C32A RID: 115498 RVA: 0x00895307 File Offset: 0x00893707
		public DActionData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700274D RID: 10061
		// (get) Token: 0x0601C32B RID: 115499 RVA: 0x00895318 File Offset: 0x00893718
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700274E RID: 10062
		// (get) Token: 0x0601C32C RID: 115500 RVA: 0x00895348 File Offset: 0x00893748
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700274F RID: 10063
		// (get) Token: 0x0601C32D RID: 115501 RVA: 0x0089537C File Offset: 0x0089377C
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002750 RID: 10064
		// (get) Token: 0x0601C32E RID: 115502 RVA: 0x008953B0 File Offset: 0x008937B0
		public int ActionType
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002751 RID: 10065
		// (get) Token: 0x0601C32F RID: 115503 RVA: 0x008953E8 File Offset: 0x008937E8
		public float Duration
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002752 RID: 10066
		// (get) Token: 0x0601C330 RID: 115504 RVA: 0x00895424 File Offset: 0x00893824
		public float DeltaScale
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002753 RID: 10067
		// (get) Token: 0x0601C331 RID: 115505 RVA: 0x0089545D File Offset: 0x0089385D
		public Vector3 DeltaPos
		{
			get
			{
				return this.GetDeltaPos(new Vector3());
			}
		}

		// Token: 0x0601C332 RID: 115506 RVA: 0x0089546C File Offset: 0x0089386C
		public Vector3 GetDeltaPos(Vector3 obj)
		{
			int num = base.__offset(16);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002754 RID: 10068
		// (get) Token: 0x0601C333 RID: 115507 RVA: 0x008954A4 File Offset: 0x008938A4
		public bool IgnoreBlock
		{
			get
			{
				int num = base.__offset(18);
				return num == 0 || 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C334 RID: 115508 RVA: 0x008954DF File Offset: 0x008938DF
		public static void StartDActionData(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x0601C335 RID: 115509 RVA: 0x008954E8 File Offset: 0x008938E8
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C336 RID: 115510 RVA: 0x008954F9 File Offset: 0x008938F9
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C337 RID: 115511 RVA: 0x00895504 File Offset: 0x00893904
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C338 RID: 115512 RVA: 0x0089550F File Offset: 0x0089390F
		public static void AddActionType(FlatBufferBuilder builder, int actionType)
		{
			builder.AddInt(3, actionType, 0);
		}

		// Token: 0x0601C339 RID: 115513 RVA: 0x0089551A File Offset: 0x0089391A
		public static void AddDuration(FlatBufferBuilder builder, float duration)
		{
			builder.AddFloat(4, duration, 0.0);
		}

		// Token: 0x0601C33A RID: 115514 RVA: 0x0089552D File Offset: 0x0089392D
		public static void AddDeltaScale(FlatBufferBuilder builder, float deltaScale)
		{
			builder.AddFloat(5, deltaScale, 0.0);
		}

		// Token: 0x0601C33B RID: 115515 RVA: 0x00895540 File Offset: 0x00893940
		public static void AddDeltaPos(FlatBufferBuilder builder, Offset<Vector3> deltaPosOffset)
		{
			builder.AddStruct(6, deltaPosOffset.Value, 0);
		}

		// Token: 0x0601C33C RID: 115516 RVA: 0x00895551 File Offset: 0x00893951
		public static void AddIgnoreBlock(FlatBufferBuilder builder, bool ignoreBlock)
		{
			builder.AddBool(7, ignoreBlock, true);
		}

		// Token: 0x0601C33D RID: 115517 RVA: 0x0089555C File Offset: 0x0089395C
		public static Offset<DActionData> EndDActionData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DActionData>(value);
		}
	}
}

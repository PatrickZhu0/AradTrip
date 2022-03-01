using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B34 RID: 19252
	public sealed class DSkillWalkControl : Table
	{
		// Token: 0x0601C2B3 RID: 115379 RVA: 0x0089444A File Offset: 0x0089284A
		public static DSkillWalkControl GetRootAsDSkillWalkControl(ByteBuffer _bb)
		{
			return DSkillWalkControl.GetRootAsDSkillWalkControl(_bb, new DSkillWalkControl());
		}

		// Token: 0x0601C2B4 RID: 115380 RVA: 0x00894457 File Offset: 0x00892857
		public static DSkillWalkControl GetRootAsDSkillWalkControl(ByteBuffer _bb, DSkillWalkControl obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C2B5 RID: 115381 RVA: 0x00894473 File Offset: 0x00892873
		public DSkillWalkControl __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002724 RID: 10020
		// (get) Token: 0x0601C2B6 RID: 115382 RVA: 0x00894484 File Offset: 0x00892884
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002725 RID: 10021
		// (get) Token: 0x0601C2B7 RID: 115383 RVA: 0x008944B4 File Offset: 0x008928B4
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002726 RID: 10022
		// (get) Token: 0x0601C2B8 RID: 115384 RVA: 0x008944E8 File Offset: 0x008928E8
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002727 RID: 10023
		// (get) Token: 0x0601C2B9 RID: 115385 RVA: 0x0089451C File Offset: 0x0089291C
		public int WalkMode
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002728 RID: 10024
		// (get) Token: 0x0601C2BA RID: 115386 RVA: 0x00894554 File Offset: 0x00892954
		public float WalkSpeedPercent
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002729 RID: 10025
		// (get) Token: 0x0601C2BB RID: 115387 RVA: 0x00894590 File Offset: 0x00892990
		public bool UseSkillSpeed
		{
			get
			{
				int num = base.__offset(14);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700272A RID: 10026
		// (get) Token: 0x0601C2BC RID: 115388 RVA: 0x008945CC File Offset: 0x008929CC
		public float WalkSpeedPercent2
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x0601C2BD RID: 115389 RVA: 0x00894608 File Offset: 0x00892A08
		public static Offset<DSkillWalkControl> CreateDSkillWalkControl(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int walkMode = 0, float walkSpeedPercent = 0f, bool useSkillSpeed = false, float walkSpeedPercent2 = 0f)
		{
			builder.StartObject(7);
			DSkillWalkControl.AddWalkSpeedPercent2(builder, walkSpeedPercent2);
			DSkillWalkControl.AddWalkSpeedPercent(builder, walkSpeedPercent);
			DSkillWalkControl.AddWalkMode(builder, walkMode);
			DSkillWalkControl.AddLength(builder, length);
			DSkillWalkControl.AddStartframe(builder, startframe);
			DSkillWalkControl.AddName(builder, name);
			DSkillWalkControl.AddUseSkillSpeed(builder, useSkillSpeed);
			return DSkillWalkControl.EndDSkillWalkControl(builder);
		}

		// Token: 0x0601C2BE RID: 115390 RVA: 0x00894657 File Offset: 0x00892A57
		public static void StartDSkillWalkControl(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0601C2BF RID: 115391 RVA: 0x00894660 File Offset: 0x00892A60
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C2C0 RID: 115392 RVA: 0x00894671 File Offset: 0x00892A71
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C2C1 RID: 115393 RVA: 0x0089467C File Offset: 0x00892A7C
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C2C2 RID: 115394 RVA: 0x00894687 File Offset: 0x00892A87
		public static void AddWalkMode(FlatBufferBuilder builder, int walkMode)
		{
			builder.AddInt(3, walkMode, 0);
		}

		// Token: 0x0601C2C3 RID: 115395 RVA: 0x00894692 File Offset: 0x00892A92
		public static void AddWalkSpeedPercent(FlatBufferBuilder builder, float walkSpeedPercent)
		{
			builder.AddFloat(4, walkSpeedPercent, 0.0);
		}

		// Token: 0x0601C2C4 RID: 115396 RVA: 0x008946A5 File Offset: 0x00892AA5
		public static void AddUseSkillSpeed(FlatBufferBuilder builder, bool useSkillSpeed)
		{
			builder.AddBool(5, useSkillSpeed, false);
		}

		// Token: 0x0601C2C5 RID: 115397 RVA: 0x008946B0 File Offset: 0x00892AB0
		public static void AddWalkSpeedPercent2(FlatBufferBuilder builder, float walkSpeedPercent2)
		{
			builder.AddFloat(6, walkSpeedPercent2, 0.0);
		}

		// Token: 0x0601C2C6 RID: 115398 RVA: 0x008946C4 File Offset: 0x00892AC4
		public static Offset<DSkillWalkControl> EndDSkillWalkControl(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillWalkControl>(value);
		}
	}
}

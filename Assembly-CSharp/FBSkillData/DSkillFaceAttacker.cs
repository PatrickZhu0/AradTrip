using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B37 RID: 19255
	public sealed class DSkillFaceAttacker : Table
	{
		// Token: 0x0601C2F8 RID: 115448 RVA: 0x00894CA6 File Offset: 0x008930A6
		public static DSkillFaceAttacker GetRootAsDSkillFaceAttacker(ByteBuffer _bb)
		{
			return DSkillFaceAttacker.GetRootAsDSkillFaceAttacker(_bb, new DSkillFaceAttacker());
		}

		// Token: 0x0601C2F9 RID: 115449 RVA: 0x00894CB3 File Offset: 0x008930B3
		public static DSkillFaceAttacker GetRootAsDSkillFaceAttacker(ByteBuffer _bb, DSkillFaceAttacker obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C2FA RID: 115450 RVA: 0x00894CCF File Offset: 0x008930CF
		public DSkillFaceAttacker __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700273C RID: 10044
		// (get) Token: 0x0601C2FB RID: 115451 RVA: 0x00894CE0 File Offset: 0x008930E0
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700273D RID: 10045
		// (get) Token: 0x0601C2FC RID: 115452 RVA: 0x00894D10 File Offset: 0x00893110
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700273E RID: 10046
		// (get) Token: 0x0601C2FD RID: 115453 RVA: 0x00894D44 File Offset: 0x00893144
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C2FE RID: 115454 RVA: 0x00894D78 File Offset: 0x00893178
		public static Offset<DSkillFaceAttacker> CreateDSkillFaceAttacker(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0)
		{
			builder.StartObject(3);
			DSkillFaceAttacker.AddLength(builder, length);
			DSkillFaceAttacker.AddStartframe(builder, startframe);
			DSkillFaceAttacker.AddName(builder, name);
			return DSkillFaceAttacker.EndDSkillFaceAttacker(builder);
		}

		// Token: 0x0601C2FF RID: 115455 RVA: 0x00894D9C File Offset: 0x0089319C
		public static void StartDSkillFaceAttacker(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0601C300 RID: 115456 RVA: 0x00894DA5 File Offset: 0x008931A5
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C301 RID: 115457 RVA: 0x00894DB6 File Offset: 0x008931B6
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C302 RID: 115458 RVA: 0x00894DC1 File Offset: 0x008931C1
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C303 RID: 115459 RVA: 0x00894DCC File Offset: 0x008931CC
		public static Offset<DSkillFaceAttacker> EndDSkillFaceAttacker(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillFaceAttacker>(value);
		}
	}
}

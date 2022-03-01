using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B27 RID: 19239
	public sealed class SkillJoystickConfig : Table
	{
		// Token: 0x0601C1DE RID: 115166 RVA: 0x00892C5E File Offset: 0x0089105E
		public static SkillJoystickConfig GetRootAsSkillJoystickConfig(ByteBuffer _bb)
		{
			return SkillJoystickConfig.GetRootAsSkillJoystickConfig(_bb, new SkillJoystickConfig());
		}

		// Token: 0x0601C1DF RID: 115167 RVA: 0x00892C6B File Offset: 0x0089106B
		public static SkillJoystickConfig GetRootAsSkillJoystickConfig(ByteBuffer _bb, SkillJoystickConfig obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C1E0 RID: 115168 RVA: 0x00892C87 File Offset: 0x00891087
		public SkillJoystickConfig __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026E8 RID: 9960
		// (get) Token: 0x0601C1E1 RID: 115169 RVA: 0x00892C98 File Offset: 0x00891098
		public int Mode
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026E9 RID: 9961
		// (get) Token: 0x0601C1E2 RID: 115170 RVA: 0x00892CCC File Offset: 0x008910CC
		public string EffectName
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026EA RID: 9962
		// (get) Token: 0x0601C1E3 RID: 115171 RVA: 0x00892CFB File Offset: 0x008910FB
		public Vector3 EffectMoveSpeed
		{
			get
			{
				return this.GetEffectMoveSpeed(new Vector3());
			}
		}

		// Token: 0x0601C1E4 RID: 115172 RVA: 0x00892D08 File Offset: 0x00891108
		public Vector3 GetEffectMoveSpeed(Vector3 obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170026EB RID: 9963
		// (get) Token: 0x0601C1E5 RID: 115173 RVA: 0x00892D3D File Offset: 0x0089113D
		public Vector3 EffectMoveRange
		{
			get
			{
				return this.GetEffectMoveRange(new Vector3());
			}
		}

		// Token: 0x0601C1E6 RID: 115174 RVA: 0x00892D4C File Offset: 0x0089114C
		public Vector3 GetEffectMoveRange(Vector3 obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601C1E7 RID: 115175 RVA: 0x00892D82 File Offset: 0x00891182
		public static void StartSkillJoystickConfig(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601C1E8 RID: 115176 RVA: 0x00892D8B File Offset: 0x0089118B
		public static void AddMode(FlatBufferBuilder builder, int mode)
		{
			builder.AddInt(0, mode, 0);
		}

		// Token: 0x0601C1E9 RID: 115177 RVA: 0x00892D96 File Offset: 0x00891196
		public static void AddEffectName(FlatBufferBuilder builder, StringOffset effectNameOffset)
		{
			builder.AddOffset(1, effectNameOffset.Value, 0);
		}

		// Token: 0x0601C1EA RID: 115178 RVA: 0x00892DA7 File Offset: 0x008911A7
		public static void AddEffectMoveSpeed(FlatBufferBuilder builder, Offset<Vector3> effectMoveSpeedOffset)
		{
			builder.AddStruct(2, effectMoveSpeedOffset.Value, 0);
		}

		// Token: 0x0601C1EB RID: 115179 RVA: 0x00892DB8 File Offset: 0x008911B8
		public static void AddEffectMoveRange(FlatBufferBuilder builder, Offset<Vector3> effectMoveRangeOffset)
		{
			builder.AddStruct(3, effectMoveRangeOffset.Value, 0);
		}

		// Token: 0x0601C1EC RID: 115180 RVA: 0x00892DCC File Offset: 0x008911CC
		public static Offset<SkillJoystickConfig> EndSkillJoystickConfig(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillJoystickConfig>(value);
		}
	}
}

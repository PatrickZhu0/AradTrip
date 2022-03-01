using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B26 RID: 19238
	public sealed class OperationConfig : Table
	{
		// Token: 0x0601C1D0 RID: 115152 RVA: 0x00892AE2 File Offset: 0x00890EE2
		public static OperationConfig GetRootAsOperationConfig(ByteBuffer _bb)
		{
			return OperationConfig.GetRootAsOperationConfig(_bb, new OperationConfig());
		}

		// Token: 0x0601C1D1 RID: 115153 RVA: 0x00892AEF File Offset: 0x00890EEF
		public static OperationConfig GetRootAsOperationConfig(ByteBuffer _bb, OperationConfig obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C1D2 RID: 115154 RVA: 0x00892B0B File Offset: 0x00890F0B
		public OperationConfig __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026E6 RID: 9958
		// (get) Token: 0x0601C1D3 RID: 115155 RVA: 0x00892B1C File Offset: 0x00890F1C
		public int ChangePhase
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C1D4 RID: 115156 RVA: 0x00892B50 File Offset: 0x00890F50
		public int GetChangeSkillIDs(int j)
		{
			int num = base.__offset(6);
			return (num == 0) ? 0 : this.bb.GetInt(base.__vector(num) + j * 4);
		}

		// Token: 0x170026E7 RID: 9959
		// (get) Token: 0x0601C1D5 RID: 115157 RVA: 0x00892B88 File Offset: 0x00890F88
		public int ChangeSkillIDsLength
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C1D6 RID: 115158 RVA: 0x00892BB0 File Offset: 0x00890FB0
		public static Offset<OperationConfig> CreateOperationConfig(FlatBufferBuilder builder, int changePhase = 0, VectorOffset changeSkillIDs = default(VectorOffset))
		{
			builder.StartObject(2);
			OperationConfig.AddChangeSkillIDs(builder, changeSkillIDs);
			OperationConfig.AddChangePhase(builder, changePhase);
			return OperationConfig.EndOperationConfig(builder);
		}

		// Token: 0x0601C1D7 RID: 115159 RVA: 0x00892BCD File Offset: 0x00890FCD
		public static void StartOperationConfig(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0601C1D8 RID: 115160 RVA: 0x00892BD6 File Offset: 0x00890FD6
		public static void AddChangePhase(FlatBufferBuilder builder, int changePhase)
		{
			builder.AddInt(0, changePhase, 0);
		}

		// Token: 0x0601C1D9 RID: 115161 RVA: 0x00892BE1 File Offset: 0x00890FE1
		public static void AddChangeSkillIDs(FlatBufferBuilder builder, VectorOffset changeSkillIDsOffset)
		{
			builder.AddOffset(1, changeSkillIDsOffset.Value, 0);
		}

		// Token: 0x0601C1DA RID: 115162 RVA: 0x00892BF4 File Offset: 0x00890FF4
		public static VectorOffset CreateChangeSkillIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C1DB RID: 115163 RVA: 0x00892C31 File Offset: 0x00891031
		public static void StartChangeSkillIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C1DC RID: 115164 RVA: 0x00892C3C File Offset: 0x0089103C
		public static Offset<OperationConfig> EndOperationConfig(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<OperationConfig>(value);
		}
	}
}

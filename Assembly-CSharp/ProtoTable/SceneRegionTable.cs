using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000591 RID: 1425
	public class SceneRegionTable : IFlatbufferObject
	{
		// Token: 0x17001401 RID: 5121
		// (get) Token: 0x060049CE RID: 18894 RVA: 0x000E8E0C File Offset: 0x000E720C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060049CF RID: 18895 RVA: 0x000E8E19 File Offset: 0x000E7219
		public static SceneRegionTable GetRootAsSceneRegionTable(ByteBuffer _bb)
		{
			return SceneRegionTable.GetRootAsSceneRegionTable(_bb, new SceneRegionTable());
		}

		// Token: 0x060049D0 RID: 18896 RVA: 0x000E8E26 File Offset: 0x000E7226
		public static SceneRegionTable GetRootAsSceneRegionTable(ByteBuffer _bb, SceneRegionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060049D1 RID: 18897 RVA: 0x000E8E42 File Offset: 0x000E7242
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060049D2 RID: 18898 RVA: 0x000E8E5C File Offset: 0x000E725C
		public SceneRegionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001402 RID: 5122
		// (get) Token: 0x060049D3 RID: 18899 RVA: 0x000E8E68 File Offset: 0x000E7268
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001403 RID: 5123
		// (get) Token: 0x060049D4 RID: 18900 RVA: 0x000E8EB4 File Offset: 0x000E72B4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060049D5 RID: 18901 RVA: 0x000E8EF6 File Offset: 0x000E72F6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001404 RID: 5124
		// (get) Token: 0x060049D6 RID: 18902 RVA: 0x000E8F04 File Offset: 0x000E7304
		public SceneRegionTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (SceneRegionTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001405 RID: 5125
		// (get) Token: 0x060049D7 RID: 18903 RVA: 0x000E8F48 File Offset: 0x000E7348
		public SceneRegionTable.eDoorType DoorType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (SceneRegionTable.eDoorType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001406 RID: 5126
		// (get) Token: 0x060049D8 RID: 18904 RVA: 0x000E8F8C File Offset: 0x000E738C
		public int ResID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001407 RID: 5127
		// (get) Token: 0x060049D9 RID: 18905 RVA: 0x000E8FD8 File Offset: 0x000E73D8
		public int ReplaceResID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060049DA RID: 18906 RVA: 0x000E9024 File Offset: 0x000E7424
		public int EffectIDArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001408 RID: 5128
		// (get) Token: 0x060049DB RID: 18907 RVA: 0x000E9074 File Offset: 0x000E7474
		public int EffectIDLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060049DC RID: 18908 RVA: 0x000E90A7 File Offset: 0x000E74A7
		public ArraySegment<byte>? GetEffectIDBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001409 RID: 5129
		// (get) Token: 0x060049DD RID: 18909 RVA: 0x000E90B6 File Offset: 0x000E74B6
		public FlatBufferArray<int> EffectID
		{
			get
			{
				if (this.EffectIDValue == null)
				{
					this.EffectIDValue = new FlatBufferArray<int>(new Func<int, int>(this.EffectIDArray), this.EffectIDLength);
				}
				return this.EffectIDValue;
			}
		}

		// Token: 0x1700140A RID: 5130
		// (get) Token: 0x060049DE RID: 18910 RVA: 0x000E90E8 File Offset: 0x000E74E8
		public int RepeatTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700140B RID: 5131
		// (get) Token: 0x060049DF RID: 18911 RVA: 0x000E9134 File Offset: 0x000E7534
		public int RepeatCount
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700140C RID: 5132
		// (get) Token: 0x060049E0 RID: 18912 RVA: 0x000E9180 File Offset: 0x000E7580
		public int FirstTimeToRepeat
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1166443832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700140D RID: 5133
		// (get) Token: 0x060049E1 RID: 18913 RVA: 0x000E91CC File Offset: 0x000E75CC
		public string ActivedEffect
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060049E2 RID: 18914 RVA: 0x000E920F File Offset: 0x000E760F
		public ArraySegment<byte>? GetActivedEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700140E RID: 5134
		// (get) Token: 0x060049E3 RID: 18915 RVA: 0x000E9220 File Offset: 0x000E7620
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060049E4 RID: 18916 RVA: 0x000E9263 File Offset: 0x000E7663
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x060049E5 RID: 18917 RVA: 0x000E9274 File Offset: 0x000E7674
		public static Offset<SceneRegionTable> CreateSceneRegionTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), SceneRegionTable.eType Type = SceneRegionTable.eType.BUFF, SceneRegionTable.eDoorType DoorType = SceneRegionTable.eDoorType.LEFT, int ResID = 0, int ReplaceResID = 0, VectorOffset EffectIDOffset = default(VectorOffset), int RepeatTime = 0, int RepeatCount = 0, int FirstTimeToRepeat = 0, StringOffset ActivedEffectOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset))
		{
			builder.StartObject(12);
			SceneRegionTable.AddDesc(builder, DescOffset);
			SceneRegionTable.AddActivedEffect(builder, ActivedEffectOffset);
			SceneRegionTable.AddFirstTimeToRepeat(builder, FirstTimeToRepeat);
			SceneRegionTable.AddRepeatCount(builder, RepeatCount);
			SceneRegionTable.AddRepeatTime(builder, RepeatTime);
			SceneRegionTable.AddEffectID(builder, EffectIDOffset);
			SceneRegionTable.AddReplaceResID(builder, ReplaceResID);
			SceneRegionTable.AddResID(builder, ResID);
			SceneRegionTable.AddDoorType(builder, DoorType);
			SceneRegionTable.AddType(builder, Type);
			SceneRegionTable.AddName(builder, NameOffset);
			SceneRegionTable.AddID(builder, ID);
			return SceneRegionTable.EndSceneRegionTable(builder);
		}

		// Token: 0x060049E6 RID: 18918 RVA: 0x000E92EC File Offset: 0x000E76EC
		public static void StartSceneRegionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x060049E7 RID: 18919 RVA: 0x000E92F6 File Offset: 0x000E76F6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060049E8 RID: 18920 RVA: 0x000E9301 File Offset: 0x000E7701
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060049E9 RID: 18921 RVA: 0x000E9312 File Offset: 0x000E7712
		public static void AddType(FlatBufferBuilder builder, SceneRegionTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x060049EA RID: 18922 RVA: 0x000E931D File Offset: 0x000E771D
		public static void AddDoorType(FlatBufferBuilder builder, SceneRegionTable.eDoorType DoorType)
		{
			builder.AddInt(3, (int)DoorType, 0);
		}

		// Token: 0x060049EB RID: 18923 RVA: 0x000E9328 File Offset: 0x000E7728
		public static void AddResID(FlatBufferBuilder builder, int ResID)
		{
			builder.AddInt(4, ResID, 0);
		}

		// Token: 0x060049EC RID: 18924 RVA: 0x000E9333 File Offset: 0x000E7733
		public static void AddReplaceResID(FlatBufferBuilder builder, int ReplaceResID)
		{
			builder.AddInt(5, ReplaceResID, 0);
		}

		// Token: 0x060049ED RID: 18925 RVA: 0x000E933E File Offset: 0x000E773E
		public static void AddEffectID(FlatBufferBuilder builder, VectorOffset EffectIDOffset)
		{
			builder.AddOffset(6, EffectIDOffset.Value, 0);
		}

		// Token: 0x060049EE RID: 18926 RVA: 0x000E9350 File Offset: 0x000E7750
		public static VectorOffset CreateEffectIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060049EF RID: 18927 RVA: 0x000E938D File Offset: 0x000E778D
		public static void StartEffectIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060049F0 RID: 18928 RVA: 0x000E9398 File Offset: 0x000E7798
		public static void AddRepeatTime(FlatBufferBuilder builder, int RepeatTime)
		{
			builder.AddInt(7, RepeatTime, 0);
		}

		// Token: 0x060049F1 RID: 18929 RVA: 0x000E93A3 File Offset: 0x000E77A3
		public static void AddRepeatCount(FlatBufferBuilder builder, int RepeatCount)
		{
			builder.AddInt(8, RepeatCount, 0);
		}

		// Token: 0x060049F2 RID: 18930 RVA: 0x000E93AE File Offset: 0x000E77AE
		public static void AddFirstTimeToRepeat(FlatBufferBuilder builder, int FirstTimeToRepeat)
		{
			builder.AddInt(9, FirstTimeToRepeat, 0);
		}

		// Token: 0x060049F3 RID: 18931 RVA: 0x000E93BA File Offset: 0x000E77BA
		public static void AddActivedEffect(FlatBufferBuilder builder, StringOffset ActivedEffectOffset)
		{
			builder.AddOffset(10, ActivedEffectOffset.Value, 0);
		}

		// Token: 0x060049F4 RID: 18932 RVA: 0x000E93CC File Offset: 0x000E77CC
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(11, DescOffset.Value, 0);
		}

		// Token: 0x060049F5 RID: 18933 RVA: 0x000E93E0 File Offset: 0x000E77E0
		public static Offset<SceneRegionTable> EndSceneRegionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SceneRegionTable>(value);
		}

		// Token: 0x060049F6 RID: 18934 RVA: 0x000E93FA File Offset: 0x000E77FA
		public static void FinishSceneRegionTableBuffer(FlatBufferBuilder builder, Offset<SceneRegionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AC7 RID: 6855
		private Table __p = new Table();

		// Token: 0x04001AC8 RID: 6856
		private FlatBufferArray<int> EffectIDValue;

		// Token: 0x02000592 RID: 1426
		public enum eType
		{
			// Token: 0x04001ACA RID: 6858
			BUFF,
			// Token: 0x04001ACB RID: 6859
			DOOR,
			// Token: 0x04001ACC RID: 6860
			TOWNDOOR,
			// Token: 0x04001ACD RID: 6861
			TRAP,
			// Token: 0x04001ACE RID: 6862
			LOOP,
			// Token: 0x04001ACF RID: 6863
			RIDE
		}

		// Token: 0x02000593 RID: 1427
		public enum eDoorType
		{
			// Token: 0x04001AD1 RID: 6865
			LEFT,
			// Token: 0x04001AD2 RID: 6866
			DT_NONE = -1,
			// Token: 0x04001AD3 RID: 6867
			TOP = 1,
			// Token: 0x04001AD4 RID: 6868
			RIGHT,
			// Token: 0x04001AD5 RID: 6869
			BUTTOM
		}

		// Token: 0x02000594 RID: 1428
		public enum eCrypt
		{
			// Token: 0x04001AD7 RID: 6871
			code = 1166443832
		}
	}
}

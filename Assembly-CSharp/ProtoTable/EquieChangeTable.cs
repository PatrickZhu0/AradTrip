using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003CF RID: 975
	public class EquieChangeTable : IFlatbufferObject
	{
		// Token: 0x17000A31 RID: 2609
		// (get) Token: 0x06002BB9 RID: 11193 RVA: 0x000A23E4 File Offset: 0x000A07E4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002BBA RID: 11194 RVA: 0x000A23F1 File Offset: 0x000A07F1
		public static EquieChangeTable GetRootAsEquieChangeTable(ByteBuffer _bb)
		{
			return EquieChangeTable.GetRootAsEquieChangeTable(_bb, new EquieChangeTable());
		}

		// Token: 0x06002BBB RID: 11195 RVA: 0x000A23FE File Offset: 0x000A07FE
		public static EquieChangeTable GetRootAsEquieChangeTable(ByteBuffer _bb, EquieChangeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002BBC RID: 11196 RVA: 0x000A241A File Offset: 0x000A081A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002BBD RID: 11197 RVA: 0x000A2434 File Offset: 0x000A0834
		public EquieChangeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x06002BBE RID: 11198 RVA: 0x000A2440 File Offset: 0x000A0840
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2015942963 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x06002BBF RID: 11199 RVA: 0x000A248C File Offset: 0x000A088C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002BC0 RID: 11200 RVA: 0x000A24CE File Offset: 0x000A08CE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06002BC1 RID: 11201 RVA: 0x000A24DC File Offset: 0x000A08DC
		public int JobIDArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-2015942963 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A34 RID: 2612
		// (get) Token: 0x06002BC2 RID: 11202 RVA: 0x000A2528 File Offset: 0x000A0928
		public int JobIDLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002BC3 RID: 11203 RVA: 0x000A255A File Offset: 0x000A095A
		public ArraySegment<byte>? GetJobIDBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x06002BC4 RID: 11204 RVA: 0x000A2568 File Offset: 0x000A0968
		public FlatBufferArray<int> JobID
		{
			get
			{
				if (this.JobIDValue == null)
				{
					this.JobIDValue = new FlatBufferArray<int>(new Func<int, int>(this.JobIDArray), this.JobIDLength);
				}
				return this.JobIDValue;
			}
		}

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x06002BC5 RID: 11205 RVA: 0x000A2598 File Offset: 0x000A0998
		public int ConvertType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2015942963 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002BC6 RID: 11206 RVA: 0x000A25E4 File Offset: 0x000A09E4
		public int UseEquipSuitArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-2015942963 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x06002BC7 RID: 11207 RVA: 0x000A2634 File Offset: 0x000A0A34
		public int UseEquipSuitLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002BC8 RID: 11208 RVA: 0x000A2667 File Offset: 0x000A0A67
		public ArraySegment<byte>? GetUseEquipSuitBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x06002BC9 RID: 11209 RVA: 0x000A2676 File Offset: 0x000A0A76
		public FlatBufferArray<int> UseEquipSuit
		{
			get
			{
				if (this.UseEquipSuitValue == null)
				{
					this.UseEquipSuitValue = new FlatBufferArray<int>(new Func<int, int>(this.UseEquipSuitArray), this.UseEquipSuitLength);
				}
				return this.UseEquipSuitValue;
			}
		}

		// Token: 0x06002BCA RID: 11210 RVA: 0x000A26A8 File Offset: 0x000A0AA8
		public int LevelArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-2015942963 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x06002BCB RID: 11211 RVA: 0x000A26F8 File Offset: 0x000A0AF8
		public int LevelLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002BCC RID: 11212 RVA: 0x000A272B File Offset: 0x000A0B2B
		public ArraySegment<byte>? GetLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x06002BCD RID: 11213 RVA: 0x000A273A File Offset: 0x000A0B3A
		public FlatBufferArray<int> Level
		{
			get
			{
				if (this.LevelValue == null)
				{
					this.LevelValue = new FlatBufferArray<int>(new Func<int, int>(this.LevelArray), this.LevelLength);
				}
				return this.LevelValue;
			}
		}

		// Token: 0x06002BCE RID: 11214 RVA: 0x000A276A File Offset: 0x000A0B6A
		public static Offset<EquieChangeTable> CreateEquieChangeTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset JobIDOffset = default(VectorOffset), int ConvertType = 0, VectorOffset UseEquipSuitOffset = default(VectorOffset), VectorOffset LevelOffset = default(VectorOffset))
		{
			builder.StartObject(6);
			EquieChangeTable.AddLevel(builder, LevelOffset);
			EquieChangeTable.AddUseEquipSuit(builder, UseEquipSuitOffset);
			EquieChangeTable.AddConvertType(builder, ConvertType);
			EquieChangeTable.AddJobID(builder, JobIDOffset);
			EquieChangeTable.AddName(builder, NameOffset);
			EquieChangeTable.AddID(builder, ID);
			return EquieChangeTable.EndEquieChangeTable(builder);
		}

		// Token: 0x06002BCF RID: 11215 RVA: 0x000A27A6 File Offset: 0x000A0BA6
		public static void StartEquieChangeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06002BD0 RID: 11216 RVA: 0x000A27AF File Offset: 0x000A0BAF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002BD1 RID: 11217 RVA: 0x000A27BA File Offset: 0x000A0BBA
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002BD2 RID: 11218 RVA: 0x000A27CB File Offset: 0x000A0BCB
		public static void AddJobID(FlatBufferBuilder builder, VectorOffset JobIDOffset)
		{
			builder.AddOffset(2, JobIDOffset.Value, 0);
		}

		// Token: 0x06002BD3 RID: 11219 RVA: 0x000A27DC File Offset: 0x000A0BDC
		public static VectorOffset CreateJobIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002BD4 RID: 11220 RVA: 0x000A2819 File Offset: 0x000A0C19
		public static void StartJobIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002BD5 RID: 11221 RVA: 0x000A2824 File Offset: 0x000A0C24
		public static void AddConvertType(FlatBufferBuilder builder, int ConvertType)
		{
			builder.AddInt(3, ConvertType, 0);
		}

		// Token: 0x06002BD6 RID: 11222 RVA: 0x000A282F File Offset: 0x000A0C2F
		public static void AddUseEquipSuit(FlatBufferBuilder builder, VectorOffset UseEquipSuitOffset)
		{
			builder.AddOffset(4, UseEquipSuitOffset.Value, 0);
		}

		// Token: 0x06002BD7 RID: 11223 RVA: 0x000A2840 File Offset: 0x000A0C40
		public static VectorOffset CreateUseEquipSuitVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002BD8 RID: 11224 RVA: 0x000A287D File Offset: 0x000A0C7D
		public static void StartUseEquipSuitVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002BD9 RID: 11225 RVA: 0x000A2888 File Offset: 0x000A0C88
		public static void AddLevel(FlatBufferBuilder builder, VectorOffset LevelOffset)
		{
			builder.AddOffset(5, LevelOffset.Value, 0);
		}

		// Token: 0x06002BDA RID: 11226 RVA: 0x000A289C File Offset: 0x000A0C9C
		public static VectorOffset CreateLevelVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002BDB RID: 11227 RVA: 0x000A28D9 File Offset: 0x000A0CD9
		public static void StartLevelVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002BDC RID: 11228 RVA: 0x000A28E4 File Offset: 0x000A0CE4
		public static Offset<EquieChangeTable> EndEquieChangeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquieChangeTable>(value);
		}

		// Token: 0x06002BDD RID: 11229 RVA: 0x000A28FE File Offset: 0x000A0CFE
		public static void FinishEquieChangeTableBuffer(FlatBufferBuilder builder, Offset<EquieChangeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040012FE RID: 4862
		private Table __p = new Table();

		// Token: 0x040012FF RID: 4863
		private FlatBufferArray<int> JobIDValue;

		// Token: 0x04001300 RID: 4864
		private FlatBufferArray<int> UseEquipSuitValue;

		// Token: 0x04001301 RID: 4865
		private FlatBufferArray<int> LevelValue;

		// Token: 0x020003D0 RID: 976
		public enum eCrypt
		{
			// Token: 0x04001303 RID: 4867
			code = -2015942963
		}
	}
}

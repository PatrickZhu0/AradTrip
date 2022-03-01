using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002D6 RID: 726
	public class BetHorseMap : IFlatbufferObject
	{
		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06001A6B RID: 6763 RVA: 0x00077EE8 File Offset: 0x000762E8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x00077EF5 File Offset: 0x000762F5
		public static BetHorseMap GetRootAsBetHorseMap(ByteBuffer _bb)
		{
			return BetHorseMap.GetRootAsBetHorseMap(_bb, new BetHorseMap());
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x00077F02 File Offset: 0x00076302
		public static BetHorseMap GetRootAsBetHorseMap(ByteBuffer _bb, BetHorseMap obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x00077F1E File Offset: 0x0007631E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x00077F38 File Offset: 0x00076338
		public BetHorseMap __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06001A70 RID: 6768 RVA: 0x00077F44 File Offset: 0x00076344
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2141412036 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06001A71 RID: 6769 RVA: 0x00077F90 File Offset: 0x00076390
		public int MapPhase
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (2141412036 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06001A72 RID: 6770 RVA: 0x00077FDC File Offset: 0x000763DC
		public int NextMap
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2141412036 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06001A73 RID: 6771 RVA: 0x00078028 File Offset: 0x00076428
		public string Name
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x0007806B File Offset: 0x0007646B
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06001A75 RID: 6773 RVA: 0x0007807C File Offset: 0x0007647C
		public string TerrainPathsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06001A76 RID: 6774 RVA: 0x000780C4 File Offset: 0x000764C4
		public int TerrainPathsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06001A77 RID: 6775 RVA: 0x000780F7 File Offset: 0x000764F7
		public FlatBufferArray<string> TerrainPaths
		{
			get
			{
				if (this.TerrainPathsValue == null)
				{
					this.TerrainPathsValue = new FlatBufferArray<string>(new Func<int, string>(this.TerrainPathsArray), this.TerrainPathsLength);
				}
				return this.TerrainPathsValue;
			}
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x00078127 File Offset: 0x00076527
		public static Offset<BetHorseMap> CreateBetHorseMap(FlatBufferBuilder builder, int ID = 0, int MapPhase = 0, int NextMap = 0, StringOffset NameOffset = default(StringOffset), VectorOffset TerrainPathsOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			BetHorseMap.AddTerrainPaths(builder, TerrainPathsOffset);
			BetHorseMap.AddName(builder, NameOffset);
			BetHorseMap.AddNextMap(builder, NextMap);
			BetHorseMap.AddMapPhase(builder, MapPhase);
			BetHorseMap.AddID(builder, ID);
			return BetHorseMap.EndBetHorseMap(builder);
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x0007815B File Offset: 0x0007655B
		public static void StartBetHorseMap(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x00078164 File Offset: 0x00076564
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x0007816F File Offset: 0x0007656F
		public static void AddMapPhase(FlatBufferBuilder builder, int MapPhase)
		{
			builder.AddInt(1, MapPhase, 0);
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x0007817A File Offset: 0x0007657A
		public static void AddNextMap(FlatBufferBuilder builder, int NextMap)
		{
			builder.AddInt(2, NextMap, 0);
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x00078185 File Offset: 0x00076585
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(3, NameOffset.Value, 0);
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x00078196 File Offset: 0x00076596
		public static void AddTerrainPaths(FlatBufferBuilder builder, VectorOffset TerrainPathsOffset)
		{
			builder.AddOffset(4, TerrainPathsOffset.Value, 0);
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x000781A8 File Offset: 0x000765A8
		public static VectorOffset CreateTerrainPathsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x000781EE File Offset: 0x000765EE
		public static void StartTerrainPathsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A81 RID: 6785 RVA: 0x000781FC File Offset: 0x000765FC
		public static Offset<BetHorseMap> EndBetHorseMap(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseMap>(value);
		}

		// Token: 0x06001A82 RID: 6786 RVA: 0x00078216 File Offset: 0x00076616
		public static void FinishBetHorseMapBuffer(FlatBufferBuilder builder, Offset<BetHorseMap> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EA7 RID: 3751
		private Table __p = new Table();

		// Token: 0x04000EA8 RID: 3752
		private FlatBufferArray<string> TerrainPathsValue;

		// Token: 0x020002D7 RID: 727
		public enum eCrypt
		{
			// Token: 0x04000EAA RID: 3754
			code = 2141412036
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200031F RID: 799
	public class ChiJiPkSceneTable : IFlatbufferObject
	{
		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06001FB3 RID: 8115 RVA: 0x00084B08 File Offset: 0x00082F08
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001FB4 RID: 8116 RVA: 0x00084B15 File Offset: 0x00082F15
		public static ChiJiPkSceneTable GetRootAsChiJiPkSceneTable(ByteBuffer _bb)
		{
			return ChiJiPkSceneTable.GetRootAsChiJiPkSceneTable(_bb, new ChiJiPkSceneTable());
		}

		// Token: 0x06001FB5 RID: 8117 RVA: 0x00084B22 File Offset: 0x00082F22
		public static ChiJiPkSceneTable GetRootAsChiJiPkSceneTable(ByteBuffer _bb, ChiJiPkSceneTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001FB6 RID: 8118 RVA: 0x00084B3E File Offset: 0x00082F3E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001FB7 RID: 8119 RVA: 0x00084B58 File Offset: 0x00082F58
		public ChiJiPkSceneTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06001FB8 RID: 8120 RVA: 0x00084B64 File Offset: 0x00082F64
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1069274954 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06001FB9 RID: 8121 RVA: 0x00084BB0 File Offset: 0x00082FB0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x00084BF2 File Offset: 0x00082FF2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x06001FBB RID: 8123 RVA: 0x00084C00 File Offset: 0x00083000
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1069274954 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001FBC RID: 8124 RVA: 0x00084C4C File Offset: 0x0008304C
		public int SceneRangeArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1069274954 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06001FBD RID: 8125 RVA: 0x00084C9C File Offset: 0x0008309C
		public int SceneRangeLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001FBE RID: 8126 RVA: 0x00084CCF File Offset: 0x000830CF
		public ArraySegment<byte>? GetSceneRangeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06001FBF RID: 8127 RVA: 0x00084CDE File Offset: 0x000830DE
		public FlatBufferArray<int> SceneRange
		{
			get
			{
				if (this.SceneRangeValue == null)
				{
					this.SceneRangeValue = new FlatBufferArray<int>(new Func<int, int>(this.SceneRangeArray), this.SceneRangeLength);
				}
				return this.SceneRangeValue;
			}
		}

		// Token: 0x06001FC0 RID: 8128 RVA: 0x00084D0E File Offset: 0x0008310E
		public static Offset<ChiJiPkSceneTable> CreateChiJiPkSceneTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int DungeonID = 0, VectorOffset SceneRangeOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			ChiJiPkSceneTable.AddSceneRange(builder, SceneRangeOffset);
			ChiJiPkSceneTable.AddDungeonID(builder, DungeonID);
			ChiJiPkSceneTable.AddName(builder, NameOffset);
			ChiJiPkSceneTable.AddID(builder, ID);
			return ChiJiPkSceneTable.EndChiJiPkSceneTable(builder);
		}

		// Token: 0x06001FC1 RID: 8129 RVA: 0x00084D3A File Offset: 0x0008313A
		public static void StartChiJiPkSceneTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001FC2 RID: 8130 RVA: 0x00084D43 File Offset: 0x00083143
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001FC3 RID: 8131 RVA: 0x00084D4E File Offset: 0x0008314E
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x00084D5F File Offset: 0x0008315F
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(2, DungeonID, 0);
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x00084D6A File Offset: 0x0008316A
		public static void AddSceneRange(FlatBufferBuilder builder, VectorOffset SceneRangeOffset)
		{
			builder.AddOffset(3, SceneRangeOffset.Value, 0);
		}

		// Token: 0x06001FC6 RID: 8134 RVA: 0x00084D7C File Offset: 0x0008317C
		public static VectorOffset CreateSceneRangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x00084DB9 File Offset: 0x000831B9
		public static void StartSceneRangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x00084DC4 File Offset: 0x000831C4
		public static Offset<ChiJiPkSceneTable> EndChiJiPkSceneTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiPkSceneTable>(value);
		}

		// Token: 0x06001FC9 RID: 8137 RVA: 0x00084DDE File Offset: 0x000831DE
		public static void FinishChiJiPkSceneTableBuffer(FlatBufferBuilder builder, Offset<ChiJiPkSceneTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F70 RID: 3952
		private Table __p = new Table();

		// Token: 0x04000F71 RID: 3953
		private FlatBufferArray<int> SceneRangeValue;

		// Token: 0x02000320 RID: 800
		public enum eCrypt
		{
			// Token: 0x04000F73 RID: 3955
			code = -1069274954
		}
	}
}

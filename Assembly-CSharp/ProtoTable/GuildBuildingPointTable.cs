using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000467 RID: 1127
	public class GuildBuildingPointTable : IFlatbufferObject
	{
		// Token: 0x17000D83 RID: 3459
		// (get) Token: 0x06003625 RID: 13861 RVA: 0x000BACEC File Offset: 0x000B90EC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003626 RID: 13862 RVA: 0x000BACF9 File Offset: 0x000B90F9
		public static GuildBuildingPointTable GetRootAsGuildBuildingPointTable(ByteBuffer _bb)
		{
			return GuildBuildingPointTable.GetRootAsGuildBuildingPointTable(_bb, new GuildBuildingPointTable());
		}

		// Token: 0x06003627 RID: 13863 RVA: 0x000BAD06 File Offset: 0x000B9106
		public static GuildBuildingPointTable GetRootAsGuildBuildingPointTable(ByteBuffer _bb, GuildBuildingPointTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003628 RID: 13864 RVA: 0x000BAD22 File Offset: 0x000B9122
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003629 RID: 13865 RVA: 0x000BAD3C File Offset: 0x000B913C
		public GuildBuildingPointTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D84 RID: 3460
		// (get) Token: 0x0600362A RID: 13866 RVA: 0x000BAD48 File Offset: 0x000B9148
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-789860713 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600362B RID: 13867 RVA: 0x000BAD94 File Offset: 0x000B9194
		public int buildLvlArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-789860713 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D85 RID: 3461
		// (get) Token: 0x0600362C RID: 13868 RVA: 0x000BADE0 File Offset: 0x000B91E0
		public int buildLvlLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600362D RID: 13869 RVA: 0x000BAE12 File Offset: 0x000B9212
		public ArraySegment<byte>? GetBuildLvlBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D86 RID: 3462
		// (get) Token: 0x0600362E RID: 13870 RVA: 0x000BAE20 File Offset: 0x000B9220
		public FlatBufferArray<int> buildLvl
		{
			get
			{
				if (this.buildLvlValue == null)
				{
					this.buildLvlValue = new FlatBufferArray<int>(new Func<int, int>(this.buildLvlArray), this.buildLvlLength);
				}
				return this.buildLvlValue;
			}
		}

		// Token: 0x0600362F RID: 13871 RVA: 0x000BAE50 File Offset: 0x000B9250
		public int buildPointArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-789860713 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D87 RID: 3463
		// (get) Token: 0x06003630 RID: 13872 RVA: 0x000BAE9C File Offset: 0x000B929C
		public int buildPointLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003631 RID: 13873 RVA: 0x000BAECE File Offset: 0x000B92CE
		public ArraySegment<byte>? GetBuildPointBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000D88 RID: 3464
		// (get) Token: 0x06003632 RID: 13874 RVA: 0x000BAEDC File Offset: 0x000B92DC
		public FlatBufferArray<int> buildPoint
		{
			get
			{
				if (this.buildPointValue == null)
				{
					this.buildPointValue = new FlatBufferArray<int>(new Func<int, int>(this.buildPointArray), this.buildPointLength);
				}
				return this.buildPointValue;
			}
		}

		// Token: 0x06003633 RID: 13875 RVA: 0x000BAF0C File Offset: 0x000B930C
		public static Offset<GuildBuildingPointTable> CreateGuildBuildingPointTable(FlatBufferBuilder builder, int ID = 0, VectorOffset buildLvlOffset = default(VectorOffset), VectorOffset buildPointOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			GuildBuildingPointTable.AddBuildPoint(builder, buildPointOffset);
			GuildBuildingPointTable.AddBuildLvl(builder, buildLvlOffset);
			GuildBuildingPointTable.AddID(builder, ID);
			return GuildBuildingPointTable.EndGuildBuildingPointTable(builder);
		}

		// Token: 0x06003634 RID: 13876 RVA: 0x000BAF30 File Offset: 0x000B9330
		public static void StartGuildBuildingPointTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06003635 RID: 13877 RVA: 0x000BAF39 File Offset: 0x000B9339
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003636 RID: 13878 RVA: 0x000BAF44 File Offset: 0x000B9344
		public static void AddBuildLvl(FlatBufferBuilder builder, VectorOffset buildLvlOffset)
		{
			builder.AddOffset(1, buildLvlOffset.Value, 0);
		}

		// Token: 0x06003637 RID: 13879 RVA: 0x000BAF58 File Offset: 0x000B9358
		public static VectorOffset CreateBuildLvlVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003638 RID: 13880 RVA: 0x000BAF95 File Offset: 0x000B9395
		public static void StartBuildLvlVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003639 RID: 13881 RVA: 0x000BAFA0 File Offset: 0x000B93A0
		public static void AddBuildPoint(FlatBufferBuilder builder, VectorOffset buildPointOffset)
		{
			builder.AddOffset(2, buildPointOffset.Value, 0);
		}

		// Token: 0x0600363A RID: 13882 RVA: 0x000BAFB4 File Offset: 0x000B93B4
		public static VectorOffset CreateBuildPointVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600363B RID: 13883 RVA: 0x000BAFF1 File Offset: 0x000B93F1
		public static void StartBuildPointVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600363C RID: 13884 RVA: 0x000BAFFC File Offset: 0x000B93FC
		public static Offset<GuildBuildingPointTable> EndGuildBuildingPointTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildBuildingPointTable>(value);
		}

		// Token: 0x0600363D RID: 13885 RVA: 0x000BB016 File Offset: 0x000B9416
		public static void FinishGuildBuildingPointTableBuffer(FlatBufferBuilder builder, Offset<GuildBuildingPointTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015AE RID: 5550
		private Table __p = new Table();

		// Token: 0x040015AF RID: 5551
		private FlatBufferArray<int> buildLvlValue;

		// Token: 0x040015B0 RID: 5552
		private FlatBufferArray<int> buildPointValue;

		// Token: 0x02000468 RID: 1128
		public enum eCrypt
		{
			// Token: 0x040015B2 RID: 5554
			code = -789860713
		}
	}
}

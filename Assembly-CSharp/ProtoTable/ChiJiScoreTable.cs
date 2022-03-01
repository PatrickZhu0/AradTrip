using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000325 RID: 805
	public class ChiJiScoreTable : IFlatbufferObject
	{
		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06001FF2 RID: 8178 RVA: 0x00085268 File Offset: 0x00083668
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001FF3 RID: 8179 RVA: 0x00085275 File Offset: 0x00083675
		public static ChiJiScoreTable GetRootAsChiJiScoreTable(ByteBuffer _bb)
		{
			return ChiJiScoreTable.GetRootAsChiJiScoreTable(_bb, new ChiJiScoreTable());
		}

		// Token: 0x06001FF4 RID: 8180 RVA: 0x00085282 File Offset: 0x00083682
		public static ChiJiScoreTable GetRootAsChiJiScoreTable(ByteBuffer _bb, ChiJiScoreTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001FF5 RID: 8181 RVA: 0x0008529E File Offset: 0x0008369E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001FF6 RID: 8182 RVA: 0x000852B8 File Offset: 0x000836B8
		public ChiJiScoreTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06001FF7 RID: 8183 RVA: 0x000852C4 File Offset: 0x000836C4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (880083663 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06001FF8 RID: 8184 RVA: 0x00085310 File Offset: 0x00083710
		public int Score
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (880083663 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001FF9 RID: 8185 RVA: 0x00085359 File Offset: 0x00083759
		public static Offset<ChiJiScoreTable> CreateChiJiScoreTable(FlatBufferBuilder builder, int ID = 0, int Score = 0)
		{
			builder.StartObject(2);
			ChiJiScoreTable.AddScore(builder, Score);
			ChiJiScoreTable.AddID(builder, ID);
			return ChiJiScoreTable.EndChiJiScoreTable(builder);
		}

		// Token: 0x06001FFA RID: 8186 RVA: 0x00085376 File Offset: 0x00083776
		public static void StartChiJiScoreTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06001FFB RID: 8187 RVA: 0x0008537F File Offset: 0x0008377F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001FFC RID: 8188 RVA: 0x0008538A File Offset: 0x0008378A
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(1, Score, 0);
		}

		// Token: 0x06001FFD RID: 8189 RVA: 0x00085398 File Offset: 0x00083798
		public static Offset<ChiJiScoreTable> EndChiJiScoreTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiScoreTable>(value);
		}

		// Token: 0x06001FFE RID: 8190 RVA: 0x000853B2 File Offset: 0x000837B2
		public static void FinishChiJiScoreTableBuffer(FlatBufferBuilder builder, Offset<ChiJiScoreTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F7B RID: 3963
		private Table __p = new Table();

		// Token: 0x02000326 RID: 806
		public enum eCrypt
		{
			// Token: 0x04000F7D RID: 3965
			code = 880083663
		}
	}
}

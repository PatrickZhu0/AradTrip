using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000302 RID: 770
	public class ChampionshipGuessBetTable : IFlatbufferObject
	{
		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06001E57 RID: 7767 RVA: 0x00081D88 File Offset: 0x00080188
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001E58 RID: 7768 RVA: 0x00081D95 File Offset: 0x00080195
		public static ChampionshipGuessBetTable GetRootAsChampionshipGuessBetTable(ByteBuffer _bb)
		{
			return ChampionshipGuessBetTable.GetRootAsChampionshipGuessBetTable(_bb, new ChampionshipGuessBetTable());
		}

		// Token: 0x06001E59 RID: 7769 RVA: 0x00081DA2 File Offset: 0x000801A2
		public static ChampionshipGuessBetTable GetRootAsChampionshipGuessBetTable(ByteBuffer _bb, ChampionshipGuessBetTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x00081DBE File Offset: 0x000801BE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x00081DD8 File Offset: 0x000801D8
		public ChampionshipGuessBetTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06001E5C RID: 7772 RVA: 0x00081DE4 File Offset: 0x000801E4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1108085613 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06001E5D RID: 7773 RVA: 0x00081E30 File Offset: 0x00080230
		public int BetValue
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1108085613 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001E5E RID: 7774 RVA: 0x00081E79 File Offset: 0x00080279
		public static Offset<ChampionshipGuessBetTable> CreateChampionshipGuessBetTable(FlatBufferBuilder builder, int ID = 0, int BetValue = 0)
		{
			builder.StartObject(2);
			ChampionshipGuessBetTable.AddBetValue(builder, BetValue);
			ChampionshipGuessBetTable.AddID(builder, ID);
			return ChampionshipGuessBetTable.EndChampionshipGuessBetTable(builder);
		}

		// Token: 0x06001E5F RID: 7775 RVA: 0x00081E96 File Offset: 0x00080296
		public static void StartChampionshipGuessBetTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x00081E9F File Offset: 0x0008029F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001E61 RID: 7777 RVA: 0x00081EAA File Offset: 0x000802AA
		public static void AddBetValue(FlatBufferBuilder builder, int BetValue)
		{
			builder.AddInt(1, BetValue, 0);
		}

		// Token: 0x06001E62 RID: 7778 RVA: 0x00081EB8 File Offset: 0x000802B8
		public static Offset<ChampionshipGuessBetTable> EndChampionshipGuessBetTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionshipGuessBetTable>(value);
		}

		// Token: 0x06001E63 RID: 7779 RVA: 0x00081ED2 File Offset: 0x000802D2
		public static void FinishChampionshipGuessBetTableBuffer(FlatBufferBuilder builder, Offset<ChampionshipGuessBetTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F2E RID: 3886
		private Table __p = new Table();

		// Token: 0x02000303 RID: 771
		public enum eCrypt
		{
			// Token: 0x04000F30 RID: 3888
			code = -1108085613
		}
	}
}

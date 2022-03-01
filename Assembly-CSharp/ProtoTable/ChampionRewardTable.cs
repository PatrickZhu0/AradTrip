using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002FD RID: 765
	public class ChampionRewardTable : IFlatbufferObject
	{
		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06001E1B RID: 7707 RVA: 0x000815C0 File Offset: 0x0007F9C0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001E1C RID: 7708 RVA: 0x000815CD File Offset: 0x0007F9CD
		public static ChampionRewardTable GetRootAsChampionRewardTable(ByteBuffer _bb)
		{
			return ChampionRewardTable.GetRootAsChampionRewardTable(_bb, new ChampionRewardTable());
		}

		// Token: 0x06001E1D RID: 7709 RVA: 0x000815DA File Offset: 0x0007F9DA
		public static ChampionRewardTable GetRootAsChampionRewardTable(ByteBuffer _bb, ChampionRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001E1E RID: 7710 RVA: 0x000815F6 File Offset: 0x0007F9F6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001E1F RID: 7711 RVA: 0x00081610 File Offset: 0x0007FA10
		public ChampionRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06001E20 RID: 7712 RVA: 0x0008161C File Offset: 0x0007FA1C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1069531270 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06001E21 RID: 7713 RVA: 0x00081668 File Offset: 0x0007FA68
		public int PlayerState
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1069531270 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06001E22 RID: 7714 RVA: 0x000816B4 File Offset: 0x0007FAB4
		public int ChampionState
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1069531270 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06001E23 RID: 7715 RVA: 0x00081700 File Offset: 0x0007FB00
		public string ItemReward
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E24 RID: 7716 RVA: 0x00081743 File Offset: 0x0007FB43
		public ArraySegment<byte>? GetItemRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06001E25 RID: 7717 RVA: 0x00081754 File Offset: 0x0007FB54
		public int title
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1069531270 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06001E26 RID: 7718 RVA: 0x000817A0 File Offset: 0x0007FBA0
		public int sender
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1069531270 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06001E27 RID: 7719 RVA: 0x000817EC File Offset: 0x0007FBEC
		public int content
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1069531270 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001E28 RID: 7720 RVA: 0x00081838 File Offset: 0x0007FC38
		public static Offset<ChampionRewardTable> CreateChampionRewardTable(FlatBufferBuilder builder, int ID = 0, int PlayerState = 0, int ChampionState = 0, StringOffset ItemRewardOffset = default(StringOffset), int title = 0, int sender = 0, int content = 0)
		{
			builder.StartObject(7);
			ChampionRewardTable.AddContent(builder, content);
			ChampionRewardTable.AddSender(builder, sender);
			ChampionRewardTable.AddTitle(builder, title);
			ChampionRewardTable.AddItemReward(builder, ItemRewardOffset);
			ChampionRewardTable.AddChampionState(builder, ChampionState);
			ChampionRewardTable.AddPlayerState(builder, PlayerState);
			ChampionRewardTable.AddID(builder, ID);
			return ChampionRewardTable.EndChampionRewardTable(builder);
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x00081887 File Offset: 0x0007FC87
		public static void StartChampionRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06001E2A RID: 7722 RVA: 0x00081890 File Offset: 0x0007FC90
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001E2B RID: 7723 RVA: 0x0008189B File Offset: 0x0007FC9B
		public static void AddPlayerState(FlatBufferBuilder builder, int PlayerState)
		{
			builder.AddInt(1, PlayerState, 0);
		}

		// Token: 0x06001E2C RID: 7724 RVA: 0x000818A6 File Offset: 0x0007FCA6
		public static void AddChampionState(FlatBufferBuilder builder, int ChampionState)
		{
			builder.AddInt(2, ChampionState, 0);
		}

		// Token: 0x06001E2D RID: 7725 RVA: 0x000818B1 File Offset: 0x0007FCB1
		public static void AddItemReward(FlatBufferBuilder builder, StringOffset ItemRewardOffset)
		{
			builder.AddOffset(3, ItemRewardOffset.Value, 0);
		}

		// Token: 0x06001E2E RID: 7726 RVA: 0x000818C2 File Offset: 0x0007FCC2
		public static void AddTitle(FlatBufferBuilder builder, int title)
		{
			builder.AddInt(4, title, 0);
		}

		// Token: 0x06001E2F RID: 7727 RVA: 0x000818CD File Offset: 0x0007FCCD
		public static void AddSender(FlatBufferBuilder builder, int sender)
		{
			builder.AddInt(5, sender, 0);
		}

		// Token: 0x06001E30 RID: 7728 RVA: 0x000818D8 File Offset: 0x0007FCD8
		public static void AddContent(FlatBufferBuilder builder, int content)
		{
			builder.AddInt(6, content, 0);
		}

		// Token: 0x06001E31 RID: 7729 RVA: 0x000818E4 File Offset: 0x0007FCE4
		public static Offset<ChampionRewardTable> EndChampionRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionRewardTable>(value);
		}

		// Token: 0x06001E32 RID: 7730 RVA: 0x000818FE File Offset: 0x0007FCFE
		public static void FinishChampionRewardTableBuffer(FlatBufferBuilder builder, Offset<ChampionRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F1D RID: 3869
		private Table __p = new Table();

		// Token: 0x020002FE RID: 766
		public enum eCrypt
		{
			// Token: 0x04000F1F RID: 3871
			code = 1069531270
		}
	}
}

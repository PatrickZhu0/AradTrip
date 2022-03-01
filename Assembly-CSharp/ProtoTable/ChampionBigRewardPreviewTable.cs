using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002F8 RID: 760
	public class ChampionBigRewardPreviewTable : IFlatbufferObject
	{
		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06001DE5 RID: 7653 RVA: 0x00080EA4 File Offset: 0x0007F2A4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001DE6 RID: 7654 RVA: 0x00080EB1 File Offset: 0x0007F2B1
		public static ChampionBigRewardPreviewTable GetRootAsChampionBigRewardPreviewTable(ByteBuffer _bb)
		{
			return ChampionBigRewardPreviewTable.GetRootAsChampionBigRewardPreviewTable(_bb, new ChampionBigRewardPreviewTable());
		}

		// Token: 0x06001DE7 RID: 7655 RVA: 0x00080EBE File Offset: 0x0007F2BE
		public static ChampionBigRewardPreviewTable GetRootAsChampionBigRewardPreviewTable(ByteBuffer _bb, ChampionBigRewardPreviewTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001DE8 RID: 7656 RVA: 0x00080EDA File Offset: 0x0007F2DA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001DE9 RID: 7657 RVA: 0x00080EF4 File Offset: 0x0007F2F4
		public ChampionBigRewardPreviewTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06001DEA RID: 7658 RVA: 0x00080F00 File Offset: 0x0007F300
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (750971628 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06001DEB RID: 7659 RVA: 0x00080F4C File Offset: 0x0007F34C
		public string ScheduleName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001DEC RID: 7660 RVA: 0x00080F8E File Offset: 0x0007F38E
		public ArraySegment<byte>? GetScheduleNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06001DED RID: 7661 RVA: 0x00080F9C File Offset: 0x0007F39C
		public int SortId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (750971628 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06001DEE RID: 7662 RVA: 0x00080FE8 File Offset: 0x0007F3E8
		public int IsShowFlag
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (750971628 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001DEF RID: 7663 RVA: 0x00081034 File Offset: 0x0007F434
		public string ItemRewardArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06001DF0 RID: 7664 RVA: 0x0008107C File Offset: 0x0007F47C
		public int ItemRewardLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06001DF1 RID: 7665 RVA: 0x000810AF File Offset: 0x0007F4AF
		public FlatBufferArray<string> ItemReward
		{
			get
			{
				if (this.ItemRewardValue == null)
				{
					this.ItemRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.ItemRewardArray), this.ItemRewardLength);
				}
				return this.ItemRewardValue;
			}
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x000810DF File Offset: 0x0007F4DF
		public static Offset<ChampionBigRewardPreviewTable> CreateChampionBigRewardPreviewTable(FlatBufferBuilder builder, int ID = 0, StringOffset ScheduleNameOffset = default(StringOffset), int SortId = 0, int IsShowFlag = 0, VectorOffset ItemRewardOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			ChampionBigRewardPreviewTable.AddItemReward(builder, ItemRewardOffset);
			ChampionBigRewardPreviewTable.AddIsShowFlag(builder, IsShowFlag);
			ChampionBigRewardPreviewTable.AddSortId(builder, SortId);
			ChampionBigRewardPreviewTable.AddScheduleName(builder, ScheduleNameOffset);
			ChampionBigRewardPreviewTable.AddID(builder, ID);
			return ChampionBigRewardPreviewTable.EndChampionBigRewardPreviewTable(builder);
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x00081113 File Offset: 0x0007F513
		public static void StartChampionBigRewardPreviewTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06001DF4 RID: 7668 RVA: 0x0008111C File Offset: 0x0007F51C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001DF5 RID: 7669 RVA: 0x00081127 File Offset: 0x0007F527
		public static void AddScheduleName(FlatBufferBuilder builder, StringOffset ScheduleNameOffset)
		{
			builder.AddOffset(1, ScheduleNameOffset.Value, 0);
		}

		// Token: 0x06001DF6 RID: 7670 RVA: 0x00081138 File Offset: 0x0007F538
		public static void AddSortId(FlatBufferBuilder builder, int SortId)
		{
			builder.AddInt(2, SortId, 0);
		}

		// Token: 0x06001DF7 RID: 7671 RVA: 0x00081143 File Offset: 0x0007F543
		public static void AddIsShowFlag(FlatBufferBuilder builder, int IsShowFlag)
		{
			builder.AddInt(3, IsShowFlag, 0);
		}

		// Token: 0x06001DF8 RID: 7672 RVA: 0x0008114E File Offset: 0x0007F54E
		public static void AddItemReward(FlatBufferBuilder builder, VectorOffset ItemRewardOffset)
		{
			builder.AddOffset(4, ItemRewardOffset.Value, 0);
		}

		// Token: 0x06001DF9 RID: 7673 RVA: 0x00081160 File Offset: 0x0007F560
		public static VectorOffset CreateItemRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DFA RID: 7674 RVA: 0x000811A6 File Offset: 0x0007F5A6
		public static void StartItemRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DFB RID: 7675 RVA: 0x000811B4 File Offset: 0x0007F5B4
		public static Offset<ChampionBigRewardPreviewTable> EndChampionBigRewardPreviewTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionBigRewardPreviewTable>(value);
		}

		// Token: 0x06001DFC RID: 7676 RVA: 0x000811CE File Offset: 0x0007F5CE
		public static void FinishChampionBigRewardPreviewTableBuffer(FlatBufferBuilder builder, Offset<ChampionBigRewardPreviewTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F10 RID: 3856
		private Table __p = new Table();

		// Token: 0x04000F11 RID: 3857
		private FlatBufferArray<string> ItemRewardValue;

		// Token: 0x020002F9 RID: 761
		public enum eCrypt
		{
			// Token: 0x04000F13 RID: 3859
			code = 750971628
		}
	}
}

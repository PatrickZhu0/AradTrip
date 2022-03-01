using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000312 RID: 786
	public class ChargeMallTable : IFlatbufferObject
	{
		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06001EF9 RID: 7929 RVA: 0x000830E0 File Offset: 0x000814E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001EFA RID: 7930 RVA: 0x000830ED File Offset: 0x000814ED
		public static ChargeMallTable GetRootAsChargeMallTable(ByteBuffer _bb)
		{
			return ChargeMallTable.GetRootAsChargeMallTable(_bb, new ChargeMallTable());
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x000830FA File Offset: 0x000814FA
		public static ChargeMallTable GetRootAsChargeMallTable(ByteBuffer _bb, ChargeMallTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001EFC RID: 7932 RVA: 0x00083116 File Offset: 0x00081516
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001EFD RID: 7933 RVA: 0x00083130 File Offset: 0x00081530
		public ChargeMallTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06001EFE RID: 7934 RVA: 0x0008313C File Offset: 0x0008153C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06001EFF RID: 7935 RVA: 0x00083188 File Offset: 0x00081588
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06001F00 RID: 7936 RVA: 0x000831D4 File Offset: 0x000815D4
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x00083216 File Offset: 0x00081616
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x00083224 File Offset: 0x00081624
		public string TagsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06001F03 RID: 7939 RVA: 0x0008326C File Offset: 0x0008166C
		public int TagsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06001F04 RID: 7940 RVA: 0x0008329F File Offset: 0x0008169F
		public FlatBufferArray<string> Tags
		{
			get
			{
				if (this.TagsValue == null)
				{
					this.TagsValue = new FlatBufferArray<string>(new Func<int, string>(this.TagsArray), this.TagsLength);
				}
				return this.TagsValue;
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06001F05 RID: 7941 RVA: 0x000832D0 File Offset: 0x000816D0
		public int ChargeMoney
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06001F06 RID: 7942 RVA: 0x0008331C File Offset: 0x0008171C
		public int VipScore
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06001F07 RID: 7943 RVA: 0x00083368 File Offset: 0x00081768
		public int DailyLimitNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001F08 RID: 7944 RVA: 0x000833B4 File Offset: 0x000817B4
		public int itemID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001F09 RID: 7945 RVA: 0x00083400 File Offset: 0x00081800
		public int itemNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001F0A RID: 7946 RVA: 0x0008344C File Offset: 0x0008184C
		public int FirstAddNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06001F0B RID: 7947 RVA: 0x00083498 File Offset: 0x00081898
		public int UnFirstAddNum
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06001F0C RID: 7948 RVA: 0x000834E4 File Offset: 0x000818E4
		public int Icon
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1118665560 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06001F0D RID: 7949 RVA: 0x00083530 File Offset: 0x00081930
		public string Name
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001F0E RID: 7950 RVA: 0x00083573 File Offset: 0x00081973
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x06001F0F RID: 7951 RVA: 0x00083584 File Offset: 0x00081984
		public static Offset<ChargeMallTable> CreateChargeMallTable(FlatBufferBuilder builder, int ID = 0, int Sort = 0, StringOffset DescOffset = default(StringOffset), VectorOffset TagsOffset = default(VectorOffset), int ChargeMoney = 0, int VipScore = 0, int DailyLimitNum = 0, int itemID = 0, int itemNum = 0, int FirstAddNum = 0, int UnFirstAddNum = 0, int Icon = 0, StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(13);
			ChargeMallTable.AddName(builder, NameOffset);
			ChargeMallTable.AddIcon(builder, Icon);
			ChargeMallTable.AddUnFirstAddNum(builder, UnFirstAddNum);
			ChargeMallTable.AddFirstAddNum(builder, FirstAddNum);
			ChargeMallTable.AddItemNum(builder, itemNum);
			ChargeMallTable.AddItemID(builder, itemID);
			ChargeMallTable.AddDailyLimitNum(builder, DailyLimitNum);
			ChargeMallTable.AddVipScore(builder, VipScore);
			ChargeMallTable.AddChargeMoney(builder, ChargeMoney);
			ChargeMallTable.AddTags(builder, TagsOffset);
			ChargeMallTable.AddDesc(builder, DescOffset);
			ChargeMallTable.AddSort(builder, Sort);
			ChargeMallTable.AddID(builder, ID);
			return ChargeMallTable.EndChargeMallTable(builder);
		}

		// Token: 0x06001F10 RID: 7952 RVA: 0x00083604 File Offset: 0x00081A04
		public static void StartChargeMallTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x06001F11 RID: 7953 RVA: 0x0008360E File Offset: 0x00081A0E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001F12 RID: 7954 RVA: 0x00083619 File Offset: 0x00081A19
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(1, Sort, 0);
		}

		// Token: 0x06001F13 RID: 7955 RVA: 0x00083624 File Offset: 0x00081A24
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x06001F14 RID: 7956 RVA: 0x00083635 File Offset: 0x00081A35
		public static void AddTags(FlatBufferBuilder builder, VectorOffset TagsOffset)
		{
			builder.AddOffset(3, TagsOffset.Value, 0);
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x00083648 File Offset: 0x00081A48
		public static VectorOffset CreateTagsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0008368E File Offset: 0x00081A8E
		public static void StartTagsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x00083699 File Offset: 0x00081A99
		public static void AddChargeMoney(FlatBufferBuilder builder, int ChargeMoney)
		{
			builder.AddInt(4, ChargeMoney, 0);
		}

		// Token: 0x06001F18 RID: 7960 RVA: 0x000836A4 File Offset: 0x00081AA4
		public static void AddVipScore(FlatBufferBuilder builder, int VipScore)
		{
			builder.AddInt(5, VipScore, 0);
		}

		// Token: 0x06001F19 RID: 7961 RVA: 0x000836AF File Offset: 0x00081AAF
		public static void AddDailyLimitNum(FlatBufferBuilder builder, int DailyLimitNum)
		{
			builder.AddInt(6, DailyLimitNum, 0);
		}

		// Token: 0x06001F1A RID: 7962 RVA: 0x000836BA File Offset: 0x00081ABA
		public static void AddItemID(FlatBufferBuilder builder, int itemID)
		{
			builder.AddInt(7, itemID, 0);
		}

		// Token: 0x06001F1B RID: 7963 RVA: 0x000836C5 File Offset: 0x00081AC5
		public static void AddItemNum(FlatBufferBuilder builder, int itemNum)
		{
			builder.AddInt(8, itemNum, 0);
		}

		// Token: 0x06001F1C RID: 7964 RVA: 0x000836D0 File Offset: 0x00081AD0
		public static void AddFirstAddNum(FlatBufferBuilder builder, int FirstAddNum)
		{
			builder.AddInt(9, FirstAddNum, 0);
		}

		// Token: 0x06001F1D RID: 7965 RVA: 0x000836DC File Offset: 0x00081ADC
		public static void AddUnFirstAddNum(FlatBufferBuilder builder, int UnFirstAddNum)
		{
			builder.AddInt(10, UnFirstAddNum, 0);
		}

		// Token: 0x06001F1E RID: 7966 RVA: 0x000836E8 File Offset: 0x00081AE8
		public static void AddIcon(FlatBufferBuilder builder, int Icon)
		{
			builder.AddInt(11, Icon, 0);
		}

		// Token: 0x06001F1F RID: 7967 RVA: 0x000836F4 File Offset: 0x00081AF4
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(12, NameOffset.Value, 0);
		}

		// Token: 0x06001F20 RID: 7968 RVA: 0x00083708 File Offset: 0x00081B08
		public static Offset<ChargeMallTable> EndChargeMallTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChargeMallTable>(value);
		}

		// Token: 0x06001F21 RID: 7969 RVA: 0x00083722 File Offset: 0x00081B22
		public static void FinishChargeMallTableBuffer(FlatBufferBuilder builder, Offset<ChargeMallTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F52 RID: 3922
		private Table __p = new Table();

		// Token: 0x04000F53 RID: 3923
		private FlatBufferArray<string> TagsValue;

		// Token: 0x02000313 RID: 787
		public enum eCrypt
		{
			// Token: 0x04000F55 RID: 3925
			code = 1118665560
		}
	}
}

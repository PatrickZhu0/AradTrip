using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200045B RID: 1115
	public class GuildActivityTable : IFlatbufferObject
	{
		// Token: 0x17000D5E RID: 3422
		// (get) Token: 0x060035A2 RID: 13730 RVA: 0x000B9CAC File Offset: 0x000B80AC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060035A3 RID: 13731 RVA: 0x000B9CB9 File Offset: 0x000B80B9
		public static GuildActivityTable GetRootAsGuildActivityTable(ByteBuffer _bb)
		{
			return GuildActivityTable.GetRootAsGuildActivityTable(_bb, new GuildActivityTable());
		}

		// Token: 0x060035A4 RID: 13732 RVA: 0x000B9CC6 File Offset: 0x000B80C6
		public static GuildActivityTable GetRootAsGuildActivityTable(ByteBuffer _bb, GuildActivityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060035A5 RID: 13733 RVA: 0x000B9CE2 File Offset: 0x000B80E2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060035A6 RID: 13734 RVA: 0x000B9CFC File Offset: 0x000B80FC
		public GuildActivityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D5F RID: 3423
		// (get) Token: 0x060035A7 RID: 13735 RVA: 0x000B9D08 File Offset: 0x000B8108
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (71967124 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D60 RID: 3424
		// (get) Token: 0x060035A8 RID: 13736 RVA: 0x000B9D54 File Offset: 0x000B8154
		public string activityName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035A9 RID: 13737 RVA: 0x000B9D96 File Offset: 0x000B8196
		public ArraySegment<byte>? GetActivityNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D61 RID: 3425
		// (get) Token: 0x060035AA RID: 13738 RVA: 0x000B9DA4 File Offset: 0x000B81A4
		public string activityDesc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035AB RID: 13739 RVA: 0x000B9DE6 File Offset: 0x000B81E6
		public ArraySegment<byte>? GetActivityDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000D62 RID: 3426
		// (get) Token: 0x060035AC RID: 13740 RVA: 0x000B9DF4 File Offset: 0x000B81F4
		public string iconPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035AD RID: 13741 RVA: 0x000B9E37 File Offset: 0x000B8237
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000D63 RID: 3427
		// (get) Token: 0x060035AE RID: 13742 RVA: 0x000B9E48 File Offset: 0x000B8248
		public string openTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x000B9E8B File Offset: 0x000B828B
		public ArraySegment<byte>? GetOpenTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000D64 RID: 3428
		// (get) Token: 0x060035B0 RID: 13744 RVA: 0x000B9E9C File Offset: 0x000B829C
		public string activityUnLockConditon
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035B1 RID: 13745 RVA: 0x000B9EDF File Offset: 0x000B82DF
		public ArraySegment<byte>? GetActivityUnLockConditonBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000D65 RID: 3429
		// (get) Token: 0x060035B2 RID: 13746 RVA: 0x000B9EF0 File Offset: 0x000B82F0
		public string btnDefaultText
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x000B9F33 File Offset: 0x000B8333
		public ArraySegment<byte>? GetBtnDefaultTextBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000D66 RID: 3430
		// (get) Token: 0x060035B4 RID: 13748 RVA: 0x000B9F44 File Offset: 0x000B8344
		public string btnCallBack
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035B5 RID: 13749 RVA: 0x000B9F87 File Offset: 0x000B8387
		public ArraySegment<byte>? GetBtnCallBackBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000D67 RID: 3431
		// (get) Token: 0x060035B6 RID: 13750 RVA: 0x000B9F98 File Offset: 0x000B8398
		public string stateUpdateCallBack
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035B7 RID: 13751 RVA: 0x000B9FDB File Offset: 0x000B83DB
		public ArraySegment<byte>? GetStateUpdateCallBackBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000D68 RID: 3432
		// (get) Token: 0x060035B8 RID: 13752 RVA: 0x000B9FEC File Offset: 0x000B83EC
		public string activityUnLockCallBack
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035B9 RID: 13753 RVA: 0x000BA02F File Offset: 0x000B842F
		public ArraySegment<byte>? GetActivityUnLockCallBackBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000D69 RID: 3433
		// (get) Token: 0x060035BA RID: 13754 RVA: 0x000BA040 File Offset: 0x000B8440
		public string openWeek
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035BB RID: 13755 RVA: 0x000BA083 File Offset: 0x000B8483
		public ArraySegment<byte>? GetOpenWeekBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000D6A RID: 3434
		// (get) Token: 0x060035BC RID: 13756 RVA: 0x000BA094 File Offset: 0x000B8494
		public string openHourStart
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035BD RID: 13757 RVA: 0x000BA0D7 File Offset: 0x000B84D7
		public ArraySegment<byte>? GetOpenHourStartBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000D6B RID: 3435
		// (get) Token: 0x060035BE RID: 13758 RVA: 0x000BA0E8 File Offset: 0x000B84E8
		public string redPointUpdateCallBack
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035BF RID: 13759 RVA: 0x000BA12B File Offset: 0x000B852B
		public ArraySegment<byte>? GetRedPointUpdateCallBackBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x060035C0 RID: 13760 RVA: 0x000BA13C File Offset: 0x000B853C
		public static Offset<GuildActivityTable> CreateGuildActivityTable(FlatBufferBuilder builder, int ID = 0, StringOffset activityNameOffset = default(StringOffset), StringOffset activityDescOffset = default(StringOffset), StringOffset iconPathOffset = default(StringOffset), StringOffset openTimeOffset = default(StringOffset), StringOffset activityUnLockConditonOffset = default(StringOffset), StringOffset btnDefaultTextOffset = default(StringOffset), StringOffset btnCallBackOffset = default(StringOffset), StringOffset stateUpdateCallBackOffset = default(StringOffset), StringOffset activityUnLockCallBackOffset = default(StringOffset), StringOffset openWeekOffset = default(StringOffset), StringOffset openHourStartOffset = default(StringOffset), StringOffset redPointUpdateCallBackOffset = default(StringOffset))
		{
			builder.StartObject(13);
			GuildActivityTable.AddRedPointUpdateCallBack(builder, redPointUpdateCallBackOffset);
			GuildActivityTable.AddOpenHourStart(builder, openHourStartOffset);
			GuildActivityTable.AddOpenWeek(builder, openWeekOffset);
			GuildActivityTable.AddActivityUnLockCallBack(builder, activityUnLockCallBackOffset);
			GuildActivityTable.AddStateUpdateCallBack(builder, stateUpdateCallBackOffset);
			GuildActivityTable.AddBtnCallBack(builder, btnCallBackOffset);
			GuildActivityTable.AddBtnDefaultText(builder, btnDefaultTextOffset);
			GuildActivityTable.AddActivityUnLockConditon(builder, activityUnLockConditonOffset);
			GuildActivityTable.AddOpenTime(builder, openTimeOffset);
			GuildActivityTable.AddIconPath(builder, iconPathOffset);
			GuildActivityTable.AddActivityDesc(builder, activityDescOffset);
			GuildActivityTable.AddActivityName(builder, activityNameOffset);
			GuildActivityTable.AddID(builder, ID);
			return GuildActivityTable.EndGuildActivityTable(builder);
		}

		// Token: 0x060035C1 RID: 13761 RVA: 0x000BA1BC File Offset: 0x000B85BC
		public static void StartGuildActivityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x000BA1C6 File Offset: 0x000B85C6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x000BA1D1 File Offset: 0x000B85D1
		public static void AddActivityName(FlatBufferBuilder builder, StringOffset activityNameOffset)
		{
			builder.AddOffset(1, activityNameOffset.Value, 0);
		}

		// Token: 0x060035C4 RID: 13764 RVA: 0x000BA1E2 File Offset: 0x000B85E2
		public static void AddActivityDesc(FlatBufferBuilder builder, StringOffset activityDescOffset)
		{
			builder.AddOffset(2, activityDescOffset.Value, 0);
		}

		// Token: 0x060035C5 RID: 13765 RVA: 0x000BA1F3 File Offset: 0x000B85F3
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset iconPathOffset)
		{
			builder.AddOffset(3, iconPathOffset.Value, 0);
		}

		// Token: 0x060035C6 RID: 13766 RVA: 0x000BA204 File Offset: 0x000B8604
		public static void AddOpenTime(FlatBufferBuilder builder, StringOffset openTimeOffset)
		{
			builder.AddOffset(4, openTimeOffset.Value, 0);
		}

		// Token: 0x060035C7 RID: 13767 RVA: 0x000BA215 File Offset: 0x000B8615
		public static void AddActivityUnLockConditon(FlatBufferBuilder builder, StringOffset activityUnLockConditonOffset)
		{
			builder.AddOffset(5, activityUnLockConditonOffset.Value, 0);
		}

		// Token: 0x060035C8 RID: 13768 RVA: 0x000BA226 File Offset: 0x000B8626
		public static void AddBtnDefaultText(FlatBufferBuilder builder, StringOffset btnDefaultTextOffset)
		{
			builder.AddOffset(6, btnDefaultTextOffset.Value, 0);
		}

		// Token: 0x060035C9 RID: 13769 RVA: 0x000BA237 File Offset: 0x000B8637
		public static void AddBtnCallBack(FlatBufferBuilder builder, StringOffset btnCallBackOffset)
		{
			builder.AddOffset(7, btnCallBackOffset.Value, 0);
		}

		// Token: 0x060035CA RID: 13770 RVA: 0x000BA248 File Offset: 0x000B8648
		public static void AddStateUpdateCallBack(FlatBufferBuilder builder, StringOffset stateUpdateCallBackOffset)
		{
			builder.AddOffset(8, stateUpdateCallBackOffset.Value, 0);
		}

		// Token: 0x060035CB RID: 13771 RVA: 0x000BA259 File Offset: 0x000B8659
		public static void AddActivityUnLockCallBack(FlatBufferBuilder builder, StringOffset activityUnLockCallBackOffset)
		{
			builder.AddOffset(9, activityUnLockCallBackOffset.Value, 0);
		}

		// Token: 0x060035CC RID: 13772 RVA: 0x000BA26B File Offset: 0x000B866B
		public static void AddOpenWeek(FlatBufferBuilder builder, StringOffset openWeekOffset)
		{
			builder.AddOffset(10, openWeekOffset.Value, 0);
		}

		// Token: 0x060035CD RID: 13773 RVA: 0x000BA27D File Offset: 0x000B867D
		public static void AddOpenHourStart(FlatBufferBuilder builder, StringOffset openHourStartOffset)
		{
			builder.AddOffset(11, openHourStartOffset.Value, 0);
		}

		// Token: 0x060035CE RID: 13774 RVA: 0x000BA28F File Offset: 0x000B868F
		public static void AddRedPointUpdateCallBack(FlatBufferBuilder builder, StringOffset redPointUpdateCallBackOffset)
		{
			builder.AddOffset(12, redPointUpdateCallBackOffset.Value, 0);
		}

		// Token: 0x060035CF RID: 13775 RVA: 0x000BA2A4 File Offset: 0x000B86A4
		public static Offset<GuildActivityTable> EndGuildActivityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildActivityTable>(value);
		}

		// Token: 0x060035D0 RID: 13776 RVA: 0x000BA2BE File Offset: 0x000B86BE
		public static void FinishGuildActivityTableBuffer(FlatBufferBuilder builder, Offset<GuildActivityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001594 RID: 5524
		private Table __p = new Table();

		// Token: 0x0200045C RID: 1116
		public enum eCrypt
		{
			// Token: 0x04001596 RID: 5526
			code = 71967124
		}
	}
}

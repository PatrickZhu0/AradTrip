using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000368 RID: 872
	public class CurrencyQuickTipsTable : IFlatbufferObject
	{
		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x0600253C RID: 9532 RVA: 0x00092AD8 File Offset: 0x00090ED8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x00092AE5 File Offset: 0x00090EE5
		public static CurrencyQuickTipsTable GetRootAsCurrencyQuickTipsTable(ByteBuffer _bb)
		{
			return CurrencyQuickTipsTable.GetRootAsCurrencyQuickTipsTable(_bb, new CurrencyQuickTipsTable());
		}

		// Token: 0x0600253E RID: 9534 RVA: 0x00092AF2 File Offset: 0x00090EF2
		public static CurrencyQuickTipsTable GetRootAsCurrencyQuickTipsTable(ByteBuffer _bb, CurrencyQuickTipsTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600253F RID: 9535 RVA: 0x00092B0E File Offset: 0x00090F0E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002540 RID: 9536 RVA: 0x00092B28 File Offset: 0x00090F28
		public CurrencyQuickTipsTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06002541 RID: 9537 RVA: 0x00092B34 File Offset: 0x00090F34
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1062778574 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06002542 RID: 9538 RVA: 0x00092B80 File Offset: 0x00090F80
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002543 RID: 9539 RVA: 0x00092BC2 File Offset: 0x00090FC2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06002544 RID: 9540 RVA: 0x00092BD0 File Offset: 0x00090FD0
		public CurrencyQuickTipsTable.eResetType ResetType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (CurrencyQuickTipsTable.eResetType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06002545 RID: 9541 RVA: 0x00092C14 File Offset: 0x00091014
		public string ResetTimePoint
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002546 RID: 9542 RVA: 0x00092C57 File Offset: 0x00091057
		public ArraySegment<byte>? GetResetTimePointBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06002547 RID: 9543 RVA: 0x00092C68 File Offset: 0x00091068
		public int PromptTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1062778574 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06002548 RID: 9544 RVA: 0x00092CB4 File Offset: 0x000910B4
		public CurrencyQuickTipsTable.eNotifyType NotifyType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (CurrencyQuickTipsTable.eNotifyType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06002549 RID: 9545 RVA: 0x00092CF8 File Offset: 0x000910F8
		public string NotifyIcon
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600254A RID: 9546 RVA: 0x00092D3B File Offset: 0x0009113B
		public ArraySegment<byte>? GetNotifyIconBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x0600254B RID: 9547 RVA: 0x00092D4C File Offset: 0x0009114C
		public static Offset<CurrencyQuickTipsTable> CreateCurrencyQuickTipsTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), CurrencyQuickTipsTable.eResetType ResetType = CurrencyQuickTipsTable.eResetType.None, StringOffset ResetTimePointOffset = default(StringOffset), int PromptTime = 0, CurrencyQuickTipsTable.eNotifyType NotifyType = CurrencyQuickTipsTable.eNotifyType.NT_NONE, StringOffset NotifyIconOffset = default(StringOffset))
		{
			builder.StartObject(7);
			CurrencyQuickTipsTable.AddNotifyIcon(builder, NotifyIconOffset);
			CurrencyQuickTipsTable.AddNotifyType(builder, NotifyType);
			CurrencyQuickTipsTable.AddPromptTime(builder, PromptTime);
			CurrencyQuickTipsTable.AddResetTimePoint(builder, ResetTimePointOffset);
			CurrencyQuickTipsTable.AddResetType(builder, ResetType);
			CurrencyQuickTipsTable.AddName(builder, NameOffset);
			CurrencyQuickTipsTable.AddID(builder, ID);
			return CurrencyQuickTipsTable.EndCurrencyQuickTipsTable(builder);
		}

		// Token: 0x0600254C RID: 9548 RVA: 0x00092D9B File Offset: 0x0009119B
		public static void StartCurrencyQuickTipsTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600254D RID: 9549 RVA: 0x00092DA4 File Offset: 0x000911A4
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600254E RID: 9550 RVA: 0x00092DAF File Offset: 0x000911AF
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600254F RID: 9551 RVA: 0x00092DC0 File Offset: 0x000911C0
		public static void AddResetType(FlatBufferBuilder builder, CurrencyQuickTipsTable.eResetType ResetType)
		{
			builder.AddInt(2, (int)ResetType, 0);
		}

		// Token: 0x06002550 RID: 9552 RVA: 0x00092DCB File Offset: 0x000911CB
		public static void AddResetTimePoint(FlatBufferBuilder builder, StringOffset ResetTimePointOffset)
		{
			builder.AddOffset(3, ResetTimePointOffset.Value, 0);
		}

		// Token: 0x06002551 RID: 9553 RVA: 0x00092DDC File Offset: 0x000911DC
		public static void AddPromptTime(FlatBufferBuilder builder, int PromptTime)
		{
			builder.AddInt(4, PromptTime, 0);
		}

		// Token: 0x06002552 RID: 9554 RVA: 0x00092DE7 File Offset: 0x000911E7
		public static void AddNotifyType(FlatBufferBuilder builder, CurrencyQuickTipsTable.eNotifyType NotifyType)
		{
			builder.AddInt(5, (int)NotifyType, 0);
		}

		// Token: 0x06002553 RID: 9555 RVA: 0x00092DF2 File Offset: 0x000911F2
		public static void AddNotifyIcon(FlatBufferBuilder builder, StringOffset NotifyIconOffset)
		{
			builder.AddOffset(6, NotifyIconOffset.Value, 0);
		}

		// Token: 0x06002554 RID: 9556 RVA: 0x00092E04 File Offset: 0x00091204
		public static Offset<CurrencyQuickTipsTable> EndCurrencyQuickTipsTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CurrencyQuickTipsTable>(value);
		}

		// Token: 0x06002555 RID: 9557 RVA: 0x00092E1E File Offset: 0x0009121E
		public static void FinishCurrencyQuickTipsTableBuffer(FlatBufferBuilder builder, Offset<CurrencyQuickTipsTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001147 RID: 4423
		private Table __p = new Table();

		// Token: 0x02000369 RID: 873
		public enum eResetType
		{
			// Token: 0x04001149 RID: 4425
			None,
			// Token: 0x0400114A RID: 4426
			Monthly,
			// Token: 0x0400114B RID: 4427
			Weekly,
			// Token: 0x0400114C RID: 4428
			Daily,
			// Token: 0x0400114D RID: 4429
			Season
		}

		// Token: 0x0200036A RID: 874
		public enum eNotifyType
		{
			// Token: 0x0400114F RID: 4431
			NT_NONE,
			// Token: 0x04001150 RID: 4432
			NT_MAGIC_INTEGRAL_EMPTYING = 7,
			// Token: 0x04001151 RID: 4433
			NT_ADVENTURE_TEAM_BOUNTY_EMPTYING = 10,
			// Token: 0x04001152 RID: 4434
			NT_ADVENTURE_TEAM_INHERIT_BLESS_EMPTYING,
			// Token: 0x04001153 RID: 4435
			NT_ADVENTURE_PASS_CARD_COIN_EMPTYING
		}

		// Token: 0x0200036B RID: 875
		public enum eCrypt
		{
			// Token: 0x04001155 RID: 4437
			code = 1062778574
		}
	}
}

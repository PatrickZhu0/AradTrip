using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004E9 RID: 1257
	public class MallGiftPackTable : IFlatbufferObject
	{
		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x06004004 RID: 16388 RVA: 0x000D2834 File Offset: 0x000D0C34
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004005 RID: 16389 RVA: 0x000D2841 File Offset: 0x000D0C41
		public static MallGiftPackTable GetRootAsMallGiftPackTable(ByteBuffer _bb)
		{
			return MallGiftPackTable.GetRootAsMallGiftPackTable(_bb, new MallGiftPackTable());
		}

		// Token: 0x06004006 RID: 16390 RVA: 0x000D284E File Offset: 0x000D0C4E
		public static MallGiftPackTable GetRootAsMallGiftPackTable(ByteBuffer _bb, MallGiftPackTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004007 RID: 16391 RVA: 0x000D286A File Offset: 0x000D0C6A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004008 RID: 16392 RVA: 0x000D2884 File Offset: 0x000D0C84
		public MallGiftPackTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170010CB RID: 4299
		// (get) Token: 0x06004009 RID: 16393 RVA: 0x000D2890 File Offset: 0x000D0C90
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1422631907 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010CC RID: 4300
		// (get) Token: 0x0600400A RID: 16394 RVA: 0x000D28DC File Offset: 0x000D0CDC
		public int activateCond
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1422631907 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010CD RID: 4301
		// (get) Token: 0x0600400B RID: 16395 RVA: 0x000D2928 File Offset: 0x000D0D28
		public int limitInterval
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1422631907 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010CE RID: 4302
		// (get) Token: 0x0600400C RID: 16396 RVA: 0x000D2974 File Offset: 0x000D0D74
		public string giftDesc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600400D RID: 16397 RVA: 0x000D29B7 File Offset: 0x000D0DB7
		public ArraySegment<byte>? GetGiftDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170010CF RID: 4303
		// (get) Token: 0x0600400E RID: 16398 RVA: 0x000D29C8 File Offset: 0x000D0DC8
		public string extraParams
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600400F RID: 16399 RVA: 0x000D2A0B File Offset: 0x000D0E0B
		public ArraySegment<byte>? GetExtraParamsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06004010 RID: 16400 RVA: 0x000D2A1A File Offset: 0x000D0E1A
		public static Offset<MallGiftPackTable> CreateMallGiftPackTable(FlatBufferBuilder builder, int ID = 0, int activateCond = 0, int limitInterval = 0, StringOffset giftDescOffset = default(StringOffset), StringOffset extraParamsOffset = default(StringOffset))
		{
			builder.StartObject(5);
			MallGiftPackTable.AddExtraParams(builder, extraParamsOffset);
			MallGiftPackTable.AddGiftDesc(builder, giftDescOffset);
			MallGiftPackTable.AddLimitInterval(builder, limitInterval);
			MallGiftPackTable.AddActivateCond(builder, activateCond);
			MallGiftPackTable.AddID(builder, ID);
			return MallGiftPackTable.EndMallGiftPackTable(builder);
		}

		// Token: 0x06004011 RID: 16401 RVA: 0x000D2A4E File Offset: 0x000D0E4E
		public static void StartMallGiftPackTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004012 RID: 16402 RVA: 0x000D2A57 File Offset: 0x000D0E57
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004013 RID: 16403 RVA: 0x000D2A62 File Offset: 0x000D0E62
		public static void AddActivateCond(FlatBufferBuilder builder, int activateCond)
		{
			builder.AddInt(1, activateCond, 0);
		}

		// Token: 0x06004014 RID: 16404 RVA: 0x000D2A6D File Offset: 0x000D0E6D
		public static void AddLimitInterval(FlatBufferBuilder builder, int limitInterval)
		{
			builder.AddInt(2, limitInterval, 0);
		}

		// Token: 0x06004015 RID: 16405 RVA: 0x000D2A78 File Offset: 0x000D0E78
		public static void AddGiftDesc(FlatBufferBuilder builder, StringOffset giftDescOffset)
		{
			builder.AddOffset(3, giftDescOffset.Value, 0);
		}

		// Token: 0x06004016 RID: 16406 RVA: 0x000D2A89 File Offset: 0x000D0E89
		public static void AddExtraParams(FlatBufferBuilder builder, StringOffset extraParamsOffset)
		{
			builder.AddOffset(4, extraParamsOffset.Value, 0);
		}

		// Token: 0x06004017 RID: 16407 RVA: 0x000D2A9C File Offset: 0x000D0E9C
		public static Offset<MallGiftPackTable> EndMallGiftPackTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MallGiftPackTable>(value);
		}

		// Token: 0x06004018 RID: 16408 RVA: 0x000D2AB6 File Offset: 0x000D0EB6
		public static void FinishMallGiftPackTableBuffer(FlatBufferBuilder builder, Offset<MallGiftPackTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400181D RID: 6173
		private Table __p = new Table();

		// Token: 0x020004EA RID: 1258
		public enum eCrypt
		{
			// Token: 0x0400181F RID: 6175
			code = 1422631907
		}
	}
}

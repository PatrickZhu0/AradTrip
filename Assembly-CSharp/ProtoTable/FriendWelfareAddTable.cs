using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200043F RID: 1087
	public class FriendWelfareAddTable : IFlatbufferObject
	{
		// Token: 0x17000CD2 RID: 3282
		// (get) Token: 0x060033F9 RID: 13305 RVA: 0x000B5F08 File Offset: 0x000B4308
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060033FA RID: 13306 RVA: 0x000B5F15 File Offset: 0x000B4315
		public static FriendWelfareAddTable GetRootAsFriendWelfareAddTable(ByteBuffer _bb)
		{
			return FriendWelfareAddTable.GetRootAsFriendWelfareAddTable(_bb, new FriendWelfareAddTable());
		}

		// Token: 0x060033FB RID: 13307 RVA: 0x000B5F22 File Offset: 0x000B4322
		public static FriendWelfareAddTable GetRootAsFriendWelfareAddTable(ByteBuffer _bb, FriendWelfareAddTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060033FC RID: 13308 RVA: 0x000B5F3E File Offset: 0x000B433E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060033FD RID: 13309 RVA: 0x000B5F58 File Offset: 0x000B4358
		public FriendWelfareAddTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000CD3 RID: 3283
		// (get) Token: 0x060033FE RID: 13310 RVA: 0x000B5F64 File Offset: 0x000B4364
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1924892469 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CD4 RID: 3284
		// (get) Token: 0x060033FF RID: 13311 RVA: 0x000B5FB0 File Offset: 0x000B43B0
		public string IntimacySpan
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003400 RID: 13312 RVA: 0x000B5FF2 File Offset: 0x000B43F2
		public ArraySegment<byte>? GetIntimacySpanBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000CD5 RID: 3285
		// (get) Token: 0x06003401 RID: 13313 RVA: 0x000B6000 File Offset: 0x000B4400
		public int ExpAddProb
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1924892469 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CD6 RID: 3286
		// (get) Token: 0x06003402 RID: 13314 RVA: 0x000B604C File Offset: 0x000B444C
		public string IntimacyName
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003403 RID: 13315 RVA: 0x000B608F File Offset: 0x000B448F
		public ArraySegment<byte>? GetIntimacyNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06003404 RID: 13316 RVA: 0x000B609E File Offset: 0x000B449E
		public static Offset<FriendWelfareAddTable> CreateFriendWelfareAddTable(FlatBufferBuilder builder, int ID = 0, StringOffset IntimacySpanOffset = default(StringOffset), int ExpAddProb = 0, StringOffset IntimacyNameOffset = default(StringOffset))
		{
			builder.StartObject(4);
			FriendWelfareAddTable.AddIntimacyName(builder, IntimacyNameOffset);
			FriendWelfareAddTable.AddExpAddProb(builder, ExpAddProb);
			FriendWelfareAddTable.AddIntimacySpan(builder, IntimacySpanOffset);
			FriendWelfareAddTable.AddID(builder, ID);
			return FriendWelfareAddTable.EndFriendWelfareAddTable(builder);
		}

		// Token: 0x06003405 RID: 13317 RVA: 0x000B60CA File Offset: 0x000B44CA
		public static void StartFriendWelfareAddTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003406 RID: 13318 RVA: 0x000B60D3 File Offset: 0x000B44D3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003407 RID: 13319 RVA: 0x000B60DE File Offset: 0x000B44DE
		public static void AddIntimacySpan(FlatBufferBuilder builder, StringOffset IntimacySpanOffset)
		{
			builder.AddOffset(1, IntimacySpanOffset.Value, 0);
		}

		// Token: 0x06003408 RID: 13320 RVA: 0x000B60EF File Offset: 0x000B44EF
		public static void AddExpAddProb(FlatBufferBuilder builder, int ExpAddProb)
		{
			builder.AddInt(2, ExpAddProb, 0);
		}

		// Token: 0x06003409 RID: 13321 RVA: 0x000B60FA File Offset: 0x000B44FA
		public static void AddIntimacyName(FlatBufferBuilder builder, StringOffset IntimacyNameOffset)
		{
			builder.AddOffset(3, IntimacyNameOffset.Value, 0);
		}

		// Token: 0x0600340A RID: 13322 RVA: 0x000B610C File Offset: 0x000B450C
		public static Offset<FriendWelfareAddTable> EndFriendWelfareAddTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FriendWelfareAddTable>(value);
		}

		// Token: 0x0600340B RID: 13323 RVA: 0x000B6126 File Offset: 0x000B4526
		public static void FinishFriendWelfareAddTableBuffer(FlatBufferBuilder builder, Offset<FriendWelfareAddTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400150B RID: 5387
		private Table __p = new Table();

		// Token: 0x02000440 RID: 1088
		public enum eCrypt
		{
			// Token: 0x0400150D RID: 5389
			code = -1924892469
		}
	}
}

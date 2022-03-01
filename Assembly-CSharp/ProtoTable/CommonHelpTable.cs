using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200035F RID: 863
	public class CommonHelpTable : IFlatbufferObject
	{
		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x060024F9 RID: 9465 RVA: 0x000922F8 File Offset: 0x000906F8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x00092305 File Offset: 0x00090705
		public static CommonHelpTable GetRootAsCommonHelpTable(ByteBuffer _bb)
		{
			return CommonHelpTable.GetRootAsCommonHelpTable(_bb, new CommonHelpTable());
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x00092312 File Offset: 0x00090712
		public static CommonHelpTable GetRootAsCommonHelpTable(ByteBuffer _bb, CommonHelpTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x0009232E File Offset: 0x0009072E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x00092348 File Offset: 0x00090748
		public CommonHelpTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x060024FE RID: 9470 RVA: 0x00092354 File Offset: 0x00090754
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1859016070 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x060024FF RID: 9471 RVA: 0x000923A0 File Offset: 0x000907A0
		public string TitleText
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x000923E2 File Offset: 0x000907E2
		public ArraySegment<byte>? GetTitleTextBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06002501 RID: 9473 RVA: 0x000923F0 File Offset: 0x000907F0
		public string Descs
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x00092432 File Offset: 0x00090832
		public ArraySegment<byte>? GetDescsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x00092440 File Offset: 0x00090840
		public static Offset<CommonHelpTable> CreateCommonHelpTable(FlatBufferBuilder builder, int ID = 0, StringOffset TitleTextOffset = default(StringOffset), StringOffset DescsOffset = default(StringOffset))
		{
			builder.StartObject(3);
			CommonHelpTable.AddDescs(builder, DescsOffset);
			CommonHelpTable.AddTitleText(builder, TitleTextOffset);
			CommonHelpTable.AddID(builder, ID);
			return CommonHelpTable.EndCommonHelpTable(builder);
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x00092464 File Offset: 0x00090864
		public static void StartCommonHelpTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x0009246D File Offset: 0x0009086D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002506 RID: 9478 RVA: 0x00092478 File Offset: 0x00090878
		public static void AddTitleText(FlatBufferBuilder builder, StringOffset TitleTextOffset)
		{
			builder.AddOffset(1, TitleTextOffset.Value, 0);
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x00092489 File Offset: 0x00090889
		public static void AddDescs(FlatBufferBuilder builder, StringOffset DescsOffset)
		{
			builder.AddOffset(2, DescsOffset.Value, 0);
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x0009249C File Offset: 0x0009089C
		public static Offset<CommonHelpTable> EndCommonHelpTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CommonHelpTable>(value);
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x000924B6 File Offset: 0x000908B6
		public static void FinishCommonHelpTableBuffer(FlatBufferBuilder builder, Offset<CommonHelpTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001129 RID: 4393
		private Table __p = new Table();

		// Token: 0x02000360 RID: 864
		public enum eCrypt
		{
			// Token: 0x0400112B RID: 4395
			code = 1859016070
		}
	}
}

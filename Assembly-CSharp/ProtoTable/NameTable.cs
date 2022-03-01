using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000524 RID: 1316
	public class NameTable : IFlatbufferObject
	{
		// Token: 0x170011FC RID: 4604
		// (get) Token: 0x0600438B RID: 17291 RVA: 0x000DAC54 File Offset: 0x000D9054
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600438C RID: 17292 RVA: 0x000DAC61 File Offset: 0x000D9061
		public static NameTable GetRootAsNameTable(ByteBuffer _bb)
		{
			return NameTable.GetRootAsNameTable(_bb, new NameTable());
		}

		// Token: 0x0600438D RID: 17293 RVA: 0x000DAC6E File Offset: 0x000D906E
		public static NameTable GetRootAsNameTable(ByteBuffer _bb, NameTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600438E RID: 17294 RVA: 0x000DAC8A File Offset: 0x000D908A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600438F RID: 17295 RVA: 0x000DACA4 File Offset: 0x000D90A4
		public NameTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011FD RID: 4605
		// (get) Token: 0x06004390 RID: 17296 RVA: 0x000DACB0 File Offset: 0x000D90B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (111743053 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011FE RID: 4606
		// (get) Token: 0x06004391 RID: 17297 RVA: 0x000DACFC File Offset: 0x000D90FC
		public int NameType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (111743053 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011FF RID: 4607
		// (get) Token: 0x06004392 RID: 17298 RVA: 0x000DAD48 File Offset: 0x000D9148
		public string NameText
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004393 RID: 17299 RVA: 0x000DAD8A File Offset: 0x000D918A
		public ArraySegment<byte>? GetNameTextBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06004394 RID: 17300 RVA: 0x000DAD98 File Offset: 0x000D9198
		public static Offset<NameTable> CreateNameTable(FlatBufferBuilder builder, int ID = 0, int NameType = 0, StringOffset NameTextOffset = default(StringOffset))
		{
			builder.StartObject(3);
			NameTable.AddNameText(builder, NameTextOffset);
			NameTable.AddNameType(builder, NameType);
			NameTable.AddID(builder, ID);
			return NameTable.EndNameTable(builder);
		}

		// Token: 0x06004395 RID: 17301 RVA: 0x000DADBC File Offset: 0x000D91BC
		public static void StartNameTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004396 RID: 17302 RVA: 0x000DADC5 File Offset: 0x000D91C5
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004397 RID: 17303 RVA: 0x000DADD0 File Offset: 0x000D91D0
		public static void AddNameType(FlatBufferBuilder builder, int NameType)
		{
			builder.AddInt(1, NameType, 0);
		}

		// Token: 0x06004398 RID: 17304 RVA: 0x000DADDB File Offset: 0x000D91DB
		public static void AddNameText(FlatBufferBuilder builder, StringOffset NameTextOffset)
		{
			builder.AddOffset(2, NameTextOffset.Value, 0);
		}

		// Token: 0x06004399 RID: 17305 RVA: 0x000DADEC File Offset: 0x000D91EC
		public static Offset<NameTable> EndNameTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<NameTable>(value);
		}

		// Token: 0x0600439A RID: 17306 RVA: 0x000DAE06 File Offset: 0x000D9206
		public static void FinishNameTableBuffer(FlatBufferBuilder builder, Offset<NameTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018F3 RID: 6387
		private Table __p = new Table();

		// Token: 0x02000525 RID: 1317
		public enum eCrypt
		{
			// Token: 0x040018F5 RID: 6389
			code = 111743053
		}
	}
}

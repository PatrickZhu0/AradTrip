using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200046B RID: 1131
	public class GuildDungeonDamageCoeffTable : IFlatbufferObject
	{
		// Token: 0x17000D96 RID: 3478
		// (get) Token: 0x06003661 RID: 13921 RVA: 0x000BB56C File Offset: 0x000B996C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003662 RID: 13922 RVA: 0x000BB579 File Offset: 0x000B9979
		public static GuildDungeonDamageCoeffTable GetRootAsGuildDungeonDamageCoeffTable(ByteBuffer _bb)
		{
			return GuildDungeonDamageCoeffTable.GetRootAsGuildDungeonDamageCoeffTable(_bb, new GuildDungeonDamageCoeffTable());
		}

		// Token: 0x06003663 RID: 13923 RVA: 0x000BB586 File Offset: 0x000B9986
		public static GuildDungeonDamageCoeffTable GetRootAsGuildDungeonDamageCoeffTable(ByteBuffer _bb, GuildDungeonDamageCoeffTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003664 RID: 13924 RVA: 0x000BB5A2 File Offset: 0x000B99A2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003665 RID: 13925 RVA: 0x000BB5BC File Offset: 0x000B99BC
		public GuildDungeonDamageCoeffTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D97 RID: 3479
		// (get) Token: 0x06003666 RID: 13926 RVA: 0x000BB5C8 File Offset: 0x000B99C8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1838784585 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D98 RID: 3480
		// (get) Token: 0x06003667 RID: 13927 RVA: 0x000BB614 File Offset: 0x000B9A14
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003668 RID: 13928 RVA: 0x000BB656 File Offset: 0x000B9A56
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D99 RID: 3481
		// (get) Token: 0x06003669 RID: 13929 RVA: 0x000BB664 File Offset: 0x000B9A64
		public int coefficient
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1838784585 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x000BB6AD File Offset: 0x000B9AAD
		public static Offset<GuildDungeonDamageCoeffTable> CreateGuildDungeonDamageCoeffTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int coefficient = 0)
		{
			builder.StartObject(3);
			GuildDungeonDamageCoeffTable.AddCoefficient(builder, coefficient);
			GuildDungeonDamageCoeffTable.AddName(builder, NameOffset);
			GuildDungeonDamageCoeffTable.AddID(builder, ID);
			return GuildDungeonDamageCoeffTable.EndGuildDungeonDamageCoeffTable(builder);
		}

		// Token: 0x0600366B RID: 13931 RVA: 0x000BB6D1 File Offset: 0x000B9AD1
		public static void StartGuildDungeonDamageCoeffTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0600366C RID: 13932 RVA: 0x000BB6DA File Offset: 0x000B9ADA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x000BB6E5 File Offset: 0x000B9AE5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x000BB6F6 File Offset: 0x000B9AF6
		public static void AddCoefficient(FlatBufferBuilder builder, int coefficient)
		{
			builder.AddInt(2, coefficient, 0);
		}

		// Token: 0x0600366F RID: 13935 RVA: 0x000BB704 File Offset: 0x000B9B04
		public static Offset<GuildDungeonDamageCoeffTable> EndGuildDungeonDamageCoeffTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildDungeonDamageCoeffTable>(value);
		}

		// Token: 0x06003670 RID: 13936 RVA: 0x000BB71E File Offset: 0x000B9B1E
		public static void FinishGuildDungeonDamageCoeffTableBuffer(FlatBufferBuilder builder, Offset<GuildDungeonDamageCoeffTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015B6 RID: 5558
		private Table __p = new Table();

		// Token: 0x0200046C RID: 1132
		public enum eCrypt
		{
			// Token: 0x040015B8 RID: 5560
			code = -1838784585
		}
	}
}

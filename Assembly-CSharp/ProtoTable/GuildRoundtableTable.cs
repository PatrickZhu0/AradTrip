using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200047F RID: 1151
	public class GuildRoundtableTable : IFlatbufferObject
	{
		// Token: 0x17000DFA RID: 3578
		// (get) Token: 0x060037B2 RID: 14258 RVA: 0x000BE4E0 File Offset: 0x000BC8E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060037B3 RID: 14259 RVA: 0x000BE4ED File Offset: 0x000BC8ED
		public static GuildRoundtableTable GetRootAsGuildRoundtableTable(ByteBuffer _bb)
		{
			return GuildRoundtableTable.GetRootAsGuildRoundtableTable(_bb, new GuildRoundtableTable());
		}

		// Token: 0x060037B4 RID: 14260 RVA: 0x000BE4FA File Offset: 0x000BC8FA
		public static GuildRoundtableTable GetRootAsGuildRoundtableTable(ByteBuffer _bb, GuildRoundtableTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060037B5 RID: 14261 RVA: 0x000BE516 File Offset: 0x000BC916
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060037B6 RID: 14262 RVA: 0x000BE530 File Offset: 0x000BC930
		public GuildRoundtableTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DFB RID: 3579
		// (get) Token: 0x060037B7 RID: 14263 RVA: 0x000BE53C File Offset: 0x000BC93C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-194548911 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DFC RID: 3580
		// (get) Token: 0x060037B8 RID: 14264 RVA: 0x000BE588 File Offset: 0x000BC988
		public GuildRoundtableTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (GuildRoundtableTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DFD RID: 3581
		// (get) Token: 0x060037B9 RID: 14265 RVA: 0x000BE5CC File Offset: 0x000BC9CC
		public int TimesLimit
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-194548911 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060037BA RID: 14266 RVA: 0x000BE618 File Offset: 0x000BCA18
		public string GetItemsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000DFE RID: 3582
		// (get) Token: 0x060037BB RID: 14267 RVA: 0x000BE660 File Offset: 0x000BCA60
		public int GetItemsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000DFF RID: 3583
		// (get) Token: 0x060037BC RID: 14268 RVA: 0x000BE693 File Offset: 0x000BCA93
		public FlatBufferArray<string> GetItems
		{
			get
			{
				if (this.GetItemsValue == null)
				{
					this.GetItemsValue = new FlatBufferArray<string>(new Func<int, string>(this.GetItemsArray), this.GetItemsLength);
				}
				return this.GetItemsValue;
			}
		}

		// Token: 0x17000E00 RID: 3584
		// (get) Token: 0x060037BD RID: 14269 RVA: 0x000BE6C4 File Offset: 0x000BCAC4
		public int MailContentID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-194548911 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060037BE RID: 14270 RVA: 0x000BE70E File Offset: 0x000BCB0E
		public static Offset<GuildRoundtableTable> CreateGuildRoundtableTable(FlatBufferBuilder builder, int ID = 0, GuildRoundtableTable.eType Type = GuildRoundtableTable.eType.First, int TimesLimit = 0, VectorOffset GetItemsOffset = default(VectorOffset), int MailContentID = 0)
		{
			builder.StartObject(5);
			GuildRoundtableTable.AddMailContentID(builder, MailContentID);
			GuildRoundtableTable.AddGetItems(builder, GetItemsOffset);
			GuildRoundtableTable.AddTimesLimit(builder, TimesLimit);
			GuildRoundtableTable.AddType(builder, Type);
			GuildRoundtableTable.AddID(builder, ID);
			return GuildRoundtableTable.EndGuildRoundtableTable(builder);
		}

		// Token: 0x060037BF RID: 14271 RVA: 0x000BE742 File Offset: 0x000BCB42
		public static void StartGuildRoundtableTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060037C0 RID: 14272 RVA: 0x000BE74B File Offset: 0x000BCB4B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060037C1 RID: 14273 RVA: 0x000BE756 File Offset: 0x000BCB56
		public static void AddType(FlatBufferBuilder builder, GuildRoundtableTable.eType Type)
		{
			builder.AddInt(1, (int)Type, 0);
		}

		// Token: 0x060037C2 RID: 14274 RVA: 0x000BE761 File Offset: 0x000BCB61
		public static void AddTimesLimit(FlatBufferBuilder builder, int TimesLimit)
		{
			builder.AddInt(2, TimesLimit, 0);
		}

		// Token: 0x060037C3 RID: 14275 RVA: 0x000BE76C File Offset: 0x000BCB6C
		public static void AddGetItems(FlatBufferBuilder builder, VectorOffset GetItemsOffset)
		{
			builder.AddOffset(3, GetItemsOffset.Value, 0);
		}

		// Token: 0x060037C4 RID: 14276 RVA: 0x000BE780 File Offset: 0x000BCB80
		public static VectorOffset CreateGetItemsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060037C5 RID: 14277 RVA: 0x000BE7C6 File Offset: 0x000BCBC6
		public static void StartGetItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060037C6 RID: 14278 RVA: 0x000BE7D1 File Offset: 0x000BCBD1
		public static void AddMailContentID(FlatBufferBuilder builder, int MailContentID)
		{
			builder.AddInt(4, MailContentID, 0);
		}

		// Token: 0x060037C7 RID: 14279 RVA: 0x000BE7DC File Offset: 0x000BCBDC
		public static Offset<GuildRoundtableTable> EndGuildRoundtableTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildRoundtableTable>(value);
		}

		// Token: 0x060037C8 RID: 14280 RVA: 0x000BE7F6 File Offset: 0x000BCBF6
		public static void FinishGuildRoundtableTableBuffer(FlatBufferBuilder builder, Offset<GuildRoundtableTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015E4 RID: 5604
		private Table __p = new Table();

		// Token: 0x040015E5 RID: 5605
		private FlatBufferArray<string> GetItemsValue;

		// Token: 0x02000480 RID: 1152
		public enum eType
		{
			// Token: 0x040015E7 RID: 5607
			First,
			// Token: 0x040015E8 RID: 5608
			Help,
			// Token: 0x040015E9 RID: 5609
			FreeHelp
		}

		// Token: 0x02000481 RID: 1153
		public enum eCrypt
		{
			// Token: 0x040015EB RID: 5611
			code = -194548911
		}
	}
}

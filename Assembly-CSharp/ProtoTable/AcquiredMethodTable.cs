using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000270 RID: 624
	public class AcquiredMethodTable : IFlatbufferObject
	{
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060014CB RID: 5323 RVA: 0x0006B864 File Offset: 0x00069C64
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x0006B871 File Offset: 0x00069C71
		public static AcquiredMethodTable GetRootAsAcquiredMethodTable(ByteBuffer _bb)
		{
			return AcquiredMethodTable.GetRootAsAcquiredMethodTable(_bb, new AcquiredMethodTable());
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x0006B87E File Offset: 0x00069C7E
		public static AcquiredMethodTable GetRootAsAcquiredMethodTable(ByteBuffer _bb, AcquiredMethodTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x0006B89A File Offset: 0x00069C9A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x0006B8B4 File Offset: 0x00069CB4
		public AcquiredMethodTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060014D0 RID: 5328 RVA: 0x0006B8C0 File Offset: 0x00069CC0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1117580373 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060014D1 RID: 5329 RVA: 0x0006B90C File Offset: 0x00069D0C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x0006B94E File Offset: 0x00069D4E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060014D3 RID: 5331 RVA: 0x0006B95C File Offset: 0x00069D5C
		public string LinkZone
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0006B99E File Offset: 0x00069D9E
		public ArraySegment<byte>? GetLinkZoneBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060014D5 RID: 5333 RVA: 0x0006B9AC File Offset: 0x00069DAC
		public string ActionDesc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0006B9EF File Offset: 0x00069DEF
		public ArraySegment<byte>? GetActionDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x060014D7 RID: 5335 RVA: 0x0006BA00 File Offset: 0x00069E00
		public int IsLink
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1117580373 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060014D8 RID: 5336 RVA: 0x0006BA4C File Offset: 0x00069E4C
		public int FuncitonID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1117580373 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060014D9 RID: 5337 RVA: 0x0006BA98 File Offset: 0x00069E98
		public string ProbilityDesc
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x0006BADB File Offset: 0x00069EDB
		public ArraySegment<byte>? GetProbilityDescBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x060014DB RID: 5339 RVA: 0x0006BAEC File Offset: 0x00069EEC
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0006BB2F File Offset: 0x00069F2F
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0006BB40 File Offset: 0x00069F40
		public int ReLinksArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (1117580373 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x060014DE RID: 5342 RVA: 0x0006BB90 File Offset: 0x00069F90
		public int ReLinksLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0006BBC3 File Offset: 0x00069FC3
		public ArraySegment<byte>? GetReLinksBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x0006BBD2 File Offset: 0x00069FD2
		public FlatBufferArray<int> ReLinks
		{
			get
			{
				if (this.ReLinksValue == null)
				{
					this.ReLinksValue = new FlatBufferArray<int>(new Func<int, int>(this.ReLinksArray), this.ReLinksLength);
				}
				return this.ReLinksValue;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060014E1 RID: 5345 RVA: 0x0006BC04 File Offset: 0x0006A004
		public int ItemId
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1117580373 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x0006BC50 File Offset: 0x0006A050
		public static Offset<AcquiredMethodTable> CreateAcquiredMethodTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset LinkZoneOffset = default(StringOffset), StringOffset ActionDescOffset = default(StringOffset), int IsLink = 0, int FuncitonID = 0, StringOffset ProbilityDescOffset = default(StringOffset), StringOffset LinkInfoOffset = default(StringOffset), VectorOffset ReLinksOffset = default(VectorOffset), int ItemId = 0)
		{
			builder.StartObject(10);
			AcquiredMethodTable.AddItemId(builder, ItemId);
			AcquiredMethodTable.AddReLinks(builder, ReLinksOffset);
			AcquiredMethodTable.AddLinkInfo(builder, LinkInfoOffset);
			AcquiredMethodTable.AddProbilityDesc(builder, ProbilityDescOffset);
			AcquiredMethodTable.AddFuncitonID(builder, FuncitonID);
			AcquiredMethodTable.AddIsLink(builder, IsLink);
			AcquiredMethodTable.AddActionDesc(builder, ActionDescOffset);
			AcquiredMethodTable.AddLinkZone(builder, LinkZoneOffset);
			AcquiredMethodTable.AddName(builder, NameOffset);
			AcquiredMethodTable.AddID(builder, ID);
			return AcquiredMethodTable.EndAcquiredMethodTable(builder);
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x0006BCB8 File Offset: 0x0006A0B8
		public static void StartAcquiredMethodTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0006BCC2 File Offset: 0x0006A0C2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0006BCCD File Offset: 0x0006A0CD
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0006BCDE File Offset: 0x0006A0DE
		public static void AddLinkZone(FlatBufferBuilder builder, StringOffset LinkZoneOffset)
		{
			builder.AddOffset(2, LinkZoneOffset.Value, 0);
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x0006BCEF File Offset: 0x0006A0EF
		public static void AddActionDesc(FlatBufferBuilder builder, StringOffset ActionDescOffset)
		{
			builder.AddOffset(3, ActionDescOffset.Value, 0);
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0006BD00 File Offset: 0x0006A100
		public static void AddIsLink(FlatBufferBuilder builder, int IsLink)
		{
			builder.AddInt(4, IsLink, 0);
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0006BD0B File Offset: 0x0006A10B
		public static void AddFuncitonID(FlatBufferBuilder builder, int FuncitonID)
		{
			builder.AddInt(5, FuncitonID, 0);
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0006BD16 File Offset: 0x0006A116
		public static void AddProbilityDesc(FlatBufferBuilder builder, StringOffset ProbilityDescOffset)
		{
			builder.AddOffset(6, ProbilityDescOffset.Value, 0);
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x0006BD27 File Offset: 0x0006A127
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(7, LinkInfoOffset.Value, 0);
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0006BD38 File Offset: 0x0006A138
		public static void AddReLinks(FlatBufferBuilder builder, VectorOffset ReLinksOffset)
		{
			builder.AddOffset(8, ReLinksOffset.Value, 0);
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0006BD4C File Offset: 0x0006A14C
		public static VectorOffset CreateReLinksVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x0006BD89 File Offset: 0x0006A189
		public static void StartReLinksVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x0006BD94 File Offset: 0x0006A194
		public static void AddItemId(FlatBufferBuilder builder, int ItemId)
		{
			builder.AddInt(9, ItemId, 0);
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x0006BDA0 File Offset: 0x0006A1A0
		public static Offset<AcquiredMethodTable> EndAcquiredMethodTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AcquiredMethodTable>(value);
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0006BDBA File Offset: 0x0006A1BA
		public static void FinishAcquiredMethodTableBuffer(FlatBufferBuilder builder, Offset<AcquiredMethodTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D72 RID: 3442
		private Table __p = new Table();

		// Token: 0x04000D73 RID: 3443
		private FlatBufferArray<int> ReLinksValue;

		// Token: 0x02000271 RID: 625
		public enum eCrypt
		{
			// Token: 0x04000D75 RID: 3445
			code = 1117580373
		}
	}
}

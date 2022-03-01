using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004DA RID: 1242
	public class LimiteBargainShowTable : IFlatbufferObject
	{
		// Token: 0x17001075 RID: 4213
		// (get) Token: 0x06003EE4 RID: 16100 RVA: 0x000CFE34 File Offset: 0x000CE234
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003EE5 RID: 16101 RVA: 0x000CFE41 File Offset: 0x000CE241
		public static LimiteBargainShowTable GetRootAsLimiteBargainShowTable(ByteBuffer _bb)
		{
			return LimiteBargainShowTable.GetRootAsLimiteBargainShowTable(_bb, new LimiteBargainShowTable());
		}

		// Token: 0x06003EE6 RID: 16102 RVA: 0x000CFE4E File Offset: 0x000CE24E
		public static LimiteBargainShowTable GetRootAsLimiteBargainShowTable(ByteBuffer _bb, LimiteBargainShowTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003EE7 RID: 16103 RVA: 0x000CFE6A File Offset: 0x000CE26A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003EE8 RID: 16104 RVA: 0x000CFE84 File Offset: 0x000CE284
		public LimiteBargainShowTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001076 RID: 4214
		// (get) Token: 0x06003EE9 RID: 16105 RVA: 0x000CFE90 File Offset: 0x000CE290
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-961920999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001077 RID: 4215
		// (get) Token: 0x06003EEA RID: 16106 RVA: 0x000CFEDC File Offset: 0x000CE2DC
		public int ShowType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-961920999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001078 RID: 4216
		// (get) Token: 0x06003EEB RID: 16107 RVA: 0x000CFF28 File Offset: 0x000CE328
		public int ShowItem
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-961920999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001079 RID: 4217
		// (get) Token: 0x06003EEC RID: 16108 RVA: 0x000CFF74 File Offset: 0x000CE374
		public int GoblinCoins
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-961920999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700107A RID: 4218
		// (get) Token: 0x06003EED RID: 16109 RVA: 0x000CFFC0 File Offset: 0x000CE3C0
		public int Price
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-961920999 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003EEE RID: 16110 RVA: 0x000D000A File Offset: 0x000CE40A
		public static Offset<LimiteBargainShowTable> CreateLimiteBargainShowTable(FlatBufferBuilder builder, int ID = 0, int ShowType = 0, int ShowItem = 0, int GoblinCoins = 0, int Price = 0)
		{
			builder.StartObject(5);
			LimiteBargainShowTable.AddPrice(builder, Price);
			LimiteBargainShowTable.AddGoblinCoins(builder, GoblinCoins);
			LimiteBargainShowTable.AddShowItem(builder, ShowItem);
			LimiteBargainShowTable.AddShowType(builder, ShowType);
			LimiteBargainShowTable.AddID(builder, ID);
			return LimiteBargainShowTable.EndLimiteBargainShowTable(builder);
		}

		// Token: 0x06003EEF RID: 16111 RVA: 0x000D003E File Offset: 0x000CE43E
		public static void StartLimiteBargainShowTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06003EF0 RID: 16112 RVA: 0x000D0047 File Offset: 0x000CE447
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003EF1 RID: 16113 RVA: 0x000D0052 File Offset: 0x000CE452
		public static void AddShowType(FlatBufferBuilder builder, int ShowType)
		{
			builder.AddInt(1, ShowType, 0);
		}

		// Token: 0x06003EF2 RID: 16114 RVA: 0x000D005D File Offset: 0x000CE45D
		public static void AddShowItem(FlatBufferBuilder builder, int ShowItem)
		{
			builder.AddInt(2, ShowItem, 0);
		}

		// Token: 0x06003EF3 RID: 16115 RVA: 0x000D0068 File Offset: 0x000CE468
		public static void AddGoblinCoins(FlatBufferBuilder builder, int GoblinCoins)
		{
			builder.AddInt(3, GoblinCoins, 0);
		}

		// Token: 0x06003EF4 RID: 16116 RVA: 0x000D0073 File Offset: 0x000CE473
		public static void AddPrice(FlatBufferBuilder builder, int Price)
		{
			builder.AddInt(4, Price, 0);
		}

		// Token: 0x06003EF5 RID: 16117 RVA: 0x000D0080 File Offset: 0x000CE480
		public static Offset<LimiteBargainShowTable> EndLimiteBargainShowTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LimiteBargainShowTable>(value);
		}

		// Token: 0x06003EF6 RID: 16118 RVA: 0x000D009A File Offset: 0x000CE49A
		public static void FinishLimiteBargainShowTableBuffer(FlatBufferBuilder builder, Offset<LimiteBargainShowTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017F0 RID: 6128
		private Table __p = new Table();

		// Token: 0x020004DB RID: 1243
		public enum eCrypt
		{
			// Token: 0x040017F2 RID: 6130
			code = -961920999
		}
	}
}

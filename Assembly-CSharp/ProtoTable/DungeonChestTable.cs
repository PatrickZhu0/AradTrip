using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000393 RID: 915
	public class DungeonChestTable : IFlatbufferObject
	{
		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x060027BF RID: 10175 RVA: 0x000987F0 File Offset: 0x00096BF0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060027C0 RID: 10176 RVA: 0x000987FD File Offset: 0x00096BFD
		public static DungeonChestTable GetRootAsDungeonChestTable(ByteBuffer _bb)
		{
			return DungeonChestTable.GetRootAsDungeonChestTable(_bb, new DungeonChestTable());
		}

		// Token: 0x060027C1 RID: 10177 RVA: 0x0009880A File Offset: 0x00096C0A
		public static DungeonChestTable GetRootAsDungeonChestTable(ByteBuffer _bb, DungeonChestTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060027C2 RID: 10178 RVA: 0x00098826 File Offset: 0x00096C26
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060027C3 RID: 10179 RVA: 0x00098840 File Offset: 0x00096C40
		public DungeonChestTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x060027C4 RID: 10180 RVA: 0x0009884C File Offset: 0x00096C4C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x060027C5 RID: 10181 RVA: 0x00098898 File Offset: 0x00096C98
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x060027C6 RID: 10182 RVA: 0x000988E4 File Offset: 0x00096CE4
		public int Score
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x060027C7 RID: 10183 RVA: 0x00098930 File Offset: 0x00096D30
		public int GoldID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x060027C8 RID: 10184 RVA: 0x0009897C File Offset: 0x00096D7C
		public int NormalChestID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x060027C9 RID: 10185 RVA: 0x000989C8 File Offset: 0x00096DC8
		public int VipChestID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x060027CA RID: 10186 RVA: 0x00098A14 File Offset: 0x00096E14
		public int PayChestID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x060027CB RID: 10187 RVA: 0x00098A60 File Offset: 0x00096E60
		public int PayChestCostItem
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x060027CC RID: 10188 RVA: 0x00098AAC File Offset: 0x00096EAC
		public int PayChestCost
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-17028789 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x00098AF8 File Offset: 0x00096EF8
		public static Offset<DungeonChestTable> CreateDungeonChestTable(FlatBufferBuilder builder, int ID = 0, int DungeonID = 0, int Score = 0, int GoldID = 0, int NormalChestID = 0, int VipChestID = 0, int PayChestID = 0, int PayChestCostItem = 0, int PayChestCost = 0)
		{
			builder.StartObject(9);
			DungeonChestTable.AddPayChestCost(builder, PayChestCost);
			DungeonChestTable.AddPayChestCostItem(builder, PayChestCostItem);
			DungeonChestTable.AddPayChestID(builder, PayChestID);
			DungeonChestTable.AddVipChestID(builder, VipChestID);
			DungeonChestTable.AddNormalChestID(builder, NormalChestID);
			DungeonChestTable.AddGoldID(builder, GoldID);
			DungeonChestTable.AddScore(builder, Score);
			DungeonChestTable.AddDungeonID(builder, DungeonID);
			DungeonChestTable.AddID(builder, ID);
			return DungeonChestTable.EndDungeonChestTable(builder);
		}

		// Token: 0x060027CE RID: 10190 RVA: 0x00098B58 File Offset: 0x00096F58
		public static void StartDungeonChestTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x060027CF RID: 10191 RVA: 0x00098B62 File Offset: 0x00096F62
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060027D0 RID: 10192 RVA: 0x00098B6D File Offset: 0x00096F6D
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(1, DungeonID, 0);
		}

		// Token: 0x060027D1 RID: 10193 RVA: 0x00098B78 File Offset: 0x00096F78
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(2, Score, 0);
		}

		// Token: 0x060027D2 RID: 10194 RVA: 0x00098B83 File Offset: 0x00096F83
		public static void AddGoldID(FlatBufferBuilder builder, int GoldID)
		{
			builder.AddInt(3, GoldID, 0);
		}

		// Token: 0x060027D3 RID: 10195 RVA: 0x00098B8E File Offset: 0x00096F8E
		public static void AddNormalChestID(FlatBufferBuilder builder, int NormalChestID)
		{
			builder.AddInt(4, NormalChestID, 0);
		}

		// Token: 0x060027D4 RID: 10196 RVA: 0x00098B99 File Offset: 0x00096F99
		public static void AddVipChestID(FlatBufferBuilder builder, int VipChestID)
		{
			builder.AddInt(5, VipChestID, 0);
		}

		// Token: 0x060027D5 RID: 10197 RVA: 0x00098BA4 File Offset: 0x00096FA4
		public static void AddPayChestID(FlatBufferBuilder builder, int PayChestID)
		{
			builder.AddInt(6, PayChestID, 0);
		}

		// Token: 0x060027D6 RID: 10198 RVA: 0x00098BAF File Offset: 0x00096FAF
		public static void AddPayChestCostItem(FlatBufferBuilder builder, int PayChestCostItem)
		{
			builder.AddInt(7, PayChestCostItem, 0);
		}

		// Token: 0x060027D7 RID: 10199 RVA: 0x00098BBA File Offset: 0x00096FBA
		public static void AddPayChestCost(FlatBufferBuilder builder, int PayChestCost)
		{
			builder.AddInt(8, PayChestCost, 0);
		}

		// Token: 0x060027D8 RID: 10200 RVA: 0x00098BC8 File Offset: 0x00096FC8
		public static Offset<DungeonChestTable> EndDungeonChestTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonChestTable>(value);
		}

		// Token: 0x060027D9 RID: 10201 RVA: 0x00098BE2 File Offset: 0x00096FE2
		public static void FinishDungeonChestTableBuffer(FlatBufferBuilder builder, Offset<DungeonChestTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011CE RID: 4558
		private Table __p = new Table();

		// Token: 0x02000394 RID: 916
		public enum eCrypt
		{
			// Token: 0x040011D0 RID: 4560
			code = -17028789
		}
	}
}

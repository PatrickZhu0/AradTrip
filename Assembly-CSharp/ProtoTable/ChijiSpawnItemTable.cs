using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200034F RID: 847
	public class ChijiSpawnItemTable : IFlatbufferObject
	{
		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06002448 RID: 9288 RVA: 0x00090A74 File Offset: 0x0008EE74
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x00090A81 File Offset: 0x0008EE81
		public static ChijiSpawnItemTable GetRootAsChijiSpawnItemTable(ByteBuffer _bb)
		{
			return ChijiSpawnItemTable.GetRootAsChijiSpawnItemTable(_bb, new ChijiSpawnItemTable());
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x00090A8E File Offset: 0x0008EE8E
		public static ChijiSpawnItemTable GetRootAsChijiSpawnItemTable(ByteBuffer _bb, ChijiSpawnItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x00090AAA File Offset: 0x0008EEAA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x00090AC4 File Offset: 0x0008EEC4
		public ChijiSpawnItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x0600244D RID: 9293 RVA: 0x00090AD0 File Offset: 0x0008EED0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x0600244E RID: 9294 RVA: 0x00090B1C File Offset: 0x0008EF1C
		public int Times
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x0600244F RID: 9295 RVA: 0x00090B68 File Offset: 0x0008EF68
		public int PackID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06002450 RID: 9296 RVA: 0x00090BB4 File Offset: 0x0008EFB4
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06002451 RID: 9297 RVA: 0x00090C00 File Offset: 0x0008F000
		public int Name
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06002452 RID: 9298 RVA: 0x00090C4C File Offset: 0x0008F04C
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06002453 RID: 9299 RVA: 0x00090C98 File Offset: 0x0008F098
		public int MinNumber
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06002454 RID: 9300 RVA: 0x00090CE4 File Offset: 0x0008F0E4
		public int MaxNumber
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x06002455 RID: 9301 RVA: 0x00090D30 File Offset: 0x0008F130
		public int MapID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-730451159 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x00090D7C File Offset: 0x0008F17C
		public static Offset<ChijiSpawnItemTable> CreateChijiSpawnItemTable(FlatBufferBuilder builder, int ID = 0, int Times = 0, int PackID = 0, int ItemID = 0, int Name = 0, int Weight = 0, int MinNumber = 0, int MaxNumber = 0, int MapID = 0)
		{
			builder.StartObject(9);
			ChijiSpawnItemTable.AddMapID(builder, MapID);
			ChijiSpawnItemTable.AddMaxNumber(builder, MaxNumber);
			ChijiSpawnItemTable.AddMinNumber(builder, MinNumber);
			ChijiSpawnItemTable.AddWeight(builder, Weight);
			ChijiSpawnItemTable.AddName(builder, Name);
			ChijiSpawnItemTable.AddItemID(builder, ItemID);
			ChijiSpawnItemTable.AddPackID(builder, PackID);
			ChijiSpawnItemTable.AddTimes(builder, Times);
			ChijiSpawnItemTable.AddID(builder, ID);
			return ChijiSpawnItemTable.EndChijiSpawnItemTable(builder);
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x00090DDC File Offset: 0x0008F1DC
		public static void StartChijiSpawnItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x00090DE6 File Offset: 0x0008F1E6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x00090DF1 File Offset: 0x0008F1F1
		public static void AddTimes(FlatBufferBuilder builder, int Times)
		{
			builder.AddInt(1, Times, 0);
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x00090DFC File Offset: 0x0008F1FC
		public static void AddPackID(FlatBufferBuilder builder, int PackID)
		{
			builder.AddInt(2, PackID, 0);
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x00090E07 File Offset: 0x0008F207
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(3, ItemID, 0);
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x00090E12 File Offset: 0x0008F212
		public static void AddName(FlatBufferBuilder builder, int Name)
		{
			builder.AddInt(4, Name, 0);
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x00090E1D File Offset: 0x0008F21D
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(5, Weight, 0);
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x00090E28 File Offset: 0x0008F228
		public static void AddMinNumber(FlatBufferBuilder builder, int MinNumber)
		{
			builder.AddInt(6, MinNumber, 0);
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x00090E33 File Offset: 0x0008F233
		public static void AddMaxNumber(FlatBufferBuilder builder, int MaxNumber)
		{
			builder.AddInt(7, MaxNumber, 0);
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x00090E3E File Offset: 0x0008F23E
		public static void AddMapID(FlatBufferBuilder builder, int MapID)
		{
			builder.AddInt(8, MapID, 0);
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x00090E4C File Offset: 0x0008F24C
		public static Offset<ChijiSpawnItemTable> EndChijiSpawnItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChijiSpawnItemTable>(value);
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x00090E66 File Offset: 0x0008F266
		public static void FinishChijiSpawnItemTableBuffer(FlatBufferBuilder builder, Offset<ChijiSpawnItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040010EE RID: 4334
		private Table __p = new Table();

		// Token: 0x02000350 RID: 848
		public enum eCrypt
		{
			// Token: 0x040010F0 RID: 4336
			code = -730451159
		}
	}
}

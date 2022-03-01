using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003A1 RID: 929
	public class DungeonMakeUp : IFlatbufferObject
	{
		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x06002876 RID: 10358 RVA: 0x0009A140 File Offset: 0x00098540
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002877 RID: 10359 RVA: 0x0009A14D File Offset: 0x0009854D
		public static DungeonMakeUp GetRootAsDungeonMakeUp(ByteBuffer _bb)
		{
			return DungeonMakeUp.GetRootAsDungeonMakeUp(_bb, new DungeonMakeUp());
		}

		// Token: 0x06002878 RID: 10360 RVA: 0x0009A15A File Offset: 0x0009855A
		public static DungeonMakeUp GetRootAsDungeonMakeUp(ByteBuffer _bb, DungeonMakeUp obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002879 RID: 10361 RVA: 0x0009A176 File Offset: 0x00098576
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600287A RID: 10362 RVA: 0x0009A190 File Offset: 0x00098590
		public DungeonMakeUp __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x0600287B RID: 10363 RVA: 0x0009A19C File Offset: 0x0009859C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x0600287C RID: 10364 RVA: 0x0009A1E8 File Offset: 0x000985E8
		public int Level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x0600287D RID: 10365 RVA: 0x0009A234 File Offset: 0x00098634
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600287E RID: 10366 RVA: 0x0009A280 File Offset: 0x00098680
		public int NormalItemIdArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x0600287F RID: 10367 RVA: 0x0009A2D0 File Offset: 0x000986D0
		public int NormalItemIdLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002880 RID: 10368 RVA: 0x0009A303 File Offset: 0x00098703
		public ArraySegment<byte>? GetNormalItemIdBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x06002881 RID: 10369 RVA: 0x0009A312 File Offset: 0x00098712
		public FlatBufferArray<int> NormalItemId
		{
			get
			{
				if (this.NormalItemIdValue == null)
				{
					this.NormalItemIdValue = new FlatBufferArray<int>(new Func<int, int>(this.NormalItemIdArray), this.NormalItemIdLength);
				}
				return this.NormalItemIdValue;
			}
		}

		// Token: 0x06002882 RID: 10370 RVA: 0x0009A344 File Offset: 0x00098744
		public int NormalNumArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x06002883 RID: 10371 RVA: 0x0009A394 File Offset: 0x00098794
		public int NormalNumLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002884 RID: 10372 RVA: 0x0009A3C7 File Offset: 0x000987C7
		public ArraySegment<byte>? GetNormalNumBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x06002885 RID: 10373 RVA: 0x0009A3D6 File Offset: 0x000987D6
		public FlatBufferArray<int> NormalNum
		{
			get
			{
				if (this.NormalNumValue == null)
				{
					this.NormalNumValue = new FlatBufferArray<int>(new Func<int, int>(this.NormalNumArray), this.NormalNumLength);
				}
				return this.NormalNumValue;
			}
		}

		// Token: 0x06002886 RID: 10374 RVA: 0x0009A408 File Offset: 0x00098808
		public int PerfectItemIdArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x06002887 RID: 10375 RVA: 0x0009A458 File Offset: 0x00098858
		public int PerfectItemIdLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002888 RID: 10376 RVA: 0x0009A48B File Offset: 0x0009888B
		public ArraySegment<byte>? GetPerfectItemIdBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x06002889 RID: 10377 RVA: 0x0009A49A File Offset: 0x0009889A
		public FlatBufferArray<int> PerfectItemId
		{
			get
			{
				if (this.PerfectItemIdValue == null)
				{
					this.PerfectItemIdValue = new FlatBufferArray<int>(new Func<int, int>(this.PerfectItemIdArray), this.PerfectItemIdLength);
				}
				return this.PerfectItemIdValue;
			}
		}

		// Token: 0x0600288A RID: 10378 RVA: 0x0009A4CC File Offset: 0x000988CC
		public int CostNumArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x0600288B RID: 10379 RVA: 0x0009A51C File Offset: 0x0009891C
		public int CostNumLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600288C RID: 10380 RVA: 0x0009A54F File Offset: 0x0009894F
		public ArraySegment<byte>? GetCostNumBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x0600288D RID: 10381 RVA: 0x0009A55E File Offset: 0x0009895E
		public FlatBufferArray<int> CostNum
		{
			get
			{
				if (this.CostNumValue == null)
				{
					this.CostNumValue = new FlatBufferArray<int>(new Func<int, int>(this.CostNumArray), this.CostNumLength);
				}
				return this.CostNumValue;
			}
		}

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x0600288E RID: 10382 RVA: 0x0009A590 File Offset: 0x00098990
		public int GoldCost
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x0600288F RID: 10383 RVA: 0x0009A5DC File Offset: 0x000989DC
		public int PointCost
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x06002890 RID: 10384 RVA: 0x0009A628 File Offset: 0x00098A28
		public int CountMax
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x06002891 RID: 10385 RVA: 0x0009A674 File Offset: 0x00098A74
		public int VipCountMax
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x06002892 RID: 10386 RVA: 0x0009A6C0 File Offset: 0x00098AC0
		public int VipLevel
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (658933059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002893 RID: 10387 RVA: 0x0009A70C File Offset: 0x00098B0C
		public static Offset<DungeonMakeUp> CreateDungeonMakeUp(FlatBufferBuilder builder, int ID = 0, int Level = 0, int DungeonID = 0, VectorOffset NormalItemIdOffset = default(VectorOffset), VectorOffset NormalNumOffset = default(VectorOffset), VectorOffset PerfectItemIdOffset = default(VectorOffset), VectorOffset CostNumOffset = default(VectorOffset), int GoldCost = 0, int PointCost = 0, int CountMax = 0, int VipCountMax = 0, int VipLevel = 0)
		{
			builder.StartObject(12);
			DungeonMakeUp.AddVipLevel(builder, VipLevel);
			DungeonMakeUp.AddVipCountMax(builder, VipCountMax);
			DungeonMakeUp.AddCountMax(builder, CountMax);
			DungeonMakeUp.AddPointCost(builder, PointCost);
			DungeonMakeUp.AddGoldCost(builder, GoldCost);
			DungeonMakeUp.AddCostNum(builder, CostNumOffset);
			DungeonMakeUp.AddPerfectItemId(builder, PerfectItemIdOffset);
			DungeonMakeUp.AddNormalNum(builder, NormalNumOffset);
			DungeonMakeUp.AddNormalItemId(builder, NormalItemIdOffset);
			DungeonMakeUp.AddDungeonID(builder, DungeonID);
			DungeonMakeUp.AddLevel(builder, Level);
			DungeonMakeUp.AddID(builder, ID);
			return DungeonMakeUp.EndDungeonMakeUp(builder);
		}

		// Token: 0x06002894 RID: 10388 RVA: 0x0009A784 File Offset: 0x00098B84
		public static void StartDungeonMakeUp(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06002895 RID: 10389 RVA: 0x0009A78E File Offset: 0x00098B8E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002896 RID: 10390 RVA: 0x0009A799 File Offset: 0x00098B99
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(1, Level, 0);
		}

		// Token: 0x06002897 RID: 10391 RVA: 0x0009A7A4 File Offset: 0x00098BA4
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(2, DungeonID, 0);
		}

		// Token: 0x06002898 RID: 10392 RVA: 0x0009A7AF File Offset: 0x00098BAF
		public static void AddNormalItemId(FlatBufferBuilder builder, VectorOffset NormalItemIdOffset)
		{
			builder.AddOffset(3, NormalItemIdOffset.Value, 0);
		}

		// Token: 0x06002899 RID: 10393 RVA: 0x0009A7C0 File Offset: 0x00098BC0
		public static VectorOffset CreateNormalItemIdVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600289A RID: 10394 RVA: 0x0009A7FD File Offset: 0x00098BFD
		public static void StartNormalItemIdVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600289B RID: 10395 RVA: 0x0009A808 File Offset: 0x00098C08
		public static void AddNormalNum(FlatBufferBuilder builder, VectorOffset NormalNumOffset)
		{
			builder.AddOffset(4, NormalNumOffset.Value, 0);
		}

		// Token: 0x0600289C RID: 10396 RVA: 0x0009A81C File Offset: 0x00098C1C
		public static VectorOffset CreateNormalNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600289D RID: 10397 RVA: 0x0009A859 File Offset: 0x00098C59
		public static void StartNormalNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600289E RID: 10398 RVA: 0x0009A864 File Offset: 0x00098C64
		public static void AddPerfectItemId(FlatBufferBuilder builder, VectorOffset PerfectItemIdOffset)
		{
			builder.AddOffset(5, PerfectItemIdOffset.Value, 0);
		}

		// Token: 0x0600289F RID: 10399 RVA: 0x0009A878 File Offset: 0x00098C78
		public static VectorOffset CreatePerfectItemIdVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060028A0 RID: 10400 RVA: 0x0009A8B5 File Offset: 0x00098CB5
		public static void StartPerfectItemIdVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060028A1 RID: 10401 RVA: 0x0009A8C0 File Offset: 0x00098CC0
		public static void AddCostNum(FlatBufferBuilder builder, VectorOffset CostNumOffset)
		{
			builder.AddOffset(6, CostNumOffset.Value, 0);
		}

		// Token: 0x060028A2 RID: 10402 RVA: 0x0009A8D4 File Offset: 0x00098CD4
		public static VectorOffset CreateCostNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060028A3 RID: 10403 RVA: 0x0009A911 File Offset: 0x00098D11
		public static void StartCostNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060028A4 RID: 10404 RVA: 0x0009A91C File Offset: 0x00098D1C
		public static void AddGoldCost(FlatBufferBuilder builder, int GoldCost)
		{
			builder.AddInt(7, GoldCost, 0);
		}

		// Token: 0x060028A5 RID: 10405 RVA: 0x0009A927 File Offset: 0x00098D27
		public static void AddPointCost(FlatBufferBuilder builder, int PointCost)
		{
			builder.AddInt(8, PointCost, 0);
		}

		// Token: 0x060028A6 RID: 10406 RVA: 0x0009A932 File Offset: 0x00098D32
		public static void AddCountMax(FlatBufferBuilder builder, int CountMax)
		{
			builder.AddInt(9, CountMax, 0);
		}

		// Token: 0x060028A7 RID: 10407 RVA: 0x0009A93E File Offset: 0x00098D3E
		public static void AddVipCountMax(FlatBufferBuilder builder, int VipCountMax)
		{
			builder.AddInt(10, VipCountMax, 0);
		}

		// Token: 0x060028A8 RID: 10408 RVA: 0x0009A94A File Offset: 0x00098D4A
		public static void AddVipLevel(FlatBufferBuilder builder, int VipLevel)
		{
			builder.AddInt(11, VipLevel, 0);
		}

		// Token: 0x060028A9 RID: 10409 RVA: 0x0009A958 File Offset: 0x00098D58
		public static Offset<DungeonMakeUp> EndDungeonMakeUp(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonMakeUp>(value);
		}

		// Token: 0x060028AA RID: 10410 RVA: 0x0009A972 File Offset: 0x00098D72
		public static void FinishDungeonMakeUpBuffer(FlatBufferBuilder builder, Offset<DungeonMakeUp> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011E4 RID: 4580
		private Table __p = new Table();

		// Token: 0x040011E5 RID: 4581
		private FlatBufferArray<int> NormalItemIdValue;

		// Token: 0x040011E6 RID: 4582
		private FlatBufferArray<int> NormalNumValue;

		// Token: 0x040011E7 RID: 4583
		private FlatBufferArray<int> PerfectItemIdValue;

		// Token: 0x040011E8 RID: 4584
		private FlatBufferArray<int> CostNumValue;

		// Token: 0x020003A2 RID: 930
		public enum eCrypt
		{
			// Token: 0x040011EA RID: 4586
			code = 658933059
		}
	}
}

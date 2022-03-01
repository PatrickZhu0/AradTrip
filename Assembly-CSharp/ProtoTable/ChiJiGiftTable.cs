using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200031B RID: 795
	public class ChiJiGiftTable : IFlatbufferObject
	{
		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06001F71 RID: 8049 RVA: 0x000841AC File Offset: 0x000825AC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001F72 RID: 8050 RVA: 0x000841B9 File Offset: 0x000825B9
		public static ChiJiGiftTable GetRootAsChiJiGiftTable(ByteBuffer _bb)
		{
			return ChiJiGiftTable.GetRootAsChiJiGiftTable(_bb, new ChiJiGiftTable());
		}

		// Token: 0x06001F73 RID: 8051 RVA: 0x000841C6 File Offset: 0x000825C6
		public static ChiJiGiftTable GetRootAsChiJiGiftTable(ByteBuffer _bb, ChiJiGiftTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001F74 RID: 8052 RVA: 0x000841E2 File Offset: 0x000825E2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001F75 RID: 8053 RVA: 0x000841FC File Offset: 0x000825FC
		public ChiJiGiftTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06001F76 RID: 8054 RVA: 0x00084208 File Offset: 0x00082608
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06001F77 RID: 8055 RVA: 0x00084254 File Offset: 0x00082654
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06001F78 RID: 8056 RVA: 0x000842A0 File Offset: 0x000826A0
		public int GiftPackID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06001F79 RID: 8057 RVA: 0x000842EC File Offset: 0x000826EC
		public int ItemCount
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001F7A RID: 8058 RVA: 0x00084338 File Offset: 0x00082738
		public int RecommendJobsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06001F7B RID: 8059 RVA: 0x00084388 File Offset: 0x00082788
		public int RecommendJobsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001F7C RID: 8060 RVA: 0x000843BB File Offset: 0x000827BB
		public ArraySegment<byte>? GetRecommendJobsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06001F7D RID: 8061 RVA: 0x000843CA File Offset: 0x000827CA
		public FlatBufferArray<int> RecommendJobs
		{
			get
			{
				if (this.RecommendJobsValue == null)
				{
					this.RecommendJobsValue = new FlatBufferArray<int>(new Func<int, int>(this.RecommendJobsArray), this.RecommendJobsLength);
				}
				return this.RecommendJobsValue;
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06001F7E RID: 8062 RVA: 0x000843FC File Offset: 0x000827FC
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001F7F RID: 8063 RVA: 0x00084448 File Offset: 0x00082848
		public int LevelsArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06001F80 RID: 8064 RVA: 0x00084498 File Offset: 0x00082898
		public int LevelsLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001F81 RID: 8065 RVA: 0x000844CB File Offset: 0x000828CB
		public ArraySegment<byte>? GetLevelsBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06001F82 RID: 8066 RVA: 0x000844DA File Offset: 0x000828DA
		public FlatBufferArray<int> Levels
		{
			get
			{
				if (this.LevelsValue == null)
				{
					this.LevelsValue = new FlatBufferArray<int>(new Func<int, int>(this.LevelsArray), this.LevelsLength);
				}
				return this.LevelsValue;
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x06001F83 RID: 8067 RVA: 0x0008450C File Offset: 0x0008290C
		public int EquipType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06001F84 RID: 8068 RVA: 0x00084558 File Offset: 0x00082958
		public int Strengthen
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (595813643 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001F85 RID: 8069 RVA: 0x000845A4 File Offset: 0x000829A4
		public static Offset<ChiJiGiftTable> CreateChiJiGiftTable(FlatBufferBuilder builder, int ID = 0, int ItemID = 0, int GiftPackID = 0, int ItemCount = 0, VectorOffset RecommendJobsOffset = default(VectorOffset), int Weight = 0, VectorOffset LevelsOffset = default(VectorOffset), int EquipType = 0, int Strengthen = 0)
		{
			builder.StartObject(9);
			ChiJiGiftTable.AddStrengthen(builder, Strengthen);
			ChiJiGiftTable.AddEquipType(builder, EquipType);
			ChiJiGiftTable.AddLevels(builder, LevelsOffset);
			ChiJiGiftTable.AddWeight(builder, Weight);
			ChiJiGiftTable.AddRecommendJobs(builder, RecommendJobsOffset);
			ChiJiGiftTable.AddItemCount(builder, ItemCount);
			ChiJiGiftTable.AddGiftPackID(builder, GiftPackID);
			ChiJiGiftTable.AddItemID(builder, ItemID);
			ChiJiGiftTable.AddID(builder, ID);
			return ChiJiGiftTable.EndChiJiGiftTable(builder);
		}

		// Token: 0x06001F86 RID: 8070 RVA: 0x00084604 File Offset: 0x00082A04
		public static void StartChiJiGiftTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06001F87 RID: 8071 RVA: 0x0008460E File Offset: 0x00082A0E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001F88 RID: 8072 RVA: 0x00084619 File Offset: 0x00082A19
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(1, ItemID, 0);
		}

		// Token: 0x06001F89 RID: 8073 RVA: 0x00084624 File Offset: 0x00082A24
		public static void AddGiftPackID(FlatBufferBuilder builder, int GiftPackID)
		{
			builder.AddInt(2, GiftPackID, 0);
		}

		// Token: 0x06001F8A RID: 8074 RVA: 0x0008462F File Offset: 0x00082A2F
		public static void AddItemCount(FlatBufferBuilder builder, int ItemCount)
		{
			builder.AddInt(3, ItemCount, 0);
		}

		// Token: 0x06001F8B RID: 8075 RVA: 0x0008463A File Offset: 0x00082A3A
		public static void AddRecommendJobs(FlatBufferBuilder builder, VectorOffset RecommendJobsOffset)
		{
			builder.AddOffset(4, RecommendJobsOffset.Value, 0);
		}

		// Token: 0x06001F8C RID: 8076 RVA: 0x0008464C File Offset: 0x00082A4C
		public static VectorOffset CreateRecommendJobsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001F8D RID: 8077 RVA: 0x00084689 File Offset: 0x00082A89
		public static void StartRecommendJobsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001F8E RID: 8078 RVA: 0x00084694 File Offset: 0x00082A94
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(5, Weight, 0);
		}

		// Token: 0x06001F8F RID: 8079 RVA: 0x0008469F File Offset: 0x00082A9F
		public static void AddLevels(FlatBufferBuilder builder, VectorOffset LevelsOffset)
		{
			builder.AddOffset(6, LevelsOffset.Value, 0);
		}

		// Token: 0x06001F90 RID: 8080 RVA: 0x000846B0 File Offset: 0x00082AB0
		public static VectorOffset CreateLevelsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001F91 RID: 8081 RVA: 0x000846ED File Offset: 0x00082AED
		public static void StartLevelsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001F92 RID: 8082 RVA: 0x000846F8 File Offset: 0x00082AF8
		public static void AddEquipType(FlatBufferBuilder builder, int EquipType)
		{
			builder.AddInt(7, EquipType, 0);
		}

		// Token: 0x06001F93 RID: 8083 RVA: 0x00084703 File Offset: 0x00082B03
		public static void AddStrengthen(FlatBufferBuilder builder, int Strengthen)
		{
			builder.AddInt(8, Strengthen, 0);
		}

		// Token: 0x06001F94 RID: 8084 RVA: 0x00084710 File Offset: 0x00082B10
		public static Offset<ChiJiGiftTable> EndChiJiGiftTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiGiftTable>(value);
		}

		// Token: 0x06001F95 RID: 8085 RVA: 0x0008472A File Offset: 0x00082B2A
		public static void FinishChiJiGiftTableBuffer(FlatBufferBuilder builder, Offset<ChiJiGiftTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F67 RID: 3943
		private Table __p = new Table();

		// Token: 0x04000F68 RID: 3944
		private FlatBufferArray<int> RecommendJobsValue;

		// Token: 0x04000F69 RID: 3945
		private FlatBufferArray<int> LevelsValue;

		// Token: 0x0200031C RID: 796
		public enum eCrypt
		{
			// Token: 0x04000F6B RID: 3947
			code = 595813643
		}
	}
}

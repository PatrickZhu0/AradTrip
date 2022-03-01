using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200044D RID: 1101
	public class GiftTable : IFlatbufferObject
	{
		// Token: 0x17000D04 RID: 3332
		// (get) Token: 0x0600348A RID: 13450 RVA: 0x000B73B8 File Offset: 0x000B57B8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600348B RID: 13451 RVA: 0x000B73C5 File Offset: 0x000B57C5
		public static GiftTable GetRootAsGiftTable(ByteBuffer _bb)
		{
			return GiftTable.GetRootAsGiftTable(_bb, new GiftTable());
		}

		// Token: 0x0600348C RID: 13452 RVA: 0x000B73D2 File Offset: 0x000B57D2
		public static GiftTable GetRootAsGiftTable(ByteBuffer _bb, GiftTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600348D RID: 13453 RVA: 0x000B73EE File Offset: 0x000B57EE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600348E RID: 13454 RVA: 0x000B7408 File Offset: 0x000B5808
		public GiftTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D05 RID: 3333
		// (get) Token: 0x0600348F RID: 13455 RVA: 0x000B7414 File Offset: 0x000B5814
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D06 RID: 3334
		// (get) Token: 0x06003490 RID: 13456 RVA: 0x000B7460 File Offset: 0x000B5860
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D07 RID: 3335
		// (get) Token: 0x06003491 RID: 13457 RVA: 0x000B74AC File Offset: 0x000B58AC
		public int GiftPackID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D08 RID: 3336
		// (get) Token: 0x06003492 RID: 13458 RVA: 0x000B74F8 File Offset: 0x000B58F8
		public int ItemCount
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003493 RID: 13459 RVA: 0x000B7544 File Offset: 0x000B5944
		public int RecommendJobsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D09 RID: 3337
		// (get) Token: 0x06003494 RID: 13460 RVA: 0x000B7594 File Offset: 0x000B5994
		public int RecommendJobsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003495 RID: 13461 RVA: 0x000B75C7 File Offset: 0x000B59C7
		public ArraySegment<byte>? GetRecommendJobsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000D0A RID: 3338
		// (get) Token: 0x06003496 RID: 13462 RVA: 0x000B75D6 File Offset: 0x000B59D6
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

		// Token: 0x17000D0B RID: 3339
		// (get) Token: 0x06003497 RID: 13463 RVA: 0x000B7608 File Offset: 0x000B5A08
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003498 RID: 13464 RVA: 0x000B7654 File Offset: 0x000B5A54
		public int LevelsArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D0C RID: 3340
		// (get) Token: 0x06003499 RID: 13465 RVA: 0x000B76A4 File Offset: 0x000B5AA4
		public int LevelsLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600349A RID: 13466 RVA: 0x000B76D7 File Offset: 0x000B5AD7
		public ArraySegment<byte>? GetLevelsBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000D0D RID: 3341
		// (get) Token: 0x0600349B RID: 13467 RVA: 0x000B76E6 File Offset: 0x000B5AE6
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

		// Token: 0x17000D0E RID: 3342
		// (get) Token: 0x0600349C RID: 13468 RVA: 0x000B7718 File Offset: 0x000B5B18
		public int EquipType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D0F RID: 3343
		// (get) Token: 0x0600349D RID: 13469 RVA: 0x000B7764 File Offset: 0x000B5B64
		public int Strengthen
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (114988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600349E RID: 13470 RVA: 0x000B77B0 File Offset: 0x000B5BB0
		public static Offset<GiftTable> CreateGiftTable(FlatBufferBuilder builder, int ID = 0, int ItemID = 0, int GiftPackID = 0, int ItemCount = 0, VectorOffset RecommendJobsOffset = default(VectorOffset), int Weight = 0, VectorOffset LevelsOffset = default(VectorOffset), int EquipType = 0, int Strengthen = 0)
		{
			builder.StartObject(9);
			GiftTable.AddStrengthen(builder, Strengthen);
			GiftTable.AddEquipType(builder, EquipType);
			GiftTable.AddLevels(builder, LevelsOffset);
			GiftTable.AddWeight(builder, Weight);
			GiftTable.AddRecommendJobs(builder, RecommendJobsOffset);
			GiftTable.AddItemCount(builder, ItemCount);
			GiftTable.AddGiftPackID(builder, GiftPackID);
			GiftTable.AddItemID(builder, ItemID);
			GiftTable.AddID(builder, ID);
			return GiftTable.EndGiftTable(builder);
		}

		// Token: 0x0600349F RID: 13471 RVA: 0x000B7810 File Offset: 0x000B5C10
		public static void StartGiftTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x060034A0 RID: 13472 RVA: 0x000B781A File Offset: 0x000B5C1A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060034A1 RID: 13473 RVA: 0x000B7825 File Offset: 0x000B5C25
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(1, ItemID, 0);
		}

		// Token: 0x060034A2 RID: 13474 RVA: 0x000B7830 File Offset: 0x000B5C30
		public static void AddGiftPackID(FlatBufferBuilder builder, int GiftPackID)
		{
			builder.AddInt(2, GiftPackID, 0);
		}

		// Token: 0x060034A3 RID: 13475 RVA: 0x000B783B File Offset: 0x000B5C3B
		public static void AddItemCount(FlatBufferBuilder builder, int ItemCount)
		{
			builder.AddInt(3, ItemCount, 0);
		}

		// Token: 0x060034A4 RID: 13476 RVA: 0x000B7846 File Offset: 0x000B5C46
		public static void AddRecommendJobs(FlatBufferBuilder builder, VectorOffset RecommendJobsOffset)
		{
			builder.AddOffset(4, RecommendJobsOffset.Value, 0);
		}

		// Token: 0x060034A5 RID: 13477 RVA: 0x000B7858 File Offset: 0x000B5C58
		public static VectorOffset CreateRecommendJobsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060034A6 RID: 13478 RVA: 0x000B7895 File Offset: 0x000B5C95
		public static void StartRecommendJobsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060034A7 RID: 13479 RVA: 0x000B78A0 File Offset: 0x000B5CA0
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(5, Weight, 0);
		}

		// Token: 0x060034A8 RID: 13480 RVA: 0x000B78AB File Offset: 0x000B5CAB
		public static void AddLevels(FlatBufferBuilder builder, VectorOffset LevelsOffset)
		{
			builder.AddOffset(6, LevelsOffset.Value, 0);
		}

		// Token: 0x060034A9 RID: 13481 RVA: 0x000B78BC File Offset: 0x000B5CBC
		public static VectorOffset CreateLevelsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060034AA RID: 13482 RVA: 0x000B78F9 File Offset: 0x000B5CF9
		public static void StartLevelsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060034AB RID: 13483 RVA: 0x000B7904 File Offset: 0x000B5D04
		public static void AddEquipType(FlatBufferBuilder builder, int EquipType)
		{
			builder.AddInt(7, EquipType, 0);
		}

		// Token: 0x060034AC RID: 13484 RVA: 0x000B790F File Offset: 0x000B5D0F
		public static void AddStrengthen(FlatBufferBuilder builder, int Strengthen)
		{
			builder.AddInt(8, Strengthen, 0);
		}

		// Token: 0x060034AD RID: 13485 RVA: 0x000B791C File Offset: 0x000B5D1C
		public static Offset<GiftTable> EndGiftTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GiftTable>(value);
		}

		// Token: 0x060034AE RID: 13486 RVA: 0x000B7936 File Offset: 0x000B5D36
		public static void FinishGiftTableBuffer(FlatBufferBuilder builder, Offset<GiftTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001573 RID: 5491
		private Table __p = new Table();

		// Token: 0x04001574 RID: 5492
		private FlatBufferArray<int> RecommendJobsValue;

		// Token: 0x04001575 RID: 5493
		private FlatBufferArray<int> LevelsValue;

		// Token: 0x0200044E RID: 1102
		public enum eCrypt
		{
			// Token: 0x04001577 RID: 5495
			code = 114988718
		}
	}
}

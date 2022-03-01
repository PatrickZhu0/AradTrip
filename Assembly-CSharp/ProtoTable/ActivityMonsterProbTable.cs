using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000280 RID: 640
	public class ActivityMonsterProbTable : IFlatbufferObject
	{
		// Token: 0x170002FC RID: 764
		// (get) Token: 0x0600163F RID: 5695 RVA: 0x0006EEA4 File Offset: 0x0006D2A4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x0006EEB1 File Offset: 0x0006D2B1
		public static ActivityMonsterProbTable GetRootAsActivityMonsterProbTable(ByteBuffer _bb)
		{
			return ActivityMonsterProbTable.GetRootAsActivityMonsterProbTable(_bb, new ActivityMonsterProbTable());
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x0006EEBE File Offset: 0x0006D2BE
		public static ActivityMonsterProbTable GetRootAsActivityMonsterProbTable(ByteBuffer _bb, ActivityMonsterProbTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x0006EEDA File Offset: 0x0006D2DA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x0006EEF4 File Offset: 0x0006D2F4
		public ActivityMonsterProbTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06001644 RID: 5700 RVA: 0x0006EF00 File Offset: 0x0006D300
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-72917580 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06001645 RID: 5701 RVA: 0x0006EF4C File Offset: 0x0006D34C
		public int ActivityID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-72917580 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x0006EF98 File Offset: 0x0006D398
		public int tagsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-72917580 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06001647 RID: 5703 RVA: 0x0006EFE4 File Offset: 0x0006D3E4
		public int tagsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x0006F016 File Offset: 0x0006D416
		public ArraySegment<byte>? GetTagsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06001649 RID: 5705 RVA: 0x0006F024 File Offset: 0x0006D424
		public FlatBufferArray<int> tags
		{
			get
			{
				if (this.tagsValue == null)
				{
					this.tagsValue = new FlatBufferArray<int>(new Func<int, int>(this.tagsArray), this.tagsLength);
				}
				return this.tagsValue;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600164A RID: 5706 RVA: 0x0006F054 File Offset: 0x0006D454
		public int Prob
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-72917580 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x0006F09E File Offset: 0x0006D49E
		public static Offset<ActivityMonsterProbTable> CreateActivityMonsterProbTable(FlatBufferBuilder builder, int ID = 0, int ActivityID = 0, VectorOffset tagsOffset = default(VectorOffset), int Prob = 0)
		{
			builder.StartObject(4);
			ActivityMonsterProbTable.AddProb(builder, Prob);
			ActivityMonsterProbTable.AddTags(builder, tagsOffset);
			ActivityMonsterProbTable.AddActivityID(builder, ActivityID);
			ActivityMonsterProbTable.AddID(builder, ID);
			return ActivityMonsterProbTable.EndActivityMonsterProbTable(builder);
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x0006F0CA File Offset: 0x0006D4CA
		public static void StartActivityMonsterProbTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x0006F0D3 File Offset: 0x0006D4D3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x0006F0DE File Offset: 0x0006D4DE
		public static void AddActivityID(FlatBufferBuilder builder, int ActivityID)
		{
			builder.AddInt(1, ActivityID, 0);
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x0006F0E9 File Offset: 0x0006D4E9
		public static void AddTags(FlatBufferBuilder builder, VectorOffset tagsOffset)
		{
			builder.AddOffset(2, tagsOffset.Value, 0);
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x0006F0FC File Offset: 0x0006D4FC
		public static VectorOffset CreateTagsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x0006F139 File Offset: 0x0006D539
		public static void StartTagsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x0006F144 File Offset: 0x0006D544
		public static void AddProb(FlatBufferBuilder builder, int Prob)
		{
			builder.AddInt(3, Prob, 0);
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x0006F150 File Offset: 0x0006D550
		public static Offset<ActivityMonsterProbTable> EndActivityMonsterProbTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivityMonsterProbTable>(value);
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0006F16A File Offset: 0x0006D56A
		public static void FinishActivityMonsterProbTableBuffer(FlatBufferBuilder builder, Offset<ActivityMonsterProbTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DA5 RID: 3493
		private Table __p = new Table();

		// Token: 0x04000DA6 RID: 3494
		private FlatBufferArray<int> tagsValue;

		// Token: 0x02000281 RID: 641
		public enum eCrypt
		{
			// Token: 0x04000DA8 RID: 3496
			code = -72917580
		}
	}
}

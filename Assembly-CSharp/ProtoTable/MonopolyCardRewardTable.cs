using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200050E RID: 1294
	public class MonopolyCardRewardTable : IFlatbufferObject
	{
		// Token: 0x170011A0 RID: 4512
		// (get) Token: 0x06004269 RID: 17001 RVA: 0x000D84FC File Offset: 0x000D68FC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600426A RID: 17002 RVA: 0x000D8509 File Offset: 0x000D6909
		public static MonopolyCardRewardTable GetRootAsMonopolyCardRewardTable(ByteBuffer _bb)
		{
			return MonopolyCardRewardTable.GetRootAsMonopolyCardRewardTable(_bb, new MonopolyCardRewardTable());
		}

		// Token: 0x0600426B RID: 17003 RVA: 0x000D8516 File Offset: 0x000D6916
		public static MonopolyCardRewardTable GetRootAsMonopolyCardRewardTable(ByteBuffer _bb, MonopolyCardRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600426C RID: 17004 RVA: 0x000D8532 File Offset: 0x000D6932
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600426D RID: 17005 RVA: 0x000D854C File Offset: 0x000D694C
		public MonopolyCardRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011A1 RID: 4513
		// (get) Token: 0x0600426E RID: 17006 RVA: 0x000D8558 File Offset: 0x000D6958
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-822971424 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011A2 RID: 4514
		// (get) Token: 0x0600426F RID: 17007 RVA: 0x000D85A4 File Offset: 0x000D69A4
		public string costCard
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004270 RID: 17008 RVA: 0x000D85E6 File Offset: 0x000D69E6
		public ArraySegment<byte>? GetCostCardBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170011A3 RID: 4515
		// (get) Token: 0x06004271 RID: 17009 RVA: 0x000D85F4 File Offset: 0x000D69F4
		public string reward
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004272 RID: 17010 RVA: 0x000D8636 File Offset: 0x000D6A36
		public ArraySegment<byte>? GetRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170011A4 RID: 4516
		// (get) Token: 0x06004273 RID: 17011 RVA: 0x000D8644 File Offset: 0x000D6A44
		public int time
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-822971424 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011A5 RID: 4517
		// (get) Token: 0x06004274 RID: 17012 RVA: 0x000D8690 File Offset: 0x000D6A90
		public int type
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-822971424 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004275 RID: 17013 RVA: 0x000D86DA File Offset: 0x000D6ADA
		public static Offset<MonopolyCardRewardTable> CreateMonopolyCardRewardTable(FlatBufferBuilder builder, int ID = 0, StringOffset costCardOffset = default(StringOffset), StringOffset rewardOffset = default(StringOffset), int time = 0, int type = 0)
		{
			builder.StartObject(5);
			MonopolyCardRewardTable.AddType(builder, type);
			MonopolyCardRewardTable.AddTime(builder, time);
			MonopolyCardRewardTable.AddReward(builder, rewardOffset);
			MonopolyCardRewardTable.AddCostCard(builder, costCardOffset);
			MonopolyCardRewardTable.AddID(builder, ID);
			return MonopolyCardRewardTable.EndMonopolyCardRewardTable(builder);
		}

		// Token: 0x06004276 RID: 17014 RVA: 0x000D870E File Offset: 0x000D6B0E
		public static void StartMonopolyCardRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004277 RID: 17015 RVA: 0x000D8717 File Offset: 0x000D6B17
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004278 RID: 17016 RVA: 0x000D8722 File Offset: 0x000D6B22
		public static void AddCostCard(FlatBufferBuilder builder, StringOffset costCardOffset)
		{
			builder.AddOffset(1, costCardOffset.Value, 0);
		}

		// Token: 0x06004279 RID: 17017 RVA: 0x000D8733 File Offset: 0x000D6B33
		public static void AddReward(FlatBufferBuilder builder, StringOffset rewardOffset)
		{
			builder.AddOffset(2, rewardOffset.Value, 0);
		}

		// Token: 0x0600427A RID: 17018 RVA: 0x000D8744 File Offset: 0x000D6B44
		public static void AddTime(FlatBufferBuilder builder, int time)
		{
			builder.AddInt(3, time, 0);
		}

		// Token: 0x0600427B RID: 17019 RVA: 0x000D874F File Offset: 0x000D6B4F
		public static void AddType(FlatBufferBuilder builder, int type)
		{
			builder.AddInt(4, type, 0);
		}

		// Token: 0x0600427C RID: 17020 RVA: 0x000D875C File Offset: 0x000D6B5C
		public static Offset<MonopolyCardRewardTable> EndMonopolyCardRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonopolyCardRewardTable>(value);
		}

		// Token: 0x0600427D RID: 17021 RVA: 0x000D8776 File Offset: 0x000D6B76
		public static void FinishMonopolyCardRewardTableBuffer(FlatBufferBuilder builder, Offset<MonopolyCardRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018CF RID: 6351
		private Table __p = new Table();

		// Token: 0x0200050F RID: 1295
		public enum eCrypt
		{
			// Token: 0x040018D1 RID: 6353
			code = -822971424
		}
	}
}

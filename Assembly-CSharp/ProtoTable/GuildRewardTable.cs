using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200047D RID: 1149
	public class GuildRewardTable : IFlatbufferObject
	{
		// Token: 0x17000DF5 RID: 3573
		// (get) Token: 0x0600379E RID: 14238 RVA: 0x000BE25C File Offset: 0x000BC65C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600379F RID: 14239 RVA: 0x000BE269 File Offset: 0x000BC669
		public static GuildRewardTable GetRootAsGuildRewardTable(ByteBuffer _bb)
		{
			return GuildRewardTable.GetRootAsGuildRewardTable(_bb, new GuildRewardTable());
		}

		// Token: 0x060037A0 RID: 14240 RVA: 0x000BE276 File Offset: 0x000BC676
		public static GuildRewardTable GetRootAsGuildRewardTable(ByteBuffer _bb, GuildRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060037A1 RID: 14241 RVA: 0x000BE292 File Offset: 0x000BC692
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060037A2 RID: 14242 RVA: 0x000BE2AC File Offset: 0x000BC6AC
		public GuildRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DF6 RID: 3574
		// (get) Token: 0x060037A3 RID: 14243 RVA: 0x000BE2B8 File Offset: 0x000BC6B8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (28736830 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DF7 RID: 3575
		// (get) Token: 0x060037A4 RID: 14244 RVA: 0x000BE304 File Offset: 0x000BC704
		public int TargetScore
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (28736830 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060037A5 RID: 14245 RVA: 0x000BE350 File Offset: 0x000BC750
		public string ItemRewardArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000DF8 RID: 3576
		// (get) Token: 0x060037A6 RID: 14246 RVA: 0x000BE398 File Offset: 0x000BC798
		public int ItemRewardLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000DF9 RID: 3577
		// (get) Token: 0x060037A7 RID: 14247 RVA: 0x000BE3CA File Offset: 0x000BC7CA
		public FlatBufferArray<string> ItemReward
		{
			get
			{
				if (this.ItemRewardValue == null)
				{
					this.ItemRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.ItemRewardArray), this.ItemRewardLength);
				}
				return this.ItemRewardValue;
			}
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x000BE3FA File Offset: 0x000BC7FA
		public static Offset<GuildRewardTable> CreateGuildRewardTable(FlatBufferBuilder builder, int ID = 0, int TargetScore = 0, VectorOffset ItemRewardOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			GuildRewardTable.AddItemReward(builder, ItemRewardOffset);
			GuildRewardTable.AddTargetScore(builder, TargetScore);
			GuildRewardTable.AddID(builder, ID);
			return GuildRewardTable.EndGuildRewardTable(builder);
		}

		// Token: 0x060037A9 RID: 14249 RVA: 0x000BE41E File Offset: 0x000BC81E
		public static void StartGuildRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060037AA RID: 14250 RVA: 0x000BE427 File Offset: 0x000BC827
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060037AB RID: 14251 RVA: 0x000BE432 File Offset: 0x000BC832
		public static void AddTargetScore(FlatBufferBuilder builder, int TargetScore)
		{
			builder.AddInt(1, TargetScore, 0);
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x000BE43D File Offset: 0x000BC83D
		public static void AddItemReward(FlatBufferBuilder builder, VectorOffset ItemRewardOffset)
		{
			builder.AddOffset(2, ItemRewardOffset.Value, 0);
		}

		// Token: 0x060037AD RID: 14253 RVA: 0x000BE450 File Offset: 0x000BC850
		public static VectorOffset CreateItemRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060037AE RID: 14254 RVA: 0x000BE496 File Offset: 0x000BC896
		public static void StartItemRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060037AF RID: 14255 RVA: 0x000BE4A4 File Offset: 0x000BC8A4
		public static Offset<GuildRewardTable> EndGuildRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildRewardTable>(value);
		}

		// Token: 0x060037B0 RID: 14256 RVA: 0x000BE4BE File Offset: 0x000BC8BE
		public static void FinishGuildRewardTableBuffer(FlatBufferBuilder builder, Offset<GuildRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015E0 RID: 5600
		private Table __p = new Table();

		// Token: 0x040015E1 RID: 5601
		private FlatBufferArray<string> ItemRewardValue;

		// Token: 0x0200047E RID: 1150
		public enum eCrypt
		{
			// Token: 0x040015E3 RID: 5603
			code = 28736830
		}
	}
}

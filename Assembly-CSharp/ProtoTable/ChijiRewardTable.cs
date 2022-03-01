using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200034B RID: 843
	public class ChijiRewardTable : IFlatbufferObject
	{
		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x06002420 RID: 9248 RVA: 0x0009058C File Offset: 0x0008E98C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x00090599 File Offset: 0x0008E999
		public static ChijiRewardTable GetRootAsChijiRewardTable(ByteBuffer _bb)
		{
			return ChijiRewardTable.GetRootAsChijiRewardTable(_bb, new ChijiRewardTable());
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x000905A6 File Offset: 0x0008E9A6
		public static ChijiRewardTable GetRootAsChijiRewardTable(ByteBuffer _bb, ChijiRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x000905C2 File Offset: 0x0008E9C2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x000905DC File Offset: 0x0008E9DC
		public ChijiRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06002425 RID: 9253 RVA: 0x000905E8 File Offset: 0x0008E9E8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-480087552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x06002426 RID: 9254 RVA: 0x00090634 File Offset: 0x0008EA34
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x00090676 File Offset: 0x0008EA76
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x06002428 RID: 9256 RVA: 0x00090684 File Offset: 0x0008EA84
		public int MinRank
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-480087552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x06002429 RID: 9257 RVA: 0x000906D0 File Offset: 0x0008EAD0
		public int MaxRank
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-480087552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x0600242A RID: 9258 RVA: 0x0009071C File Offset: 0x0008EB1C
		public int RewardBoxID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-480087552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x00090766 File Offset: 0x0008EB66
		public static Offset<ChijiRewardTable> CreateChijiRewardTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int MinRank = 0, int MaxRank = 0, int RewardBoxID = 0)
		{
			builder.StartObject(5);
			ChijiRewardTable.AddRewardBoxID(builder, RewardBoxID);
			ChijiRewardTable.AddMaxRank(builder, MaxRank);
			ChijiRewardTable.AddMinRank(builder, MinRank);
			ChijiRewardTable.AddName(builder, NameOffset);
			ChijiRewardTable.AddID(builder, ID);
			return ChijiRewardTable.EndChijiRewardTable(builder);
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x0009079A File Offset: 0x0008EB9A
		public static void StartChijiRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x000907A3 File Offset: 0x0008EBA3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x000907AE File Offset: 0x0008EBAE
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x000907BF File Offset: 0x0008EBBF
		public static void AddMinRank(FlatBufferBuilder builder, int MinRank)
		{
			builder.AddInt(2, MinRank, 0);
		}

		// Token: 0x06002430 RID: 9264 RVA: 0x000907CA File Offset: 0x0008EBCA
		public static void AddMaxRank(FlatBufferBuilder builder, int MaxRank)
		{
			builder.AddInt(3, MaxRank, 0);
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x000907D5 File Offset: 0x0008EBD5
		public static void AddRewardBoxID(FlatBufferBuilder builder, int RewardBoxID)
		{
			builder.AddInt(4, RewardBoxID, 0);
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x000907E0 File Offset: 0x0008EBE0
		public static Offset<ChijiRewardTable> EndChijiRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChijiRewardTable>(value);
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x000907FA File Offset: 0x0008EBFA
		public static void FinishChijiRewardTableBuffer(FlatBufferBuilder builder, Offset<ChijiRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040010E8 RID: 4328
		private Table __p = new Table();

		// Token: 0x0200034C RID: 844
		public enum eCrypt
		{
			// Token: 0x040010EA RID: 4330
			code = -480087552
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004E1 RID: 1249
	public class MagicCardProbabilityTable : IFlatbufferObject
	{
		// Token: 0x17001085 RID: 4229
		// (get) Token: 0x06003F20 RID: 16160 RVA: 0x000D0538 File Offset: 0x000CE938
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003F21 RID: 16161 RVA: 0x000D0545 File Offset: 0x000CE945
		public static MagicCardProbabilityTable GetRootAsMagicCardProbabilityTable(ByteBuffer _bb)
		{
			return MagicCardProbabilityTable.GetRootAsMagicCardProbabilityTable(_bb, new MagicCardProbabilityTable());
		}

		// Token: 0x06003F22 RID: 16162 RVA: 0x000D0552 File Offset: 0x000CE952
		public static MagicCardProbabilityTable GetRootAsMagicCardProbabilityTable(ByteBuffer _bb, MagicCardProbabilityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003F23 RID: 16163 RVA: 0x000D056E File Offset: 0x000CE96E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003F24 RID: 16164 RVA: 0x000D0588 File Offset: 0x000CE988
		public MagicCardProbabilityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001086 RID: 4230
		// (get) Token: 0x06003F25 RID: 16165 RVA: 0x000D0594 File Offset: 0x000CE994
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1042591994 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001087 RID: 4231
		// (get) Token: 0x06003F26 RID: 16166 RVA: 0x000D05E0 File Offset: 0x000CE9E0
		public int MinProbability
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1042591994 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001088 RID: 4232
		// (get) Token: 0x06003F27 RID: 16167 RVA: 0x000D062C File Offset: 0x000CEA2C
		public int MaxProbability
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1042591994 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001089 RID: 4233
		// (get) Token: 0x06003F28 RID: 16168 RVA: 0x000D0678 File Offset: 0x000CEA78
		public string SuccessName
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F29 RID: 16169 RVA: 0x000D06BB File Offset: 0x000CEABB
		public ArraySegment<byte>? GetSuccessNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06003F2A RID: 16170 RVA: 0x000D06CA File Offset: 0x000CEACA
		public static Offset<MagicCardProbabilityTable> CreateMagicCardProbabilityTable(FlatBufferBuilder builder, int ID = 0, int MinProbability = 0, int MaxProbability = 0, StringOffset SuccessNameOffset = default(StringOffset))
		{
			builder.StartObject(4);
			MagicCardProbabilityTable.AddSuccessName(builder, SuccessNameOffset);
			MagicCardProbabilityTable.AddMaxProbability(builder, MaxProbability);
			MagicCardProbabilityTable.AddMinProbability(builder, MinProbability);
			MagicCardProbabilityTable.AddID(builder, ID);
			return MagicCardProbabilityTable.EndMagicCardProbabilityTable(builder);
		}

		// Token: 0x06003F2B RID: 16171 RVA: 0x000D06F6 File Offset: 0x000CEAF6
		public static void StartMagicCardProbabilityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003F2C RID: 16172 RVA: 0x000D06FF File Offset: 0x000CEAFF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003F2D RID: 16173 RVA: 0x000D070A File Offset: 0x000CEB0A
		public static void AddMinProbability(FlatBufferBuilder builder, int MinProbability)
		{
			builder.AddInt(1, MinProbability, 0);
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x000D0715 File Offset: 0x000CEB15
		public static void AddMaxProbability(FlatBufferBuilder builder, int MaxProbability)
		{
			builder.AddInt(2, MaxProbability, 0);
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x000D0720 File Offset: 0x000CEB20
		public static void AddSuccessName(FlatBufferBuilder builder, StringOffset SuccessNameOffset)
		{
			builder.AddOffset(3, SuccessNameOffset.Value, 0);
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x000D0734 File Offset: 0x000CEB34
		public static Offset<MagicCardProbabilityTable> EndMagicCardProbabilityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MagicCardProbabilityTable>(value);
		}

		// Token: 0x06003F31 RID: 16177 RVA: 0x000D074E File Offset: 0x000CEB4E
		public static void FinishMagicCardProbabilityTableBuffer(FlatBufferBuilder builder, Offset<MagicCardProbabilityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017FD RID: 6141
		private Table __p = new Table();

		// Token: 0x020004E2 RID: 1250
		public enum eCrypt
		{
			// Token: 0x040017FF RID: 6143
			code = -1042591994
		}
	}
}

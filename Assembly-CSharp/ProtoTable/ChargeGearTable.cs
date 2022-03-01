using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000310 RID: 784
	public class ChargeGearTable : IFlatbufferObject
	{
		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001EE4 RID: 7908 RVA: 0x00082E54 File Offset: 0x00081254
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001EE5 RID: 7909 RVA: 0x00082E61 File Offset: 0x00081261
		public static ChargeGearTable GetRootAsChargeGearTable(ByteBuffer _bb)
		{
			return ChargeGearTable.GetRootAsChargeGearTable(_bb, new ChargeGearTable());
		}

		// Token: 0x06001EE6 RID: 7910 RVA: 0x00082E6E File Offset: 0x0008126E
		public static ChargeGearTable GetRootAsChargeGearTable(ByteBuffer _bb, ChargeGearTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001EE7 RID: 7911 RVA: 0x00082E8A File Offset: 0x0008128A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001EE8 RID: 7912 RVA: 0x00082EA4 File Offset: 0x000812A4
		public ChargeGearTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06001EE9 RID: 7913 RVA: 0x00082EB0 File Offset: 0x000812B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1110766585 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06001EEA RID: 7914 RVA: 0x00082EFC File Offset: 0x000812FC
		public string Channel
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001EEB RID: 7915 RVA: 0x00082F3E File Offset: 0x0008133E
		public ArraySegment<byte>? GetChannelBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06001EEC RID: 7916 RVA: 0x00082F4C File Offset: 0x0008134C
		public string ProductIdsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06001EED RID: 7917 RVA: 0x00082F94 File Offset: 0x00081394
		public int ProductIdsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06001EEE RID: 7918 RVA: 0x00082FC6 File Offset: 0x000813C6
		public FlatBufferArray<string> ProductIds
		{
			get
			{
				if (this.ProductIdsValue == null)
				{
					this.ProductIdsValue = new FlatBufferArray<string>(new Func<int, string>(this.ProductIdsArray), this.ProductIdsLength);
				}
				return this.ProductIdsValue;
			}
		}

		// Token: 0x06001EEF RID: 7919 RVA: 0x00082FF6 File Offset: 0x000813F6
		public static Offset<ChargeGearTable> CreateChargeGearTable(FlatBufferBuilder builder, int ID = 0, StringOffset ChannelOffset = default(StringOffset), VectorOffset ProductIdsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			ChargeGearTable.AddProductIds(builder, ProductIdsOffset);
			ChargeGearTable.AddChannel(builder, ChannelOffset);
			ChargeGearTable.AddID(builder, ID);
			return ChargeGearTable.EndChargeGearTable(builder);
		}

		// Token: 0x06001EF0 RID: 7920 RVA: 0x0008301A File Offset: 0x0008141A
		public static void StartChargeGearTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001EF1 RID: 7921 RVA: 0x00083023 File Offset: 0x00081423
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001EF2 RID: 7922 RVA: 0x0008302E File Offset: 0x0008142E
		public static void AddChannel(FlatBufferBuilder builder, StringOffset ChannelOffset)
		{
			builder.AddOffset(1, ChannelOffset.Value, 0);
		}

		// Token: 0x06001EF3 RID: 7923 RVA: 0x0008303F File Offset: 0x0008143F
		public static void AddProductIds(FlatBufferBuilder builder, VectorOffset ProductIdsOffset)
		{
			builder.AddOffset(2, ProductIdsOffset.Value, 0);
		}

		// Token: 0x06001EF4 RID: 7924 RVA: 0x00083050 File Offset: 0x00081450
		public static VectorOffset CreateProductIdsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001EF5 RID: 7925 RVA: 0x00083096 File Offset: 0x00081496
		public static void StartProductIdsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001EF6 RID: 7926 RVA: 0x000830A4 File Offset: 0x000814A4
		public static Offset<ChargeGearTable> EndChargeGearTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChargeGearTable>(value);
		}

		// Token: 0x06001EF7 RID: 7927 RVA: 0x000830BE File Offset: 0x000814BE
		public static void FinishChargeGearTableBuffer(FlatBufferBuilder builder, Offset<ChargeGearTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F4E RID: 3918
		private Table __p = new Table();

		// Token: 0x04000F4F RID: 3919
		private FlatBufferArray<string> ProductIdsValue;

		// Token: 0x02000311 RID: 785
		public enum eCrypt
		{
			// Token: 0x04000F51 RID: 3921
			code = 1110766585
		}
	}
}

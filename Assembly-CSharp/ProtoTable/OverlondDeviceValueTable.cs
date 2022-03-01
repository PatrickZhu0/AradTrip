using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000544 RID: 1348
	public class OverlondDeviceValueTable : IFlatbufferObject
	{
		// Token: 0x170012B2 RID: 4786
		// (get) Token: 0x060045A6 RID: 17830 RVA: 0x000DFC28 File Offset: 0x000DE028
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060045A7 RID: 17831 RVA: 0x000DFC35 File Offset: 0x000DE035
		public static OverlondDeviceValueTable GetRootAsOverlondDeviceValueTable(ByteBuffer _bb)
		{
			return OverlondDeviceValueTable.GetRootAsOverlondDeviceValueTable(_bb, new OverlondDeviceValueTable());
		}

		// Token: 0x060045A8 RID: 17832 RVA: 0x000DFC42 File Offset: 0x000DE042
		public static OverlondDeviceValueTable GetRootAsOverlondDeviceValueTable(ByteBuffer _bb, OverlondDeviceValueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060045A9 RID: 17833 RVA: 0x000DFC5E File Offset: 0x000DE05E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060045AA RID: 17834 RVA: 0x000DFC78 File Offset: 0x000DE078
		public OverlondDeviceValueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012B3 RID: 4787
		// (get) Token: 0x060045AB RID: 17835 RVA: 0x000DFC84 File Offset: 0x000DE084
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (578876886 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012B4 RID: 4788
		// (get) Token: 0x060045AC RID: 17836 RVA: 0x000DFCD0 File Offset: 0x000DE0D0
		public int ItemDataID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (578876886 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012B5 RID: 4789
		// (get) Token: 0x060045AD RID: 17837 RVA: 0x000DFD1C File Offset: 0x000DE11C
		public int SharpenLv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (578876886 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012B6 RID: 4790
		// (get) Token: 0x060045AE RID: 17838 RVA: 0x000DFD68 File Offset: 0x000DE168
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (578876886 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060045AF RID: 17839 RVA: 0x000DFDB2 File Offset: 0x000DE1B2
		public static Offset<OverlondDeviceValueTable> CreateOverlondDeviceValueTable(FlatBufferBuilder builder, int ID = 0, int ItemDataID = 0, int SharpenLv = 0, int Weight = 0)
		{
			builder.StartObject(4);
			OverlondDeviceValueTable.AddWeight(builder, Weight);
			OverlondDeviceValueTable.AddSharpenLv(builder, SharpenLv);
			OverlondDeviceValueTable.AddItemDataID(builder, ItemDataID);
			OverlondDeviceValueTable.AddID(builder, ID);
			return OverlondDeviceValueTable.EndOverlondDeviceValueTable(builder);
		}

		// Token: 0x060045B0 RID: 17840 RVA: 0x000DFDDE File Offset: 0x000DE1DE
		public static void StartOverlondDeviceValueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060045B1 RID: 17841 RVA: 0x000DFDE7 File Offset: 0x000DE1E7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060045B2 RID: 17842 RVA: 0x000DFDF2 File Offset: 0x000DE1F2
		public static void AddItemDataID(FlatBufferBuilder builder, int ItemDataID)
		{
			builder.AddInt(1, ItemDataID, 0);
		}

		// Token: 0x060045B3 RID: 17843 RVA: 0x000DFDFD File Offset: 0x000DE1FD
		public static void AddSharpenLv(FlatBufferBuilder builder, int SharpenLv)
		{
			builder.AddInt(2, SharpenLv, 0);
		}

		// Token: 0x060045B4 RID: 17844 RVA: 0x000DFE08 File Offset: 0x000DE208
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(3, Weight, 0);
		}

		// Token: 0x060045B5 RID: 17845 RVA: 0x000DFE14 File Offset: 0x000DE214
		public static Offset<OverlondDeviceValueTable> EndOverlondDeviceValueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<OverlondDeviceValueTable>(value);
		}

		// Token: 0x060045B6 RID: 17846 RVA: 0x000DFE2E File Offset: 0x000DE22E
		public static void FinishOverlondDeviceValueTableBuffer(FlatBufferBuilder builder, Offset<OverlondDeviceValueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040019ED RID: 6637
		private Table __p = new Table();

		// Token: 0x02000545 RID: 1349
		public enum eCrypt
		{
			// Token: 0x040019EF RID: 6639
			code = 578876886
		}
	}
}

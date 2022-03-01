using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003EF RID: 1007
	public class EquipInitialAttribute : IFlatbufferObject
	{
		// Token: 0x17000AF1 RID: 2801
		// (get) Token: 0x06002DEE RID: 11758 RVA: 0x000A78D8 File Offset: 0x000A5CD8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002DEF RID: 11759 RVA: 0x000A78E5 File Offset: 0x000A5CE5
		public static EquipInitialAttribute GetRootAsEquipInitialAttribute(ByteBuffer _bb)
		{
			return EquipInitialAttribute.GetRootAsEquipInitialAttribute(_bb, new EquipInitialAttribute());
		}

		// Token: 0x06002DF0 RID: 11760 RVA: 0x000A78F2 File Offset: 0x000A5CF2
		public static EquipInitialAttribute GetRootAsEquipInitialAttribute(ByteBuffer _bb, EquipInitialAttribute obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002DF1 RID: 11761 RVA: 0x000A790E File Offset: 0x000A5D0E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002DF2 RID: 11762 RVA: 0x000A7928 File Offset: 0x000A5D28
		public EquipInitialAttribute __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AF2 RID: 2802
		// (get) Token: 0x06002DF3 RID: 11763 RVA: 0x000A7934 File Offset: 0x000A5D34
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1229955750 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AF3 RID: 2803
		// (get) Token: 0x06002DF4 RID: 11764 RVA: 0x000A7980 File Offset: 0x000A5D80
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1229955750 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AF4 RID: 2804
		// (get) Token: 0x06002DF5 RID: 11765 RVA: 0x000A79CC File Offset: 0x000A5DCC
		public int Strengthen
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1229955750 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AF5 RID: 2805
		// (get) Token: 0x06002DF6 RID: 11766 RVA: 0x000A7A18 File Offset: 0x000A5E18
		public int EquipQL
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1229955750 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x06002DF7 RID: 11767 RVA: 0x000A7A64 File Offset: 0x000A5E64
		public int Lease
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1229955750 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002DF8 RID: 11768 RVA: 0x000A7AB0 File Offset: 0x000A5EB0
		public string FitOccuArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06002DF9 RID: 11769 RVA: 0x000A7AF8 File Offset: 0x000A5EF8
		public int FitOccuLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000AF8 RID: 2808
		// (get) Token: 0x06002DFA RID: 11770 RVA: 0x000A7B2B File Offset: 0x000A5F2B
		public FlatBufferArray<string> FitOccu
		{
			get
			{
				if (this.FitOccuValue == null)
				{
					this.FitOccuValue = new FlatBufferArray<string>(new Func<int, string>(this.FitOccuArray), this.FitOccuLength);
				}
				return this.FitOccuValue;
			}
		}

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x06002DFB RID: 11771 RVA: 0x000A7B5C File Offset: 0x000A5F5C
		public int Source
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1229955750 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002DFC RID: 11772 RVA: 0x000A7BA8 File Offset: 0x000A5FA8
		public static Offset<EquipInitialAttribute> CreateEquipInitialAttribute(FlatBufferBuilder builder, int ID = 0, int ItemID = 0, int Strengthen = 0, int EquipQL = 0, int Lease = 0, VectorOffset FitOccuOffset = default(VectorOffset), int Source = 0)
		{
			builder.StartObject(7);
			EquipInitialAttribute.AddSource(builder, Source);
			EquipInitialAttribute.AddFitOccu(builder, FitOccuOffset);
			EquipInitialAttribute.AddLease(builder, Lease);
			EquipInitialAttribute.AddEquipQL(builder, EquipQL);
			EquipInitialAttribute.AddStrengthen(builder, Strengthen);
			EquipInitialAttribute.AddItemID(builder, ItemID);
			EquipInitialAttribute.AddID(builder, ID);
			return EquipInitialAttribute.EndEquipInitialAttribute(builder);
		}

		// Token: 0x06002DFD RID: 11773 RVA: 0x000A7BF7 File Offset: 0x000A5FF7
		public static void StartEquipInitialAttribute(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002DFE RID: 11774 RVA: 0x000A7C00 File Offset: 0x000A6000
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002DFF RID: 11775 RVA: 0x000A7C0B File Offset: 0x000A600B
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(1, ItemID, 0);
		}

		// Token: 0x06002E00 RID: 11776 RVA: 0x000A7C16 File Offset: 0x000A6016
		public static void AddStrengthen(FlatBufferBuilder builder, int Strengthen)
		{
			builder.AddInt(2, Strengthen, 0);
		}

		// Token: 0x06002E01 RID: 11777 RVA: 0x000A7C21 File Offset: 0x000A6021
		public static void AddEquipQL(FlatBufferBuilder builder, int EquipQL)
		{
			builder.AddInt(3, EquipQL, 0);
		}

		// Token: 0x06002E02 RID: 11778 RVA: 0x000A7C2C File Offset: 0x000A602C
		public static void AddLease(FlatBufferBuilder builder, int Lease)
		{
			builder.AddInt(4, Lease, 0);
		}

		// Token: 0x06002E03 RID: 11779 RVA: 0x000A7C37 File Offset: 0x000A6037
		public static void AddFitOccu(FlatBufferBuilder builder, VectorOffset FitOccuOffset)
		{
			builder.AddOffset(5, FitOccuOffset.Value, 0);
		}

		// Token: 0x06002E04 RID: 11780 RVA: 0x000A7C48 File Offset: 0x000A6048
		public static VectorOffset CreateFitOccuVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E05 RID: 11781 RVA: 0x000A7C8E File Offset: 0x000A608E
		public static void StartFitOccuVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E06 RID: 11782 RVA: 0x000A7C99 File Offset: 0x000A6099
		public static void AddSource(FlatBufferBuilder builder, int Source)
		{
			builder.AddInt(6, Source, 0);
		}

		// Token: 0x06002E07 RID: 11783 RVA: 0x000A7CA4 File Offset: 0x000A60A4
		public static Offset<EquipInitialAttribute> EndEquipInitialAttribute(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipInitialAttribute>(value);
		}

		// Token: 0x06002E08 RID: 11784 RVA: 0x000A7CBE File Offset: 0x000A60BE
		public static void FinishEquipInitialAttributeBuffer(FlatBufferBuilder builder, Offset<EquipInitialAttribute> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400135E RID: 4958
		private Table __p = new Table();

		// Token: 0x0400135F RID: 4959
		private FlatBufferArray<string> FitOccuValue;

		// Token: 0x020003F0 RID: 1008
		public enum eCrypt
		{
			// Token: 0x04001361 RID: 4961
			code = -1229955750
		}
	}
}

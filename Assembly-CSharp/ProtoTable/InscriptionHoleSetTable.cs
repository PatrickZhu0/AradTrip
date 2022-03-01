using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004A2 RID: 1186
	public class InscriptionHoleSetTable : IFlatbufferObject
	{
		// Token: 0x17000EA4 RID: 3748
		// (get) Token: 0x060039CC RID: 14796 RVA: 0x000C3240 File Offset: 0x000C1640
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060039CD RID: 14797 RVA: 0x000C324D File Offset: 0x000C164D
		public static InscriptionHoleSetTable GetRootAsInscriptionHoleSetTable(ByteBuffer _bb)
		{
			return InscriptionHoleSetTable.GetRootAsInscriptionHoleSetTable(_bb, new InscriptionHoleSetTable());
		}

		// Token: 0x060039CE RID: 14798 RVA: 0x000C325A File Offset: 0x000C165A
		public static InscriptionHoleSetTable GetRootAsInscriptionHoleSetTable(ByteBuffer _bb, InscriptionHoleSetTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060039CF RID: 14799 RVA: 0x000C3276 File Offset: 0x000C1676
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060039D0 RID: 14800 RVA: 0x000C3290 File Offset: 0x000C1690
		public InscriptionHoleSetTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EA5 RID: 3749
		// (get) Token: 0x060039D1 RID: 14801 RVA: 0x000C329C File Offset: 0x000C169C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2109726158 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060039D2 RID: 14802 RVA: 0x000C32E8 File Offset: 0x000C16E8
		public int ThirdTypeArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-2109726158 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EA6 RID: 3750
		// (get) Token: 0x060039D3 RID: 14803 RVA: 0x000C3334 File Offset: 0x000C1734
		public int ThirdTypeLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060039D4 RID: 14804 RVA: 0x000C3366 File Offset: 0x000C1766
		public ArraySegment<byte>? GetThirdTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000EA7 RID: 3751
		// (get) Token: 0x060039D5 RID: 14805 RVA: 0x000C3374 File Offset: 0x000C1774
		public FlatBufferArray<int> ThirdType
		{
			get
			{
				if (this.ThirdTypeValue == null)
				{
					this.ThirdTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.ThirdTypeArray), this.ThirdTypeLength);
				}
				return this.ThirdTypeValue;
			}
		}

		// Token: 0x17000EA8 RID: 3752
		// (get) Token: 0x060039D6 RID: 14806 RVA: 0x000C33A4 File Offset: 0x000C17A4
		public string InscriptionHolePicture
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039D7 RID: 14807 RVA: 0x000C33E6 File Offset: 0x000C17E6
		public ArraySegment<byte>? GetInscriptionHolePictureBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x060039D8 RID: 14808 RVA: 0x000C33F4 File Offset: 0x000C17F4
		public static Offset<InscriptionHoleSetTable> CreateInscriptionHoleSetTable(FlatBufferBuilder builder, int ID = 0, VectorOffset ThirdTypeOffset = default(VectorOffset), StringOffset InscriptionHolePictureOffset = default(StringOffset))
		{
			builder.StartObject(3);
			InscriptionHoleSetTable.AddInscriptionHolePicture(builder, InscriptionHolePictureOffset);
			InscriptionHoleSetTable.AddThirdType(builder, ThirdTypeOffset);
			InscriptionHoleSetTable.AddID(builder, ID);
			return InscriptionHoleSetTable.EndInscriptionHoleSetTable(builder);
		}

		// Token: 0x060039D9 RID: 14809 RVA: 0x000C3418 File Offset: 0x000C1818
		public static void StartInscriptionHoleSetTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060039DA RID: 14810 RVA: 0x000C3421 File Offset: 0x000C1821
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060039DB RID: 14811 RVA: 0x000C342C File Offset: 0x000C182C
		public static void AddThirdType(FlatBufferBuilder builder, VectorOffset ThirdTypeOffset)
		{
			builder.AddOffset(1, ThirdTypeOffset.Value, 0);
		}

		// Token: 0x060039DC RID: 14812 RVA: 0x000C3440 File Offset: 0x000C1840
		public static VectorOffset CreateThirdTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060039DD RID: 14813 RVA: 0x000C347D File Offset: 0x000C187D
		public static void StartThirdTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060039DE RID: 14814 RVA: 0x000C3488 File Offset: 0x000C1888
		public static void AddInscriptionHolePicture(FlatBufferBuilder builder, StringOffset InscriptionHolePictureOffset)
		{
			builder.AddOffset(2, InscriptionHolePictureOffset.Value, 0);
		}

		// Token: 0x060039DF RID: 14815 RVA: 0x000C349C File Offset: 0x000C189C
		public static Offset<InscriptionHoleSetTable> EndInscriptionHoleSetTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InscriptionHoleSetTable>(value);
		}

		// Token: 0x060039E0 RID: 14816 RVA: 0x000C34B6 File Offset: 0x000C18B6
		public static void FinishInscriptionHoleSetTableBuffer(FlatBufferBuilder builder, Offset<InscriptionHoleSetTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400164A RID: 5706
		private Table __p = new Table();

		// Token: 0x0400164B RID: 5707
		private FlatBufferArray<int> ThirdTypeValue;

		// Token: 0x020004A3 RID: 1187
		public enum eCrypt
		{
			// Token: 0x0400164D RID: 5709
			code = -2109726158
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200030D RID: 781
	public class ChargeDisplayTable : IFlatbufferObject
	{
		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06001ECB RID: 7883 RVA: 0x00082B4C File Offset: 0x00080F4C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001ECC RID: 7884 RVA: 0x00082B59 File Offset: 0x00080F59
		public static ChargeDisplayTable GetRootAsChargeDisplayTable(ByteBuffer _bb)
		{
			return ChargeDisplayTable.GetRootAsChargeDisplayTable(_bb, new ChargeDisplayTable());
		}

		// Token: 0x06001ECD RID: 7885 RVA: 0x00082B66 File Offset: 0x00080F66
		public static ChargeDisplayTable GetRootAsChargeDisplayTable(ByteBuffer _bb, ChargeDisplayTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001ECE RID: 7886 RVA: 0x00082B82 File Offset: 0x00080F82
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001ECF RID: 7887 RVA: 0x00082B9C File Offset: 0x00080F9C
		public ChargeDisplayTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06001ED0 RID: 7888 RVA: 0x00082BA8 File Offset: 0x00080FA8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-991510898 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06001ED1 RID: 7889 RVA: 0x00082BF4 File Offset: 0x00080FF4
		public int ActivityID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-991510898 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06001ED2 RID: 7890 RVA: 0x00082C40 File Offset: 0x00081040
		public ChargeDisplayTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ChargeDisplayTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06001ED3 RID: 7891 RVA: 0x00082C84 File Offset: 0x00081084
		public string ItemID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001ED4 RID: 7892 RVA: 0x00082CC7 File Offset: 0x000810C7
		public ArraySegment<byte>? GetItemIDBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06001ED5 RID: 7893 RVA: 0x00082CD8 File Offset: 0x000810D8
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001ED6 RID: 7894 RVA: 0x00082D1B File Offset: 0x0008111B
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001ED7 RID: 7895 RVA: 0x00082D2C File Offset: 0x0008112C
		public string ModelPath
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001ED8 RID: 7896 RVA: 0x00082D6F File Offset: 0x0008116F
		public ArraySegment<byte>? GetModelPathBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06001ED9 RID: 7897 RVA: 0x00082D7E File Offset: 0x0008117E
		public static Offset<ChargeDisplayTable> CreateChargeDisplayTable(FlatBufferBuilder builder, int ID = 0, int ActivityID = 0, ChargeDisplayTable.eType Type = ChargeDisplayTable.eType.Texture, StringOffset ItemIDOffset = default(StringOffset), StringOffset IconPathOffset = default(StringOffset), StringOffset ModelPathOffset = default(StringOffset))
		{
			builder.StartObject(6);
			ChargeDisplayTable.AddModelPath(builder, ModelPathOffset);
			ChargeDisplayTable.AddIconPath(builder, IconPathOffset);
			ChargeDisplayTable.AddItemID(builder, ItemIDOffset);
			ChargeDisplayTable.AddType(builder, Type);
			ChargeDisplayTable.AddActivityID(builder, ActivityID);
			ChargeDisplayTable.AddID(builder, ID);
			return ChargeDisplayTable.EndChargeDisplayTable(builder);
		}

		// Token: 0x06001EDA RID: 7898 RVA: 0x00082DBA File Offset: 0x000811BA
		public static void StartChargeDisplayTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06001EDB RID: 7899 RVA: 0x00082DC3 File Offset: 0x000811C3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001EDC RID: 7900 RVA: 0x00082DCE File Offset: 0x000811CE
		public static void AddActivityID(FlatBufferBuilder builder, int ActivityID)
		{
			builder.AddInt(1, ActivityID, 0);
		}

		// Token: 0x06001EDD RID: 7901 RVA: 0x00082DD9 File Offset: 0x000811D9
		public static void AddType(FlatBufferBuilder builder, ChargeDisplayTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06001EDE RID: 7902 RVA: 0x00082DE4 File Offset: 0x000811E4
		public static void AddItemID(FlatBufferBuilder builder, StringOffset ItemIDOffset)
		{
			builder.AddOffset(3, ItemIDOffset.Value, 0);
		}

		// Token: 0x06001EDF RID: 7903 RVA: 0x00082DF5 File Offset: 0x000811F5
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(4, IconPathOffset.Value, 0);
		}

		// Token: 0x06001EE0 RID: 7904 RVA: 0x00082E06 File Offset: 0x00081206
		public static void AddModelPath(FlatBufferBuilder builder, StringOffset ModelPathOffset)
		{
			builder.AddOffset(5, ModelPathOffset.Value, 0);
		}

		// Token: 0x06001EE1 RID: 7905 RVA: 0x00082E18 File Offset: 0x00081218
		public static Offset<ChargeDisplayTable> EndChargeDisplayTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChargeDisplayTable>(value);
		}

		// Token: 0x06001EE2 RID: 7906 RVA: 0x00082E32 File Offset: 0x00081232
		public static void FinishChargeDisplayTableBuffer(FlatBufferBuilder builder, Offset<ChargeDisplayTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F48 RID: 3912
		private Table __p = new Table();

		// Token: 0x0200030E RID: 782
		public enum eType
		{
			// Token: 0x04000F4A RID: 3914
			Texture,
			// Token: 0x04000F4B RID: 3915
			Model
		}

		// Token: 0x0200030F RID: 783
		public enum eCrypt
		{
			// Token: 0x04000F4D RID: 3917
			code = -991510898
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000554 RID: 1364
	public class PictureFrameTable : IFlatbufferObject
	{
		// Token: 0x170012F2 RID: 4850
		// (get) Token: 0x06004669 RID: 18025 RVA: 0x000E17CC File Offset: 0x000DFBCC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600466A RID: 18026 RVA: 0x000E17D9 File Offset: 0x000DFBD9
		public static PictureFrameTable GetRootAsPictureFrameTable(ByteBuffer _bb)
		{
			return PictureFrameTable.GetRootAsPictureFrameTable(_bb, new PictureFrameTable());
		}

		// Token: 0x0600466B RID: 18027 RVA: 0x000E17E6 File Offset: 0x000DFBE6
		public static PictureFrameTable GetRootAsPictureFrameTable(ByteBuffer _bb, PictureFrameTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600466C RID: 18028 RVA: 0x000E1802 File Offset: 0x000DFC02
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600466D RID: 18029 RVA: 0x000E181C File Offset: 0x000DFC1C
		public PictureFrameTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012F3 RID: 4851
		// (get) Token: 0x0600466E RID: 18030 RVA: 0x000E1828 File Offset: 0x000DFC28
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-395137297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012F4 RID: 4852
		// (get) Token: 0x0600466F RID: 18031 RVA: 0x000E1874 File Offset: 0x000DFC74
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004670 RID: 18032 RVA: 0x000E18B6 File Offset: 0x000DFCB6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170012F5 RID: 4853
		// (get) Token: 0x06004671 RID: 18033 RVA: 0x000E18C4 File Offset: 0x000DFCC4
		public int TabID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-395137297 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012F6 RID: 4854
		// (get) Token: 0x06004672 RID: 18034 RVA: 0x000E1910 File Offset: 0x000DFD10
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004673 RID: 18035 RVA: 0x000E1953 File Offset: 0x000DFD53
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170012F7 RID: 4855
		// (get) Token: 0x06004674 RID: 18036 RVA: 0x000E1964 File Offset: 0x000DFD64
		public string Conditions
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004675 RID: 18037 RVA: 0x000E19A7 File Offset: 0x000DFDA7
		public ArraySegment<byte>? GetConditionsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06004676 RID: 18038 RVA: 0x000E19B6 File Offset: 0x000DFDB6
		public static Offset<PictureFrameTable> CreatePictureFrameTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int TabID = 0, StringOffset IconPathOffset = default(StringOffset), StringOffset ConditionsOffset = default(StringOffset))
		{
			builder.StartObject(5);
			PictureFrameTable.AddConditions(builder, ConditionsOffset);
			PictureFrameTable.AddIconPath(builder, IconPathOffset);
			PictureFrameTable.AddTabID(builder, TabID);
			PictureFrameTable.AddName(builder, NameOffset);
			PictureFrameTable.AddID(builder, ID);
			return PictureFrameTable.EndPictureFrameTable(builder);
		}

		// Token: 0x06004677 RID: 18039 RVA: 0x000E19EA File Offset: 0x000DFDEA
		public static void StartPictureFrameTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004678 RID: 18040 RVA: 0x000E19F3 File Offset: 0x000DFDF3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004679 RID: 18041 RVA: 0x000E19FE File Offset: 0x000DFDFE
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600467A RID: 18042 RVA: 0x000E1A0F File Offset: 0x000DFE0F
		public static void AddTabID(FlatBufferBuilder builder, int TabID)
		{
			builder.AddInt(2, TabID, 0);
		}

		// Token: 0x0600467B RID: 18043 RVA: 0x000E1A1A File Offset: 0x000DFE1A
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(3, IconPathOffset.Value, 0);
		}

		// Token: 0x0600467C RID: 18044 RVA: 0x000E1A2B File Offset: 0x000DFE2B
		public static void AddConditions(FlatBufferBuilder builder, StringOffset ConditionsOffset)
		{
			builder.AddOffset(4, ConditionsOffset.Value, 0);
		}

		// Token: 0x0600467D RID: 18045 RVA: 0x000E1A3C File Offset: 0x000DFE3C
		public static Offset<PictureFrameTable> EndPictureFrameTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PictureFrameTable>(value);
		}

		// Token: 0x0600467E RID: 18046 RVA: 0x000E1A56 File Offset: 0x000DFE56
		public static void FinishPictureFrameTableBuffer(FlatBufferBuilder builder, Offset<PictureFrameTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A18 RID: 6680
		private Table __p = new Table();

		// Token: 0x02000555 RID: 1365
		public enum eCrypt
		{
			// Token: 0x04001A1A RID: 6682
			code = -395137297
		}
	}
}

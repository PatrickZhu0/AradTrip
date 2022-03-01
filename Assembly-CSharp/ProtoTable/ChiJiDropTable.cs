using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000316 RID: 790
	public class ChiJiDropTable : IFlatbufferObject
	{
		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06001F48 RID: 8008 RVA: 0x00083C9C File Offset: 0x0008209C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001F49 RID: 8009 RVA: 0x00083CA9 File Offset: 0x000820A9
		public static ChiJiDropTable GetRootAsChiJiDropTable(ByteBuffer _bb)
		{
			return ChiJiDropTable.GetRootAsChiJiDropTable(_bb, new ChiJiDropTable());
		}

		// Token: 0x06001F4A RID: 8010 RVA: 0x00083CB6 File Offset: 0x000820B6
		public static ChiJiDropTable GetRootAsChiJiDropTable(ByteBuffer _bb, ChiJiDropTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001F4B RID: 8011 RVA: 0x00083CD2 File Offset: 0x000820D2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x00083CEC File Offset: 0x000820EC
		public ChiJiDropTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001F4D RID: 8013 RVA: 0x00083CF8 File Offset: 0x000820F8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (598615558 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06001F4E RID: 8014 RVA: 0x00083D44 File Offset: 0x00082144
		public int Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (598615558 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06001F4F RID: 8015 RVA: 0x00083D90 File Offset: 0x00082190
		public int DropID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (598615558 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001F50 RID: 8016 RVA: 0x00083DD9 File Offset: 0x000821D9
		public static Offset<ChiJiDropTable> CreateChiJiDropTable(FlatBufferBuilder builder, int ID = 0, int Name = 0, int DropID = 0)
		{
			builder.StartObject(3);
			ChiJiDropTable.AddDropID(builder, DropID);
			ChiJiDropTable.AddName(builder, Name);
			ChiJiDropTable.AddID(builder, ID);
			return ChiJiDropTable.EndChiJiDropTable(builder);
		}

		// Token: 0x06001F51 RID: 8017 RVA: 0x00083DFD File Offset: 0x000821FD
		public static void StartChiJiDropTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001F52 RID: 8018 RVA: 0x00083E06 File Offset: 0x00082206
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001F53 RID: 8019 RVA: 0x00083E11 File Offset: 0x00082211
		public static void AddName(FlatBufferBuilder builder, int Name)
		{
			builder.AddInt(1, Name, 0);
		}

		// Token: 0x06001F54 RID: 8020 RVA: 0x00083E1C File Offset: 0x0008221C
		public static void AddDropID(FlatBufferBuilder builder, int DropID)
		{
			builder.AddInt(2, DropID, 0);
		}

		// Token: 0x06001F55 RID: 8021 RVA: 0x00083E28 File Offset: 0x00082228
		public static Offset<ChiJiDropTable> EndChiJiDropTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiDropTable>(value);
		}

		// Token: 0x06001F56 RID: 8022 RVA: 0x00083E42 File Offset: 0x00082242
		public static void FinishChiJiDropTableBuffer(FlatBufferBuilder builder, Offset<ChiJiDropTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F59 RID: 3929
		private Table __p = new Table();

		// Token: 0x02000317 RID: 791
		public enum eCrypt
		{
			// Token: 0x04000F5B RID: 3931
			code = 598615558
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005D1 RID: 1489
	public class StrenTicketFusePramMappingTable : IFlatbufferObject
	{
		// Token: 0x170015BD RID: 5565
		// (get) Token: 0x06004F01 RID: 20225 RVA: 0x000F591C File Offset: 0x000F3D1C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004F02 RID: 20226 RVA: 0x000F5929 File Offset: 0x000F3D29
		public static StrenTicketFusePramMappingTable GetRootAsStrenTicketFusePramMappingTable(ByteBuffer _bb)
		{
			return StrenTicketFusePramMappingTable.GetRootAsStrenTicketFusePramMappingTable(_bb, new StrenTicketFusePramMappingTable());
		}

		// Token: 0x06004F03 RID: 20227 RVA: 0x000F5936 File Offset: 0x000F3D36
		public static StrenTicketFusePramMappingTable GetRootAsStrenTicketFusePramMappingTable(ByteBuffer _bb, StrenTicketFusePramMappingTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004F04 RID: 20228 RVA: 0x000F5952 File Offset: 0x000F3D52
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004F05 RID: 20229 RVA: 0x000F596C File Offset: 0x000F3D6C
		public StrenTicketFusePramMappingTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015BE RID: 5566
		// (get) Token: 0x06004F06 RID: 20230 RVA: 0x000F5978 File Offset: 0x000F3D78
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2103834065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015BF RID: 5567
		// (get) Token: 0x06004F07 RID: 20231 RVA: 0x000F59C4 File Offset: 0x000F3DC4
		public int MuLowerRange
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2103834065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015C0 RID: 5568
		// (get) Token: 0x06004F08 RID: 20232 RVA: 0x000F5A10 File Offset: 0x000F3E10
		public int MuUpperRange
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2103834065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015C1 RID: 5569
		// (get) Token: 0x06004F09 RID: 20233 RVA: 0x000F5A5C File Offset: 0x000F3E5C
		public int Sigmal
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2103834065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004F0A RID: 20234 RVA: 0x000F5AA6 File Offset: 0x000F3EA6
		public static Offset<StrenTicketFusePramMappingTable> CreateStrenTicketFusePramMappingTable(FlatBufferBuilder builder, int ID = 0, int MuLowerRange = 0, int MuUpperRange = 0, int Sigmal = 0)
		{
			builder.StartObject(4);
			StrenTicketFusePramMappingTable.AddSigmal(builder, Sigmal);
			StrenTicketFusePramMappingTable.AddMuUpperRange(builder, MuUpperRange);
			StrenTicketFusePramMappingTable.AddMuLowerRange(builder, MuLowerRange);
			StrenTicketFusePramMappingTable.AddID(builder, ID);
			return StrenTicketFusePramMappingTable.EndStrenTicketFusePramMappingTable(builder);
		}

		// Token: 0x06004F0B RID: 20235 RVA: 0x000F5AD2 File Offset: 0x000F3ED2
		public static void StartStrenTicketFusePramMappingTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004F0C RID: 20236 RVA: 0x000F5ADB File Offset: 0x000F3EDB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004F0D RID: 20237 RVA: 0x000F5AE6 File Offset: 0x000F3EE6
		public static void AddMuLowerRange(FlatBufferBuilder builder, int MuLowerRange)
		{
			builder.AddInt(1, MuLowerRange, 0);
		}

		// Token: 0x06004F0E RID: 20238 RVA: 0x000F5AF1 File Offset: 0x000F3EF1
		public static void AddMuUpperRange(FlatBufferBuilder builder, int MuUpperRange)
		{
			builder.AddInt(2, MuUpperRange, 0);
		}

		// Token: 0x06004F0F RID: 20239 RVA: 0x000F5AFC File Offset: 0x000F3EFC
		public static void AddSigmal(FlatBufferBuilder builder, int Sigmal)
		{
			builder.AddInt(3, Sigmal, 0);
		}

		// Token: 0x06004F10 RID: 20240 RVA: 0x000F5B08 File Offset: 0x000F3F08
		public static Offset<StrenTicketFusePramMappingTable> EndStrenTicketFusePramMappingTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<StrenTicketFusePramMappingTable>(value);
		}

		// Token: 0x06004F11 RID: 20241 RVA: 0x000F5B22 File Offset: 0x000F3F22
		public static void FinishStrenTicketFusePramMappingTableBuffer(FlatBufferBuilder builder, Offset<StrenTicketFusePramMappingTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BDB RID: 7131
		private Table __p = new Table();

		// Token: 0x020005D2 RID: 1490
		public enum eCrypt
		{
			// Token: 0x04001BDD RID: 7133
			code = -2103834065
		}
	}
}

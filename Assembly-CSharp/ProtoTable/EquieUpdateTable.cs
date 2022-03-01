using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003D1 RID: 977
	public class EquieUpdateTable : IFlatbufferObject
	{
		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x06002BDF RID: 11231 RVA: 0x000A2920 File Offset: 0x000A0D20
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002BE0 RID: 11232 RVA: 0x000A292D File Offset: 0x000A0D2D
		public static EquieUpdateTable GetRootAsEquieUpdateTable(ByteBuffer _bb)
		{
			return EquieUpdateTable.GetRootAsEquieUpdateTable(_bb, new EquieUpdateTable());
		}

		// Token: 0x06002BE1 RID: 11233 RVA: 0x000A293A File Offset: 0x000A0D3A
		public static EquieUpdateTable GetRootAsEquieUpdateTable(ByteBuffer _bb, EquieUpdateTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002BE2 RID: 11234 RVA: 0x000A2956 File Offset: 0x000A0D56
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002BE3 RID: 11235 RVA: 0x000A2970 File Offset: 0x000A0D70
		public EquieUpdateTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06002BE4 RID: 11236 RVA: 0x000A297C File Offset: 0x000A0D7C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (437936418 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06002BE5 RID: 11237 RVA: 0x000A29C8 File Offset: 0x000A0DC8
		public int EquieID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (437936418 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x06002BE6 RID: 11238 RVA: 0x000A2A14 File Offset: 0x000A0E14
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (437936418 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x06002BE7 RID: 11239 RVA: 0x000A2A60 File Offset: 0x000A0E60
		public int NextLvEquieID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (437936418 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x06002BE8 RID: 11240 RVA: 0x000A2AAC File Offset: 0x000A0EAC
		public string MaterialConsume
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002BE9 RID: 11241 RVA: 0x000A2AEF File Offset: 0x000A0EEF
		public ArraySegment<byte>? GetMaterialConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x06002BEA RID: 11242 RVA: 0x000A2B00 File Offset: 0x000A0F00
		public string IncreaseMaterialConsume
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002BEB RID: 11243 RVA: 0x000A2B43 File Offset: 0x000A0F43
		public ArraySegment<byte>? GetIncreaseMaterialConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06002BEC RID: 11244 RVA: 0x000A2B54 File Offset: 0x000A0F54
		public int AnnounceID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (437936418 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x000A2BA0 File Offset: 0x000A0FA0
		public static Offset<EquieUpdateTable> CreateEquieUpdateTable(FlatBufferBuilder builder, int ID = 0, int EquieID = 0, int JobID = 0, int NextLvEquieID = 0, StringOffset MaterialConsumeOffset = default(StringOffset), StringOffset IncreaseMaterialConsumeOffset = default(StringOffset), int AnnounceID = 0)
		{
			builder.StartObject(7);
			EquieUpdateTable.AddAnnounceID(builder, AnnounceID);
			EquieUpdateTable.AddIncreaseMaterialConsume(builder, IncreaseMaterialConsumeOffset);
			EquieUpdateTable.AddMaterialConsume(builder, MaterialConsumeOffset);
			EquieUpdateTable.AddNextLvEquieID(builder, NextLvEquieID);
			EquieUpdateTable.AddJobID(builder, JobID);
			EquieUpdateTable.AddEquieID(builder, EquieID);
			EquieUpdateTable.AddID(builder, ID);
			return EquieUpdateTable.EndEquieUpdateTable(builder);
		}

		// Token: 0x06002BEE RID: 11246 RVA: 0x000A2BEF File Offset: 0x000A0FEF
		public static void StartEquieUpdateTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x000A2BF8 File Offset: 0x000A0FF8
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002BF0 RID: 11248 RVA: 0x000A2C03 File Offset: 0x000A1003
		public static void AddEquieID(FlatBufferBuilder builder, int EquieID)
		{
			builder.AddInt(1, EquieID, 0);
		}

		// Token: 0x06002BF1 RID: 11249 RVA: 0x000A2C0E File Offset: 0x000A100E
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(2, JobID, 0);
		}

		// Token: 0x06002BF2 RID: 11250 RVA: 0x000A2C19 File Offset: 0x000A1019
		public static void AddNextLvEquieID(FlatBufferBuilder builder, int NextLvEquieID)
		{
			builder.AddInt(3, NextLvEquieID, 0);
		}

		// Token: 0x06002BF3 RID: 11251 RVA: 0x000A2C24 File Offset: 0x000A1024
		public static void AddMaterialConsume(FlatBufferBuilder builder, StringOffset MaterialConsumeOffset)
		{
			builder.AddOffset(4, MaterialConsumeOffset.Value, 0);
		}

		// Token: 0x06002BF4 RID: 11252 RVA: 0x000A2C35 File Offset: 0x000A1035
		public static void AddIncreaseMaterialConsume(FlatBufferBuilder builder, StringOffset IncreaseMaterialConsumeOffset)
		{
			builder.AddOffset(5, IncreaseMaterialConsumeOffset.Value, 0);
		}

		// Token: 0x06002BF5 RID: 11253 RVA: 0x000A2C46 File Offset: 0x000A1046
		public static void AddAnnounceID(FlatBufferBuilder builder, int AnnounceID)
		{
			builder.AddInt(6, AnnounceID, 0);
		}

		// Token: 0x06002BF6 RID: 11254 RVA: 0x000A2C54 File Offset: 0x000A1054
		public static Offset<EquieUpdateTable> EndEquieUpdateTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquieUpdateTable>(value);
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x000A2C6E File Offset: 0x000A106E
		public static void FinishEquieUpdateTableBuffer(FlatBufferBuilder builder, Offset<EquieUpdateTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001304 RID: 4868
		private Table __p = new Table();

		// Token: 0x020003D2 RID: 978
		public enum eCrypt
		{
			// Token: 0x04001306 RID: 4870
			code = 437936418
		}
	}
}

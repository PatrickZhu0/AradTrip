using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000395 RID: 917
	public class DungeonClearTimeTable : IFlatbufferObject
	{
		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x060027DB RID: 10203 RVA: 0x00098C04 File Offset: 0x00097004
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060027DC RID: 10204 RVA: 0x00098C11 File Offset: 0x00097011
		public static DungeonClearTimeTable GetRootAsDungeonClearTimeTable(ByteBuffer _bb)
		{
			return DungeonClearTimeTable.GetRootAsDungeonClearTimeTable(_bb, new DungeonClearTimeTable());
		}

		// Token: 0x060027DD RID: 10205 RVA: 0x00098C1E File Offset: 0x0009701E
		public static DungeonClearTimeTable GetRootAsDungeonClearTimeTable(ByteBuffer _bb, DungeonClearTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060027DE RID: 10206 RVA: 0x00098C3A File Offset: 0x0009703A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060027DF RID: 10207 RVA: 0x00098C54 File Offset: 0x00097054
		public DungeonClearTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x060027E0 RID: 10208 RVA: 0x00098C60 File Offset: 0x00097060
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x060027E1 RID: 10209 RVA: 0x00098CAC File Offset: 0x000970AC
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x060027E2 RID: 10210 RVA: 0x00098CF8 File Offset: 0x000970F8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060027E3 RID: 10211 RVA: 0x00098D3A File Offset: 0x0009713A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x060027E4 RID: 10212 RVA: 0x00098D48 File Offset: 0x00097148
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x060027E5 RID: 10213 RVA: 0x00098D94 File Offset: 0x00097194
		public int Score
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x060027E6 RID: 10214 RVA: 0x00098DE0 File Offset: 0x000971E0
		public int Level29
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x060027E7 RID: 10215 RVA: 0x00098E2C File Offset: 0x0009722C
		public int Level39
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x060027E8 RID: 10216 RVA: 0x00098E78 File Offset: 0x00097278
		public int Level49
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x060027E9 RID: 10217 RVA: 0x00098EC4 File Offset: 0x000972C4
		public int Level59
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x060027EA RID: 10218 RVA: 0x00098F10 File Offset: 0x00097310
		public int Level69
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-475196374 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060027EB RID: 10219 RVA: 0x00098F5C File Offset: 0x0009735C
		public static Offset<DungeonClearTimeTable> CreateDungeonClearTimeTable(FlatBufferBuilder builder, int ID = 0, int DungeonID = 0, StringOffset NameOffset = default(StringOffset), int Level = 0, int Score = 0, int Level29 = 0, int Level39 = 0, int Level49 = 0, int Level59 = 0, int Level69 = 0)
		{
			builder.StartObject(10);
			DungeonClearTimeTable.AddLevel69(builder, Level69);
			DungeonClearTimeTable.AddLevel59(builder, Level59);
			DungeonClearTimeTable.AddLevel49(builder, Level49);
			DungeonClearTimeTable.AddLevel39(builder, Level39);
			DungeonClearTimeTable.AddLevel29(builder, Level29);
			DungeonClearTimeTable.AddScore(builder, Score);
			DungeonClearTimeTable.AddLevel(builder, Level);
			DungeonClearTimeTable.AddName(builder, NameOffset);
			DungeonClearTimeTable.AddDungeonID(builder, DungeonID);
			DungeonClearTimeTable.AddID(builder, ID);
			return DungeonClearTimeTable.EndDungeonClearTimeTable(builder);
		}

		// Token: 0x060027EC RID: 10220 RVA: 0x00098FC4 File Offset: 0x000973C4
		public static void StartDungeonClearTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x060027ED RID: 10221 RVA: 0x00098FCE File Offset: 0x000973CE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060027EE RID: 10222 RVA: 0x00098FD9 File Offset: 0x000973D9
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(1, DungeonID, 0);
		}

		// Token: 0x060027EF RID: 10223 RVA: 0x00098FE4 File Offset: 0x000973E4
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x060027F0 RID: 10224 RVA: 0x00098FF5 File Offset: 0x000973F5
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x060027F1 RID: 10225 RVA: 0x00099000 File Offset: 0x00097400
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(4, Score, 0);
		}

		// Token: 0x060027F2 RID: 10226 RVA: 0x0009900B File Offset: 0x0009740B
		public static void AddLevel29(FlatBufferBuilder builder, int Level29)
		{
			builder.AddInt(5, Level29, 0);
		}

		// Token: 0x060027F3 RID: 10227 RVA: 0x00099016 File Offset: 0x00097416
		public static void AddLevel39(FlatBufferBuilder builder, int Level39)
		{
			builder.AddInt(6, Level39, 0);
		}

		// Token: 0x060027F4 RID: 10228 RVA: 0x00099021 File Offset: 0x00097421
		public static void AddLevel49(FlatBufferBuilder builder, int Level49)
		{
			builder.AddInt(7, Level49, 0);
		}

		// Token: 0x060027F5 RID: 10229 RVA: 0x0009902C File Offset: 0x0009742C
		public static void AddLevel59(FlatBufferBuilder builder, int Level59)
		{
			builder.AddInt(8, Level59, 0);
		}

		// Token: 0x060027F6 RID: 10230 RVA: 0x00099037 File Offset: 0x00097437
		public static void AddLevel69(FlatBufferBuilder builder, int Level69)
		{
			builder.AddInt(9, Level69, 0);
		}

		// Token: 0x060027F7 RID: 10231 RVA: 0x00099044 File Offset: 0x00097444
		public static Offset<DungeonClearTimeTable> EndDungeonClearTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonClearTimeTable>(value);
		}

		// Token: 0x060027F8 RID: 10232 RVA: 0x0009905E File Offset: 0x0009745E
		public static void FinishDungeonClearTimeTableBuffer(FlatBufferBuilder builder, Offset<DungeonClearTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011D1 RID: 4561
		private Table __p = new Table();

		// Token: 0x02000396 RID: 918
		public enum eCrypt
		{
			// Token: 0x040011D3 RID: 4563
			code = -475196374
		}
	}
}

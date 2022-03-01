using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200039B RID: 923
	public class DungeonFinishTimeTable : IFlatbufferObject
	{
		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x06002823 RID: 10275 RVA: 0x000995A8 File Offset: 0x000979A8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002824 RID: 10276 RVA: 0x000995B5 File Offset: 0x000979B5
		public static DungeonFinishTimeTable GetRootAsDungeonFinishTimeTable(ByteBuffer _bb)
		{
			return DungeonFinishTimeTable.GetRootAsDungeonFinishTimeTable(_bb, new DungeonFinishTimeTable());
		}

		// Token: 0x06002825 RID: 10277 RVA: 0x000995C2 File Offset: 0x000979C2
		public static DungeonFinishTimeTable GetRootAsDungeonFinishTimeTable(ByteBuffer _bb, DungeonFinishTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002826 RID: 10278 RVA: 0x000995DE File Offset: 0x000979DE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002827 RID: 10279 RVA: 0x000995F8 File Offset: 0x000979F8
		public DungeonFinishTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x06002828 RID: 10280 RVA: 0x00099604 File Offset: 0x00097A04
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008FC RID: 2300
		// (get) Token: 0x06002829 RID: 10281 RVA: 0x00099650 File Offset: 0x00097A50
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x0600282A RID: 10282 RVA: 0x0009969C File Offset: 0x00097A9C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600282B RID: 10283 RVA: 0x000996DE File Offset: 0x00097ADE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x0600282C RID: 10284 RVA: 0x000996EC File Offset: 0x00097AEC
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x0600282D RID: 10285 RVA: 0x00099738 File Offset: 0x00097B38
		public int Level29
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x0600282E RID: 10286 RVA: 0x00099784 File Offset: 0x00097B84
		public int Level39
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x0600282F RID: 10287 RVA: 0x000997D0 File Offset: 0x00097BD0
		public int Level49
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06002830 RID: 10288 RVA: 0x0009981C File Offset: 0x00097C1C
		public int Level59
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06002831 RID: 10289 RVA: 0x00099868 File Offset: 0x00097C68
		public int Level69
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1861192908 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002832 RID: 10290 RVA: 0x000998B4 File Offset: 0x00097CB4
		public static Offset<DungeonFinishTimeTable> CreateDungeonFinishTimeTable(FlatBufferBuilder builder, int ID = 0, int DungeonID = 0, StringOffset NameOffset = default(StringOffset), int Level = 0, int Level29 = 0, int Level39 = 0, int Level49 = 0, int Level59 = 0, int Level69 = 0)
		{
			builder.StartObject(9);
			DungeonFinishTimeTable.AddLevel69(builder, Level69);
			DungeonFinishTimeTable.AddLevel59(builder, Level59);
			DungeonFinishTimeTable.AddLevel49(builder, Level49);
			DungeonFinishTimeTable.AddLevel39(builder, Level39);
			DungeonFinishTimeTable.AddLevel29(builder, Level29);
			DungeonFinishTimeTable.AddLevel(builder, Level);
			DungeonFinishTimeTable.AddName(builder, NameOffset);
			DungeonFinishTimeTable.AddDungeonID(builder, DungeonID);
			DungeonFinishTimeTable.AddID(builder, ID);
			return DungeonFinishTimeTable.EndDungeonFinishTimeTable(builder);
		}

		// Token: 0x06002833 RID: 10291 RVA: 0x00099914 File Offset: 0x00097D14
		public static void StartDungeonFinishTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06002834 RID: 10292 RVA: 0x0009991E File Offset: 0x00097D1E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002835 RID: 10293 RVA: 0x00099929 File Offset: 0x00097D29
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(1, DungeonID, 0);
		}

		// Token: 0x06002836 RID: 10294 RVA: 0x00099934 File Offset: 0x00097D34
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06002837 RID: 10295 RVA: 0x00099945 File Offset: 0x00097D45
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x00099950 File Offset: 0x00097D50
		public static void AddLevel29(FlatBufferBuilder builder, int Level29)
		{
			builder.AddInt(4, Level29, 0);
		}

		// Token: 0x06002839 RID: 10297 RVA: 0x0009995B File Offset: 0x00097D5B
		public static void AddLevel39(FlatBufferBuilder builder, int Level39)
		{
			builder.AddInt(5, Level39, 0);
		}

		// Token: 0x0600283A RID: 10298 RVA: 0x00099966 File Offset: 0x00097D66
		public static void AddLevel49(FlatBufferBuilder builder, int Level49)
		{
			builder.AddInt(6, Level49, 0);
		}

		// Token: 0x0600283B RID: 10299 RVA: 0x00099971 File Offset: 0x00097D71
		public static void AddLevel59(FlatBufferBuilder builder, int Level59)
		{
			builder.AddInt(7, Level59, 0);
		}

		// Token: 0x0600283C RID: 10300 RVA: 0x0009997C File Offset: 0x00097D7C
		public static void AddLevel69(FlatBufferBuilder builder, int Level69)
		{
			builder.AddInt(8, Level69, 0);
		}

		// Token: 0x0600283D RID: 10301 RVA: 0x00099988 File Offset: 0x00097D88
		public static Offset<DungeonFinishTimeTable> EndDungeonFinishTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonFinishTimeTable>(value);
		}

		// Token: 0x0600283E RID: 10302 RVA: 0x000999A2 File Offset: 0x00097DA2
		public static void FinishDungeonFinishTimeTableBuffer(FlatBufferBuilder builder, Offset<DungeonFinishTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011DA RID: 4570
		private Table __p = new Table();

		// Token: 0x0200039C RID: 924
		public enum eCrypt
		{
			// Token: 0x040011DC RID: 4572
			code = -1861192908
		}
	}
}

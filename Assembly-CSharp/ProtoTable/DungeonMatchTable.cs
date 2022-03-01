using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003A3 RID: 931
	public class DungeonMatchTable : IFlatbufferObject
	{
		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x060028AC RID: 10412 RVA: 0x0009A994 File Offset: 0x00098D94
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060028AD RID: 10413 RVA: 0x0009A9A1 File Offset: 0x00098DA1
		public static DungeonMatchTable GetRootAsDungeonMatchTable(ByteBuffer _bb)
		{
			return DungeonMatchTable.GetRootAsDungeonMatchTable(_bb, new DungeonMatchTable());
		}

		// Token: 0x060028AE RID: 10414 RVA: 0x0009A9AE File Offset: 0x00098DAE
		public static DungeonMatchTable GetRootAsDungeonMatchTable(ByteBuffer _bb, DungeonMatchTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060028AF RID: 10415 RVA: 0x0009A9CA File Offset: 0x00098DCA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060028B0 RID: 10416 RVA: 0x0009A9E4 File Offset: 0x00098DE4
		public DungeonMatchTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x060028B1 RID: 10417 RVA: 0x0009A9F0 File Offset: 0x00098DF0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-31842059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x060028B2 RID: 10418 RVA: 0x0009AA3C File Offset: 0x00098E3C
		public int MatchPlayerNum
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-31842059 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060028B3 RID: 10419 RVA: 0x0009AA85 File Offset: 0x00098E85
		public static Offset<DungeonMatchTable> CreateDungeonMatchTable(FlatBufferBuilder builder, int ID = 0, int MatchPlayerNum = 0)
		{
			builder.StartObject(2);
			DungeonMatchTable.AddMatchPlayerNum(builder, MatchPlayerNum);
			DungeonMatchTable.AddID(builder, ID);
			return DungeonMatchTable.EndDungeonMatchTable(builder);
		}

		// Token: 0x060028B4 RID: 10420 RVA: 0x0009AAA2 File Offset: 0x00098EA2
		public static void StartDungeonMatchTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x060028B5 RID: 10421 RVA: 0x0009AAAB File Offset: 0x00098EAB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060028B6 RID: 10422 RVA: 0x0009AAB6 File Offset: 0x00098EB6
		public static void AddMatchPlayerNum(FlatBufferBuilder builder, int MatchPlayerNum)
		{
			builder.AddInt(1, MatchPlayerNum, 0);
		}

		// Token: 0x060028B7 RID: 10423 RVA: 0x0009AAC4 File Offset: 0x00098EC4
		public static Offset<DungeonMatchTable> EndDungeonMatchTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonMatchTable>(value);
		}

		// Token: 0x060028B8 RID: 10424 RVA: 0x0009AADE File Offset: 0x00098EDE
		public static void FinishDungeonMatchTableBuffer(FlatBufferBuilder builder, Offset<DungeonMatchTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011EB RID: 4587
		private Table __p = new Table();

		// Token: 0x020003A4 RID: 932
		public enum eCrypt
		{
			// Token: 0x040011ED RID: 4589
			code = -31842059
		}
	}
}

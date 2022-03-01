using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005AA RID: 1450
	public class SeasonTable : IFlatbufferObject
	{
		// Token: 0x17001469 RID: 5225
		// (get) Token: 0x06004B16 RID: 19222 RVA: 0x000EBD1C File Offset: 0x000EA11C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004B17 RID: 19223 RVA: 0x000EBD29 File Offset: 0x000EA129
		public static SeasonTable GetRootAsSeasonTable(ByteBuffer _bb)
		{
			return SeasonTable.GetRootAsSeasonTable(_bb, new SeasonTable());
		}

		// Token: 0x06004B18 RID: 19224 RVA: 0x000EBD36 File Offset: 0x000EA136
		public static SeasonTable GetRootAsSeasonTable(ByteBuffer _bb, SeasonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004B19 RID: 19225 RVA: 0x000EBD52 File Offset: 0x000EA152
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004B1A RID: 19226 RVA: 0x000EBD6C File Offset: 0x000EA16C
		public SeasonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700146A RID: 5226
		// (get) Token: 0x06004B1B RID: 19227 RVA: 0x000EBD78 File Offset: 0x000EA178
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-767684625 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700146B RID: 5227
		// (get) Token: 0x06004B1C RID: 19228 RVA: 0x000EBDC4 File Offset: 0x000EA1C4
		public int SeasonEventType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-767684625 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700146C RID: 5228
		// (get) Token: 0x06004B1D RID: 19229 RVA: 0x000EBE10 File Offset: 0x000EA210
		public int SeasonCyclesType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-767684625 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700146D RID: 5229
		// (get) Token: 0x06004B1E RID: 19230 RVA: 0x000EBE5C File Offset: 0x000EA25C
		public int StartDay
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-767684625 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700146E RID: 5230
		// (get) Token: 0x06004B1F RID: 19231 RVA: 0x000EBEA8 File Offset: 0x000EA2A8
		public int StartTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-767684625 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004B20 RID: 19232 RVA: 0x000EBEF2 File Offset: 0x000EA2F2
		public static Offset<SeasonTable> CreateSeasonTable(FlatBufferBuilder builder, int ID = 0, int SeasonEventType = 0, int SeasonCyclesType = 0, int StartDay = 0, int StartTime = 0)
		{
			builder.StartObject(5);
			SeasonTable.AddStartTime(builder, StartTime);
			SeasonTable.AddStartDay(builder, StartDay);
			SeasonTable.AddSeasonCyclesType(builder, SeasonCyclesType);
			SeasonTable.AddSeasonEventType(builder, SeasonEventType);
			SeasonTable.AddID(builder, ID);
			return SeasonTable.EndSeasonTable(builder);
		}

		// Token: 0x06004B21 RID: 19233 RVA: 0x000EBF26 File Offset: 0x000EA326
		public static void StartSeasonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004B22 RID: 19234 RVA: 0x000EBF2F File Offset: 0x000EA32F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004B23 RID: 19235 RVA: 0x000EBF3A File Offset: 0x000EA33A
		public static void AddSeasonEventType(FlatBufferBuilder builder, int SeasonEventType)
		{
			builder.AddInt(1, SeasonEventType, 0);
		}

		// Token: 0x06004B24 RID: 19236 RVA: 0x000EBF45 File Offset: 0x000EA345
		public static void AddSeasonCyclesType(FlatBufferBuilder builder, int SeasonCyclesType)
		{
			builder.AddInt(2, SeasonCyclesType, 0);
		}

		// Token: 0x06004B25 RID: 19237 RVA: 0x000EBF50 File Offset: 0x000EA350
		public static void AddStartDay(FlatBufferBuilder builder, int StartDay)
		{
			builder.AddInt(3, StartDay, 0);
		}

		// Token: 0x06004B26 RID: 19238 RVA: 0x000EBF5B File Offset: 0x000EA35B
		public static void AddStartTime(FlatBufferBuilder builder, int StartTime)
		{
			builder.AddInt(4, StartTime, 0);
		}

		// Token: 0x06004B27 RID: 19239 RVA: 0x000EBF68 File Offset: 0x000EA368
		public static Offset<SeasonTable> EndSeasonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SeasonTable>(value);
		}

		// Token: 0x06004B28 RID: 19240 RVA: 0x000EBF82 File Offset: 0x000EA382
		public static void FinishSeasonTableBuffer(FlatBufferBuilder builder, Offset<SeasonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B11 RID: 6929
		private Table __p = new Table();

		// Token: 0x020005AB RID: 1451
		public enum eCrypt
		{
			// Token: 0x04001B13 RID: 6931
			code = -767684625
		}
	}
}

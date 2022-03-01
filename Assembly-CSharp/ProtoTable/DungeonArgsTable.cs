using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000391 RID: 913
	public class DungeonArgsTable : IFlatbufferObject
	{
		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x060027AB RID: 10155 RVA: 0x00098568 File Offset: 0x00096968
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060027AC RID: 10156 RVA: 0x00098575 File Offset: 0x00096975
		public static DungeonArgsTable GetRootAsDungeonArgsTable(ByteBuffer _bb)
		{
			return DungeonArgsTable.GetRootAsDungeonArgsTable(_bb, new DungeonArgsTable());
		}

		// Token: 0x060027AD RID: 10157 RVA: 0x00098582 File Offset: 0x00096982
		public static DungeonArgsTable GetRootAsDungeonArgsTable(ByteBuffer _bb, DungeonArgsTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060027AE RID: 10158 RVA: 0x0009859E File Offset: 0x0009699E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060027AF RID: 10159 RVA: 0x000985B8 File Offset: 0x000969B8
		public DungeonArgsTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x060027B0 RID: 10160 RVA: 0x000985C4 File Offset: 0x000969C4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2093642235 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x060027B1 RID: 10161 RVA: 0x00098610 File Offset: 0x00096A10
		public int TimeScore
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2093642235 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x060027B2 RID: 10162 RVA: 0x0009865C File Offset: 0x00096A5C
		public int BackHitScore
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2093642235 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x060027B3 RID: 10163 RVA: 0x000986A8 File Offset: 0x00096AA8
		public int CombScore
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2093642235 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x060027B4 RID: 10164 RVA: 0x000986F4 File Offset: 0x00096AF4
		public int ComboArg
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2093642235 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x0009873E File Offset: 0x00096B3E
		public static Offset<DungeonArgsTable> CreateDungeonArgsTable(FlatBufferBuilder builder, int ID = 0, int TimeScore = 0, int BackHitScore = 0, int CombScore = 0, int ComboArg = 0)
		{
			builder.StartObject(5);
			DungeonArgsTable.AddComboArg(builder, ComboArg);
			DungeonArgsTable.AddCombScore(builder, CombScore);
			DungeonArgsTable.AddBackHitScore(builder, BackHitScore);
			DungeonArgsTable.AddTimeScore(builder, TimeScore);
			DungeonArgsTable.AddID(builder, ID);
			return DungeonArgsTable.EndDungeonArgsTable(builder);
		}

		// Token: 0x060027B6 RID: 10166 RVA: 0x00098772 File Offset: 0x00096B72
		public static void StartDungeonArgsTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060027B7 RID: 10167 RVA: 0x0009877B File Offset: 0x00096B7B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060027B8 RID: 10168 RVA: 0x00098786 File Offset: 0x00096B86
		public static void AddTimeScore(FlatBufferBuilder builder, int TimeScore)
		{
			builder.AddInt(1, TimeScore, 0);
		}

		// Token: 0x060027B9 RID: 10169 RVA: 0x00098791 File Offset: 0x00096B91
		public static void AddBackHitScore(FlatBufferBuilder builder, int BackHitScore)
		{
			builder.AddInt(2, BackHitScore, 0);
		}

		// Token: 0x060027BA RID: 10170 RVA: 0x0009879C File Offset: 0x00096B9C
		public static void AddCombScore(FlatBufferBuilder builder, int CombScore)
		{
			builder.AddInt(3, CombScore, 0);
		}

		// Token: 0x060027BB RID: 10171 RVA: 0x000987A7 File Offset: 0x00096BA7
		public static void AddComboArg(FlatBufferBuilder builder, int ComboArg)
		{
			builder.AddInt(4, ComboArg, 0);
		}

		// Token: 0x060027BC RID: 10172 RVA: 0x000987B4 File Offset: 0x00096BB4
		public static Offset<DungeonArgsTable> EndDungeonArgsTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonArgsTable>(value);
		}

		// Token: 0x060027BD RID: 10173 RVA: 0x000987CE File Offset: 0x00096BCE
		public static void FinishDungeonArgsTableBuffer(FlatBufferBuilder builder, Offset<DungeonArgsTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011CB RID: 4555
		private Table __p = new Table();

		// Token: 0x02000392 RID: 914
		public enum eCrypt
		{
			// Token: 0x040011CD RID: 4557
			code = -2093642235
		}
	}
}

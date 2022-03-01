using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002F6 RID: 758
	public class ChampionBattleTable : IFlatbufferObject
	{
		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06001DD3 RID: 7635 RVA: 0x00080CC4 File Offset: 0x0007F0C4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001DD4 RID: 7636 RVA: 0x00080CD1 File Offset: 0x0007F0D1
		public static ChampionBattleTable GetRootAsChampionBattleTable(ByteBuffer _bb)
		{
			return ChampionBattleTable.GetRootAsChampionBattleTable(_bb, new ChampionBattleTable());
		}

		// Token: 0x06001DD5 RID: 7637 RVA: 0x00080CDE File Offset: 0x0007F0DE
		public static ChampionBattleTable GetRootAsChampionBattleTable(ByteBuffer _bb, ChampionBattleTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001DD6 RID: 7638 RVA: 0x00080CFA File Offset: 0x0007F0FA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x00080D14 File Offset: 0x0007F114
		public ChampionBattleTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001DD8 RID: 7640 RVA: 0x00080D20 File Offset: 0x0007F120
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-146039425 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001DD9 RID: 7641 RVA: 0x00080D6C File Offset: 0x0007F16C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001DDA RID: 7642 RVA: 0x00080DAE File Offset: 0x0007F1AE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06001DDB RID: 7643 RVA: 0x00080DBC File Offset: 0x0007F1BC
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001DDC RID: 7644 RVA: 0x00080DFE File Offset: 0x0007F1FE
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001DDD RID: 7645 RVA: 0x00080E0C File Offset: 0x0007F20C
		public static Offset<ChampionBattleTable> CreateChampionBattleTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset))
		{
			builder.StartObject(3);
			ChampionBattleTable.AddIcon(builder, IconOffset);
			ChampionBattleTable.AddName(builder, NameOffset);
			ChampionBattleTable.AddID(builder, ID);
			return ChampionBattleTable.EndChampionBattleTable(builder);
		}

		// Token: 0x06001DDE RID: 7646 RVA: 0x00080E30 File Offset: 0x0007F230
		public static void StartChampionBattleTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001DDF RID: 7647 RVA: 0x00080E39 File Offset: 0x0007F239
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001DE0 RID: 7648 RVA: 0x00080E44 File Offset: 0x0007F244
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x00080E55 File Offset: 0x0007F255
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(2, IconOffset.Value, 0);
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x00080E68 File Offset: 0x0007F268
		public static Offset<ChampionBattleTable> EndChampionBattleTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionBattleTable>(value);
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x00080E82 File Offset: 0x0007F282
		public static void FinishChampionBattleTableBuffer(FlatBufferBuilder builder, Offset<ChampionBattleTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F0D RID: 3853
		private Table __p = new Table();

		// Token: 0x020002F7 RID: 759
		public enum eCrypt
		{
			// Token: 0x04000F0F RID: 3855
			code = -146039425
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000561 RID: 1377
	public class PveTrainingMonsterTable : IFlatbufferObject
	{
		// Token: 0x17001325 RID: 4901
		// (get) Token: 0x0600470D RID: 18189 RVA: 0x000E2D5C File Offset: 0x000E115C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600470E RID: 18190 RVA: 0x000E2D69 File Offset: 0x000E1169
		public static PveTrainingMonsterTable GetRootAsPveTrainingMonsterTable(ByteBuffer _bb)
		{
			return PveTrainingMonsterTable.GetRootAsPveTrainingMonsterTable(_bb, new PveTrainingMonsterTable());
		}

		// Token: 0x0600470F RID: 18191 RVA: 0x000E2D76 File Offset: 0x000E1176
		public static PveTrainingMonsterTable GetRootAsPveTrainingMonsterTable(ByteBuffer _bb, PveTrainingMonsterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004710 RID: 18192 RVA: 0x000E2D92 File Offset: 0x000E1192
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004711 RID: 18193 RVA: 0x000E2DAC File Offset: 0x000E11AC
		public PveTrainingMonsterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001326 RID: 4902
		// (get) Token: 0x06004712 RID: 18194 RVA: 0x000E2DB8 File Offset: 0x000E11B8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (647185045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001327 RID: 4903
		// (get) Token: 0x06004713 RID: 18195 RVA: 0x000E2E04 File Offset: 0x000E1204
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004714 RID: 18196 RVA: 0x000E2E46 File Offset: 0x000E1246
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06004715 RID: 18197 RVA: 0x000E2E54 File Offset: 0x000E1254
		public static Offset<PveTrainingMonsterTable> CreatePveTrainingMonsterTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(2);
			PveTrainingMonsterTable.AddName(builder, NameOffset);
			PveTrainingMonsterTable.AddID(builder, ID);
			return PveTrainingMonsterTable.EndPveTrainingMonsterTable(builder);
		}

		// Token: 0x06004716 RID: 18198 RVA: 0x000E2E71 File Offset: 0x000E1271
		public static void StartPveTrainingMonsterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06004717 RID: 18199 RVA: 0x000E2E7A File Offset: 0x000E127A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004718 RID: 18200 RVA: 0x000E2E85 File Offset: 0x000E1285
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004719 RID: 18201 RVA: 0x000E2E98 File Offset: 0x000E1298
		public static Offset<PveTrainingMonsterTable> EndPveTrainingMonsterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PveTrainingMonsterTable>(value);
		}

		// Token: 0x0600471A RID: 18202 RVA: 0x000E2EB2 File Offset: 0x000E12B2
		public static void FinishPveTrainingMonsterTableBuffer(FlatBufferBuilder builder, Offset<PveTrainingMonsterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A33 RID: 6707
		private Table __p = new Table();

		// Token: 0x02000562 RID: 1378
		public enum eCrypt
		{
			// Token: 0x04001A35 RID: 6709
			code = 647185045
		}
	}
}

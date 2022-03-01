using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005BF RID: 1471
	public class SkillPreInfoTable : IFlatbufferObject
	{
		// Token: 0x17001511 RID: 5393
		// (get) Token: 0x06004D0B RID: 19723 RVA: 0x000F07C0 File Offset: 0x000EEBC0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004D0C RID: 19724 RVA: 0x000F07CD File Offset: 0x000EEBCD
		public static SkillPreInfoTable GetRootAsSkillPreInfoTable(ByteBuffer _bb)
		{
			return SkillPreInfoTable.GetRootAsSkillPreInfoTable(_bb, new SkillPreInfoTable());
		}

		// Token: 0x06004D0D RID: 19725 RVA: 0x000F07DA File Offset: 0x000EEBDA
		public static SkillPreInfoTable GetRootAsSkillPreInfoTable(ByteBuffer _bb, SkillPreInfoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004D0E RID: 19726 RVA: 0x000F07F6 File Offset: 0x000EEBF6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004D0F RID: 19727 RVA: 0x000F0810 File Offset: 0x000EEC10
		public SkillPreInfoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001512 RID: 5394
		// (get) Token: 0x06004D10 RID: 19728 RVA: 0x000F081C File Offset: 0x000EEC1C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-882410950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001513 RID: 5395
		// (get) Token: 0x06004D11 RID: 19729 RVA: 0x000F0868 File Offset: 0x000EEC68
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D12 RID: 19730 RVA: 0x000F08AA File Offset: 0x000EECAA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001514 RID: 5396
		// (get) Token: 0x06004D13 RID: 19731 RVA: 0x000F08B8 File Offset: 0x000EECB8
		public string Path
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004D14 RID: 19732 RVA: 0x000F08FA File Offset: 0x000EECFA
		public ArraySegment<byte>? GetPathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001515 RID: 5397
		// (get) Token: 0x06004D15 RID: 19733 RVA: 0x000F0908 File Offset: 0x000EED08
		public int Count
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-882410950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004D16 RID: 19734 RVA: 0x000F0952 File Offset: 0x000EED52
		public static Offset<SkillPreInfoTable> CreateSkillPreInfoTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset PathOffset = default(StringOffset), int Count = 0)
		{
			builder.StartObject(4);
			SkillPreInfoTable.AddCount(builder, Count);
			SkillPreInfoTable.AddPath(builder, PathOffset);
			SkillPreInfoTable.AddName(builder, NameOffset);
			SkillPreInfoTable.AddID(builder, ID);
			return SkillPreInfoTable.EndSkillPreInfoTable(builder);
		}

		// Token: 0x06004D17 RID: 19735 RVA: 0x000F097E File Offset: 0x000EED7E
		public static void StartSkillPreInfoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004D18 RID: 19736 RVA: 0x000F0987 File Offset: 0x000EED87
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004D19 RID: 19737 RVA: 0x000F0992 File Offset: 0x000EED92
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004D1A RID: 19738 RVA: 0x000F09A3 File Offset: 0x000EEDA3
		public static void AddPath(FlatBufferBuilder builder, StringOffset PathOffset)
		{
			builder.AddOffset(2, PathOffset.Value, 0);
		}

		// Token: 0x06004D1B RID: 19739 RVA: 0x000F09B4 File Offset: 0x000EEDB4
		public static void AddCount(FlatBufferBuilder builder, int Count)
		{
			builder.AddInt(3, Count, 0);
		}

		// Token: 0x06004D1C RID: 19740 RVA: 0x000F09C0 File Offset: 0x000EEDC0
		public static Offset<SkillPreInfoTable> EndSkillPreInfoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillPreInfoTable>(value);
		}

		// Token: 0x06004D1D RID: 19741 RVA: 0x000F09DA File Offset: 0x000EEDDA
		public static void FinishSkillPreInfoTableBuffer(FlatBufferBuilder builder, Offset<SkillPreInfoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B86 RID: 7046
		private Table __p = new Table();

		// Token: 0x020005C0 RID: 1472
		public enum eCrypt
		{
			// Token: 0x04001B88 RID: 7048
			code = -882410950
		}
	}
}

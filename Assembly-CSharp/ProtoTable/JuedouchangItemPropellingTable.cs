using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004CF RID: 1231
	public class JuedouchangItemPropellingTable : IFlatbufferObject
	{
		// Token: 0x17001008 RID: 4104
		// (get) Token: 0x06003DC7 RID: 15815 RVA: 0x000CD070 File Offset: 0x000CB470
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003DC8 RID: 15816 RVA: 0x000CD07D File Offset: 0x000CB47D
		public static JuedouchangItemPropellingTable GetRootAsJuedouchangItemPropellingTable(ByteBuffer _bb)
		{
			return JuedouchangItemPropellingTable.GetRootAsJuedouchangItemPropellingTable(_bb, new JuedouchangItemPropellingTable());
		}

		// Token: 0x06003DC9 RID: 15817 RVA: 0x000CD08A File Offset: 0x000CB48A
		public static JuedouchangItemPropellingTable GetRootAsJuedouchangItemPropellingTable(ByteBuffer _bb, JuedouchangItemPropellingTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003DCA RID: 15818 RVA: 0x000CD0A6 File Offset: 0x000CB4A6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003DCB RID: 15819 RVA: 0x000CD0C0 File Offset: 0x000CB4C0
		public JuedouchangItemPropellingTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001009 RID: 4105
		// (get) Token: 0x06003DCC RID: 15820 RVA: 0x000CD0CC File Offset: 0x000CB4CC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1702050784 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700100A RID: 4106
		// (get) Token: 0x06003DCD RID: 15821 RVA: 0x000CD118 File Offset: 0x000CB518
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003DCE RID: 15822 RVA: 0x000CD15A File Offset: 0x000CB55A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700100B RID: 4107
		// (get) Token: 0x06003DCF RID: 15823 RVA: 0x000CD168 File Offset: 0x000CB568
		public int NeedMinLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1702050784 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700100C RID: 4108
		// (get) Token: 0x06003DD0 RID: 15824 RVA: 0x000CD1B4 File Offset: 0x000CB5B4
		public int NeedMaxLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1702050784 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700100D RID: 4109
		// (get) Token: 0x06003DD1 RID: 15825 RVA: 0x000CD200 File Offset: 0x000CB600
		public int ItemLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1702050784 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003DD2 RID: 15826 RVA: 0x000CD24A File Offset: 0x000CB64A
		public static Offset<JuedouchangItemPropellingTable> CreateJuedouchangItemPropellingTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int NeedMinLevel = 0, int NeedMaxLevel = 0, int ItemLevel = 0)
		{
			builder.StartObject(5);
			JuedouchangItemPropellingTable.AddItemLevel(builder, ItemLevel);
			JuedouchangItemPropellingTable.AddNeedMaxLevel(builder, NeedMaxLevel);
			JuedouchangItemPropellingTable.AddNeedMinLevel(builder, NeedMinLevel);
			JuedouchangItemPropellingTable.AddName(builder, NameOffset);
			JuedouchangItemPropellingTable.AddID(builder, ID);
			return JuedouchangItemPropellingTable.EndJuedouchangItemPropellingTable(builder);
		}

		// Token: 0x06003DD3 RID: 15827 RVA: 0x000CD27E File Offset: 0x000CB67E
		public static void StartJuedouchangItemPropellingTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06003DD4 RID: 15828 RVA: 0x000CD287 File Offset: 0x000CB687
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003DD5 RID: 15829 RVA: 0x000CD292 File Offset: 0x000CB692
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003DD6 RID: 15830 RVA: 0x000CD2A3 File Offset: 0x000CB6A3
		public static void AddNeedMinLevel(FlatBufferBuilder builder, int NeedMinLevel)
		{
			builder.AddInt(2, NeedMinLevel, 0);
		}

		// Token: 0x06003DD7 RID: 15831 RVA: 0x000CD2AE File Offset: 0x000CB6AE
		public static void AddNeedMaxLevel(FlatBufferBuilder builder, int NeedMaxLevel)
		{
			builder.AddInt(3, NeedMaxLevel, 0);
		}

		// Token: 0x06003DD8 RID: 15832 RVA: 0x000CD2B9 File Offset: 0x000CB6B9
		public static void AddItemLevel(FlatBufferBuilder builder, int ItemLevel)
		{
			builder.AddInt(4, ItemLevel, 0);
		}

		// Token: 0x06003DD9 RID: 15833 RVA: 0x000CD2C4 File Offset: 0x000CB6C4
		public static Offset<JuedouchangItemPropellingTable> EndJuedouchangItemPropellingTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<JuedouchangItemPropellingTable>(value);
		}

		// Token: 0x06003DDA RID: 15834 RVA: 0x000CD2DE File Offset: 0x000CB6DE
		public static void FinishJuedouchangItemPropellingTableBuffer(FlatBufferBuilder builder, Offset<JuedouchangItemPropellingTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017D6 RID: 6102
		private Table __p = new Table();

		// Token: 0x020004D0 RID: 1232
		public enum eCrypt
		{
			// Token: 0x040017D8 RID: 6104
			code = -1702050784
		}
	}
}

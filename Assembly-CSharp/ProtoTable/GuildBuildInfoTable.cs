using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000465 RID: 1125
	public class GuildBuildInfoTable : IFlatbufferObject
	{
		// Token: 0x17000D7B RID: 3451
		// (get) Token: 0x06003609 RID: 13833 RVA: 0x000BA964 File Offset: 0x000B8D64
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600360A RID: 13834 RVA: 0x000BA971 File Offset: 0x000B8D71
		public static GuildBuildInfoTable GetRootAsGuildBuildInfoTable(ByteBuffer _bb)
		{
			return GuildBuildInfoTable.GetRootAsGuildBuildInfoTable(_bb, new GuildBuildInfoTable());
		}

		// Token: 0x0600360B RID: 13835 RVA: 0x000BA97E File Offset: 0x000B8D7E
		public static GuildBuildInfoTable GetRootAsGuildBuildInfoTable(ByteBuffer _bb, GuildBuildInfoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600360C RID: 13836 RVA: 0x000BA99A File Offset: 0x000B8D9A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600360D RID: 13837 RVA: 0x000BA9B4 File Offset: 0x000B8DB4
		public GuildBuildInfoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D7C RID: 3452
		// (get) Token: 0x0600360E RID: 13838 RVA: 0x000BA9C0 File Offset: 0x000B8DC0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1348486067 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D7D RID: 3453
		// (get) Token: 0x0600360F RID: 13839 RVA: 0x000BAA0C File Offset: 0x000B8E0C
		public int buildType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1348486067 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D7E RID: 3454
		// (get) Token: 0x06003610 RID: 13840 RVA: 0x000BAA58 File Offset: 0x000B8E58
		public string buildName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003611 RID: 13841 RVA: 0x000BAA9A File Offset: 0x000B8E9A
		public ArraySegment<byte>? GetBuildNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000D7F RID: 3455
		// (get) Token: 0x06003612 RID: 13842 RVA: 0x000BAAA8 File Offset: 0x000B8EA8
		public string buildIconPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003613 RID: 13843 RVA: 0x000BAAEB File Offset: 0x000B8EEB
		public ArraySegment<byte>? GetBuildIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000D80 RID: 3456
		// (get) Token: 0x06003614 RID: 13844 RVA: 0x000BAAFC File Offset: 0x000B8EFC
		public string buildNamePath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003615 RID: 13845 RVA: 0x000BAB3F File Offset: 0x000B8F3F
		public ArraySegment<byte>? GetBuildNamePathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000D81 RID: 3457
		// (get) Token: 0x06003616 RID: 13846 RVA: 0x000BAB50 File Offset: 0x000B8F50
		public string buildDesc
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003617 RID: 13847 RVA: 0x000BAB93 File Offset: 0x000B8F93
		public ArraySegment<byte>? GetBuildDescBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000D82 RID: 3458
		// (get) Token: 0x06003618 RID: 13848 RVA: 0x000BABA4 File Offset: 0x000B8FA4
		public bool isOpen
		{
			get
			{
				int num = this.__p.__offset(16);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x000BABF0 File Offset: 0x000B8FF0
		public static Offset<GuildBuildInfoTable> CreateGuildBuildInfoTable(FlatBufferBuilder builder, int ID = 0, int buildType = 0, StringOffset buildNameOffset = default(StringOffset), StringOffset buildIconPathOffset = default(StringOffset), StringOffset buildNamePathOffset = default(StringOffset), StringOffset buildDescOffset = default(StringOffset), bool isOpen = false)
		{
			builder.StartObject(7);
			GuildBuildInfoTable.AddBuildDesc(builder, buildDescOffset);
			GuildBuildInfoTable.AddBuildNamePath(builder, buildNamePathOffset);
			GuildBuildInfoTable.AddBuildIconPath(builder, buildIconPathOffset);
			GuildBuildInfoTable.AddBuildName(builder, buildNameOffset);
			GuildBuildInfoTable.AddBuildType(builder, buildType);
			GuildBuildInfoTable.AddID(builder, ID);
			GuildBuildInfoTable.AddIsOpen(builder, isOpen);
			return GuildBuildInfoTable.EndGuildBuildInfoTable(builder);
		}

		// Token: 0x0600361A RID: 13850 RVA: 0x000BAC3F File Offset: 0x000B903F
		public static void StartGuildBuildInfoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600361B RID: 13851 RVA: 0x000BAC48 File Offset: 0x000B9048
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600361C RID: 13852 RVA: 0x000BAC53 File Offset: 0x000B9053
		public static void AddBuildType(FlatBufferBuilder builder, int buildType)
		{
			builder.AddInt(1, buildType, 0);
		}

		// Token: 0x0600361D RID: 13853 RVA: 0x000BAC5E File Offset: 0x000B905E
		public static void AddBuildName(FlatBufferBuilder builder, StringOffset buildNameOffset)
		{
			builder.AddOffset(2, buildNameOffset.Value, 0);
		}

		// Token: 0x0600361E RID: 13854 RVA: 0x000BAC6F File Offset: 0x000B906F
		public static void AddBuildIconPath(FlatBufferBuilder builder, StringOffset buildIconPathOffset)
		{
			builder.AddOffset(3, buildIconPathOffset.Value, 0);
		}

		// Token: 0x0600361F RID: 13855 RVA: 0x000BAC80 File Offset: 0x000B9080
		public static void AddBuildNamePath(FlatBufferBuilder builder, StringOffset buildNamePathOffset)
		{
			builder.AddOffset(4, buildNamePathOffset.Value, 0);
		}

		// Token: 0x06003620 RID: 13856 RVA: 0x000BAC91 File Offset: 0x000B9091
		public static void AddBuildDesc(FlatBufferBuilder builder, StringOffset buildDescOffset)
		{
			builder.AddOffset(5, buildDescOffset.Value, 0);
		}

		// Token: 0x06003621 RID: 13857 RVA: 0x000BACA2 File Offset: 0x000B90A2
		public static void AddIsOpen(FlatBufferBuilder builder, bool isOpen)
		{
			builder.AddBool(6, isOpen, false);
		}

		// Token: 0x06003622 RID: 13858 RVA: 0x000BACB0 File Offset: 0x000B90B0
		public static Offset<GuildBuildInfoTable> EndGuildBuildInfoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildBuildInfoTable>(value);
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x000BACCA File Offset: 0x000B90CA
		public static void FinishGuildBuildInfoTableBuffer(FlatBufferBuilder builder, Offset<GuildBuildInfoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015AB RID: 5547
		private Table __p = new Table();

		// Token: 0x02000466 RID: 1126
		public enum eCrypt
		{
			// Token: 0x040015AD RID: 5549
			code = -1348486067
		}
	}
}

using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000309 RID: 777
	public class ChannelNameSwitch : IFlatbufferObject
	{
		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06001EA5 RID: 7845 RVA: 0x0008272C File Offset: 0x00080B2C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001EA6 RID: 7846 RVA: 0x00082739 File Offset: 0x00080B39
		public static ChannelNameSwitch GetRootAsChannelNameSwitch(ByteBuffer _bb)
		{
			return ChannelNameSwitch.GetRootAsChannelNameSwitch(_bb, new ChannelNameSwitch());
		}

		// Token: 0x06001EA7 RID: 7847 RVA: 0x00082746 File Offset: 0x00080B46
		public static ChannelNameSwitch GetRootAsChannelNameSwitch(ByteBuffer _bb, ChannelNameSwitch obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001EA8 RID: 7848 RVA: 0x00082762 File Offset: 0x00080B62
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001EA9 RID: 7849 RVA: 0x0008277C File Offset: 0x00080B7C
		public ChannelNameSwitch __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06001EAA RID: 7850 RVA: 0x00082788 File Offset: 0x00080B88
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1972744578 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06001EAB RID: 7851 RVA: 0x000827D4 File Offset: 0x00080BD4
		public string EnglishName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001EAC RID: 7852 RVA: 0x00082816 File Offset: 0x00080C16
		public ArraySegment<byte>? GetEnglishNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06001EAD RID: 7853 RVA: 0x00082824 File Offset: 0x00080C24
		public string ChineseName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001EAE RID: 7854 RVA: 0x00082866 File Offset: 0x00080C66
		public ArraySegment<byte>? GetChineseNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001EAF RID: 7855 RVA: 0x00082874 File Offset: 0x00080C74
		public static Offset<ChannelNameSwitch> CreateChannelNameSwitch(FlatBufferBuilder builder, int ID = 0, StringOffset EnglishNameOffset = default(StringOffset), StringOffset ChineseNameOffset = default(StringOffset))
		{
			builder.StartObject(3);
			ChannelNameSwitch.AddChineseName(builder, ChineseNameOffset);
			ChannelNameSwitch.AddEnglishName(builder, EnglishNameOffset);
			ChannelNameSwitch.AddID(builder, ID);
			return ChannelNameSwitch.EndChannelNameSwitch(builder);
		}

		// Token: 0x06001EB0 RID: 7856 RVA: 0x00082898 File Offset: 0x00080C98
		public static void StartChannelNameSwitch(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001EB1 RID: 7857 RVA: 0x000828A1 File Offset: 0x00080CA1
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001EB2 RID: 7858 RVA: 0x000828AC File Offset: 0x00080CAC
		public static void AddEnglishName(FlatBufferBuilder builder, StringOffset EnglishNameOffset)
		{
			builder.AddOffset(1, EnglishNameOffset.Value, 0);
		}

		// Token: 0x06001EB3 RID: 7859 RVA: 0x000828BD File Offset: 0x00080CBD
		public static void AddChineseName(FlatBufferBuilder builder, StringOffset ChineseNameOffset)
		{
			builder.AddOffset(2, ChineseNameOffset.Value, 0);
		}

		// Token: 0x06001EB4 RID: 7860 RVA: 0x000828D0 File Offset: 0x00080CD0
		public static Offset<ChannelNameSwitch> EndChannelNameSwitch(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChannelNameSwitch>(value);
		}

		// Token: 0x06001EB5 RID: 7861 RVA: 0x000828EA File Offset: 0x00080CEA
		public static void FinishChannelNameSwitchBuffer(FlatBufferBuilder builder, Offset<ChannelNameSwitch> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F42 RID: 3906
		private Table __p = new Table();

		// Token: 0x0200030A RID: 778
		public enum eCrypt
		{
			// Token: 0x04000F44 RID: 3908
			code = -1972744578
		}
	}
}

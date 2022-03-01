using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000376 RID: 886
	public class DefaultAdminServerTable : IFlatbufferObject
	{
		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x060025E4 RID: 9700 RVA: 0x00094328 File Offset: 0x00092728
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060025E5 RID: 9701 RVA: 0x00094335 File Offset: 0x00092735
		public static DefaultAdminServerTable GetRootAsDefaultAdminServerTable(ByteBuffer _bb)
		{
			return DefaultAdminServerTable.GetRootAsDefaultAdminServerTable(_bb, new DefaultAdminServerTable());
		}

		// Token: 0x060025E6 RID: 9702 RVA: 0x00094342 File Offset: 0x00092742
		public static DefaultAdminServerTable GetRootAsDefaultAdminServerTable(ByteBuffer _bb, DefaultAdminServerTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060025E7 RID: 9703 RVA: 0x0009435E File Offset: 0x0009275E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060025E8 RID: 9704 RVA: 0x00094378 File Offset: 0x00092778
		public DefaultAdminServerTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x060025E9 RID: 9705 RVA: 0x00094384 File Offset: 0x00092784
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1051300737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x060025EA RID: 9706 RVA: 0x000943D0 File Offset: 0x000927D0
		public string ServerID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060025EB RID: 9707 RVA: 0x00094412 File Offset: 0x00092812
		public ArraySegment<byte>? GetServerIDBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x060025EC RID: 9708 RVA: 0x00094420 File Offset: 0x00092820
		public string ServerIP
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060025ED RID: 9709 RVA: 0x00094462 File Offset: 0x00092862
		public ArraySegment<byte>? GetServerIPBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x060025EE RID: 9710 RVA: 0x00094470 File Offset: 0x00092870
		public string ServerName
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060025EF RID: 9711 RVA: 0x000944B3 File Offset: 0x000928B3
		public ArraySegment<byte>? GetServerNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x060025F0 RID: 9712 RVA: 0x000944C4 File Offset: 0x000928C4
		public int ServerPort
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1051300737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x060025F1 RID: 9713 RVA: 0x00094510 File Offset: 0x00092910
		public int ServerStaus
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1051300737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060025F2 RID: 9714 RVA: 0x0009455A File Offset: 0x0009295A
		public static Offset<DefaultAdminServerTable> CreateDefaultAdminServerTable(FlatBufferBuilder builder, int ID = 0, StringOffset ServerIDOffset = default(StringOffset), StringOffset ServerIPOffset = default(StringOffset), StringOffset ServerNameOffset = default(StringOffset), int ServerPort = 0, int ServerStaus = 0)
		{
			builder.StartObject(6);
			DefaultAdminServerTable.AddServerStaus(builder, ServerStaus);
			DefaultAdminServerTable.AddServerPort(builder, ServerPort);
			DefaultAdminServerTable.AddServerName(builder, ServerNameOffset);
			DefaultAdminServerTable.AddServerIP(builder, ServerIPOffset);
			DefaultAdminServerTable.AddServerID(builder, ServerIDOffset);
			DefaultAdminServerTable.AddID(builder, ID);
			return DefaultAdminServerTable.EndDefaultAdminServerTable(builder);
		}

		// Token: 0x060025F3 RID: 9715 RVA: 0x00094596 File Offset: 0x00092996
		public static void StartDefaultAdminServerTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x060025F4 RID: 9716 RVA: 0x0009459F File Offset: 0x0009299F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060025F5 RID: 9717 RVA: 0x000945AA File Offset: 0x000929AA
		public static void AddServerID(FlatBufferBuilder builder, StringOffset ServerIDOffset)
		{
			builder.AddOffset(1, ServerIDOffset.Value, 0);
		}

		// Token: 0x060025F6 RID: 9718 RVA: 0x000945BB File Offset: 0x000929BB
		public static void AddServerIP(FlatBufferBuilder builder, StringOffset ServerIPOffset)
		{
			builder.AddOffset(2, ServerIPOffset.Value, 0);
		}

		// Token: 0x060025F7 RID: 9719 RVA: 0x000945CC File Offset: 0x000929CC
		public static void AddServerName(FlatBufferBuilder builder, StringOffset ServerNameOffset)
		{
			builder.AddOffset(3, ServerNameOffset.Value, 0);
		}

		// Token: 0x060025F8 RID: 9720 RVA: 0x000945DD File Offset: 0x000929DD
		public static void AddServerPort(FlatBufferBuilder builder, int ServerPort)
		{
			builder.AddInt(4, ServerPort, 0);
		}

		// Token: 0x060025F9 RID: 9721 RVA: 0x000945E8 File Offset: 0x000929E8
		public static void AddServerStaus(FlatBufferBuilder builder, int ServerStaus)
		{
			builder.AddInt(5, ServerStaus, 0);
		}

		// Token: 0x060025FA RID: 9722 RVA: 0x000945F4 File Offset: 0x000929F4
		public static Offset<DefaultAdminServerTable> EndDefaultAdminServerTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DefaultAdminServerTable>(value);
		}

		// Token: 0x060025FB RID: 9723 RVA: 0x0009460E File Offset: 0x00092A0E
		public static void FinishDefaultAdminServerTableBuffer(FlatBufferBuilder builder, Offset<DefaultAdminServerTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001188 RID: 4488
		private Table __p = new Table();

		// Token: 0x02000377 RID: 887
		public enum eCrypt
		{
			// Token: 0x0400118A RID: 4490
			code = -1051300737
		}
	}
}

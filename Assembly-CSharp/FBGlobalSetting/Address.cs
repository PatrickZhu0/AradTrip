using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000126 RID: 294
	public sealed class Address : Table
	{
		// Token: 0x060006DA RID: 1754 RVA: 0x000284E2 File Offset: 0x000268E2
		public static Address GetRootAsAddress(ByteBuffer _bb)
		{
			return Address.GetRootAsAddress(_bb, new Address());
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x000284EF File Offset: 0x000268EF
		public static Address GetRootAsAddress(ByteBuffer _bb, Address obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0002850B File Offset: 0x0002690B
		public Address __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0002851C File Offset: 0x0002691C
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x0002854C File Offset: 0x0002694C
		public string Ip
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0002857C File Offset: 0x0002697C
		public ushort Port
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetUshort(num + this.bb_pos);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060006E0 RID: 1760 RVA: 0x000285B0 File Offset: 0x000269B0
		public uint Id
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0U : this.bb.GetUint(num + this.bb_pos);
			}
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x000285E5 File Offset: 0x000269E5
		public static Offset<Address> CreateAddress(FlatBufferBuilder builder, StringOffset name = default(StringOffset), StringOffset ip = default(StringOffset), ushort port = 0, uint id = 0U)
		{
			builder.StartObject(4);
			Address.AddId(builder, id);
			Address.AddIp(builder, ip);
			Address.AddName(builder, name);
			Address.AddPort(builder, port);
			return Address.EndAddress(builder);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00028611 File Offset: 0x00026A11
		public static void StartAddress(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0002861A File Offset: 0x00026A1A
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0002862B File Offset: 0x00026A2B
		public static void AddIp(FlatBufferBuilder builder, StringOffset ipOffset)
		{
			builder.AddOffset(1, ipOffset.Value, 0);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0002863C File Offset: 0x00026A3C
		public static void AddPort(FlatBufferBuilder builder, ushort port)
		{
			builder.AddUshort(2, port, 0);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00028647 File Offset: 0x00026A47
		public static void AddId(FlatBufferBuilder builder, uint id)
		{
			builder.AddUint(3, id, 0U);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00028654 File Offset: 0x00026A54
		public static Offset<Address> EndAddress(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<Address>(value);
		}
	}
}

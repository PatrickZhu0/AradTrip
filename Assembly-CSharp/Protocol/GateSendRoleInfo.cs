using System;

namespace Protocol
{
	// Token: 0x020009C0 RID: 2496
	[Protocol]
	public class GateSendRoleInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FE8 RID: 28648 RVA: 0x00144298 File Offset: 0x00142698
		public uint GetMsgID()
		{
			return 300301U;
		}

		// Token: 0x06006FE9 RID: 28649 RVA: 0x0014429F File Offset: 0x0014269F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FEA RID: 28650 RVA: 0x001442A7 File Offset: 0x001426A7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FEB RID: 28651 RVA: 0x001442B0 File Offset: 0x001426B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roles.Length);
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.appointmentOccus.Length);
			for (int j = 0; j < this.appointmentOccus.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.appointmentOccus[j]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.appointmentRoleNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.baseRoleField);
			BaseDLL.encode_uint32(buffer, ref pos_, this.extensibleRoleField);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unlockedExtensibleRoleField);
		}

		// Token: 0x06006FEC RID: 28652 RVA: 0x00144368 File Offset: 0x00142768
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roles = new RoleInfo[(int)num];
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i] = new RoleInfo();
				this.roles[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.appointmentOccus = new byte[(int)num2];
			for (int j = 0; j < this.appointmentOccus.Length; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.appointmentOccus[j]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.appointmentRoleNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.baseRoleField);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.extensibleRoleField);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unlockedExtensibleRoleField);
		}

		// Token: 0x06006FED RID: 28653 RVA: 0x00144440 File Offset: 0x00142840
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roles.Length);
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.appointmentOccus.Length);
			for (int j = 0; j < this.appointmentOccus.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.appointmentOccus[j]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.appointmentRoleNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.baseRoleField);
			BaseDLL.encode_uint32(buffer, ref pos_, this.extensibleRoleField);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unlockedExtensibleRoleField);
		}

		// Token: 0x06006FEE RID: 28654 RVA: 0x001444F8 File Offset: 0x001428F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roles = new RoleInfo[(int)num];
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i] = new RoleInfo();
				this.roles[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.appointmentOccus = new byte[(int)num2];
			for (int j = 0; j < this.appointmentOccus.Length; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.appointmentOccus[j]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.appointmentRoleNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.baseRoleField);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.extensibleRoleField);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unlockedExtensibleRoleField);
		}

		// Token: 0x06006FEF RID: 28655 RVA: 0x001445D0 File Offset: 0x001429D0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.roles.Length; i++)
			{
				num += this.roles[i].getLen();
			}
			num += 2 + this.appointmentOccus.Length;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040032FA RID: 13050
		public const uint MsgID = 300301U;

		// Token: 0x040032FB RID: 13051
		public uint Sequence;

		// Token: 0x040032FC RID: 13052
		public RoleInfo[] roles = new RoleInfo[0];

		// Token: 0x040032FD RID: 13053
		public byte[] appointmentOccus = new byte[0];

		// Token: 0x040032FE RID: 13054
		public uint appointmentRoleNum;

		// Token: 0x040032FF RID: 13055
		public uint baseRoleField;

		// Token: 0x04003300 RID: 13056
		public uint extensibleRoleField;

		// Token: 0x04003301 RID: 13057
		public uint unlockedExtensibleRoleField;
	}
}

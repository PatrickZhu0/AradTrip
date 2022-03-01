using System;

namespace behaviac
{
	// Token: 0x02002A75 RID: 10869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node20 : Condition
	{
		// Token: 0x06013E11 RID: 81425 RVA: 0x005F59EB File Offset: 0x005F3DEB
		public Condition_bt_Guanka_apc_guijian_sha_node20()
		{
			this.opl_p0 = 1506;
		}

		// Token: 0x06013E12 RID: 81426 RVA: 0x005F5A00 File Offset: 0x005F3E00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D885 RID: 55429
		private int opl_p0;
	}
}

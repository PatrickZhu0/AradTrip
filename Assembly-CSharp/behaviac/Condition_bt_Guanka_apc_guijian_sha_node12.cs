using System;

namespace behaviac
{
	// Token: 0x02002A71 RID: 10865
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node12 : Condition
	{
		// Token: 0x06013E09 RID: 81417 RVA: 0x005F56C7 File Offset: 0x005F3AC7
		public Condition_bt_Guanka_apc_guijian_sha_node12()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013E0A RID: 81418 RVA: 0x005F56DC File Offset: 0x005F3ADC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D87D RID: 55421
		private int opl_p0;
	}
}

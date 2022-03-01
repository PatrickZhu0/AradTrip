using System;

namespace behaviac
{
	// Token: 0x02002A41 RID: 10817
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node20 : Condition
	{
		// Token: 0x06013DAE RID: 81326 RVA: 0x005F2B93 File Offset: 0x005F0F93
		public Condition_bt_Guanka_apc_guijian_cha_node20()
		{
			this.opl_p0 = 1509;
		}

		// Token: 0x06013DAF RID: 81327 RVA: 0x005F2BA8 File Offset: 0x005F0FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D820 RID: 55328
		private int opl_p0;
	}
}

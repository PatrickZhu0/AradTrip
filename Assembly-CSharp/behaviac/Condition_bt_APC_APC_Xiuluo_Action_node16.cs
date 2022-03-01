using System;

namespace behaviac
{
	// Token: 0x02001E34 RID: 7732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node16 : Condition
	{
		// Token: 0x06012616 RID: 75286 RVA: 0x0055EBFF File Offset: 0x0055CFFF
		public Condition_bt_APC_APC_Xiuluo_Action_node16()
		{
			this.opl_p0 = 7113;
		}

		// Token: 0x06012617 RID: 75287 RVA: 0x0055EC14 File Offset: 0x0055D014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFFD RID: 49149
		private int opl_p0;
	}
}

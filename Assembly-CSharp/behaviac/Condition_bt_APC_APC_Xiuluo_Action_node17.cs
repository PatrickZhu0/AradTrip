using System;

namespace behaviac
{
	// Token: 0x02001E3D RID: 7741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node17 : Condition
	{
		// Token: 0x06012628 RID: 75304 RVA: 0x0055F3BB File Offset: 0x0055D7BB
		public Condition_bt_APC_APC_Xiuluo_Action_node17()
		{
			this.opl_p0 = 7112;
		}

		// Token: 0x06012629 RID: 75305 RVA: 0x0055F3D0 File Offset: 0x0055D7D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C010 RID: 49168
		private int opl_p0;
	}
}

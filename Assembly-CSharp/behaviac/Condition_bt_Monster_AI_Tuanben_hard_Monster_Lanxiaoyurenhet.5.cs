using System;

namespace behaviac
{
	// Token: 0x02003D2C RID: 15660
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node3 : Condition
	{
		// Token: 0x060161F2 RID: 90610 RVA: 0x006AFF32 File Offset: 0x006AE332
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node3()
		{
			this.opl_p0 = 21021;
		}

		// Token: 0x060161F3 RID: 90611 RVA: 0x006AFF48 File Offset: 0x006AE348
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA69 RID: 64105
		private int opl_p0;
	}
}

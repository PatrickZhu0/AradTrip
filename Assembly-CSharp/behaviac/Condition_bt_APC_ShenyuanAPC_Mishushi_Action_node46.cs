using System;

namespace behaviac
{
	// Token: 0x02001E9E RID: 7838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node46 : Condition
	{
		// Token: 0x060126E6 RID: 75494 RVA: 0x00563BD7 File Offset: 0x00561FD7
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node46()
		{
			this.opl_p0 = 9744;
		}

		// Token: 0x060126E7 RID: 75495 RVA: 0x00563BEC File Offset: 0x00561FEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0D4 RID: 49364
		private int opl_p0;
	}
}

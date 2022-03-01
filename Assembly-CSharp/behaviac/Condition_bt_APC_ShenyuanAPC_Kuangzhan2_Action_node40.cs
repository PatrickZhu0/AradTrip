using System;

namespace behaviac
{
	// Token: 0x02001E68 RID: 7784
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node40 : Condition
	{
		// Token: 0x0601267C RID: 75388 RVA: 0x005618A3 File Offset: 0x0055FCA3
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node40()
		{
			this.opl_p0 = 9716;
		}

		// Token: 0x0601267D RID: 75389 RVA: 0x005618B8 File Offset: 0x0055FCB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C065 RID: 49253
		private int opl_p0;
	}
}

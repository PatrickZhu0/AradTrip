using System;

namespace behaviac
{
	// Token: 0x02001D8C RID: 7564
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node74 : Condition
	{
		// Token: 0x060124D3 RID: 74963 RVA: 0x005573DB File Offset: 0x005557DB
		public Condition_bt_APC_APC_Kuangzhan2_Action_node74()
		{
			this.opl_p0 = 9719;
		}

		// Token: 0x060124D4 RID: 74964 RVA: 0x005573F0 File Offset: 0x005557F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEBF RID: 48831
		private int opl_p0;
	}
}

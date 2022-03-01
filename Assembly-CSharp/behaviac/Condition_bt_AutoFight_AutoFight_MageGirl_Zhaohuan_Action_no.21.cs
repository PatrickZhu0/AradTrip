using System;

namespace behaviac
{
	// Token: 0x02002764 RID: 10084
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node28 : Condition
	{
		// Token: 0x06013809 RID: 79881 RVA: 0x005CFF2D File Offset: 0x005CE32D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node28()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601380A RID: 79882 RVA: 0x005CFF40 File Offset: 0x005CE340
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D26B RID: 53867
		private float opl_p0;
	}
}

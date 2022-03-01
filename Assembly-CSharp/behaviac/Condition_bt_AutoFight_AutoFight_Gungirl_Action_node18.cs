using System;

namespace behaviac
{
	// Token: 0x020024AB RID: 9387
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node18 : Condition
	{
		// Token: 0x060132A1 RID: 78497 RVA: 0x005B03A5 File Offset: 0x005AE7A5
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node18()
		{
			this.opl_p0 = 2508;
		}

		// Token: 0x060132A2 RID: 78498 RVA: 0x005B03B8 File Offset: 0x005AE7B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCBC RID: 52412
		private int opl_p0;
	}
}

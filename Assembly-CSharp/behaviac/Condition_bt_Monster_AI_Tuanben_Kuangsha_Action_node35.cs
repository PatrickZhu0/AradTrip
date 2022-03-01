using System;

namespace behaviac
{
	// Token: 0x02003ABA RID: 15034
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node35 : Condition
	{
		// Token: 0x06015D33 RID: 89395 RVA: 0x006983FE File Offset: 0x006967FE
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node35()
		{
			this.opl_p0 = 21034;
		}

		// Token: 0x06015D34 RID: 89396 RVA: 0x00698414 File Offset: 0x00696814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F64F RID: 63055
		private int opl_p0;
	}
}

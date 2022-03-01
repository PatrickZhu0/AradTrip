using System;

namespace behaviac
{
	// Token: 0x02003ADA RID: 15066
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node31 : Condition
	{
		// Token: 0x06015D73 RID: 89459 RVA: 0x00698ED1 File Offset: 0x006972D1
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node31()
		{
			this.opl_p0 = 21033;
		}

		// Token: 0x06015D74 RID: 89460 RVA: 0x00698EE4 File Offset: 0x006972E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F683 RID: 63107
		private int opl_p0;
	}
}

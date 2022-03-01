using System;

namespace behaviac
{
	// Token: 0x02003ADF RID: 15071
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node47 : Condition
	{
		// Token: 0x06015D7D RID: 89469 RVA: 0x006990E5 File Offset: 0x006974E5
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node47()
		{
			this.opl_p0 = 21029;
		}

		// Token: 0x06015D7E RID: 89470 RVA: 0x006990F8 File Offset: 0x006974F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F68E RID: 63118
		private int opl_p0;
	}
}

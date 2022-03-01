using System;

namespace behaviac
{
	// Token: 0x02003AD5 RID: 15061
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node24 : Condition
	{
		// Token: 0x06015D69 RID: 89449 RVA: 0x00698CBD File Offset: 0x006970BD
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node24()
		{
			this.opl_p0 = 21031;
		}

		// Token: 0x06015D6A RID: 89450 RVA: 0x00698CD0 File Offset: 0x006970D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F678 RID: 63096
		private int opl_p0;
	}
}

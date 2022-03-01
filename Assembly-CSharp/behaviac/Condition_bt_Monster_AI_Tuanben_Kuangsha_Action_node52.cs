using System;

namespace behaviac
{
	// Token: 0x02003AD0 RID: 15056
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node52 : Condition
	{
		// Token: 0x06015D5F RID: 89439 RVA: 0x00698AA9 File Offset: 0x00696EA9
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node52()
		{
			this.opl_p0 = 21030;
		}

		// Token: 0x06015D60 RID: 89440 RVA: 0x00698ABC File Offset: 0x00696EBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F66D RID: 63085
		private int opl_p0;
	}
}

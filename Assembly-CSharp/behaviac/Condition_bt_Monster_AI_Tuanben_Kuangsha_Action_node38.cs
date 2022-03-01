using System;

namespace behaviac
{
	// Token: 0x02003AC3 RID: 15043
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node38 : Condition
	{
		// Token: 0x06015D45 RID: 89413 RVA: 0x00698665 File Offset: 0x00696A65
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node38()
		{
			this.opl_p0 = 21401;
		}

		// Token: 0x06015D46 RID: 89414 RVA: 0x00698678 File Offset: 0x00696A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F658 RID: 63064
		private int opl_p0;
	}
}

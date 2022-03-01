using System;

namespace behaviac
{
	// Token: 0x02003654 RID: 13908
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node4 : Condition
	{
		// Token: 0x060154CA RID: 87242 RVA: 0x0066C49F File Offset: 0x0066A89F
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node4()
		{
			this.opl_p0 = 5428;
		}

		// Token: 0x060154CB RID: 87243 RVA: 0x0066C4B4 File Offset: 0x0066A8B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE82 RID: 61058
		private int opl_p0;
	}
}

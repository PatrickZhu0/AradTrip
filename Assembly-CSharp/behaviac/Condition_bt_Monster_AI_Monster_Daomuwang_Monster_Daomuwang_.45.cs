using System;

namespace behaviac
{
	// Token: 0x02003658 RID: 13912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node14 : Condition
	{
		// Token: 0x060154D2 RID: 87250 RVA: 0x0066C653 File Offset: 0x0066AA53
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node14()
		{
			this.opl_p0 = 5661;
		}

		// Token: 0x060154D3 RID: 87251 RVA: 0x0066C668 File Offset: 0x0066AA68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE8A RID: 61066
		private int opl_p0;
	}
}

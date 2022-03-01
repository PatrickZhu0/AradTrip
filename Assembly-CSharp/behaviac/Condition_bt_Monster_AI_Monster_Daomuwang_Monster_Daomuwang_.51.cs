using System;

namespace behaviac
{
	// Token: 0x02003660 RID: 13920
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node19 : Condition
	{
		// Token: 0x060154E2 RID: 87266 RVA: 0x0066C9BB File Offset: 0x0066ADBB
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node19()
		{
			this.opl_p0 = 5426;
		}

		// Token: 0x060154E3 RID: 87267 RVA: 0x0066C9D0 File Offset: 0x0066ADD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE9A RID: 61082
		private int opl_p0;
	}
}

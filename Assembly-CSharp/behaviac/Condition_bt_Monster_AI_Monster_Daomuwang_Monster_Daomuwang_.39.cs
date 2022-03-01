using System;

namespace behaviac
{
	// Token: 0x02003650 RID: 13904
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node29 : Condition
	{
		// Token: 0x060154C2 RID: 87234 RVA: 0x0066C2EB File Offset: 0x0066A6EB
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node29()
		{
			this.opl_p0 = 5430;
		}

		// Token: 0x060154C3 RID: 87235 RVA: 0x0066C300 File Offset: 0x0066A700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE7A RID: 61050
		private int opl_p0;
	}
}

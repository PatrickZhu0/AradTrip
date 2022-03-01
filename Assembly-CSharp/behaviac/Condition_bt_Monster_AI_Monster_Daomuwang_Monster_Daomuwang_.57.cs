using System;

namespace behaviac
{
	// Token: 0x02003669 RID: 13929
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node29 : Condition
	{
		// Token: 0x060154F3 RID: 87283 RVA: 0x0066D4B7 File Offset: 0x0066B8B7
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node29()
		{
			this.opl_p0 = 5430;
		}

		// Token: 0x060154F4 RID: 87284 RVA: 0x0066D4CC File Offset: 0x0066B8CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEAA RID: 61098
		private int opl_p0;
	}
}

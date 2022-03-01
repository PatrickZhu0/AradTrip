using System;

namespace behaviac
{
	// Token: 0x02003671 RID: 13937
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node14 : Condition
	{
		// Token: 0x06015503 RID: 87299 RVA: 0x0066D81F File Offset: 0x0066BC1F
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node14()
		{
			this.opl_p0 = 5660;
		}

		// Token: 0x06015504 RID: 87300 RVA: 0x0066D834 File Offset: 0x0066BC34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEBA RID: 61114
		private int opl_p0;
	}
}

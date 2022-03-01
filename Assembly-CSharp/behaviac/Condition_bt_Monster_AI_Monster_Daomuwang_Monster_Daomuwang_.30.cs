using System;

namespace behaviac
{
	// Token: 0x02003643 RID: 13891
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node9 : Condition
	{
		// Token: 0x060154A9 RID: 87209 RVA: 0x0066B63B File Offset: 0x00669A3B
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node9()
		{
			this.opl_p0 = 5425;
		}

		// Token: 0x060154AA RID: 87210 RVA: 0x0066B650 File Offset: 0x00669A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE62 RID: 61026
		private int opl_p0;
	}
}

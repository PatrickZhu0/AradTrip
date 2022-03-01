using System;

namespace behaviac
{
	// Token: 0x0200362A RID: 13866
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node9 : Condition
	{
		// Token: 0x06015478 RID: 87160 RVA: 0x0066A46F File Offset: 0x0066886F
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node9()
		{
			this.opl_p0 = 5425;
		}

		// Token: 0x06015479 RID: 87161 RVA: 0x0066A484 File Offset: 0x00668884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE32 RID: 60978
		private int opl_p0;
	}
}

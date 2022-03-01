using System;

namespace behaviac
{
	// Token: 0x020034B5 RID: 13493
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node16 : Condition
	{
		// Token: 0x060151B0 RID: 86448 RVA: 0x0065C126 File Offset: 0x0065A526
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node16()
		{
			this.opl_p0 = 6206;
		}

		// Token: 0x060151B1 RID: 86449 RVA: 0x0065C13C File Offset: 0x0065A53C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAB9 RID: 60089
		private int opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003632 RID: 13874
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node24 : Condition
	{
		// Token: 0x06015488 RID: 87176 RVA: 0x0066A7D7 File Offset: 0x00668BD7
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node24()
		{
			this.opl_p0 = 5424;
		}

		// Token: 0x06015489 RID: 87177 RVA: 0x0066A7EC File Offset: 0x00668BEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE42 RID: 60994
		private int opl_p0;
	}
}

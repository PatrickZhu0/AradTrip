using System;

namespace behaviac
{
	// Token: 0x02003413 RID: 13331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node31 : Condition
	{
		// Token: 0x06015077 RID: 86135 RVA: 0x00655D29 File Offset: 0x00654129
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node31()
		{
			this.opl_p0 = 6222;
		}

		// Token: 0x06015078 RID: 86136 RVA: 0x00655D3C File Offset: 0x0065413C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E94F RID: 59727
		private int opl_p0;
	}
}

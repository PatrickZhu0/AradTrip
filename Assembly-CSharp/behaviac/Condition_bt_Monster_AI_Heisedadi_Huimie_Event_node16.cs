using System;

namespace behaviac
{
	// Token: 0x02003429 RID: 13353
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node16 : Condition
	{
		// Token: 0x060150A1 RID: 86177 RVA: 0x00656ABA File Offset: 0x00654EBA
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node16()
		{
			this.opl_p0 = 30960011;
		}

		// Token: 0x060150A2 RID: 86178 RVA: 0x00656AD0 File Offset: 0x00654ED0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E973 RID: 59763
		private int opl_p0;
	}
}

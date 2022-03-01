using System;

namespace behaviac
{
	// Token: 0x0200342C RID: 13356
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node55 : Condition
	{
		// Token: 0x060150A6 RID: 86182 RVA: 0x00656BD2 File Offset: 0x00654FD2
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node55()
		{
			this.opl_p0 = 30960011;
		}

		// Token: 0x060150A7 RID: 86183 RVA: 0x00656BE8 File Offset: 0x00654FE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E976 RID: 59766
		private int opl_p0;
	}
}

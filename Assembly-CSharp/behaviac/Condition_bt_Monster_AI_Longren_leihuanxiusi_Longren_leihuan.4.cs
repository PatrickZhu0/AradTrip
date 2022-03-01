using System;

namespace behaviac
{
	// Token: 0x02003596 RID: 13718
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node7 : Condition
	{
		// Token: 0x0601535C RID: 86876 RVA: 0x006648AB File Offset: 0x00662CAB
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node7()
		{
			this.opl_p0 = 5171;
		}

		// Token: 0x0601535D RID: 86877 RVA: 0x006648C0 File Offset: 0x00662CC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED24 RID: 60708
		private int opl_p0;
	}
}

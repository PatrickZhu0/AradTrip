using System;

namespace behaviac
{
	// Token: 0x020035E8 RID: 13800
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node26 : Condition
	{
		// Token: 0x060153F8 RID: 87032 RVA: 0x00667A43 File Offset: 0x00665E43
		public Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node26()
		{
			this.opl_p0 = 5417;
		}

		// Token: 0x060153F9 RID: 87033 RVA: 0x00667A58 File Offset: 0x00665E58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDB4 RID: 60852
		private int opl_p0;
	}
}

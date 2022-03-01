using System;

namespace behaviac
{
	// Token: 0x020035DE RID: 13790
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node9 : Condition
	{
		// Token: 0x060153E5 RID: 87013 RVA: 0x00667483 File Offset: 0x00665883
		public Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node9()
		{
			this.opl_p0 = 5417;
		}

		// Token: 0x060153E6 RID: 87014 RVA: 0x00667498 File Offset: 0x00665898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDA6 RID: 60838
		private int opl_p0;
	}
}

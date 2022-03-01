using System;

namespace behaviac
{
	// Token: 0x020035E2 RID: 13794
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node4 : Condition
	{
		// Token: 0x060153EC RID: 87020 RVA: 0x00667845 File Offset: 0x00665C45
		public Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node4()
		{
			this.opl_p0 = 5653;
		}

		// Token: 0x060153ED RID: 87021 RVA: 0x00667858 File Offset: 0x00665C58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDAD RID: 60845
		private int opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020035DA RID: 13786
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4 : Condition
	{
		// Token: 0x060153DD RID: 87005 RVA: 0x006672EB File Offset: 0x006656EB
		public Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node4()
		{
			this.opl_p0 = 5413;
		}

		// Token: 0x060153DE RID: 87006 RVA: 0x00667300 File Offset: 0x00665700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED9F RID: 60831
		private int opl_p0;
	}
}

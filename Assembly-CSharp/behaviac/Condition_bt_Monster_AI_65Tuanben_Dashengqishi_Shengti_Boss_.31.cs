using System;

namespace behaviac
{
	// Token: 0x02002E00 RID: 11776
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node96 : Condition
	{
		// Token: 0x060144DD RID: 83165 RVA: 0x006194AB File Offset: 0x006178AB
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node96()
		{
			this.opl_p0 = 21631;
		}

		// Token: 0x060144DE RID: 83166 RVA: 0x006194C0 File Offset: 0x006178C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE8B RID: 56971
		private int opl_p0;
	}
}

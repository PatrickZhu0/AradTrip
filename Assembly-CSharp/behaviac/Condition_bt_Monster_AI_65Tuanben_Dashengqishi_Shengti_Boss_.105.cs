using System;

namespace behaviac
{
	// Token: 0x02002E80 RID: 11904
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node168 : Condition
	{
		// Token: 0x060145DD RID: 83421 RVA: 0x0061C8D1 File Offset: 0x0061ACD1
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node168()
		{
			this.opl_p0 = 21625;
		}

		// Token: 0x060145DE RID: 83422 RVA: 0x0061C8E4 File Offset: 0x0061ACE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF6A RID: 57194
		private int opl_p0;
	}
}

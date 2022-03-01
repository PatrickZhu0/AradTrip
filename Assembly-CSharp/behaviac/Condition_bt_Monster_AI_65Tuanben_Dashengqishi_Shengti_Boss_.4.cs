using System;

namespace behaviac
{
	// Token: 0x02002DCF RID: 11727
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node40 : Condition
	{
		// Token: 0x0601447B RID: 83067 RVA: 0x0061815B File Offset: 0x0061655B
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node40()
		{
			this.opl_p0 = 21631;
		}

		// Token: 0x0601447C RID: 83068 RVA: 0x00618170 File Offset: 0x00616570
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE3A RID: 56890
		private int opl_p0;
	}
}

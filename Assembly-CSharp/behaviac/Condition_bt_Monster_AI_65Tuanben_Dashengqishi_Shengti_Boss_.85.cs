using System;

namespace behaviac
{
	// Token: 0x02002E62 RID: 11874
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node251 : Condition
	{
		// Token: 0x060145A1 RID: 83361 RVA: 0x0061BB35 File Offset: 0x00619F35
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node251()
		{
			this.opl_p0 = 21638;
		}

		// Token: 0x060145A2 RID: 83362 RVA: 0x0061BB48 File Offset: 0x00619F48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF2C RID: 57132
		private int opl_p0;
	}
}

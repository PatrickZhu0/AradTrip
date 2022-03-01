using System;

namespace behaviac
{
	// Token: 0x02002DAD RID: 11693
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node7 : Condition
	{
		// Token: 0x0601443B RID: 83003 RVA: 0x0061634D File Offset: 0x0061474D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node7()
		{
			this.opl_p0 = 21644;
		}

		// Token: 0x0601443C RID: 83004 RVA: 0x00616360 File Offset: 0x00614760
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE02 RID: 56834
		private int opl_p0;
	}
}

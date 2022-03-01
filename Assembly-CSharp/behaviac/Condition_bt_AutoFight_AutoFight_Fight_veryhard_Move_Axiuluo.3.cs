using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002477 RID: 9335
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node2 : Condition
	{
		// Token: 0x0601323C RID: 78396 RVA: 0x005AE39C File Offset: 0x005AC79C
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node2()
		{
			this.opl_p0 = new List<int>();
			this.opl_p0.Capacity = 2;
			int item = 1514;
			this.opl_p0.Add(item);
			int item2 = 1715;
			this.opl_p0.Add(item2);
		}

		// Token: 0x0601323D RID: 78397 RVA: 0x005AE3EC File Offset: 0x005AC7EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillInCD(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC5B RID: 52315
		private List<int> opl_p0;
	}
}

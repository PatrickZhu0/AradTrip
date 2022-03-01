using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200247B RID: 9339
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node1 : Condition
	{
		// Token: 0x06013244 RID: 78404 RVA: 0x005AE510 File Offset: 0x005AC910
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node1()
		{
			this.opl_p0 = new List<int>();
			this.opl_p0.Capacity = 2;
			int item = 1514;
			this.opl_p0.Add(item);
			int item2 = 1715;
			this.opl_p0.Add(item2);
		}

		// Token: 0x06013245 RID: 78405 RVA: 0x005AE560 File Offset: 0x005AC960
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillCanUse(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC62 RID: 52322
		private List<int> opl_p0;
	}
}

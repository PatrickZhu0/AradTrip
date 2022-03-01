using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002484 RID: 9348
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2 : Condition
	{
		// Token: 0x06013255 RID: 78421 RVA: 0x005AEB78 File Offset: 0x005ACF78
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2()
		{
			this.opl_p0 = new List<int>();
			this.opl_p0.Capacity = 3;
			int item = 1909;
			this.opl_p0.Add(item);
			int item2 = 1514;
			this.opl_p0.Add(item2);
			int item3 = 1503;
			this.opl_p0.Add(item3);
		}

		// Token: 0x06013256 RID: 78422 RVA: 0x005AEBD8 File Offset: 0x005ACFD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillInCD(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC72 RID: 52338
		private List<int> opl_p0;
	}
}

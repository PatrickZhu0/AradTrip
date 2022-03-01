using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002495 RID: 9365
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node1 : Condition
	{
		// Token: 0x06013276 RID: 78454 RVA: 0x005AF4F8 File Offset: 0x005AD8F8
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node1()
		{
			this.opl_p0 = new List<int>();
			this.opl_p0.Capacity = 3;
			int item = 1512;
			this.opl_p0.Add(item);
			int item2 = 1514;
			this.opl_p0.Add(item2);
			int item3 = 1503;
			this.opl_p0.Add(item3);
		}

		// Token: 0x06013277 RID: 78455 RVA: 0x005AF558 File Offset: 0x005AD958
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillCanUse(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC90 RID: 52368
		private List<int> opl_p0;
	}
}

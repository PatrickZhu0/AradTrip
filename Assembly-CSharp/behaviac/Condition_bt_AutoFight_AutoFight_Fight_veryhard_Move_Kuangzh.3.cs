using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002491 RID: 9361
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2 : Condition
	{
		// Token: 0x0601326E RID: 78446 RVA: 0x005AF374 File Offset: 0x005AD774
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2()
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

		// Token: 0x0601326F RID: 78447 RVA: 0x005AF3D4 File Offset: 0x005AD7D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillInCD(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC89 RID: 52361
		private List<int> opl_p0;
	}
}

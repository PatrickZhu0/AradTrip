using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002488 RID: 9352
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node1 : Condition
	{
		// Token: 0x0601325D RID: 78429 RVA: 0x005AECFC File Offset: 0x005AD0FC
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node1()
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

		// Token: 0x0601325E RID: 78430 RVA: 0x005AED5C File Offset: 0x005AD15C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillCanUse(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC79 RID: 52345
		private List<int> opl_p0;
	}
}

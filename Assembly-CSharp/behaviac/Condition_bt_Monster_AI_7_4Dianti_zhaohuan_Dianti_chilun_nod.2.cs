using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F29 RID: 12073
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node7 : Condition
	{
		// Token: 0x06014726 RID: 83750 RVA: 0x00626C3C File Offset: 0x0062503C
		public Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node7()
		{
			this.opl_p0 = new List<int>();
			this.opl_p0.Capacity = 1;
			int item = 20308;
			this.opl_p0.Add(item);
		}

		// Token: 0x06014727 RID: 83751 RVA: 0x00626C78 File Offset: 0x00625078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_AtLeastOneSkillInCD(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E09A RID: 57498
		private List<int> opl_p0;
	}
}

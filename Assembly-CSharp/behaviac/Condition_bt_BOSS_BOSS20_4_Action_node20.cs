using System;

namespace behaviac
{
	// Token: 0x020029F1 RID: 10737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node20 : Condition
	{
		// Token: 0x06013D15 RID: 81173 RVA: 0x005EE5F7 File Offset: 0x005EC9F7
		public Condition_bt_BOSS_BOSS20_4_Action_node20()
		{
			this.opl_p0 = 5051;
		}

		// Token: 0x06013D16 RID: 81174 RVA: 0x005EE60C File Offset: 0x005ECA0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D789 RID: 55177
		private int opl_p0;
	}
}

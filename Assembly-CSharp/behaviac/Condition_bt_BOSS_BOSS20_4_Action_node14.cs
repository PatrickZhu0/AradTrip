using System;

namespace behaviac
{
	// Token: 0x020029E0 RID: 10720
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node14 : Condition
	{
		// Token: 0x06013CF3 RID: 81139 RVA: 0x005EDEC3 File Offset: 0x005EC2C3
		public Condition_bt_BOSS_BOSS20_4_Action_node14()
		{
			this.opl_p0 = 5521;
		}

		// Token: 0x06013CF4 RID: 81140 RVA: 0x005EDED8 File Offset: 0x005EC2D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D766 RID: 55142
		private int opl_p0;
	}
}

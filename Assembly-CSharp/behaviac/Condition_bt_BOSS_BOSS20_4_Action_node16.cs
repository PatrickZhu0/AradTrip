using System;

namespace behaviac
{
	// Token: 0x020029ED RID: 10733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node16 : Condition
	{
		// Token: 0x06013D0D RID: 81165 RVA: 0x005EE443 File Offset: 0x005EC843
		public Condition_bt_BOSS_BOSS20_4_Action_node16()
		{
			this.opl_p0 = 5050;
		}

		// Token: 0x06013D0E RID: 81166 RVA: 0x005EE458 File Offset: 0x005EC858
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D781 RID: 55169
		private int opl_p0;
	}
}

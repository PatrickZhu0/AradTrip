using System;

namespace behaviac
{
	// Token: 0x02003CA6 RID: 15526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node65 : Condition
	{
		// Token: 0x060160F3 RID: 90355 RVA: 0x006AA2BD File Offset: 0x006A86BD
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node65()
		{
			this.opl_p0 = 21050;
		}

		// Token: 0x060160F4 RID: 90356 RVA: 0x006AA2D0 File Offset: 0x006A86D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F99A RID: 63898
		private int opl_p0;
	}
}

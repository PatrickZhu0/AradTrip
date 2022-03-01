using System;

namespace behaviac
{
	// Token: 0x02003C1B RID: 15387
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node35 : Condition
	{
		// Token: 0x06015FE1 RID: 90081 RVA: 0x006A509E File Offset: 0x006A349E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node35()
		{
			this.opl_p0 = 21066;
		}

		// Token: 0x06015FE2 RID: 90082 RVA: 0x006A50B4 File Offset: 0x006A34B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F85F RID: 63583
		private int opl_p0;
	}
}

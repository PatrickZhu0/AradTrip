using System;

namespace behaviac
{
	// Token: 0x02003D68 RID: 15720
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node49 : Condition
	{
		// Token: 0x06016266 RID: 90726 RVA: 0x006B160B File Offset: 0x006AFA0B
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node49()
		{
			this.opl_p0 = 21083;
		}

		// Token: 0x06016267 RID: 90727 RVA: 0x006B1620 File Offset: 0x006AFA20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAC0 RID: 64192
		private int opl_p0;
	}
}

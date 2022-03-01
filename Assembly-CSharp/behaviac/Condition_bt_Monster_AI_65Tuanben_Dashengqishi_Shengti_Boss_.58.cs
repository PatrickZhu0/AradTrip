using System;

namespace behaviac
{
	// Token: 0x02002E31 RID: 11825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node111 : Condition
	{
		// Token: 0x0601453F RID: 83263 RVA: 0x0061A7DF File Offset: 0x00618BDF
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node111()
		{
			this.opl_p0 = 21631;
		}

		// Token: 0x06014540 RID: 83264 RVA: 0x0061A7F4 File Offset: 0x00618BF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEDB RID: 57051
		private int opl_p0;
	}
}

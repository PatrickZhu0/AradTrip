using System;

namespace behaviac
{
	// Token: 0x02002F34 RID: 12084
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node5 : Condition
	{
		// Token: 0x06014739 RID: 83769 RVA: 0x006273C2 File Offset: 0x006257C2
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601473A RID: 83770 RVA: 0x006273F8 File Offset: 0x006257F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0A9 RID: 57513
		private int opl_p0;

		// Token: 0x0400E0AA RID: 57514
		private int opl_p1;

		// Token: 0x0400E0AB RID: 57515
		private int opl_p2;

		// Token: 0x0400E0AC RID: 57516
		private int opl_p3;
	}
}

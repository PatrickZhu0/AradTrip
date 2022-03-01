using System;

namespace behaviac
{
	// Token: 0x02003372 RID: 13170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node5 : Condition
	{
		// Token: 0x06014F42 RID: 85826 RVA: 0x0065029E File Offset: 0x0064E69E
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node5()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06014F43 RID: 85827 RVA: 0x006502C0 File Offset: 0x0064E6C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E809 RID: 59401
		private HMType opl_p0;

		// Token: 0x0400E80A RID: 59402
		private BE_Operation opl_p1;

		// Token: 0x0400E80B RID: 59403
		private float opl_p2;
	}
}

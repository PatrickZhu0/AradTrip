using System;

namespace behaviac
{
	// Token: 0x020026B7 RID: 9911
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node79 : Condition
	{
		// Token: 0x060136B1 RID: 79537 RVA: 0x005C8917 File Offset: 0x005C6D17
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node79()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x060136B2 RID: 79538 RVA: 0x005C8934 File Offset: 0x005C6D34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D106 RID: 53510
		private BE_Target opl_p0;

		// Token: 0x0400D107 RID: 53511
		private BE_Equal opl_p1;

		// Token: 0x0400D108 RID: 53512
		private BE_State opl_p2;
	}
}

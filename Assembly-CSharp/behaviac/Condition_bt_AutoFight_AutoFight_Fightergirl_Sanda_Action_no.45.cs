using System;

namespace behaviac
{
	// Token: 0x02001F5E RID: 8030
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node72 : Condition
	{
		// Token: 0x0601285F RID: 75871 RVA: 0x0056B853 File Offset: 0x00569C53
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node72()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012860 RID: 75872 RVA: 0x0056B870 File Offset: 0x00569C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C258 RID: 49752
		private BE_Target opl_p0;

		// Token: 0x0400C259 RID: 49753
		private BE_Equal opl_p1;

		// Token: 0x0400C25A RID: 49754
		private BE_State opl_p2;
	}
}

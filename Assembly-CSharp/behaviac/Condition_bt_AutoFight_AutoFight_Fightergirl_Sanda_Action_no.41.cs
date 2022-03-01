using System;

namespace behaviac
{
	// Token: 0x02001F59 RID: 8025
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node52 : Condition
	{
		// Token: 0x06012855 RID: 75861 RVA: 0x0056B63F File Offset: 0x00569A3F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012856 RID: 75862 RVA: 0x0056B65C File Offset: 0x00569A5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C24D RID: 49741
		private BE_Target opl_p0;

		// Token: 0x0400C24E RID: 49742
		private BE_Equal opl_p1;

		// Token: 0x0400C24F RID: 49743
		private BE_State opl_p2;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028C2 RID: 10434
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node50 : Condition
	{
		// Token: 0x06013ABE RID: 80574 RVA: 0x005DF957 File Offset: 0x005DDD57
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node50()
		{
			this.opl_p0 = 1702;
		}

		// Token: 0x06013ABF RID: 80575 RVA: 0x005DF96C File Offset: 0x005DDD6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D51E RID: 54558
		private int opl_p0;
	}
}

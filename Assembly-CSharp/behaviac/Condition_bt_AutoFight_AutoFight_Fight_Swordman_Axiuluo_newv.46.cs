using System;

namespace behaviac
{
	// Token: 0x0200223F RID: 8767
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node11 : Condition
	{
		// Token: 0x06012E07 RID: 77319 RVA: 0x005903D7 File Offset: 0x0058E7D7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node11()
		{
			this.opl_p0 = 10001;
		}

		// Token: 0x06012E08 RID: 77320 RVA: 0x005903EC File Offset: 0x0058E7EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C802 RID: 51202
		private int opl_p0;
	}
}

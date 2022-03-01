using System;

namespace behaviac
{
	// Token: 0x0200221B RID: 8731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node50 : Condition
	{
		// Token: 0x06012DC0 RID: 77248 RVA: 0x0058DBEB File Offset: 0x0058BFEB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node50()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012DC1 RID: 77249 RVA: 0x0058DC00 File Offset: 0x0058C000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7B7 RID: 51127
		private int opl_p0;
	}
}

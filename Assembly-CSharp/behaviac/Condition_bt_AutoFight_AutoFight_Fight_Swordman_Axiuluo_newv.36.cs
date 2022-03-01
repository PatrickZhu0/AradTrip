using System;

namespace behaviac
{
	// Token: 0x02002230 RID: 8752
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node25 : Condition
	{
		// Token: 0x06012DEA RID: 77290 RVA: 0x0058ECE5 File Offset: 0x0058D0E5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node25()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06012DEB RID: 77291 RVA: 0x0058ECF8 File Offset: 0x0058D0F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7EA RID: 51178
		private int opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002211 RID: 8721
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node33 : Condition
	{
		// Token: 0x06012DAC RID: 77228 RVA: 0x0058D0A3 File Offset: 0x0058B4A3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node33()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012DAD RID: 77229 RVA: 0x0058D0B8 File Offset: 0x0058B4B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7A1 RID: 51105
		private int opl_p0;
	}
}

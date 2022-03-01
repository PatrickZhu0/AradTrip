using System;

namespace behaviac
{
	// Token: 0x02002216 RID: 8726
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node39 : Condition
	{
		// Token: 0x06012DB6 RID: 77238 RVA: 0x0058D6A3 File Offset: 0x0058BAA3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node39()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012DB7 RID: 77239 RVA: 0x0058D6B8 File Offset: 0x0058BAB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7AC RID: 51116
		private int opl_p0;
	}
}

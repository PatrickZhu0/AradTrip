using System;

namespace behaviac
{
	// Token: 0x02002235 RID: 8757
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node14 : Condition
	{
		// Token: 0x06012DF4 RID: 77300 RVA: 0x0058EEFB File Offset: 0x0058D2FB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node14()
		{
			this.opl_p0 = 1715;
		}

		// Token: 0x06012DF5 RID: 77301 RVA: 0x0058EF10 File Offset: 0x0058D310
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7F5 RID: 51189
		private int opl_p0;
	}
}

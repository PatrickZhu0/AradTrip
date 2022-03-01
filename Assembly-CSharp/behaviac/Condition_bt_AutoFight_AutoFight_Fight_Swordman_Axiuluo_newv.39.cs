using System;

namespace behaviac
{
	// Token: 0x02002234 RID: 8756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node13 : Condition
	{
		// Token: 0x06012DF2 RID: 77298 RVA: 0x0058EEB3 File Offset: 0x0058D2B3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012DF3 RID: 77299 RVA: 0x0058EEC8 File Offset: 0x0058D2C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7F4 RID: 51188
		private float opl_p0;
	}
}

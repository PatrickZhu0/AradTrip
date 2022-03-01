using System;

namespace behaviac
{
	// Token: 0x02002226 RID: 8742
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node59 : Condition
	{
		// Token: 0x06012DD6 RID: 77270 RVA: 0x0058E816 File Offset: 0x0058CC16
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node59()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06012DD7 RID: 77271 RVA: 0x0058E82C File Offset: 0x0058CC2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7CD RID: 51149
		private float opl_p0;
	}
}

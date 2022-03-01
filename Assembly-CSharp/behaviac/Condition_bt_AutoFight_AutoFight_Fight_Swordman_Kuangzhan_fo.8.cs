using System;

namespace behaviac
{
	// Token: 0x0200233F RID: 9023
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node19 : Condition
	{
		// Token: 0x06012FED RID: 77805 RVA: 0x0059E408 File Offset: 0x0059C808
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node19()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x06012FEE RID: 77806 RVA: 0x0059E41C File Offset: 0x0059C81C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA06 RID: 51718
		private float opl_p0;
	}
}

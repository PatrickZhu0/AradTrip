using System;

namespace behaviac
{
	// Token: 0x020020C6 RID: 8390
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node17 : Condition
	{
		// Token: 0x06012B22 RID: 76578 RVA: 0x0057D736 File Offset: 0x0057BB36
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node17()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06012B23 RID: 76579 RVA: 0x0057D74C File Offset: 0x0057BB4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C515 RID: 50453
		private float opl_p0;
	}
}

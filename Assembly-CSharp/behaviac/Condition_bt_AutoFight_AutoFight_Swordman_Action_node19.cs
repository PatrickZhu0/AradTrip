using System;

namespace behaviac
{
	// Token: 0x02002881 RID: 10369
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node19 : Condition
	{
		// Token: 0x06013A3F RID: 80447 RVA: 0x005DCEE1 File Offset: 0x005DB2E1
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node19()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013A40 RID: 80448 RVA: 0x005DCEF4 File Offset: 0x005DB2F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D49A RID: 54426
		private float opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200204A RID: 8266
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node22 : Condition
	{
		// Token: 0x06012A2E RID: 76334 RVA: 0x0057760E File Offset: 0x00575A0E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node22()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x06012A2F RID: 76335 RVA: 0x00577624 File Offset: 0x00575A24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C421 RID: 50209
		private float opl_p0;
	}
}

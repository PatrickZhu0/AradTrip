using System;

namespace behaviac
{
	// Token: 0x02002016 RID: 8214
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node7 : Condition
	{
		// Token: 0x060129C7 RID: 76231 RVA: 0x0057526E File Offset: 0x0057366E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node7()
		{
			this.opl_p0 = 0.67f;
		}

		// Token: 0x060129C8 RID: 76232 RVA: 0x00575284 File Offset: 0x00573684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3BA RID: 50106
		private float opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200204E RID: 8270
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node27 : Condition
	{
		// Token: 0x06012A36 RID: 76342 RVA: 0x0057785A File Offset: 0x00575C5A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node27()
		{
			this.opl_p0 = 0.58f;
		}

		// Token: 0x06012A37 RID: 76343 RVA: 0x00577870 File Offset: 0x00575C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C429 RID: 50217
		private float opl_p0;
	}
}

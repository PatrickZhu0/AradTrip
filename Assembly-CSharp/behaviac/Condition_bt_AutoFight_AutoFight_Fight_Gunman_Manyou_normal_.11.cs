using System;

namespace behaviac
{
	// Token: 0x0200218E RID: 8590
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node27 : Condition
	{
		// Token: 0x06012CAC RID: 76972 RVA: 0x00586D02 File Offset: 0x00585102
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node27()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x06012CAD RID: 76973 RVA: 0x00586D18 File Offset: 0x00585118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C69F RID: 50847
		private float opl_p0;
	}
}

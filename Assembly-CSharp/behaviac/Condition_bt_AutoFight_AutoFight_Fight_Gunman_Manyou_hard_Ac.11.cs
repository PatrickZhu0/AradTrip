using System;

namespace behaviac
{
	// Token: 0x02002166 RID: 8550
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node27 : Condition
	{
		// Token: 0x06012C5D RID: 76893 RVA: 0x00584EE6 File Offset: 0x005832E6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node27()
		{
			this.opl_p0 = 0.68f;
		}

		// Token: 0x06012C5E RID: 76894 RVA: 0x00584EFC File Offset: 0x005832FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C650 RID: 50768
		private float opl_p0;
	}
}

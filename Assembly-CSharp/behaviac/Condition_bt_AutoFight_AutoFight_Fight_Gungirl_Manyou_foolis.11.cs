using System;

namespace behaviac
{
	// Token: 0x02001FFA RID: 8186
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node22 : Condition
	{
		// Token: 0x06012990 RID: 76176 RVA: 0x005738EA File Offset: 0x00571CEA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node22()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06012991 RID: 76177 RVA: 0x00573900 File Offset: 0x00571D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C383 RID: 50051
		private float opl_p0;
	}
}

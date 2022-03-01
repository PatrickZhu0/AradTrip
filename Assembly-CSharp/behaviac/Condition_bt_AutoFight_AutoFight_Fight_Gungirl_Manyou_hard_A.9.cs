using System;

namespace behaviac
{
	// Token: 0x02002022 RID: 8226
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node22 : Condition
	{
		// Token: 0x060129DF RID: 76255 RVA: 0x005757F2 File Offset: 0x00573BF2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node22()
		{
			this.opl_p0 = 0.76f;
		}

		// Token: 0x060129E0 RID: 76256 RVA: 0x00575808 File Offset: 0x00573C08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3D2 RID: 50130
		private float opl_p0;
	}
}

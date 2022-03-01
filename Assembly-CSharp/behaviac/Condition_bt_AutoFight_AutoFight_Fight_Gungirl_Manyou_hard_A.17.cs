using System;

namespace behaviac
{
	// Token: 0x02002032 RID: 8242
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node42 : Condition
	{
		// Token: 0x060129FF RID: 76287 RVA: 0x0057601E File Offset: 0x0057441E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node42()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012A00 RID: 76288 RVA: 0x00576034 File Offset: 0x00574434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3F2 RID: 50162
		private float opl_p0;
	}
}

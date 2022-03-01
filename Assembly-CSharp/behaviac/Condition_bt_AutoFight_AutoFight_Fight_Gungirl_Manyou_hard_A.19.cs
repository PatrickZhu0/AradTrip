using System;

namespace behaviac
{
	// Token: 0x02002036 RID: 8246
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node47 : Condition
	{
		// Token: 0x06012A07 RID: 76295 RVA: 0x005761BA File Offset: 0x005745BA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node47()
		{
			this.opl_p0 = 0.83f;
		}

		// Token: 0x06012A08 RID: 76296 RVA: 0x005761D0 File Offset: 0x005745D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3FA RID: 50170
		private float opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002621 RID: 9761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node87 : Condition
	{
		// Token: 0x06013588 RID: 79240 RVA: 0x005C13BA File Offset: 0x005BF7BA
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node87()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013589 RID: 79241 RVA: 0x005C13D0 File Offset: 0x005BF7D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFD2 RID: 53202
		private float opl_p0;
	}
}

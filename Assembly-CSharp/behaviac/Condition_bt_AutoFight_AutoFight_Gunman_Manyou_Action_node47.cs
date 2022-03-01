using System;

namespace behaviac
{
	// Token: 0x0200262D RID: 9773
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node47 : Condition
	{
		// Token: 0x060135A0 RID: 79264 RVA: 0x005C1926 File Offset: 0x005BFD26
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node47()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060135A1 RID: 79265 RVA: 0x005C193C File Offset: 0x005BFD3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFEE RID: 53230
		private float opl_p0;
	}
}

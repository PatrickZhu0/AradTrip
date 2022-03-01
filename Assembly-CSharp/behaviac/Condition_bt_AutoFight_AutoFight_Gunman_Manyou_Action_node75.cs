using System;

namespace behaviac
{
	// Token: 0x02002625 RID: 9765
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node75 : Condition
	{
		// Token: 0x06013590 RID: 79248 RVA: 0x005C15BE File Offset: 0x005BF9BE
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node75()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06013591 RID: 79249 RVA: 0x005C15D4 File Offset: 0x005BF9D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFDE RID: 53214
		private float opl_p0;
	}
}

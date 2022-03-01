using System;

namespace behaviac
{
	// Token: 0x02002603 RID: 9731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node22 : Condition
	{
		// Token: 0x0601354C RID: 79180 RVA: 0x005C062E File Offset: 0x005BEA2E
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node22()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601354D RID: 79181 RVA: 0x005C0644 File Offset: 0x005BEA44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF98 RID: 53144
		private float opl_p0;
	}
}

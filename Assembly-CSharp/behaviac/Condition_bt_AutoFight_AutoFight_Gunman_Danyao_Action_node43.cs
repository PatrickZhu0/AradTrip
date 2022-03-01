using System;

namespace behaviac
{
	// Token: 0x020025ED RID: 9709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node43 : Condition
	{
		// Token: 0x06013521 RID: 79137 RVA: 0x005BE1B9 File Offset: 0x005BC5B9
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node43()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013522 RID: 79138 RVA: 0x005BE1CC File Offset: 0x005BC5CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF68 RID: 53096
		private float opl_p0;
	}
}

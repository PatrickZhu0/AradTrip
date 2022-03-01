using System;

namespace behaviac
{
	// Token: 0x020025E2 RID: 9698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node80 : Condition
	{
		// Token: 0x0601350B RID: 79115 RVA: 0x005BDC35 File Offset: 0x005BC035
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node80()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601350C RID: 79116 RVA: 0x005BDC48 File Offset: 0x005BC048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF51 RID: 53073
		private float opl_p0;
	}
}

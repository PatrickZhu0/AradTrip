using System;

namespace behaviac
{
	// Token: 0x020025D2 RID: 9682
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node11 : Condition
	{
		// Token: 0x060134EB RID: 79083 RVA: 0x005BD565 File Offset: 0x005BB965
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node11()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060134EC RID: 79084 RVA: 0x005BD578 File Offset: 0x005BB978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF31 RID: 53041
		private float opl_p0;
	}
}

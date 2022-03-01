using System;

namespace behaviac
{
	// Token: 0x020025E7 RID: 9703
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node67 : Condition
	{
		// Token: 0x06013515 RID: 79125 RVA: 0x005BDE8B File Offset: 0x005BC28B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node67()
		{
			this.opl_p0 = 1008;
		}

		// Token: 0x06013516 RID: 79126 RVA: 0x005BDEA0 File Offset: 0x005BC2A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF5A RID: 53082
		private int opl_p0;
	}
}

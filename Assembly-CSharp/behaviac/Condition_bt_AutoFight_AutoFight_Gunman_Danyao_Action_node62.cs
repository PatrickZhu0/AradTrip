using System;

namespace behaviac
{
	// Token: 0x020025DF RID: 9695
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node62 : Condition
	{
		// Token: 0x06013505 RID: 79109 RVA: 0x005BDAC7 File Offset: 0x005BBEC7
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node62()
		{
			this.opl_p0 = 1013;
		}

		// Token: 0x06013506 RID: 79110 RVA: 0x005BDADC File Offset: 0x005BBEDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF4A RID: 53066
		private int opl_p0;
	}
}

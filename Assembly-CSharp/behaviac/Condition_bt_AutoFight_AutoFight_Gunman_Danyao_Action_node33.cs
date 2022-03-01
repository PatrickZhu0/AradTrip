using System;

namespace behaviac
{
	// Token: 0x020025BF RID: 9663
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node33 : Condition
	{
		// Token: 0x060134C5 RID: 79045 RVA: 0x005BCD8F File Offset: 0x005BB18F
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node33()
		{
			this.opl_p0 = 1307;
		}

		// Token: 0x060134C6 RID: 79046 RVA: 0x005BCDA4 File Offset: 0x005BB1A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF02 RID: 52994
		private int opl_p0;
	}
}

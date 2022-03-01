using System;

namespace behaviac
{
	// Token: 0x02002580 RID: 9600
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node33 : Condition
	{
		// Token: 0x06013448 RID: 78920 RVA: 0x005BA4AD File Offset: 0x005B88AD
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node33()
		{
			this.opl_p0 = 1204;
		}

		// Token: 0x06013449 RID: 78921 RVA: 0x005BA4C0 File Offset: 0x005B88C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE72 RID: 52850
		private int opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020025D3 RID: 9683
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node12 : Condition
	{
		// Token: 0x060134ED RID: 79085 RVA: 0x005BD5AB File Offset: 0x005BB9AB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node12()
		{
			this.opl_p0 = 1302;
		}

		// Token: 0x060134EE RID: 79086 RVA: 0x005BD5C0 File Offset: 0x005BB9C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF32 RID: 53042
		private int opl_p0;
	}
}

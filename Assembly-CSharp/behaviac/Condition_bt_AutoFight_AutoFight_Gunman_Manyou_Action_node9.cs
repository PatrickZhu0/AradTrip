using System;

namespace behaviac
{
	// Token: 0x020025F9 RID: 9721
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node9 : Condition
	{
		// Token: 0x06013538 RID: 79160 RVA: 0x005C0185 File Offset: 0x005BE585
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node9()
		{
			this.opl_p0 = 1015;
		}

		// Token: 0x06013539 RID: 79161 RVA: 0x005C0198 File Offset: 0x005BE598
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF81 RID: 53121
		private int opl_p0;
	}
}

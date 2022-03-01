using System;

namespace behaviac
{
	// Token: 0x02002605 RID: 9733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node24 : Condition
	{
		// Token: 0x06013550 RID: 79184 RVA: 0x005C06F1 File Offset: 0x005BEAF1
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node24()
		{
			this.opl_p0 = 1102;
		}

		// Token: 0x06013551 RID: 79185 RVA: 0x005C0704 File Offset: 0x005BEB04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF9D RID: 53149
		private int opl_p0;
	}
}

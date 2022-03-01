using System;

namespace behaviac
{
	// Token: 0x0200205C RID: 8284
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node44 : Action
	{
		// Token: 0x06012A52 RID: 76370 RVA: 0x00577EFD File Offset: 0x005762FD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012A53 RID: 76371 RVA: 0x00577F17 File Offset: 0x00576317
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C446 RID: 50246
		private int method_p0;
	}
}

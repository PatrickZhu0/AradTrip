using System;

namespace behaviac
{
	// Token: 0x020021C4 RID: 8644
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node44 : Action
	{
		// Token: 0x06012D17 RID: 77079 RVA: 0x005891C1 File Offset: 0x005875C1
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012D18 RID: 77080 RVA: 0x005891DB File Offset: 0x005875DB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C70B RID: 50955
		private int method_p0;
	}
}

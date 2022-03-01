using System;

namespace behaviac
{
	// Token: 0x020021C0 RID: 8640
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node39 : Action
	{
		// Token: 0x06012D0F RID: 77071 RVA: 0x00588F19 File Offset: 0x00587319
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1006;
		}

		// Token: 0x06012D10 RID: 77072 RVA: 0x00588F33 File Offset: 0x00587333
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C703 RID: 50947
		private int method_p0;
	}
}

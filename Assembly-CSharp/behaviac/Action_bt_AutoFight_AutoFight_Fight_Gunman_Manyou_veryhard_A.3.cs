using System;

namespace behaviac
{
	// Token: 0x020021A8 RID: 8616
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node9 : Action
	{
		// Token: 0x06012CDF RID: 77023 RVA: 0x00588411 File Offset: 0x00586811
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1101;
		}

		// Token: 0x06012CE0 RID: 77024 RVA: 0x0058842B File Offset: 0x0058682B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6D3 RID: 50899
		private int method_p0;
	}
}

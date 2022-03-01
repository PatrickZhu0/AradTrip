using System;

namespace behaviac
{
	// Token: 0x020020E4 RID: 8420
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node24 : Action
	{
		// Token: 0x06012B5D RID: 76637 RVA: 0x0057ED05 File Offset: 0x0057D105
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012B5E RID: 76638 RVA: 0x0057ED1F File Offset: 0x0057D11F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C551 RID: 50513
		private int method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002160 RID: 8544
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node19 : Action
	{
		// Token: 0x06012C51 RID: 76881 RVA: 0x00584BC1 File Offset: 0x00582FC1
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012C52 RID: 76882 RVA: 0x00584BDB File Offset: 0x00582FDB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C645 RID: 50757
		private int method_p0;
	}
}

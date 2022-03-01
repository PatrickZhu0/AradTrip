using System;

namespace behaviac
{
	// Token: 0x02002074 RID: 8308
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node24 : Action
	{
		// Token: 0x06012A81 RID: 76417 RVA: 0x005794ED File Offset: 0x005778ED
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012A82 RID: 76418 RVA: 0x00579507 File Offset: 0x00577907
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C475 RID: 50293
		private int method_p0;
	}
}

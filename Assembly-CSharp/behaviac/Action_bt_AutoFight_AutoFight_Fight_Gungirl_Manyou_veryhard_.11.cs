using System;

namespace behaviac
{
	// Token: 0x02002078 RID: 8312
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node29 : Action
	{
		// Token: 0x06012A89 RID: 76425 RVA: 0x00579739 File Offset: 0x00577B39
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2510;
		}

		// Token: 0x06012A8A RID: 76426 RVA: 0x00579753 File Offset: 0x00577B53
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C47D RID: 50301
		private int method_p0;
	}
}

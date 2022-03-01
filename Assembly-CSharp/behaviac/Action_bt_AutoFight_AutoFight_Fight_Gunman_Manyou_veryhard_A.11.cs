using System;

namespace behaviac
{
	// Token: 0x020021B8 RID: 8632
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node29 : Action
	{
		// Token: 0x06012CFF RID: 77055 RVA: 0x00588BE1 File Offset: 0x00586FE1
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1008;
		}

		// Token: 0x06012D00 RID: 77056 RVA: 0x00588BFB File Offset: 0x00586FFB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6F3 RID: 50931
		private int method_p0;
	}
}

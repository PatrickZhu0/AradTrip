using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002517 RID: 9495
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node29 : Action
	{
		// Token: 0x06013377 RID: 78711 RVA: 0x005B5CB4 File Offset: 0x005B40B4
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2606;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013378 RID: 78712 RVA: 0x005B5D44 File Offset: 0x005B4144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD99 RID: 52633
		private List<Input> method_p0;

		// Token: 0x0400CD9A RID: 52634
		private bool method_p1;
	}
}

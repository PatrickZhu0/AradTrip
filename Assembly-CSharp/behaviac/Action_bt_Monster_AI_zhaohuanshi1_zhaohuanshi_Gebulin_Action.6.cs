using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200404D RID: 16461
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node33 : Action
	{
		// Token: 0x060167F9 RID: 92153 RVA: 0x006CF200 File Offset: 0x006CD600
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node33()
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
			item.skillID = 5110;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060167FA RID: 92154 RVA: 0x006CF290 File Offset: 0x006CD690
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010044 RID: 65604
		private List<Input> method_p0;

		// Token: 0x04010045 RID: 65605
		private bool method_p1;
	}
}

using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003814 RID: 14356
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7 : Action
	{
		// Token: 0x06015817 RID: 88087 RVA: 0x0067D7C4 File Offset: 0x0067BBC4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7()
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
			item.skillID = 21200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015818 RID: 88088 RVA: 0x0067D854 File Offset: 0x0067BC54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1DB RID: 61915
		private List<Input> method_p0;

		// Token: 0x0400F1DC RID: 61916
		private bool method_p1;
	}
}

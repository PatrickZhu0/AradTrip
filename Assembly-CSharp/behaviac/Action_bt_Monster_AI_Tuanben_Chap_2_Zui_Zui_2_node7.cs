using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003808 RID: 14344
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node7 : Action
	{
		// Token: 0x06015801 RID: 88065 RVA: 0x0067D158 File Offset: 0x0067B558
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node7()
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

		// Token: 0x06015802 RID: 88066 RVA: 0x0067D1E8 File Offset: 0x0067B5E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1C9 RID: 61897
		private List<Input> method_p0;

		// Token: 0x0400F1CA RID: 61898
		private bool method_p1;
	}
}

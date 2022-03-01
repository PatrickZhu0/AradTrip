using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020037BF RID: 14271
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node11 : Action
	{
		// Token: 0x0601577F RID: 87935 RVA: 0x0067AD14 File Offset: 0x00679114
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node11()
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
			item.skillID = 21187;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015780 RID: 87936 RVA: 0x0067ADA4 File Offset: 0x006791A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F132 RID: 61746
		private List<Input> method_p0;

		// Token: 0x0400F133 RID: 61747
		private bool method_p1;
	}
}

using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039E8 RID: 14824
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node34 : Action
	{
		// Token: 0x06015BA0 RID: 88992 RVA: 0x0068F9A4 File Offset: 0x0068DDA4
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node34()
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
			item.skillID = 21076;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015BA1 RID: 88993 RVA: 0x0068FA34 File Offset: 0x0068DE34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E0 RID: 62688
		private List<Input> method_p0;

		// Token: 0x0400F4E1 RID: 62689
		private bool method_p1;
	}
}

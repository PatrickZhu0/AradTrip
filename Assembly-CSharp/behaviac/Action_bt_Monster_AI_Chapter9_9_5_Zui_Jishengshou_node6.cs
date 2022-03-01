using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031D7 RID: 12759
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Jishengshou_node6 : Action
	{
		// Token: 0x06014C3F RID: 85055 RVA: 0x006417EC File Offset: 0x0063FBEC
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Jishengshou_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21535;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C40 RID: 85056 RVA: 0x0064187D File Offset: 0x0063FC7D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E597 RID: 58775
		private List<Input> method_p0;

		// Token: 0x0400E598 RID: 58776
		private bool method_p1;
	}
}

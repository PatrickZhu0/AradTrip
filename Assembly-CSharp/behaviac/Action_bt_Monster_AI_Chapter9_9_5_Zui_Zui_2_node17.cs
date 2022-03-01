using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031F6 RID: 12790
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node17 : Action
	{
		// Token: 0x06014C78 RID: 85112 RVA: 0x0064254C File Offset: 0x0064094C
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node17()
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
			item.skillID = 21565;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C79 RID: 85113 RVA: 0x006425DC File Offset: 0x006409DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5CF RID: 58831
		private List<Input> method_p0;

		// Token: 0x0400E5D0 RID: 58832
		private bool method_p1;
	}
}

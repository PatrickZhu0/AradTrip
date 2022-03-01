using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200400C RID: 16396
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node30 : Action
	{
		// Token: 0x0601677C RID: 92028 RVA: 0x006CC9CC File Offset: 0x006CADCC
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node30()
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
			item.skillID = 5091;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601677D RID: 92029 RVA: 0x006CCA5C File Offset: 0x006CAE5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFCC RID: 65484
		private List<Input> method_p0;

		// Token: 0x0400FFCD RID: 65485
		private bool method_p1;
	}
}

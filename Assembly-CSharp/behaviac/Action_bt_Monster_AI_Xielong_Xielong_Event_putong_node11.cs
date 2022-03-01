using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E45 RID: 15941
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node11 : Action
	{
		// Token: 0x0601640F RID: 91151 RVA: 0x006BA714 File Offset: 0x006B8B14
		public Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node11()
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
			item.skillID = 7082;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016410 RID: 91152 RVA: 0x006BA7A4 File Offset: 0x006B8BA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC66 RID: 64614
		private List<Input> method_p0;

		// Token: 0x0400FC67 RID: 64615
		private bool method_p1;
	}
}

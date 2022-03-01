using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D8F RID: 11663
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node32 : Action
	{
		// Token: 0x060143FF RID: 82943 RVA: 0x006157D0 File Offset: 0x00613BD0
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node32()
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
			item.skillID = 21646;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014400 RID: 82944 RVA: 0x00615860 File Offset: 0x00613C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDCB RID: 56779
		private List<Input> method_p0;

		// Token: 0x0400DDCC RID: 56780
		private bool method_p1;
	}
}

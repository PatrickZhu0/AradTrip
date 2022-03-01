using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B86 RID: 11142
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node32 : Action
	{
		// Token: 0x06014018 RID: 81944 RVA: 0x00601F18 File Offset: 0x00600318
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node32()
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
			item.skillID = 20769;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014019 RID: 81945 RVA: 0x00601FA8 File Offset: 0x006003A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA15 RID: 55829
		private List<Input> method_p0;

		// Token: 0x0400DA16 RID: 55830
		private bool method_p1;
	}
}

using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F2B RID: 12075
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node10 : Action
	{
		// Token: 0x0601472A RID: 83754 RVA: 0x00626CF8 File Offset: 0x006250F8
		public Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node10()
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
			item.skillID = 20309;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601472B RID: 83755 RVA: 0x00626D88 File Offset: 0x00625188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E09C RID: 57500
		private List<Input> method_p0;

		// Token: 0x0400E09D RID: 57501
		private bool method_p1;
	}
}

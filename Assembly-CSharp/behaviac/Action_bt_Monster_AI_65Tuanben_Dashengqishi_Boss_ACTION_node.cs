using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D8A RID: 11658
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node17 : Action
	{
		// Token: 0x060143F5 RID: 82933 RVA: 0x0061561C File Offset: 0x00613A1C
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node17()
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

		// Token: 0x060143F6 RID: 82934 RVA: 0x006156AC File Offset: 0x00613AAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDC5 RID: 56773
		private List<Input> method_p0;

		// Token: 0x0400DDC6 RID: 56774
		private bool method_p1;
	}
}

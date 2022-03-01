using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200311D RID: 12573
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Event_node2 : Action
	{
		// Token: 0x06014AE1 RID: 84705 RVA: 0x0063A444 File Offset: 0x00638844
		public Action_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Event_node2()
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
			item.skillID = 20719;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014AE2 RID: 84706 RVA: 0x0063A4D4 File Offset: 0x006388D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E44D RID: 58445
		private List<Input> method_p0;

		// Token: 0x0400E44E RID: 58446
		private bool method_p1;
	}
}

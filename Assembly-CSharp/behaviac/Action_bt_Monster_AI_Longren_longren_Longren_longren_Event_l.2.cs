using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035A4 RID: 13732
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node8 : Action
	{
		// Token: 0x06015377 RID: 86903 RVA: 0x006650EC File Offset: 0x006634EC
		public Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node8()
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
			item.skillID = 5164;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015378 RID: 86904 RVA: 0x0066517C File Offset: 0x0066357C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED41 RID: 60737
		private List<Input> method_p0;

		// Token: 0x0400ED42 RID: 60738
		private bool method_p1;
	}
}

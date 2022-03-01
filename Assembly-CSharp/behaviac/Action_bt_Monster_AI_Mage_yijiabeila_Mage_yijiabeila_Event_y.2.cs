using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035B9 RID: 13753
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node6 : Action
	{
		// Token: 0x0601539F RID: 86943 RVA: 0x00665DB0 File Offset: 0x006641B0
		public Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node6()
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
			item.skillID = 5331;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060153A0 RID: 86944 RVA: 0x00665E40 File Offset: 0x00664240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED6A RID: 60778
		private List<Input> method_p0;

		// Token: 0x0400ED6B RID: 60779
		private bool method_p1;
	}
}

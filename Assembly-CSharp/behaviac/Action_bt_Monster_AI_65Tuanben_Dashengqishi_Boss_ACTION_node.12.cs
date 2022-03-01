using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DAB RID: 11691
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node4 : Action
	{
		// Token: 0x06014437 RID: 82999 RVA: 0x00616228 File Offset: 0x00614628
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node4()
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
			item.skillID = 21643;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014438 RID: 83000 RVA: 0x006162B8 File Offset: 0x006146B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDFC RID: 56828
		private List<Input> method_p0;

		// Token: 0x0400DDFD RID: 56829
		private bool method_p1;
	}
}

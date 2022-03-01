using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003C0B RID: 15371
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node56 : Action
	{
		// Token: 0x06015FC1 RID: 90049 RVA: 0x006A4AC4 File Offset: 0x006A2EC4
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node56()
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
			item.skillID = 21171;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015FC2 RID: 90050 RVA: 0x006A4B54 File Offset: 0x006A2F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F841 RID: 63553
		private List<Input> method_p0;

		// Token: 0x0400F842 RID: 63554
		private bool method_p1;
	}
}

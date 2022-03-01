using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003BA5 RID: 15269
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node18 : Action
	{
		// Token: 0x06015EFA RID: 89850 RVA: 0x006A0854 File Offset: 0x0069EC54
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node18()
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
			item.skillID = 21075;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015EFB RID: 89851 RVA: 0x006A08E4 File Offset: 0x0069ECE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7A1 RID: 63393
		private List<Input> method_p0;

		// Token: 0x0400F7A2 RID: 63394
		private bool method_p1;
	}
}

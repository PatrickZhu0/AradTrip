using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B9B RID: 15259
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node36 : Action
	{
		// Token: 0x06015EE6 RID: 89830 RVA: 0x006A04C4 File Offset: 0x0069E8C4
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node36()
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
			item.skillID = 21176;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015EE7 RID: 89831 RVA: 0x006A0554 File Offset: 0x0069E954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F794 RID: 63380
		private List<Input> method_p0;

		// Token: 0x0400F795 RID: 63381
		private bool method_p1;
	}
}

using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039DF RID: 14815
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node28 : Action
	{
		// Token: 0x06015B8E RID: 88974 RVA: 0x0068F5C0 File Offset: 0x0068D9C0
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node28()
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
			item.skillID = 21159;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015B8F RID: 88975 RVA: 0x0068F650 File Offset: 0x0068DA50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4D0 RID: 62672
		private List<Input> method_p0;

		// Token: 0x0400F4D1 RID: 62673
		private bool method_p1;
	}
}

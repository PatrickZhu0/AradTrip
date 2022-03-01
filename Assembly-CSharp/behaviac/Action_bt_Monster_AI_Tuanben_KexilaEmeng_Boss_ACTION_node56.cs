using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039D6 RID: 14806
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node56 : Action
	{
		// Token: 0x06015B7C RID: 88956 RVA: 0x0068F290 File Offset: 0x0068D690
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node56()
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
			item.skillID = 21174;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015B7D RID: 88957 RVA: 0x0068F320 File Offset: 0x0068D720
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C4 RID: 62660
		private List<Input> method_p0;

		// Token: 0x0400F4C5 RID: 62661
		private bool method_p1;
	}
}

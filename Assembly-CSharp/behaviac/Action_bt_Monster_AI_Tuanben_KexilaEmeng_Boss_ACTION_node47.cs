using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039D1 RID: 14801
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node47 : Action
	{
		// Token: 0x06015B72 RID: 88946 RVA: 0x0068F0EC File Offset: 0x0068D4EC
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node47()
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
			item.skillID = 21172;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015B73 RID: 88947 RVA: 0x0068F17C File Offset: 0x0068D57C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4BF RID: 62655
		private List<Input> method_p0;

		// Token: 0x0400F4C0 RID: 62656
		private bool method_p1;
	}
}

using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039DA RID: 14810
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node36 : Action
	{
		// Token: 0x06015B84 RID: 88964 RVA: 0x0068F3FC File Offset: 0x0068D7FC
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node36()
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

		// Token: 0x06015B85 RID: 88965 RVA: 0x0068F48C File Offset: 0x0068D88C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4CA RID: 62666
		private List<Input> method_p0;

		// Token: 0x0400F4CB RID: 62667
		private bool method_p1;
	}
}

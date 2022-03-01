using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A16 RID: 14870
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node1 : Action
	{
		// Token: 0x06015BF7 RID: 89079 RVA: 0x00691ABC File Offset: 0x0068FEBC
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node1()
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
			item.skillID = 21407;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015BF8 RID: 89080 RVA: 0x00691B4C File Offset: 0x0068FF4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F511 RID: 62737
		private List<Input> method_p0;

		// Token: 0x0400F512 RID: 62738
		private bool method_p1;
	}
}

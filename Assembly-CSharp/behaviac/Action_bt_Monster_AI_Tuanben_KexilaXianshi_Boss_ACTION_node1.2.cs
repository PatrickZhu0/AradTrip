using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A55 RID: 14933
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node16 : Action
	{
		// Token: 0x06015C73 RID: 89203 RVA: 0x00693CBC File Offset: 0x006920BC
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node16()
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
			item.skillID = 21060;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C74 RID: 89204 RVA: 0x00693D4C File Offset: 0x0069214C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F59D RID: 62877
		private List<Input> method_p0;

		// Token: 0x0400F59E RID: 62878
		private bool method_p1;
	}
}

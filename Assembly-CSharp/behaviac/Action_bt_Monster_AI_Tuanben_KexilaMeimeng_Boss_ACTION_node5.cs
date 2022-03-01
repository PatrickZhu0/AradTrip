using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A1F RID: 14879
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node56 : Action
	{
		// Token: 0x06015C08 RID: 89096 RVA: 0x00691E6C File Offset: 0x0069026C
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node56()
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

		// Token: 0x06015C09 RID: 89097 RVA: 0x00691EFC File Offset: 0x006902FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F51C RID: 62748
		private List<Input> method_p0;

		// Token: 0x0400F51D RID: 62749
		private bool method_p1;
	}
}

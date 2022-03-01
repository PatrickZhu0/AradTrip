using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031BD RID: 12733
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node45 : Action
	{
		// Token: 0x06014C0D RID: 85005 RVA: 0x0063FB7C File Offset: 0x0063DF7C
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node45()
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
			item.skillID = 21569;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C0E RID: 85006 RVA: 0x0063FC0C File Offset: 0x0063E00C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E56A RID: 58730
		private List<Input> method_p0;

		// Token: 0x0400E56B RID: 58731
		private bool method_p1;
	}
}

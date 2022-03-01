using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031B0 RID: 12720
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node33 : Action
	{
		// Token: 0x06014BF3 RID: 84979 RVA: 0x0063F62C File Offset: 0x0063DA2C
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node33()
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
			item.skillID = 21548;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BF4 RID: 84980 RVA: 0x0063F6BC File Offset: 0x0063DABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E557 RID: 58711
		private List<Input> method_p0;

		// Token: 0x0400E558 RID: 58712
		private bool method_p1;
	}
}

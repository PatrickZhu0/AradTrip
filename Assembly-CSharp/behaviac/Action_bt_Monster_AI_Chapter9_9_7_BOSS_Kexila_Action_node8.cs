using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031FF RID: 12799
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8 : Action
	{
		// Token: 0x06014C88 RID: 85128 RVA: 0x00642D64 File Offset: 0x00641164
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8()
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
			item.skillID = 21562;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C89 RID: 85129 RVA: 0x00642DF4 File Offset: 0x006411F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5DB RID: 58843
		private List<Input> method_p0;

		// Token: 0x0400E5DC RID: 58844
		private bool method_p1;
	}
}

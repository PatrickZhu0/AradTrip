using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200321B RID: 12827
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node2 : Action
	{
		// Token: 0x06014CBF RID: 85183 RVA: 0x00644178 File Offset: 0x00642578
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node2()
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
			item.skillID = 21563;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014CC0 RID: 85184 RVA: 0x00644208 File Offset: 0x00642608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E608 RID: 58888
		private List<Input> method_p0;

		// Token: 0x0400E609 RID: 58889
		private bool method_p1;
	}
}

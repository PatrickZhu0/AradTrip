using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B86 RID: 15238
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2 : Action
	{
		// Token: 0x06015EBE RID: 89790 RVA: 0x0069FB00 File Offset: 0x0069DF00
		public Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2()
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
			item.skillID = 21360;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015EBF RID: 89791 RVA: 0x0069FB90 File Offset: 0x0069DF90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F780 RID: 63360
		private List<Input> method_p0;

		// Token: 0x0400F781 RID: 63361
		private bool method_p1;
	}
}

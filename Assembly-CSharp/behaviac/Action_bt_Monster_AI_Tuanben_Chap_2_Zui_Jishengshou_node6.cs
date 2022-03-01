using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020037BA RID: 14266
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node6 : Action
	{
		// Token: 0x06015776 RID: 87926 RVA: 0x0067AA28 File Offset: 0x00678E28
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21186;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015777 RID: 87927 RVA: 0x0067AAB9 File Offset: 0x00678EB9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F126 RID: 61734
		private List<Input> method_p0;

		// Token: 0x0400F127 RID: 61735
		private bool method_p1;
	}
}
